using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Realizations
{
    public class RealizationPhoto
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public Guid RealizationId { get; set; }
    }
}
