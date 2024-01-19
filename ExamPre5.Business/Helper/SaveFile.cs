using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre5.Business.Helper
{
    public static class SaveFile
    {
        public static string SaveImage(string root, string directory , IFormFile file)
        {
            string newFile = file.FileName.Length> 64 ? file.FileName.Substring(file.FileName.Length-64,64) : file.FileName;


            string fileName = Guid.NewGuid().ToString() + newFile;

            string path = Path.Combine(root, directory, fileName);

            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }
    }
}
