using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ProductsWebApplication.Models;
using System.Net.Http;
using System.Web.Http;

namespace ProductsWebApplication.Controllers
{
    public class CarController : ApiController
    {
        public IEnumerable<Car> GetValues()
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                return entity.Cars.ToList();
            }   
                
        }


        public IEnumerable<Car> GetValues(string types)
        {

            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                if (types.Equals("booked"))
                {
                    var query = from value in entity.Cars
                                where value.IsBooked == false
                                select value;
                    return query.ToList();
                }
                else
                {
                    var query = from value in entity.Cars
                                where value.IsSaved == false
                                select value;
                    return query.ToList();
                }
            }

        }

        [HttpPost]
        public void Insertion([FromBody]Car car)
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                entity.Cars.Add(car);
                entity.SaveChanges();
            }

        }
    }
}
