﻿using Application.Master;
using Application.ProductCatalog;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMasterServices, MasterServices>();
            services.AddScoped<IProductServices, ProductServices>();
        }
    }
}