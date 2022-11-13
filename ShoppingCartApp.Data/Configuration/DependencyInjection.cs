using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCartApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Data.Configuration
{
    public static partial class DependencyInjection
    {
        public static void Repositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartAppContext>(m =>
            {
                m.UseSqlServer(configuration.GetConnectionString("SCAPPDb"));
            });
        }
    }
}
