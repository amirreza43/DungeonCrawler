using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLib
{

    public class Player{

        [Key]
        public string Username{get; set;}
        public string Name{get; set;}
        public double Hp{get; set;}
        public int Xp{get; set;}
        public int Lvl{get; set;}
        public double Attack{get; set;}
        public double Defense{get; set;}
        public int HighScore{get; set;}
        public string Weapon{get; set;}
        public Armor Helmet{get; set;}
        public Armor ChestPlate{get; set;}
        public Armor Leggings{get; set;}
        public Armor Boots{get; set;}

        public Player(string username, string name, string weapon){
            Username = username;
            Name = name;
            Weapon = weapon;
            Attack = 5.00;
            Lvl =1;
            Xp =0;
            Defense = 12;
            // Armor Helmet = ;
            // ChestPlate = new Armor(){Name="Starting ChestPlate", Defense=5.00};
            // Leggings = new Armor(){Name="Starting Leggings", Defense=3.00};
            // Boots = new Armor(){Name="Starting Boots", Defense=2.00};
            Hp = 12;
        }

    }

}