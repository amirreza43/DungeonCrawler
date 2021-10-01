using System;

namespace DatabaseLib
{

    public class Boss{
        public double Hp;
        public double Attack;
        public double Defense;
        public double MissChance;

        public Boss(double hp, double att, double def, double missChance){
            Hp = hp;
            Attack = att;
            Defense = def;
            MissChance = missChance;
        }
 
    }

}
