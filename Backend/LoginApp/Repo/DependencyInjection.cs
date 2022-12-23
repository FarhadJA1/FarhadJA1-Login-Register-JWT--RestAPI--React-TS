using Microsoft.Extensions.DependencyInjection;
using Repo.Repositories.Implementations;
using Repo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
