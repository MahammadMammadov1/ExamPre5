using ExamPre5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Core.Models
{
    public class Setting : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 30)]
        public string Key { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string Value { get; set; }
    }
}
