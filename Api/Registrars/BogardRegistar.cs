using Application.UserProfiles.Queries;
using MediatR;

namespace Api.Registrars
{
    public class BogardRegistar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfiles));
            builder.Services.AddMediatR(typeof(GetAllUserProfiles));
        }
    }
}
