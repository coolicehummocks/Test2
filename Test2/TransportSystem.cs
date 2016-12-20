using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class TransportSystem
    {
        Bus bus1;
        Station station1;

        public TransportSystem()
        {
            bus1 = new Bus(20) { Name = "Num 20" };
            station1 = new Station();
            bus1.BusStop += station1.BusIsComing;
            bus1.BusGoAway += station1.BusIsGoingAway;
        }

        public string Iterate()
        {
            DateTime now = DateTime.Now;
            int sec = Int32.Parse(now.ToString("ss").Substring(1));
            var rnd = new Random();

            //Bus state
            if (sec < 3 || sec > 8)
            {
                bus1.IsStand = false;
                bus1.IsDoorOpen = false;

                var passengerCount = rnd.Next(2, 4);
                station1.AddPassengers(PassengerCreator.CreatePassengers(passengerCount));
            }
            else
            {
                bus1.IsStand = true;

                if(sec > 3 && sec < 8)
                {
                    bus1.IsDoorOpen = true;
                }
                else
                {
                    bus1.IsDoorOpen = false;
                }
            }

            
            return String.Format("sec: {0}, Bus is stand: {1}, door is open: {2}, passengers on station: {3}", sec, station1.IsBusStand, bus1.IsDoorOpen, station1.Passengers.Count);
        }
    }
}
