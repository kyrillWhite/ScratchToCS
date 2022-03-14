using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestApp
{
    public class Test
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Num { get; set; }
        public string InputData { get; set; }
        public string OutputData { get; set; }
        public Problem Problem { get; set; }
        public int ProblemId { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
