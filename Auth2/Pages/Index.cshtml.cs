using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auth2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // At this stage, if we have NOT yet logged in, we have an anonymous identity. 
            // Watching base.User.Identity (The primary identity), we can see that there are no claims, and IsAuthenticated is false
            // because we have not yet logged in.
            // asp.net creates the primary identity for us, regardless of whether or not we have logged in.
            // i.e. we have a security context, albeit an anonymous (empty) one.
        }
    }
}