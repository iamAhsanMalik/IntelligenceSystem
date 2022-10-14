using IFC;

var builder = WebApplication.CreateBuilder(args);

// Register IFC services to the container.
builder.Services.AddIFCServices(builder.Configuration);

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    await app.AddRequestPipelineAsync();
    app.Run();
}