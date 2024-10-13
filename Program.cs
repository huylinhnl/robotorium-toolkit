using System.Security.Claims;
using System.Web.Helpers;
using BlazorLoginDiscord.Data;
using Discord.OAuth2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RoboToolkit.Components;
using RoboToolkit.Extentions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMessageServices();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opt.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = OpenshiftDefaults.AuthenticationScheme;
}).AddCookie()
    .AddDiscord(x =>
    {
        x.AppId = "custom-oauth";//Configuration["Discord:AppId"];
        x.AppSecret = "sha256~Adfler9dfgXDH_Fc7Adfler9dfgXDHFc7";// Configuration["Discord:AppSecret"];
        // x.Scope.Add("guilds");

        //Required for accessing the oauth2 token in order to make requests on the user's behalf, ie. accessing the user's guild list
        x.SaveTokens = true;
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<UserService>();
builder.Services.AddServerSideBlazor();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});



app.Run();
//certlm.msc