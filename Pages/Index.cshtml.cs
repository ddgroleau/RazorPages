using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPDotNetRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        public string PartyName { get; set; }
        public int PartySize { get; set; }
        public string PartyPreference { get; set; }
        public List<SelectListItem> PartyPreferences { get; set; }
        public string PartyPhoneNumber { get; set; }

        public void OnGet()
        {
            PartyPreferences = new List<SelectListItem>
            {
                new SelectListItem {Value = "In", Text = "Inside"},
                new SelectListItem {Value = "Out", Text ="Outside"}
            };
        }
    }
}
