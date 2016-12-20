using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class Bus
    {
        public delegate void EventBusHandler(Bus bus);
        bool stand;
        public string Name { get; set; }
        List<Passenger> Passengers { get; set; }
        int SeatsMaxCount { get; set; }

        public bool IsStand {
            get { return stand; }
            set
            {
                if (stand != value)
                {
                    if(value)
                    {
                        BusStop(this);
                    }
                    else
                    {
                        BusGoAway(this);
                    }
                    stand = value;
                }
            }
        }
        public bool IsDoorOpen { get; set; }
        public bool IsSeatsExist {
            get
            {
                return Passengers.Count < SeatsMaxCount;
            }
        }

        public event EventBusHandler BusGoAway;
        public event EventBusHandler BusStop;

        public Bus(int seats)
        {
            SeatsMaxCount = seats;
            Passengers = new List<Passenger>();
        }
        public void AddPassenger(Passenger pass)
        {
            if (IsSeatsExist)
                Passengers.Add(pass);
        }
    }
}
