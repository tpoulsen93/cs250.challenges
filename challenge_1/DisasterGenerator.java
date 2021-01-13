import java.util.Random;

public class DisasterGenerator{

    private enum Disasters {NOTHING, HURRICANE, FAMINE, DISEASE, WOLVES};
    private Random disasterSelector;

    public DisasterGenerator()
    {
        disasterSelector = new Random();
    }

    public String newDisasterStrike(Character[] people)
    {
        Disasters[] disasters = Disasters.values();
        int selection = disasterSelector.nextInt(disasters.length);

        switch (disasters[selection])
        {
            case HURRICANE:
                for (Character person : people)
                {
                    if (person.myShelter() == 0)
                        person.loseHealth(5);
                    person.loseShelter(3);
                }    
                return "Hurricane";

            case DISEASE:
                for (Character person : people)
                    person.loseHealth(2);
                return "Disease";
                
            case FAMINE:
                for (Character person : people)
                    person.loseFood(2);
                return "Famine";
                
            case WOLVES:
                Character huntsmen = getPerson("Hunter", people);
                if (huntsmen.getMode() == 1) //society mode
                {
                    //Hunter is alive scenario
                    if (huntsmen.isAlive())
                        for (Character person : people)
                            person.loseHealth(1);
                    else //hunter is dead scenario:
                        for (Character person : people)
                            person.loseHealth(3);
                }
                else    //anarchy mode
                {
                    for (Character person : people)
                        if (person.type().equals("Hunter"))
                            person.loseHealth(1);
                        else
                            person.loseHealth(3);
                }
                return "Wolves";

            case NOTHING:
                return "No Disaster";
                
			default:
				return "No Disaster";       
        }
    }

    private Character getPerson(String type, Character[] peeps)
    {
        for (Character person : peeps)
            if (person.type().equals(type))
                return person;

        //hopefull these lines are never reached...
        System.err.println("No Hunter in the group");
        System.exit(1);
        return new Character(1);
    }
}
