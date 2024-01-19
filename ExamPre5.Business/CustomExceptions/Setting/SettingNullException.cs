using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.CustomExceptions.Setting
{
    public class SettingNullException : Exception
    {
        public string Prop { get; set; }
        public SettingNullException()
        {
        }

        public SettingNullException(string ex, string? message) : base(message)
        {
            Prop = ex;
        }
    }
}
