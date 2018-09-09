using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DataAccess;
using System.Web.Http;
using ProductsWebApplication.Models;

namespace ProductsWebApplication.Controllers
{
    public class AirController : ApiController
    {
        public IEnumerable<Air> GetValues()
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                return entity.Airs.ToList();
            }

        }


        public IEnumerable<Air> GetValues(string types)
        {

            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                if (types.Equals("booked"))
                {
                    var query = from value in entity.Airs
                                where value.IsBooked == false
                                select value;
                    return query.ToList();
                }
                else
                {
                    var query = from value in entity.Airs
                                where value.IsSaved == false
                                select value;
                    return query.ToList();
                }
            }

        }


        [HttpPost]
        public void Insertion([FromBody]Air air)
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                entity.Airs.Add(air);
                entity.SaveChanges();
            }

        }
    }
}
