using System;

namespace ComputingTheCategoricalImperative
{
    class Citizen
    {
        private int wage, wealth;
        private Boolean thief;

        public Citizen()
        {
            wealth = 0;
            thief = false;
        }
        
        public int work()
        {
            wealth += wage;
            return wage;
        }      

        public int getRobbed()
        {
            int stolen = wealth/2;
            wealth -= stolen;
            return stolen;
        }      

        public int steal(Citizen victim)
        {
            int stolen = victim.getRobbed();
            wealth += stolen;
            return stolen;
        }

        public void setWage(int amount)
        {
            wage = amount;
        }

        public int getWealth()
        {
            return wealth;
        }

        public void setThief()
        {
            thief = true;
        }
    
        public Boolean isThief()
        {
            return thief;
        }
    }
}
