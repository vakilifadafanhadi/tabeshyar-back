using Microsoft.EntityFrameworkCore;
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
