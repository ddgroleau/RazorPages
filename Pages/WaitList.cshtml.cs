using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPDotNetRazorApp.Data;
using ASPDotNetRazorApp.Models;

namespace ASPDotNetRazorApp.Pages
{
    public class WaitListModel : PageModel
    {
        private readonly DataContext _context;

        public WaitListModel(DataContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Party Party { get; set; }
        public List<SelectListItem> PartyPreferences { get; set; }
        public List<Party> Parties { get; set; }

        public async Task OnGetAsync()
        {    
            try
            {
                Parties = await _context.Parties.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error.\n " + e);
            }
            finally
            {
                PartyPreferences = new List<SelectListItem>
                {
                    new SelectListItem {Value = "Inside", Text = "Inside"},
                    new SelectListItem {Value = "Outside", Text ="Outside"}
                };
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (await _context.Parties.FindAsync(Party.PartyName) == null)
            {
                 _context.Parties.Add(Party);
            }
            else
            {
                Party party = await _context.Parties.FindAsync(Party.PartyName);
                party.PartySize = Party.PartySize;
                party.PartyPreference = Party.PartyPreference;
                party.PartyPhoneNumber = Party.PartyPhoneNumber;
                _context.Parties.Update(party);
            }
            await _context.SaveChangesAsync();
            Console.WriteLine($"Added {Party.PartyName}, party of {Party.PartySize}, seated {Party.PartyPreference}, call {Party.PartyPhoneNumber}.");
            return RedirectToPage("./WaitList", Party = new Party());
        }
        public async Task<IActionResult> OnPostDeleteAsync(string partyName)
        {
            Party partyToDelete = await _context.Parties.FindAsync(partyName);
            if (partyToDelete != null)
            {
                _context.Parties.Remove(partyToDelete);
            }
            await _context.SaveChangesAsync();
            Console.WriteLine($"Deleted {partyToDelete.PartyName}, party of {partyToDelete.PartySize}, seated {partyToDelete.PartyPreference}, call {partyToDelete.PartyPhoneNumber}.");
            return RedirectToPage("./WaitList", Party = new Party());
        }
    }
}

