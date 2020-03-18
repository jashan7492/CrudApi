using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using Microsoft.AspNetCore.Cors;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class studentController : ControllerBase
    {
        studentContext obj = new studentContext();
        // GET: api/student
        [HttpGet]
        [Route("List")]
        public IEnumerable<Tbstudent> List()
        {
            return obj.Tbstudent.ToList();
        }

        // GET: api/student/5
        [HttpGet]
        [Route("Find/{id}")]
        public Tbstudent Find(string id)
        {
            return obj.Tbstudent.Find(id);
        }

        // POST: api/student
        [HttpPost]
        [Route("Create")]
        public string Create([FromBody] Tbstudent tbstudent)
        {
            obj.Tbstudent.Add(tbstudent);
            obj.SaveChanges();
            return "1";
        }

        // PUT: api/student/5
        [HttpPut]
        [Route("Update/{id}")]
        public string Update([FromBody]Tbstudent tbstudent)
        {
            obj.Entry(tbstudent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            obj.SaveChanges();
            return "1";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public string Delete(string id)
        {
            Tbstudent t = obj.Tbstudent.Find(id);
            obj.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            obj.SaveChanges();
            return "1";
        }
    }
}
