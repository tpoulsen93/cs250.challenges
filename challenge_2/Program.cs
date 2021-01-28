using System;
using System.Collections.Generic;


namespace ComputingTheCategoricalImperative
{
    class Program
    {
        static void Main(string[] args)
        {
            //check for correct # of arguments
            if (args.Length < 3 || args.Length > 3)
                throw new ArgumentException("Incorrect # of arguments. Try again.");

            //assign arguments provided to variables
            int population = int.Parse(args[0]);
            if (population%100 != 0)
                throw new ArgumentException("The population argument must be divisible by 100.");
            
            float thiefPercentage = float.Parse(args[1]);
            if (thiefPercentage < 0 || thiefPercentage > 1)
                throw new ArgumentException("Thief Percentage must be between 0 and 100 inclusive.");
            
            //categorical imperative switch
            Boolean catImpSwitch;
            if (int.Parse(args[2]) < 1)
                catImpSwitch = false;
            else
                catImpSwitch = true;

            //create citizen array
            var citizens = new Citizen[population];

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

            //assign thieves
            var rand = new Random();
            int thiefCount = 0;
            while(thiefCount < (thiefPercentage * population))
            {
                Citizen thiefCandidate = citizens[rand.Next(citizens.Length)];
                if (!thiefCandidate.isThief())
                {
                    thiefCandidate.setThief();
                    thiefCount++;
                }
            }

/*
            //check that correct number of citizens of each type were created
            
            int poorCount = upperCount = middleUpperCount = middleLowerCount = lowerCount = 0;
            
            foreach (Citizen citizen in citizens)
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

            Console.WriteLine("There are a total of " + citizens.Length + " citizens in the list.");
            Console.WriteLine("There should be " + population + " citizens\n");    
            Console.WriteLine("The list contains " + upperCount + " UpperClass Citizens.");
            Console.WriteLine("The list contains " + middleUpperCount + " MiddleUpperClass Citizens.");
            Console.WriteLine("The list contains " + middleLowerCount + " MiddleLowerClass Citizens.");
            Console.WriteLine("The list contains " + lowerCount + " LowerClass Citizens.");
            Console.WriteLine("The list contains " + poorCount + " PoorClass Citizens.");
*/            
           
            //create simulator
            var simulator = new Simulator(citizens, catImpSwitch);
            const int simTime = 10 * 52; //10 years

            //run simulation
            for (int i = 0; i < simTime; i++)
                simulator.simulateWeek();


        }
    }
}
