using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestApp
{
    public class TestResult
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsCorrect { get; set; } = false;
        public string ErrorText { get; set; }
        public string ResultOutputData { get; set; }
        public Solution Solution { get; set; }
        public int SolutionId { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
    }
}
