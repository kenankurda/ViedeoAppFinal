using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViedeoAppFinal.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DayOfBirth { get; set; }
        public IList<Video> Videos { get; set; }
    }
}
