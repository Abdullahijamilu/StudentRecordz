using System.Diagnostics;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StudentRecordz.Models;

namespace StudentRecordz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentRecordsContext _context;


        public HomeController(ILogger<HomeController> logger, StudentRecordsContext Context)
        {
            _context = Context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterEntry(Student request)
        {
            TempData["success"] = null;
            var data = request;
            _context.Students.Add(data);
            int save = _context.SaveChanges();
            if (save > 0)
            {
                TempData["success"] = "saved successfully";
            }
            return RedirectToAction("Register");
        }

        public IActionResult Records()
        {
            return View();
        }
        public IActionResult RecordsEntry(Result request)
        {
            TempData["success"] = null;
            var data = request;
            _context.Results.Add(data);
            int save = _context.SaveChanges();
            if (save > 0)
            {
                TempData["success"] = "saved successfully";
            }
            return RedirectToAction("Record");
        }

        public IActionResult GetRecord()
        {
            TempData["success"] = null;
            var data = _context.Students.ToList();
            if (data.Any() == true)
            {
                TempData["success"] = "Items retrieved Successfully";
            }
            return View(data);
        }
        public IActionResult Details(int Id)
        {
            TempData["success"] = null;


            var student = _context.Students.Include(s => s.Results).FirstOrDefault(s => s.Id == Id);


            if (student == null)
            {
                return RedirectToAction("GetRecord");
            }

            TempData["success"] = "Items retrieved Successfully";
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
