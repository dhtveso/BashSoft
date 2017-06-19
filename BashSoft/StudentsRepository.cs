using System;
using System.Collections.Generic;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!StudentsRepository.isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitialisedException);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] token = input.Split(' ');
                string course = token[0];
                string student = token[1];
                int mark = int.Parse(token[2]);

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse[course] = new Dictionary<string, List<int>>();
                }
                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course][student] = new List<int>();
                }

                studentsByCourse[course][student].Add(mark);
                input = Console.ReadLine();
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }

            return false;
        }

        private static bool IsQueryForStudentPossiblе(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
    }
}
