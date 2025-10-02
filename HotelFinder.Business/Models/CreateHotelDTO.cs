using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Models
{
    public class CreateHotelDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
