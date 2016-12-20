using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class Passenger
    {
        public string Name { get; set; }
    }

    public static class PassengerCreator
    {
        static string[] Names = {"Jacob", "James", "Jarib", "Jaziz", "Jehonathan", "Joanna", "John", "Jonah", "Jordan", "Jose", "Joshua", "Josiphiah", "Judah", "Julia", "Juttah"};
        
        public static string GetName()
        {
            var rnd = new Random();
            var index = rnd.Next(0, Names.Length - 1);
            return Names[index]; 
        }

        public static IEnumerable<Passenger> CreatePassengers(int num)
        {
            var passengerList = new List<Passenger>();
            for (int i = 0; i < num; i++)
            {
                passengerList.Add(new Passenger { Name = GetName() });
            }
            return passengerList;
        }
    }
}
    