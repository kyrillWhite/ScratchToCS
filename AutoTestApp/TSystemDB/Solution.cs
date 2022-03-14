using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestApp
{
    public class Solution
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }
        public string TranslationError { get; set; }
        public string FileName { get; set; }
        public string SolutionFile { get; set; }
        public int TestPassed { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
