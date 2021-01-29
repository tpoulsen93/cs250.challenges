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
            {
                Console.Error.WriteLine("Usage: <population size> <percentage of thieves> <categorical imperative switch>");
                Console.Error.WriteLine("<population size>: must be divisible by 100.");
                Console.Error.WriteLine("<percentage of thieves>: must be between 0 and 100. (inclusive)");
                Console.Error.WriteLine("<categorical imperative switch>: OFF < 1 > ON");
                throw new ArgumentException("Incorrect # of arguments.");
            }

            //assign arguments provided to variables
            int population = int.Parse(args[0]);
            if (population%100 != 0)
                throw new ArgumentException("The population argument must be divisible by 100.");
            
            int thiefCount = 0;
            float thiefPercentage = float.Parse(args[1]);
            if (thiefPercentage < 0 || thiefPercentage > 100)
                throw new ArgumentException("Thief Percentage must be between 0 and 100 inclusive.");
            if (thiefPercentage != 0)
                thiefCount = (int)(population * ((float)thiefPercentage/100));

            //categorical imperative switch
            Boolean catImpSwitch;
            if (int.Parse(args[2]) < 1)
                catImpSwitch = false;
            else
                catImpSwitch = true;

            //build simulator
            var simulator = new Simulator(population, thiefCount, catImpSwitch);
            simulator.build();
            float avgCitizenWealth = 0;
            float avgThiefWealth = 0;
            float runningAvgCitWealth = 0;
            float runningAvgThiefWealth = 0;
            const int weeks = 52;
            const int years = 10;

            //run simulation for 10 years
            for (int i = 0; i < years; i++)
            {
                for (int j = 0; j < weeks; j++)
                    simulator.simulateWeek();

                avgCitizenWealth = simulator.getAvgCitizenWealth();
                avgThiefWealth = simulator.getAvgThiefWealth();
                runningAvgCitWealth += avgCitizenWealth;
                runningAvgThiefWealth += avgThiefWealth;
                Console.WriteLine("Avg citizen wealth for year " + (i+1) + " was " + avgCitizenWealth);
                Console.WriteLine("Avg thief wealth for year " + (i+1) + " was " + avgThiefWealth);
            }

            //calculate and print wealth averages
            Console.WriteLine("\nTotal wealth created from work: " + simulator.getWealthMade());
            Console.WriteLine("Total wealth stolen: " + simulator.getWealthStolen());
            Console.WriteLine("\nAvg citizen wealth per year was\t" + (runningAvgCitWealth / years));
            Console.WriteLine("Avg thief wealth per year was\t" + (runningAvgThiefWealth / years));

            simulator.checkBuild();
        }
    }
}
