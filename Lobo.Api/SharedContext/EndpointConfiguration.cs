using Lobo.Api.CustomerContext.Endpoints;

namespace Lobo.Api.SharedContext;

public static class EndpointConfiguration
{
    extension(IEndpointRouteBuilder endpoints)
    {
        public void MapEndpoints()
        {
            endpoints.MapCustomerEndpoints();
        }
    }
}