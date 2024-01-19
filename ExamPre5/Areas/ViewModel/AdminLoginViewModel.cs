using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace ExamPre5.Areas.ViewModel
{
    public class AdminLoginViewModel
    {

        [StringLength(maximumLength: 30)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
