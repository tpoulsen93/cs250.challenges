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
        
        public void work()
        {
            wealth += wage;
        }      

        public int getRobbed()
        {
            int amountStolen = wealth/2;
            wealth -= amountStolen;
            return amountStolen;
        }      

        public void steal(Citizen victim)
        {
                wealth += victim.getRobbed();
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
