using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x => x.DestinationID == id).Include(c => c.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLastFourDestinations()
        {
            using (var context = new Context())
            {
                var values = context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();
                return values;
            }
        }

        public List<Destination> GetTop3DestinationsByReservation()
        {
            using (var context = new Context())
            {
                var result = context.Destinations
                    .Include(d => d.Reservations)  // Reservations'ı dahil et
                    .OrderByDescending(d => d.Reservations.Count)  // Rezervasyon sayısına göre sırala
                    .Take(3)  // İlk 3'ü al
                    .ToList();
                return result;
            }
        }


    }
}
