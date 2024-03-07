using ms_web.api.Dtos;

namespace ms_web.api.Endpoints;

public static class ProductsEndpoints
{
    const string GetProductEndpointName = "GetProduct";
    static readonly List<ProductDtos> products = [
        new (1, "Apple", 500),
        new (2, "Banana", 300),
        new (3, "Orange", 400),
        new (4, "Grapes", 600),
        new (5, "Strawberry", 700),
        new (6, "Pineapple", 450),
        new (7, "Watermelon", 250),
        new (8, "Kiwi", 550),
        new (9, "Mango", 800),
        new (10, "Peach", 350),
        new (11, "Pear", 480),
        new (12, "Plum", 320),
        new (13, "Cherry", 680),
        new (14, "Blueberry", 600),
        new (15, "Raspberry", 750),
        new (16, "Lemon", 400),
        new (17, "Avocado", 900),
        new (18, "Pomegranate", 1000),
        new (19, "Apricot", 380),
        new (20, "Cantaloupe", 300),
        new (21, "Guava", 550),
        new (22, "Dragon Fruit", 900),
        new (23, "Passion Fruit", 650),
        new (24, "Lychee", 750),
        new (25, "Mangosteen", 900),
        new (26, "Durian", 1000),
        new (27, "Starfruit", 400),
        new (28, "Persimmon", 600),
        new (29, "Papaya", 450),
        new (30, "Jackfruit", 300),
        new (31, "Tangerine", 350),
        new (32, "Lime", 200),
        new (33, "Fig", 800),
        new (34, "Coconut", 100),
        new (35, "Grapefruit", 450),
        new (36, "Cranberry", 700),
        new (37, "Blackberry", 600),
        new (38, "Currant", 550),
        new (39, "Gooseberry", 500),
        new (40, "Rhubarb", 300)
    ];

    public static RouteGroupBuilder MapProductsEndproints(this WebApplication app)
    {

        var group = app.MapGroup("products")
                        .WithParameterValidation();

        // GET /products
        group.MapGet("/", () => products);

        // GET /products/1
        group.MapGet("/{id}", (int id) => 
        {
            ProductDtos? product = products.Find(product => product.Id == id);

                return product is null ? Results.NotFound() : Results.Ok(product);
            })
                .WithName(GetProductEndpointName);

        // POST /products
        group.MapPost("/create", (CreateProductDto newProduct) =>
        {
            ProductDtos product = new(
                products.Count + 1,
                newProduct.Name,
                newProduct.Price
            );

            products.Add(product);

            return Results.CreatedAtRoute(GetProductEndpointName, new { id = product.Id }, product);
        });

        // PUT /products
        group.MapPut("/update/{id}", (int id, UpdateProductDto updateProduct) =>
        {
            var index = products.FindIndex(product => product.Id == id);

            if(index == -1)
            {
                return Results.NotFound();
            }

            products[index] = new ProductDtos(
                id,
                updateProduct.Name,
                updateProduct.Price
                );

            return Results.NoContent();
        });

        // DELETE /products/1
        group.MapDelete("/delete/{id}", (int id) => 
        {
            products.RemoveAll(products => products.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
