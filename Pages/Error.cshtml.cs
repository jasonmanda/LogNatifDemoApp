using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LogNatifDemoApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public string ErrorMessage { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        // public void OnGet()
        // {
        //     RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        // }

        public void OnGet(int? status)
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
 
            if(status.HasValue){
                if(status==404)  ErrorMessage = "La page est introuvable";
                    // Redirect("NotFound");
            }
        }

    }
}
