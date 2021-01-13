public class Doctor extends Character implements ProfessionalSpecialization
{
    public Doctor(int mode)
    {
        super(mode);
    }

    @Override
    public void doSkill(int mode, Character[] people)
    {
        if (myFood() == 1)
            addFood(1);
        else
            if (mode == 0)
                anarchySkill();
            else
                societySkill(people);
    }

    @Override
    public void anarchySkill() 
    {
        
            addHealth(2);
    }

    @Override
    public void societySkill(Character[] people) 
    {
        if (myFood() == 1)
            addFood(1);
        else
            for (Character person : people)
                person.addHealth(2);         
    }
}