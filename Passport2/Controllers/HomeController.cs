using Microsoft.AspNetCore.Mvc;
using Passport2.Models;
using System.Collections.Generic;

namespace Passport2.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<UserDetails> _users = new()
        {
            new UserDetails { Id = 1, FullName = "John Doe", Email = "john@example.com", PhoneNumber = "123456789", Country = "Jordan" },
            new UserDetails { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", PhoneNumber = "987654321", Country = "Jordan" }
        };

        private static readonly List<PassportApplication> _applications = new()
        {
            new PassportApplication { ApplicationID = 1, UserDetailsId = 1, Status = "Approved", DateOfApplication = System.DateTime.Now.AddDays(-10) },
            new PassportApplication { ApplicationID = 2, UserDetailsId = 2, Status = "Pending", DateOfApplication = System.DateTime.Now.AddDays(-5) }
        };

        private static readonly List<Residency> _residencies = new()
        {
            new Residency { ResidencyID = 1, ForeignResidentName = "Ali Khan", Nationality = "Pakistani", Address = "Amman, Jordan" },
            new Residency { ResidencyID = 2, ForeignResidentName = "Sara Lee", Nationality = "American", Address = "Irbid, Jordan" }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDetails()
        {
            return View(_users);
        }

        public IActionResult PassportApplications()
        {
            return View(_applications);
        }

        public IActionResult ResidencyRecords()
        {
            return View(_residencies);
        }
    }
}
