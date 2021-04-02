using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonCS07
{
    class Statements7_2
    {
        ///  Listing 7.1 Working with statements in C#
        public void DescribeAge1(int age)
        {
            string ageDescription = null;
            var greeting = "Hello";

            if (age < 18)
                ageDescription = "Child!";
            else if (age < 65)
                greeting = "Adult!";

            Console.WriteLine($"{greeting}! You are a '{ageDescription}'");
        }

        /// Listing 7.2 Working with expressions in C#
        private static string GetText(int age)
        {
            if (age < 18) return "Child!";
            else if (age < 65) return "Adult!";
            else return "OAP!";
        }

        public void DescribeAge2(int age)
        {
            var ageDescription = GetText(age);
            var greeting = "Hello";
            Console.WriteLine($"{greeting}! You are a '{ageDescription}'");
        }

    }
}
