using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestApp
{
    public class Problem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Num { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public bool ByTest { get; set; }
        public List<Test> Tests { get; set; } = new();
        public List<Solution> Solutions { get; set; } = new();
    }
}
