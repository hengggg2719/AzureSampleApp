using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureSampleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string WelcomeMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            WelcomeMessage = _configuration["WelcomeMessage"] ?? "Welcome";
        }
    }
}