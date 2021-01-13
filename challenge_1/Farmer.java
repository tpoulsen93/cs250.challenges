public class Farmer extends Character implements ProfessionalSpecialization {
    
    public Farmer(int mode)
    {
        super(mode);
    }

    @Override
    public void doSkill(int mode, Character[] people) {
        if (mode == 0)
            anarchySkill();
        else
            societySkill(people);
    }

    @Override
    public void anarchySkill() 
    {
        addFood(3);
    }

    @Override
    public void societySkill(Character[] people) 
    {
        for (Character person : people)
            person.addFood(3);
    }

}
