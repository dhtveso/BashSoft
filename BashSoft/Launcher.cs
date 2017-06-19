using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            IOManager.TraverseDirectory(0);
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
            //Tester.CompareContent(@"D:\SoftUni\test2.txt", @"D:\SoftUni\test3.txt");
            IOManager.CreateDirectoryInCurrentFolder("pesho");
        }
    }
}
