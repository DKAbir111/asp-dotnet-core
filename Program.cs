using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Swagger services add
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



var categories = new List<Category>();
//get all categories
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});


//post category
app.MapPost("/api/categories", ([FromBody] Category category) =>
{
    var newCategory = new Category
    {
        CategoryId = Guid.NewGuid(),
        Name = category.Name,
        Description = category.Description,
        CreatedAt = DateTime.UtcNow
    };

    categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);
});


//get category by id
app.MapGet("/api/categories/{id}", (Guid id) =>
{
    var category = categories.FirstOrDefault(c => c.CategoryId == id);
    if (category == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(category);
});


//delete category by id
app.MapDelete("/api/categories/{id}", (Guid id) =>
{
    var category = categories.FirstOrDefault(c => c.CategoryId == id);
    if (category == null)
    {
        return Results.NotFound();
    }
    categories.Remove(category);
    return Results.NoContent();
});

//put category by id
app.MapPut("/api/categories/{id}", (Guid id, [FromBody] Category updatedCategory) =>
{
    var category = categories.FirstOrDefault(c => c.CategoryId == id);
    if (category == null)
    {
        return Results.NotFound();
    }
    category = category with
    {
        Name = updatedCategory.Name,
        Description = updatedCategory.Description
    };
    return Results.Ok(category);
});

// 🔥 Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

app.Run();


public record Category
{
    public Guid CategoryId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }

    public DateTime CreatedAt { get; init; }
}