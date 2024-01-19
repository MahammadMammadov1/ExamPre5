using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.CustomExceptions.Team
{
    public class ImageFileRequiredException : Exception
    {
        public string Prop { get; set; }
        public ImageFileRequiredException()
        {
        }

        public ImageFileRequiredException(string ex, string? message) : base(message)
        {
            Prop = ex;
        }
    }
}
