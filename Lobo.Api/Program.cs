using Lobo.Api.SharedContext;
using Microsoft.EntityFrameworkCore;
using Lobo.Infrastructure.SharedContext.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

WebApplication app = builder.Build();
app.MapEndpoints();

app.UseHttpsRedirection();
app.Run();