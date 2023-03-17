using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeMng;
using EmployeeMng.Models;

namespace EmployeeMng.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Empl> Get()
        {

            using (EmployeetblEntities entities= new EmployeetblEntities()) 
            {
               return entities.Empl.ToList();
            }
        }
        public Empl Get(int id)
        {
            using (EmployeetblEntities entities = new EmployeetblEntities())
            {
               return entities.Empl.FirstOrDefault(e=>e.ID== id);   
            }
        }
        public void Put (int id,[FromBody]Empl empl)
        {
            using (EmployeetblEntities entities = new EmployeetblEntities())
            {
                var entity = entities.Empl.FirstOrDefault(e=>e.ID== id);
                entity.FirstName = empl.FirstName;
                entity.LastName = empl.LastName;
                entity.Gender= empl.Gender;
                entity.Salary= empl.Salary;

                entities.SaveChanges();
            }
                
        }
        public void Delete (int id)
        {
            using (EmployeetblEntities entities = new EmployeetblEntities())
            {
                var entity = entities.Empl.FirstOrDefault(e=>e.ID== id);
                if(entity != null)
                {
                    entities.Empl.Remove(entity);
                    entities.SaveChanges();
                }

                 
            }
        }

    }
}
