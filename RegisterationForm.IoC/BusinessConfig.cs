﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterationForm.BL.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterationForm.IoC
{
    public static class BusinessConfig
    {
        public static IServiceCollection AddBsinesses(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UserSkillsBusiness>();
            services.AddScoped<SkillBusiness>();
            services.AddScoped<UserBusiness>();

            return services;
        }
    }
}
