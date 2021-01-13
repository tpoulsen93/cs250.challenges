public class BenefitsOfSociety
{
    public static void main(String[] args)
    {
        //get mode from command line
        if (args.length != 1)
        {
            System.err.println("Usage: java BenefitsOfSociety <mode> **0 = anarchy, 1 = society**");
            System.exit(1);
        }
        int mode = Integer.parseInt(args[0]);
        if (mode == 0)
            System.out.println("Running in Anarchy mode ...\n");
        else
            System.out.println("Running in Society mode ...\n");



        //run the simulation 100 times to get the average survival time
        //uncomment all lines with aterisks at the beginning to run the simulation 1000 times and get the average
//** */        int totalDaysSurvived = 0;
//** */        for (int j = 0; j < 1000; j++)
//** */        {
            boolean allDead = false;
            int daysSurvived = 0;

            //create characters and put them in an array of people
            Character doc = new Doctor(mode);
            Character farmer = new Farmer(mode);
            Character carpenter = new Carpenter(mode);
            Character hunter = new Hunter(mode);

            Character[] people = {doc, farmer, carpenter, hunter};

            //create Disaster Generator
            DisasterGenerator disasterGenerator = new DisasterGenerator();
            String disasterOfTheDay;

            //run the simulation on a loop until either 1 year is reached or everyone is dead. each iteration is 1 day
            for (int i = 0; i < 365; i++)
            {
                //do each of the peoples skills
                for (Character person : people)
                {
                    if (person.isAlive())
                    {   //the farmer only gets to do his ability once every 3 days
                        if (person.type().equals("Farmer"))
                        {
                            if (i % 3 == 0)
                                person.doSkill(mode, people);
                        }
                        else //everyone else does their skill every day
                            person.doSkill(mode, people);

                        person.loseFood(1);
                    }
                }

                //disaster strike
                disasterOfTheDay = disasterGenerator.newDisasterStrike(people);
                System.out.println("Day " + i + ": " + disasterOfTheDay);
                System.out.println("----------------------------------------------------------");

                //print characters status
                allDead = true;
                for (Character person : people)
                {
                    System.out.println(person.toString());
                    
                    if (person.isAlive())
                        allDead = false;
                }

                //check for survivors and increment daysSurvived if survivors exist
                if (allDead)
                {
                    System.out.println("Everyone is dead\t:(");
                    break;
                }
                daysSurvived++;
                System.out.println();
            }

            if (daysSurvived == 365)
                System.out.println("Congratulations! You survived a whole year!");

            System.out.println("Days survived: " + daysSurvived + "\n");
//** */            totalDaysSurvived += daysSurvived;
//** */        }
//** */        System.out.println("Average days survived: " + totalDaysSurvived/1000);
    }
}