using ASPNETCORE_app_with_repository_pattern;
using ASPNETCORE_app_with_repository_pattern.Data;
using ASPNETCORE_app_with_repository_pattern.Model;
using ASPNETCORE_app_with_repository_pattern.Model.DTO;
using ASPNETCORE_app_with_repository_pattern.Repository;
using ASPNETCORE_app_with_repository_pattern.Repository.IRepository;
using ASPNETCORE_app_with_repository_pattern.VehcileService;
using ASPNETCORE_app_with_repository_pattern.VehcileService.IVehcileService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("Vehcile")));

builder.Services.AddScoped<IVehcileRepository<Vehicle>, VehcileRepository>();


IMapper mapper = MapperConfig.RegisterMapper().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IVehcileService<VehcileDto>, VehcileService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    //app.UseExceptionHandler("/Home/Error");
    ////    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllers();
    //name: "default",
    //pattern: "{controller=Vehcile}/{action=Get}/{id?}");

app.Run();



//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();





















//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
//app.UseAuthentication(); ;

//app.UseAuthorization();
//app.MapRazorPages();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

//app.Run();