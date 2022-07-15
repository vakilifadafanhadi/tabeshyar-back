using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy",policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<tabeshyar_back.TabeshyarDb>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<tabeshyar_back.TabeshyarDb>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
}
app.UseRouting();
app.UseEndpoints(configure =>
configure.MapDefaultControllerRoute().RequireCors("corsPolicy"));
app.UseCors("corsPolicy");
app.Run();
