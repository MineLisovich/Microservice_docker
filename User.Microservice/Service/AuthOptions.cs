﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Microservice.Service
{
    public class AuthOptions
    {
        /// <summary>
        /// Создатель токена
        /// </summary>
        public const string ISSUER = "Authorization.Microservice";
        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string AUDIENCE = "AuthClient";
        /// <summary>
        /// Секретный ключ для кодирования
        /// </summary>
        const string KEY = "ZjNsWoNSIWRycb28412Bsgw312MJ";
        /// <summary>
        /// Время жизни токена (в минутах)
        /// </summary>
        public const int LIFETIME = 120;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
