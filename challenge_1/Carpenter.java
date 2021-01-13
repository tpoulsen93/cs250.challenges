public class Carpenter extends Character implements ProfessionalSpecialization {
    
    public Carpenter(int mode)
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
    public void anarchySkill() {
        addShelter(2);
    }

    @Override
    public void societySkill(Character[] people) {
        for (Character person : people)
            person.addShelter(1);
    }
}
