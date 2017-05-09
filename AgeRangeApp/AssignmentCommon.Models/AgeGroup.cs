using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models
{
    public class AgeGroup
    {
        public int Id { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Description { get; set; }
    }
}
