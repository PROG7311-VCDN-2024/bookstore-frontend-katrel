using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sprint_books.Models;

namespace sprint_books.Controllers
{
    public class UserdetailController : Controller
    {
        private readonly SprintContext _context;

        public UserdetailController(SprintContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Models.Userdetail user)
        {
            if (ModelState.IsValid)
            {
               

                _context.Userdetails.Add(user);
                _context.SaveChanges();

                TempData["Message"] = "Registration successful!";
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Models.Userdetail user)
        {
            if (ModelState.IsValid)
            {
                

                var existingUser = _context.Userdetails
                    .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if (existingUser != null)
                {
                    TempData["Message"] = "Login successful!";
                    return RedirectToAction("Index", "Store"); 
                }
                else
                {
                    TempData["ErrorMessage"] = "Login failed. Please check your credentials.";
                }
            }

            return View(user);
        }
        /*Code Attribute for register/login 
 * Source:https://youtu.be/Uq0y8oxnx-8?si=4BD6zNhxuyi0IEH4
 * Creater : OpenEducation - How to create Custom Login Registration in Asp.Net MVC 5 (Code First)
 */

        // Helper method to compute SHA-256 hash
       
    }
}


/*Code Attribute for RegisterController
 * Source: https://youtu.be/mWntrphY54w?si=211xKfrvgZc5-i4B 
 * Creater : Csharp Space- How to create login page in ASP.net Core MVC with Database
 */