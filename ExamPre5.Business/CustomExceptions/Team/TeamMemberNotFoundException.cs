using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.CustomExceptions.Team
{
    public class TeamMemberNotFoundException : Exception
    {
        public string Prop { get; set; }
        public TeamMemberNotFoundException()
        {
        }

        public TeamMemberNotFoundException(string ex, string? message) : base(message)
        {
            Prop = ex;
        }
    }
}
