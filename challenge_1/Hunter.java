import java.util.Random;

public class Hunter extends Character implements ProfessionalSpecialization{
    
    Random rand;

    public Hunter(int mode)
    {
        super(mode);
        rand = new Random();
    }

    @Override
    public void doSkill(int mode, Character[] people)
    {
        if (rand.nextInt(5) == 0)   //successful hunt
            if (getMode() == 0)
                anarchySkill();
            else
                societySkill(people);
    }

    @Override
    public void anarchySkill()
    {
        addFood(2);
    }

    @Override
    public void societySkill(Character[] people)
    {
        for (Character person : people)
            person.addFood(2);
    }
}
