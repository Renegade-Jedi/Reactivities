using Domain.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Realizations
{
    public class Realization
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Location { get; set; }
        public ICollection<RealizationPhoto> Photos { get; set; }
    }
}
