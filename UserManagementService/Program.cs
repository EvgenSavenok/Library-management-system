using UserManagementService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();  
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=RoleSelection}/{id?}");  

app.Run();
