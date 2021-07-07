using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary;
using DataAccessLibrary.DataAccess;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   
            return View();
        }

        public IActionResult ViewEmployee()
        {
                var data = EmployeeClass.LoadEmployee();

                List<EmployeeModel> employee = new List<EmployeeModel>();

                foreach (var row in data)
                {
                    employee.Add(new EmployeeModel
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        Email = row.Email,
                        Address = row.Address,
                        Position = row.Position,
                        Salary = row.Salary
                    });
                }
            return View(employee);
            
        }

        public IActionResult SignUpEmployee() 
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SignUpEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeClass.InsertEmployee(model.FirstName,
                                             model.LastName,
                                             model.Email,
                                             model.Address,
                                             model.Position,
                                             model.Salary);

                return RedirectToAction("ViewEmployee");
            }

            return View();
        }

        public IActionResult EditEmployee(int id) 
        {
            var data = EmployeeClass.LoadEmployee();

            List<EditModel> employee = new List<EditModel>();

            foreach (var row in data)
            {
                employee.Add(new EditModel
                {   
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Email = row.Email,
                    Address = row.Address,
                    Position = row.Position,
                    Salary = row.Salary
                });
            }

            var val = employee.Where(s => s.Id == id).FirstOrDefault();

            return View(val);
        }

        [HttpPost]
        public IActionResult EditEmployee(EditModel model) 
        {
            if (ModelState.IsValid) 
            {
                EmployeeClass.UpdateEmployee(model.Id,
                                             model.FirstName,
                                             model.LastName,
                                             model.Email,
                                             model.Address,
                                             model.Position,
                                             model.Salary);

                return RedirectToAction("ViewEmployee");
            }

            return View();
        }

        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var data = EmployeeClass.LoadEmployee();

                var val = data.Where(s => s.Id == id).FirstOrDefault();

                DeleteModel delete = new DeleteModel
                {
                    Id = val.Id,
                    FirstName = val.FirstName,
                    LastName = val.LastName,
                    Email = val.Email,
                    Position = val.Position

                };

                return View(delete);
            }
            catch (NullReferenceException) 
            {
                return RedirectToAction("ViewEmployee");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteEmployee(DeleteModel model)
        {
            EmployeeClass.DeleteEmployee(model.Id);

            return RedirectToAction("ViewEmployee");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
