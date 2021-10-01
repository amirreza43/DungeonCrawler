using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
namespace MainApp
{

    public class PlayerActions{
        public static (int row, int col) PlayerPosition;
        public static Room room;

        public static void Seek(string direction, Room room, (int, int) playerPos){

                List<(int row, int col, string dir)> availableSeeksPos = new List<(int, int, string)>{};
                List<string> availableSeeksstrings = new List<string>{};

                if(playerPos.Equals((1,1))){ 
                    availableSeeksPos.Add((1,2,"Right"));
                    availableSeeksstrings.Add("Right");
                    availableSeeksPos.Add((2,1, "Down"));
                    availableSeeksstrings.Add("Down");
                }
                if(playerPos.Equals((1,2))){ 
                    availableSeeksPos.Add((1,3, "Right"));
                    availableSeeksstrings.Add("Right");
                    availableSeeksPos.Add((1,1, "Left"));
                    availableSeeksstrings.Add("Left");
                    availableSeeksPos.Add((2,2, "Down"));
                    availableSeeksstrings.Add("Down");
                }
                if(playerPos.Equals((1,3))){ 
                    availableSeeksPos.Add((1,2, "Left"));
                    availableSeeksstrings.Add("Left");
                    availableSeeksPos.Add((2,3, "Down"));
                    availableSeeksstrings.Add("Down");
                }
                if(playerPos.Equals((2,1))){ 
                    availableSeeksPos.Add((1,1, "Up"));
                    availableSeeksstrings.Add("Up");
                    availableSeeksPos.Add((2,2, "Right"));
                    availableSeeksstrings.Add("Right");
                    availableSeeksPos.Add((3,1, "Down"));
                    availableSeeksstrings.Add("Down");
                }
                if(playerPos.Equals((2,2))){ 
                    availableSeeksPos.Add((3,2, "Down"));
                    availableSeeksstrings.Add("Down");
                    availableSeeksPos.Add((2,1, "Left"));
                    availableSeeksstrings.Add("Left");
                    availableSeeksPos.Add((2,3, "Right"));
                    availableSeeksstrings.Add("Right");
                    availableSeeksPos.Add((1,2, "Up"));
                    availableSeeksstrings.Add("Up");
                }
                if(playerPos.Equals((2,3))){ 
                    availableSeeksPos.Add((1,3, "Up"));
                    availableSeeksstrings.Add("Up");
                    availableSeeksPos.Add((2,2, "Left"));
                    availableSeeksstrings.Add("Left");
                    availableSeeksPos.Add((3,3, "Down"));
                    availableSeeksstrings.Add("Down");
                }
                if(playerPos.Equals((3,1))){ 
                    availableSeeksPos.Add((2,1, "Up"));
                    availableSeeksstrings.Add("Up");
                    availableSeeksPos.Add((3,2, "Right"));
                    availableSeeksstrings.Add("Right");
                }
                if(playerPos.Equals((3,2))){ 
                    availableSeeksPos.Add((2,2, "Up"));
                    availableSeeksstrings.Add("Up");
                    availableSeeksPos.Add((3,1, "Left"));
                    availableSeeksstrings.Add("Left");
                    availableSeeksPos.Add((3,3, "Right"));
                    availableSeeksstrings.Add("Right");
                }
                if(playerPos.Equals((3,3))){ 
                    availableSeeksPos.Add((2,3, "Up"));
                    availableSeeksstrings.Add("Up");
                    availableSeeksPos.Add((3,2, "Left"));
                    availableSeeksstrings.Add("Left");
                }

                if(availableSeeksstrings.Contains(direction)){
                    (int row, int col, string dir) availableSeek = availableSeeksPos.Where(d => d.dir == direction).First();
                    
                    if(room.EnemyPos[0].Equals((availableSeek.row, availableSeek.col))){                        
                        Console.WriteLine("There is an enemy there!");
                    }else
                    if(room.NextPos.Equals((availableSeek.row, availableSeek.col))){
                        Console.WriteLine("There is an entry to a new room there!");
                    }else{
                        Console.WriteLine("The tile seems empty.");
                    }
                }else{
                    Console.WriteLine("Tile not available");
                }
        }
        public static void Move(string direction, Room room, (int, int) playerPos, Player player, Database db){

                List<(int row, int col, string dir)> availableMovesPos = new List<(int, int, string)>{};
                List<string> availableMovesstrings = new List<string>{};

                if(playerPos.Equals((1,1))){ 
                    availableMovesPos.Add((1,2,"Right"));
                    availableMovesstrings.Add("Right");
                    availableMovesPos.Add((2,1, "Down"));
                    availableMovesstrings.Add("Down");
                }
                if(playerPos.Equals((1,2))){ 
                    availableMovesPos.Add((1,3, "Right"));
                    availableMovesstrings.Add("Right");
                    availableMovesPos.Add((1,1, "Left"));
                    availableMovesstrings.Add("Left");
                    availableMovesPos.Add((2,2, "Down"));
                    availableMovesstrings.Add("Down");
                }
                if(playerPos.Equals((1,3))){ 
                    availableMovesPos.Add((1,2, "Left"));
                    availableMovesstrings.Add("Left");
                    availableMovesPos.Add((2,3, "Down"));
                    availableMovesstrings.Add("Down");
                }
                if(playerPos.Equals((2,1))){ 
                    availableMovesPos.Add((1,1, "Up"));
                    availableMovesstrings.Add("Up");
                    availableMovesPos.Add((2,2, "Right"));
                    availableMovesstrings.Add("Right");
                    availableMovesPos.Add((3,1, "Down"));
                    availableMovesstrings.Add("Down");
                }
                if(playerPos.Equals((2,2))){ 
                    availableMovesPos.Add((3,2, "Down"));
                    availableMovesstrings.Add("Down");
                    availableMovesPos.Add((2,1, "Left"));
                    availableMovesstrings.Add("Left");
                    availableMovesPos.Add((2,3, "Right"));
                    availableMovesstrings.Add("Right");
                    availableMovesPos.Add((1,2, "Up"));
                    availableMovesstrings.Add("Up");
                }
                if(playerPos.Equals((2,3))){ 
                    availableMovesPos.Add((1,3, "Up"));
                    availableMovesstrings.Add("Up");
                    availableMovesPos.Add((2,2, "Left"));
                    availableMovesstrings.Add("Left");
                    availableMovesPos.Add((3,3, "Down"));
                    availableMovesstrings.Add("Down");
                }
                if(playerPos.Equals((3,1))){ 
                    availableMovesPos.Add((2,1, "Up"));
                    availableMovesstrings.Add("Up");
                    availableMovesPos.Add((3,2, "Right"));
                    availableMovesstrings.Add("Right");
                }
                if(playerPos.Equals((3,2))){ 
                    availableMovesPos.Add((2,2, "Up"));
                    availableMovesstrings.Add("Up");
                    availableMovesPos.Add((3,1, "Left"));
                    availableMovesstrings.Add("Left");
                    availableMovesPos.Add((3,3, "Right"));
                    availableMovesstrings.Add("Right");
                }
                if(playerPos.Equals((3,3))){ 
                    availableMovesPos.Add((2,3, "Up"));
                    availableMovesstrings.Add("Up");
                    availableMovesPos.Add((3,2, "Left"));
                    availableMovesstrings.Add("Left");
                }

                if(availableMovesstrings.Contains(direction)){
                    (int row, int col, string dir) availableMove = availableMovesPos.Where(d => d.dir == direction).First();
                    
                    if(room.EnemyPos[0].Equals((availableMove.row, availableMove.col))){                        
                        PlayerPosition = (availableMove.row, availableMove.col);
                        Battle(player, room, db);
                    }else
                    if(room.NextPos.Equals((availableMove.row, availableMove.col)) && room.EnemyPos[0].Equals((0,0))){
                        PlayerPosition = (availableMove.row, availableMove.col);
                        PlayerActions.room = Next(player);
                        Random rnd = new Random();
                        var addRandomHp = rnd.Next(0, 14);
                        player.Hp += addRandomHp;
                        db.Update(player);
                        db.SaveChanges();
                    }else if(room.NextPos.Equals((availableMove.row, availableMove.col)) && !room.EnemyPos[0].Equals((0,0))){
                        Console.WriteLine("You have to defeat all the enemies in this room first!");
                    }
                    else{
                        PlayerPosition = (availableMove.row, availableMove.col);
                    }
                }else{
                    Console.WriteLine("That tile is not available!");
                }

        }

        public static void Battle(Player player, Room room, Database db){

            Console.WriteLine("Battle has now started.");
            Console.WriteLine($"{player.Name}'s stats: \nHp: {player.Hp} Attack: {player.Attack} Defense: {player.Defense} Lvl(Xp): {player.Lvl}({player.Xp})");
            Console.WriteLine($"Your Enemy's stats: \nHp: {RoomGeneration.enemies[0].Hp} Attack: {RoomGeneration.enemies[0].Attack} Defense: {RoomGeneration.enemies[0].Defense}");
            var playerDmg = player.Attack - RoomGeneration.enemies[0].Defense;
            while(true){
                Console.WriteLine($"{player.Name}'s attacK dealt {playerDmg} amount of damage to the enemy.");
                RoomGeneration.enemies[0].Hp -= playerDmg;
                var enHp = RoomGeneration.enemies[0].Hp <= 0? 0 : RoomGeneration.enemies[0].Hp;
                Console.WriteLine($"Enemy now has {enHp} Hp.");
                if(RoomGeneration.enemies[0].Hp <= 0){
                    RoomGeneration.enemies[0].Hp = 0;
                    RoomGeneration.enemies.RemoveAt(0);
                    room.EnemyPos = new List<(int, int)>{(0, 0)};
                    player.Xp += 5;
                    if(player.Xp == 10){
                        player.Lvl += 1;
                        player.Xp = 0;
                    }
                    player.Hp += 2;
                    player.HighScore = player.Lvl;
                    Console.WriteLine($"The enemy was defeated. {player.Name}'s Hp is {player.Hp}. You gained 5 Xp!");
                    Console.WriteLine($"{player.Name}'s stats: \nHp: {player.Hp} Attack: {player.Attack} Defense: {player.Defense} Lvl(Xp): {player.Lvl}({player.Xp})");
                    db.Update(player);
                    db.SaveChanges();
                    break;
                }

                var enemyDmg =  RoomGeneration.enemies[0].Attack - player.Defense;
                Console.WriteLine($"Enemy's attack dealt {enemyDmg} amount of damage to {player.Name}");
                 if(player.Hp <= 0){
                    player.Hp = 0;
                    break;
                }
                player.Hp -= enemyDmg; 
                Console.WriteLine($"{player.Name} now has {player.Hp} Hp.");
                db.Update(player);
                db.SaveChanges();
            }


        }
        public static Room Next(Player player){

            Room room =RoomGeneration.GenerateRoom(player.Lvl);


            return room;
        }

    }

}