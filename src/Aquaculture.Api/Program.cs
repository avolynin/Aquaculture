using Aquaculture.Api.Extensions;
using Aquaculture.Application.Extensions;
using Aquaculture.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy(
    "CorsPolicy",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000");
    }));
builder.Services.AddSwaggerGen();

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseDeveloperExceptionPage();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors("CorsPolicy");
    app.Run();
}
