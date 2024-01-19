﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.CustomExceptions.Team
{
    public class FileLengthException : Exception
    {
        public string Prop { get; set; }
        public FileLengthException()
        {
        }

        public FileLengthException(string ex , string? message) : base(message)
        {
            Prop = ex;
        }
    }
}
