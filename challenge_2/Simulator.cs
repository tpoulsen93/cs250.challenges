using System;
using System.Collections.Generic;

namespace ComputingTheCategoricalImperative
{
    class Simulator
    {
        private long wealthStolen, wealthCreated;
        private int population, thiefCount;
        private Citizen[] citizens;
        private Boolean catImpSwitch;
        private Random rand;
        

        public Simulator(int population, int thiefCount, Boolean categoricalImperative)
        {
            wealthStolen = wealthCreated = 0;
            this.population = population;
            this.thiefCount = thiefCount;
            catImpSwitch = categoricalImperative;
            citizens = new Citizen[population];
            rand = new Random();
        }

        //build array of citizens
        public void build()
        {
            //find all the Counts for creating correct # of citizens per class
            int upperCount = (int)(population * 0.1);
            int middleUpperCount = upperCount + (int)(population * 0.2);
            int middleLowerCount = middleUpperCount + (int)(population * 0.5);
            int lowerCount = middleLowerCount + (int)(population * 0.1);
            //poorClass can be filled until the end

            //create citizens and fill array
            for (int i = 0; i < population; i++)
                if (i < upperCount)
                    citizens[i] = new UpperClass();
                else if (i < middleUpperCount)
                    citizens[i] = new MiddleUpperClass();
                else if (i < middleLowerCount)
                    citizens[i] = new MiddleLowerClass();
                else if (i < lowerCount)
                    citizens[i] = new LowerClass();
                else
                    citizens[i] = new PoorClass();

            assignThieves();
        }

        //simulate a week for each citizen
        public void simulateWeek()
        {
            //work
            foreach (Citizen citizen in citizens)
                wealthCreated += citizen.work();

            //steal
            foreach (Citizen citizen in citizens)
                if (catImpSwitch) //all citizens steal from each other
                    wealthStolen += citizen.steal(findVictim(citizen));
                else    //only the thieves do the stealing
                    if (citizen.isThief())
                        wealthStolen += citizen.steal(findVictim(citizen));            
        }

        public long getCitizenWealth()
        {
            long citizenWealth = 0;
            foreach (Citizen citizen in citizens)
                if (!citizen.isThief())
                    citizenWealth += citizen.getWealth();
                    
            return citizenWealth;
        }

        public float getAvgCitizenWealth()
        {
            return getCitizenWealth() / (population - thiefCount);
        }

        public long getThiefWealth()
        {
            long thiefWealth = 0;
            foreach (Citizen citizen in citizens)
                if (citizen.isThief())
                    thiefWealth += citizen.getWealth();
            return thiefWealth;        }

        public float getAvgThiefWealth()
        {
            if (thiefCount != 0)
                return getThiefWealth() / (thiefCount);
            return 0;
        }

        public long getWealthStolen()
        {
            return wealthStolen;
        }

        public long getWealthMade()
        {
            return wealthCreated;
        }

        //make sure the thief isn't stealing from themself... cause that would be weird...
        private Citizen findVictim(Citizen citizen)
        {
            Citizen victim = citizens[rand.Next(citizens.Length)];
            while (citizen.Equals(victim))
                victim = citizens[rand.Next(citizens.Length)];

            return victim;
        }

        //assign thieves
        private void assignThieves()
        {
            int thieves = 0;
            while(thieves < thiefCount)
            {
                Citizen thiefCandidate = citizens[rand.Next(citizens.Length)];
                if (!thiefCandidate.isThief())
                {
                    thiefCandidate.setThief();
                    thieves++;
                }
            }
        }

        //check that correct number of citizens of each type were created
        public void checkBuild()
        {
            int thieves = 0;
            int upperCount = 0;
            int middleUpperCount = 0;
            int middleLowerCount = 0;
            int lowerCount = 0;
            int poorCount = 0;

            foreach (Citizen citizen in citizens)
            {
                if (citizen.GetType().Name.Equals("UpperClass"))
                    upperCount++;
                else if (citizen.GetType().Name.Equals("MiddleUpperClass"))
                    middleUpperCount++;
                else if (citizen.GetType().Name.Equals("MiddleLowerClass"))
                    middleLowerCount++;
                else if (citizen.GetType().Name.Equals("LowerClass"))
                    lowerCount++;
                else if (citizen.GetType().Name.Equals("PoorClass"))
                    poorCount++;
            
                if (citizen.isThief())
                    thieves++;
            }

            Console.WriteLine("\n---------------Build Verification---------------\n");
            Console.WriteLine("There are a total of " + citizens.Length + " citizens in the list.");
            Console.WriteLine(thiefCount + " of them should be thieves.\nThere are:\n");
            Console.WriteLine(upperCount + " UpperClass Citizens.");
            Console.WriteLine(middleUpperCount + " MiddleUpperClass Citizens.");
            Console.WriteLine(middleLowerCount + " MiddleLowerClass Citizens.");
            Console.WriteLine(lowerCount + " LowerClass Citizens.");
            Console.WriteLine(poorCount + " PoorClass Citizens.");
            Console.WriteLine("\n" + thieves + " of those citizens were randomly selected as thieves.");
        }
    }
}