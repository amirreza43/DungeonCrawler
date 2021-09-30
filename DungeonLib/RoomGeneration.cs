using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLib;

namespace DungeonLib
{

    public class RoomGeneration{
        public static Room GenerateRoom(int playerLevel){

            List<Enemy> enemies= new List<Enemy>();

            switch (playerLevel)
            {
                case 1:
                enemies.Add(new Enemy(10, 3, 10));
                enemies.Add(new Enemy(10, 3, 10));
                Chest chest = new Chest(){};
                Room room = new Room(){
                    Row = 3,
                    Column = 3,

                };
                break;
                
                default:
                Console.WriteLine("Error in GenerateRoom function.");
                break;
            }

        }

    }

}