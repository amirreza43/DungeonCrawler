using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLib
{
    public class Enemy{
        public double Hp;
        public double Attack;
        public double Defense;

        public Enemy(double hp, double att, double def){
            Hp = hp;
            Attack = att;
            Defense = def;
        }

    }
}