using Admin.Microservice.Domain;
using Admin.Microservice.Domain.Repositories;
using Admin.Microservice.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
configuration.Bind("ConnectionString", new Config());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAdminEntity, EFAdminEntity>();
builder.Services.AddTransient<AuthOptions>();
builder.Services.AddDbContext<AdminDbContext>(x => x.UseSqlServer(Config.DefaultConnection));
// Add services to the container.
builder.Services.AddControllersWithViews();

//Authorization settings
builder.Services.AddAuthentication(options =>
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


app.UseHttpsRedirection();
app.UseStaticFiles();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=Index}/{id?}");

app.Run();
