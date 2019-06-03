using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDomain = AppDomain.CurrentDomain;
            AnalizeDomain(currentDomain);

            var secondDomain = AppDomain.CreateDomain("Another Specific Domain Area");
            AnalizeDomain(secondDomain);
            secondDomain.ExecuteAssembly(secondDomain.BaseDirectory + "Test2.exe", new string[] { "5", "7" });
            AnalizeDomain(secondDomain);

            AppDomain.Unload(secondDomain);

            Console.ReadLine();
        }

        private static void AnalizeDomain(AppDomain currentDomain)
        {
            Console.WriteLine($"***{currentDomain.FriendlyName}, {currentDomain.BaseDirectory}, {currentDomain.Id}");

            var assemblies = currentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                Console.WriteLine($"{assembly.FullName}, {assembly.Location}");
            }
        }
    }
}
