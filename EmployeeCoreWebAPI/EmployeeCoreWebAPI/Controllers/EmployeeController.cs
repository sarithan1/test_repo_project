using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeCoreWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeCoreWebAPI.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private EmployeeCoreWebAPI.Models.EmployeeDBContext _context;

        // GET: api/<controller>


        //// GET: UserTbs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userTb = await _context.TblEmployee.SingleOrDefault(m => m.EmployeeId == id);
        //    if (userTb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userTb);
        //}

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Employee Get Method" };
        }

        private EmployeeDBContext db = new EmployeeDBContext();
        [Produces("application/json")]
        [HttpGet("findcount")]
        public string Findcount()
        {
            var employees = db.TblEmployee.ToList();
            return "test" + employees.Count();
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult FindAll()
         {
            try
            {
                var employees = db.TblEmployee.ToList();
                return Ok(employees);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<employees>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (db.TblEmployee.Find(id) != null)
            {
                return "Employee name is: "+db.TblEmployee.Find(id).EmployeeName;
            }
            else
            {
                return "*****No Employee found****";
            }
   
        }

        // POST api/<employees>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<employees>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<employees>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
