using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabEx7.Service;
using System.IO;
using LabEx7.Model;

namespace LabEx7.Helper
{
    class FileManager
    {
        public static void SaveToFile(HashSet<Student> students)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\studentdb." + DateTime.Now.ToString("MMddyyyyhhmmss") + ".txt";
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (Student student in students)
                {
                    sw.WriteLine(student.ToString());
                }
            }
            Environment.Exit(0);
        }
    }
}
