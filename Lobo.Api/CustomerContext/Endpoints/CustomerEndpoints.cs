using Lobo.Application.CustomerContext.UseCases.GetCustomerById;
using Lobo.Application.SharedContext.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Lobo.Api.CustomerContext.Endpoints;

public static class CustomerEndpoints
{
    extension(IEndpointRouteBuilder endpoints)
    {
        public IEndpointRouteBuilder MapCustomerEndpoints()
        {
            RouteGroupBuilder groupBuilder = endpoints.MapGroup("api/customer/").RequireAuthorization();

            groupBuilder.MapGet("get-customer-by-id", GetCustomerByIdEndpoint);

            return endpoints;
        }
    }

    private static async Task<IResult> GetCustomerByIdEndpoint(
        [AsParameters] GetCustomerByIdQuery request,
        [FromServices] HandlerAsync<GetCustomerByIdQuery, GetCustomerByIdResponse> handler
    )
    {
        Result<GetCustomerByIdResponse> response = await handler.HandleAsync(request);
        return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
    }
}