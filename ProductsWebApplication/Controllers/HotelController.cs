using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsWebApplication.Models;

namespace ProductsWebApplication.Controllers
{
    public class HotelController : ApiController
    {
        public IEnumerable<Hotel> GetValues()
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                return entity.Hotels.ToList();
            }

        }


        public IEnumerable<Hotel> GetValues(string types)
        {

            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                if (types.Equals("booked"))
                {
                    var query = from value in entity.Hotels
                                where value.IsBooked == false
                                select value;
                    return query.ToList();
                }
                else
                {
                    var query = from value in entity.Hotels
                                where value.IsSaved == false
                                select value;
                    return query.ToList();
                }
            }

        }

        [HttpPost]
        public void Insertion([FromBody]Hotel hot)
        {
            using (ProductDataBaseEntities entity = new ProductDataBaseEntities())
            {
                entity.Hotels.Add(hot);
                entity.SaveChanges();
            }

        }
    }


   


}
