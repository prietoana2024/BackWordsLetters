using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SopadeLetras.DAL.DBContext;
using SopadeLetras.DLL.Servicios;
using SopadeLetras.DLL.Servicios.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SopadeLetras.DLL;

namespace SopadeLetras.IOC
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BdSopaLetrasContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });
            services.AddScoped<ISopaLetrasService, SopaLetrasService>();
            services.AddScoped<DbContext, BdSopaLetrasContext>();
        }
    }
}
