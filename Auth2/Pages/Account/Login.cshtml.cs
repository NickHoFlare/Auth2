using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Auth2.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // This is a toy app. Shh.
            if (Credential.UserName == "admin" && Credential.Password == "password")
            {
                // Create security context (claimset)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Credential.UserName),
                    new Claim(ClaimTypes.Email, "email@test.com")
                };
                var identity = new ClaimsIdentity(claims, Constants.CookieSchemeName);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(Constants.CookieSchemeName, claimsPrincipal);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
