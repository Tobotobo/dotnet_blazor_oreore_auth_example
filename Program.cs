using DotnetBlazorAuthExample.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 認証系サービスの追加
builder.Services
    .AddAuthorization(options =>
    {
        options.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build(); // デフォルトで認証を必須にする
    })
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";  // 未ログイン状態でアクセスした際に表示されるページ
        options.LogoutPath = null;
    });

// Blazor用の認証情報を提供するためのコンポーネント
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

// 認証情報を CascadingParameter で渡すようにする
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// 静的ファイルを提供 ※認証不要 = 認証認可より前に追加すること
app.UseStaticFiles();

// 認証認可のミドルウェアを追加 ※app.UseAntiforgery() より前に追加すること
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
