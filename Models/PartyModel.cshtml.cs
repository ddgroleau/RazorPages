using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetRazorApp.Models
{
    public class PartyModel : PageModel
    {
        
        [BindProperty]
        public string PartyName { get; set; }
        [BindProperty]
        public int PartySize { get; set; }
        [BindProperty]
        public string PartyPreference { get; set; }
        public List<SelectListItem> PartyPreferences { get; set; }
        [BindProperty]
        public string PartyPhoneNumber { get; set; }

        public void OnGet()
        {
            PartyPreferences = new List<SelectListItem>
            {
                new SelectListItem {Value = "In", Text = "Inside"},
                new SelectListItem {Value = "Out", Text ="Outside"}
            };
        }
        public IActionResult OnPost()
        {
            Console.WriteLine($"Incoming party,{PartyName} party of {PartySize}. Seat {PartyPreference} and contact at {PartyPhoneNumber}.");
            return RedirectToPage("WaitList", new PartyModel());
        }
    }
    
}
