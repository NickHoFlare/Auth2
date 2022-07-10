using Auth2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(Constants.CookieSchemeName).AddCookie(Constants.CookieSchemeName,
    options => { 
        options.Cookie.Name = Constants.CookieSchemeName; 
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Without UseAuthentication middleware, ASP.NET does not look in the Request headers for a cookie to populate the security context with
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
