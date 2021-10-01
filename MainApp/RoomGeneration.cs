using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLib;

namespace MainApp
{

    public class RoomGeneration{
        public static List<Enemy> enemies= new List<Enemy>();
        public static Room GenerateRoom(int playerLevel){
            int enemyPosRow1;
            int enemyPosRow2;
            int enemyPosCol1;
            int enemyPosCol2;
            int nextPosRow;
            int nextPosCol;
            int startRow;
            int startCol;
            Room room;
            Random rnd = new Random();
            switch (playerLevel)
            {
                case  < 6:
                startRow = rnd.Next(1, 4);
                startCol = rnd.Next(1, 4);

                while(true){
                    enemyPosRow1 = rnd.Next(1, 4);
                    enemyPosCol1 = rnd.Next(1, 4);
                    nextPosCol = rnd.Next(1, 4);
                    nextPosRow = rnd.Next(1, 4);
                    
                    if(enemyPosRow1 != startRow && nextPosRow != enemyPosRow1 && nextPosRow != startRow) {
                        break;
                    }
                }
                var enemyHp = rnd.Next(8, 13);
                var enemyAtt = rnd.Next(13, 16);
                var enemyDef = rnd.Next(1, 5);
                enemies = new List<Enemy>{new Enemy(enemyHp, enemyAtt, enemyDef)};
                room = new Room(){
                    Row = 3,
                    Column = 3,
                    
                    StartPos  = (startRow, startCol),

                    EnemyPos = new List<(int, int)>{(enemyPosRow1, enemyPosCol1)},

                    NextPos = (nextPosRow, nextPosCol)
                };
                PlayerActions.PlayerPosition = (startRow, startCol);
                return room;
                
                case  > 5:
                startRow = rnd.Next(1, 4);
                startCol = rnd.Next(1, 4);

                while(true){
                    enemyPosRow1 = rnd.Next(1, 4);
                    enemyPosCol1 = rnd.Next(1, 4);
                    enemyPosRow2 = rnd.Next(1, 4);
                    enemyPosCol2 = rnd.Next(1, 4);
                    nextPosCol = rnd.Next(1, 4);
                    nextPosRow = rnd.Next(1, 4);
                    
                    if(enemyPosRow1 != startRow && nextPosRow != enemyPosRow1 && nextPosRow != startRow && enemyPosRow2 != startRow && enemyPosRow2 != nextPosRow) {
                        break;
                    }
                }
                var enemyHp1 = rnd.Next(10, 15);
                var enemyAtt1 = rnd.Next(13, 16);
                var enemyDef1 = rnd.Next(1, 5);
                var enemyHp2 = rnd.Next(10, 15);
                var enemyAtt2 = rnd.Next(13, 16);
                var enemyDef2 = rnd.Next(1, 5);
                enemies = new List<Enemy>{new Enemy(enemyHp1, enemyAtt1, enemyDef1), new Enemy(enemyHp2, enemyAtt2, enemyDef2)};
                room = new Room(){
                    Row = 3,
                    Column = 3,
                    
                    StartPos  = (startRow, startCol),

                    EnemyPos = new List<(int, int)>{(enemyPosRow1, enemyPosCol1)},

                    NextPos = (nextPosRow, nextPosCol)
                };
                PlayerActions.PlayerPosition = (startRow, startCol);
                return room;
                
                default:
                Console.WriteLine("Error in GenerateRoom function.");
                Room defaultroom = new Room();
                return defaultroom;
                
            }

        }

    }

}