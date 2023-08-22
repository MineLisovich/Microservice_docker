using Authorization.Microservice.Domain;
using Authorization.Microservice.Domain.Repositories;
using Authorization.Microservice.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;
configuration.Bind("ConnectionString", new Config());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsersRepository, EFUserRepository>();
builder.Services.AddTransient<AuthOptions>();
builder.Services.AddDbContext<AuthorizationDbContext>(x => x.UseSqlServer(Config.DefaultConnection));
builder.Services.AddCors();
Console.WriteLine(Config.DefaultConnection);
//Authorization settings
builder.Services.AddAuthentication(options=>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
    option =>
    {
       
      option.RequireHttpsMetadata = false; // елсли  если равно false, то SSL при отправке токена не используется. Однако данный вариант установлен только дя тестирования. В реальном приложении все же лучше использовать передачу данных по протоколу https.
      option.SaveToken = true;
      option.TokenValidationParameters = new TokenValidationParameters
      {
          //указывает, будет ли валидироваться создатель при валидации токена
          ValidateIssuer = true,
          //строка представляющая издателя
          ValidIssuer = AuthOptions.ISSUER,

          //будет ли валидироваться потребитель токена
          ValidateAudience = true,
          //установка потребителя токена
          ValidAudience = AuthOptions.AUDIENCE,

          //будет ли валидироваться время существования токена
          ValidateLifetime = true,

          //установка секретного ключа
          IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
          //валидация секретного ключа
          ValidateIssuerSigningKey = true,
      };
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin 
    .AllowCredentials());

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies[".AspNetCore.Application.Id"];
    if (!string.IsNullOrEmpty(token))
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Xss-Protection", "1");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    await next();
});
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
