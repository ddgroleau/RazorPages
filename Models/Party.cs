using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPDotNetRazorApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ASPDotNetRazorApp.Models
{
    public class Party
    {
        [Key]
        public string PartyName { get; set; }
        public int PartySize { get; set; }
        public string PartyPreference { get; set; }
        public string PartyPhoneNumber { get; set; }
    }
}
