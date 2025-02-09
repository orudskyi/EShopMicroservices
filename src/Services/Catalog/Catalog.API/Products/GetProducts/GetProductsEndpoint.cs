﻿namespace Catalog.API.Products.GetProducts;

//public record GetProductsRequest();
public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductQuery());

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(statusCode: StatusCodes.Status200OK)
            .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
            .WithSummary("Get products")
            .WithDescription("Get products");
    }
}