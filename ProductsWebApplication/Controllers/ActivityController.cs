using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using ProductsWebApplication.Models;

namespace ProductsWebApplication.Controllers
{
    public class ActivityController : ApiController
    {
        public IEnumerable<Activity> GetValues()
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                return entity.Activities.ToList();
            }

        }

      

        [HttpPut]
        public void PutValues(SettingValue item)
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                if (item.type == "booked")
                {

                    entity.Activities.Find(item.id).IsBooked = true;
                    entity.SaveChanges();
                }
                else
                {
                    entity.Activities.Find(item.id).IsSaved = true;
                    entity.SaveChanges();
                }
            }

        }
        [HttpPost]
        public void Insertion([FromBody]Activity act)
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                entity.Activities.Add(act);
                entity.SaveChanges();
            }                
           
        }
    }
}
