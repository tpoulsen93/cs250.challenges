using System;
using System.Collections.Generic;

namespace ComputingTheCategoricalImperative
{
    class Simulator
    {
        private int totalCitizenWealth, totalThiefWealth;
        private Citizen[] citizens;
        private Boolean catImpSwitch;
        private Random rand;
        

        public Simulator(Citizen[] citizenArray, Boolean categoricalImperative)
        {
            catImpSwitch = categoricalImperative;
            citizens = citizenArray;
            rand = new Random();
        }

        //simulate a week for each citizen
        public void simulateWeek()
        {
            //do weekly actions
            foreach (Citizen citizen in citizens)
            {
                citizen.work();

                if (catImpSwitch) //all citizens steal from each other
                    citizen.steal(findVictim(citizen));
                else    //only the thieves do the stealing
                    if (citizen.isThief())
                        citizen.steal(findVictim(citizen));            
            }

            //tabulate weekly wealth amounts
            //had to do this in a seperate loop because of the random victim selection :/
            foreach (Citizen citizen in citizens)
            {
                if (citizen.isThief())
                    totalThiefWealth += citizen.getWealth();
                else
                    totalCitizenWealth += citizen.getWealth();
            }

        }

        //make sure the thief isn't stealing from themself... cause that would be weird...
        private Citizen findVictim(Citizen citizen)
        {
            Citizen victim = citizens[rand.Next(citizens.Length)];
            while (citizen.Equals(victim))
                victim = citizens[rand.Next(citizens.Length)];

            return victim;
        }
    }
}