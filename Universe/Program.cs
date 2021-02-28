using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Universe.DataAccess;
using Universe.Entity;

namespace Universe
{
    class Program
    {

        static void Main(string[] args)
        {
            IRepository<User> userRepo = new UserRepository();

            var tugkan = new User() { Name = "Tuğkan", Surname = "Meral", TCKN = "99999999999" };
            userRepo.Add(tugkan);

            var user = userRepo.Get(u => u.TCKN == tugkan.TCKN);

            Console.WriteLine($"{user.Name} {user.Surname}");
            Console.WriteLine($"TCKN: {user.TCKN}");
            

            // UNCOMMENT BELOW TO CHECK OVER RUN DURATION
            //IRepository<UserTest> userTestRepo = new UserTestRepository();
            //Thread.Sleep(3000);
            //double totalDiffOne = 0;
            //double totalDiffTwo = 0;
            //int counter = 0;

            //for (int i = 1; i < 12; i++)
            //{
            //    Console.WriteLine($"i = {i}");
            //    var tOne = DateTime.Now;
            //    var user = userRepo.Get(p => p.Id == i);
            //    var tTwo = DateTime.Now;

            //    var tThree = DateTime.Now;
            //    var userTest = userTestRepo.GetTest(p => p.Id == i);
            //    var tFour = DateTime.Now;

            //    var diffOne = (tTwo - tOne).TotalMilliseconds;
            //    var diffTwo = (tFour - tThree).TotalMilliseconds;

            //    if (i > 3)
            //    {
            //        totalDiffOne += diffOne;
            //        totalDiffTwo += diffTwo;
            //        counter++;
            //    }

            //    Console.WriteLine($"Reflection ile Get() : \t\t{diffOne}ms");
            //    Console.WriteLine($"Direkt Get() : \t\t\t{diffTwo}ms");
            //    Console.WriteLine($"\n");
            //}

            //Console.WriteLine("TOTAL");
            //Console.WriteLine($"Reflection ile Get() : \t\t\t{totalDiffOne / counter}");
            //Console.WriteLine($"Direkt Get() : \t\t\t{totalDiffTwo / counter}");
        }
    }
}
