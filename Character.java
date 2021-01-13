public class Character
{
    private int health, food, shelter, mode;

    //Mode: 1 -> Society Mode
    //Mode: 0 -> Anarchy Mode
    public Character(int mode)
    {
        this.mode = mode;
        shelter = 10;
        health = 10;
        food = 10;
    }

    public void doSkill(int mode, Character[] people)
    {
        System.out.println("I don't have any skills... :(");
    }

    public int getSkillMode()
    {
        return mode;
    }

    public boolean isAlive()
    {
        if (health > 0 && food > 0)
            return true;
        else
            return false;
    }
    
    public int getMode()
    {
        return mode;
    }

    public int myHealth()
    {
        return health;
    }

    public void addHealth(int hp)
    {
        health += hp;
        if (health > 10)
            health = 10;
    }

    public void loseHealth(int hp)
    {
        health -= hp;
        if (health < 0)
            health = 0;
    }

    public int myShelter()
    {
        return shelter;
    }

    public void addShelter(int num)
    {
        shelter += num;
        if (shelter > 10)
            shelter = 10;
    }

    public void loseShelter(int num)
    {
        shelter -= num;
        if (shelter < 0)
            shelter = 0;
    }
    
    public int myFood()
    {
        return food;
    }

    public void addFood(int num)
    {
        food += num;
    }

    public void loseFood(int num)
    {
        food -= num;
        if (food < 0)
            food = 0;
    }

    public String toString()
    {
        String result = type() + ": ";
        if (isAlive())
            result += "Health - " + myHealth() + ".  Food - " + myFood() + ".  Shelter - " + myShelter();
        else
            result += "Dead";
            
        return result;
    }

    public String type()
    {
        return getClass().getSimpleName();
    }
}