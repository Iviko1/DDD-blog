using Dal;
using Microsoft.EntityFrameworkCore;

namespace Api.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));
        }
    }
}
