using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Swagger services add
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



// 🔥 Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();


