using AlAnon.Areas.Identity;
using AlAnon.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using AlAnon.Repository;
using AlAnon.Repository.IRepository;
using AlAnon.Areas.Identity.Initializer;
using Microsoft.AspNetCore.Identity.UI.Services;
using AlAnon.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider); ;
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Repository
builder.Services.AddScoped<IGrupoRepository, GrupoRepository>();

// Add Repository for Info
builder.Services.AddScoped<IInfoRepository, InfoRepository>();

// Add DB Seeded with Admin Role
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

// Add Repository for User Roles
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Add Email Server
builder.Services.AddTransient<IEmailSender, MailKitEmailSender>();
builder.Services.Configure<MailKitEmailSenderOptions>(options =>
{
    options.Host_Address =builder.Configuration["ExternalProviders:MailKit:SMTP:Address"];
    options.Host_Port = Convert.ToInt32(builder.Configuration["ExternalProviders:MailKit:SMTP:Port"]);
    options.Host_Username = builder.Configuration["ExternalProviders:MailKit:SMTP:Account"];
    options.Host_Password = builder.Configuration["ExternalProviders:MailKit:SMTP:Password"];
    options.Sender_EMail = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderEmail"];
    options.Sender_Name = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderName"];
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
seedDatabase();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

void seedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}