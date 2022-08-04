using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tabeshyar_back.ModelViews;
using tabeshyar_back.Repositories;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<tabeshyar_back.TabeshyarDb>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper); builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<tabeshyar_back.TabeshyarDb>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers()
             .RequireCors(MyAllowSpecificOrigins);
});
app.Run();
