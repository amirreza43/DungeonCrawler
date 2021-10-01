using System;
using System.Linq;
using System.Collections.Generic;
using DatabaseLib;
using DungeonLib;
namespace MainApp
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            using var db = new Database();
           ;
            Console.WriteLine("Enter Your Username:");
            var playerUsername = Console.ReadLine();
            Console.WriteLine("Enter your Name");
            var playerName = Console.ReadLine();
            Player player = GeneratePlayer.CreatePlayer(db, playerUsername, playerName);
            if(player.Name == null){
                Console.WriteLine("New Player Account created");
            }else{
                playerName = player.Name;
                Console.WriteLine($"{player.Name}'s stats: \nHp: {player.Hp}, Attack: {player.Attack}, Defense: {player.Defense}, Lvl(Xp): {player.Lvl}({player.Xp}), HighScore: {player.HighScore}");

            }

            PlayerActions.room = RoomGeneration.GenerateRoom(player.Lvl);
            PlayerActions.PlayerPosition = PlayerActions.room.StartPos;


            while (true)
            {
                 
                Console.WriteLine($"{playerName}'s current position: {PlayerActions.PlayerPosition}, EnemyPos{PlayerActions.room.EnemyPos[0]}, NextPos: {PlayerActions.room.NextPos}\n");
                // 0 0 P
                // 0 0 0
                // 0 0 0
                for(int row = 1; row <4; row++){
                    for(int col =1; col<4; col++){

                        
                        if(PlayerActions.PlayerPosition.col == col && PlayerActions.PlayerPosition.row == row && col == 3){
                            Console.Write(" P \n");
                        }else if(PlayerActions.PlayerPosition.col == col && PlayerActions.PlayerPosition.row == row){
                            Console.Write(" P ");
                        }else
                        if(col==3){
                            Console.Write(" 0 \n");
                        }else{
                            Console.Write(" 0 ");
                        }

                    }
                }
                Console.WriteLine("\nWhat do you want to do? (Seek, Move/Battle, Stats, HighScores, Leave)");

                var playerAction = Console.ReadLine();
                var playerActionArray = playerAction.Split(' ');
                if(playerActionArray[0] == "Seek" && playerActionArray.Length > 1){

                    PlayerActions.Seek(playerActionArray[1], PlayerActions.room, PlayerActions.PlayerPosition);

                }else if(playerActionArray[0] == "Move" || playerActionArray[0]== "Battle"){
                    
                    PlayerActions.Move(playerActionArray[1], PlayerActions.room, PlayerActions.PlayerPosition, player, db);
                
                }else if(playerActionArray[0]=="Stats"){
                    Console.WriteLine($"{player.Name}'s stats: \nHp: {player.Hp}, Attack: {player.Attack}, Defense: {player.Defense}, Lvl(Xp): {player.Lvl}({player.Xp}), HighScore: {player.HighScore}");
                    continue;

                }else if(playerActionArray[0]=="HighScores"){

                    Console.WriteLine("\n-------\n-------");
                    db.Players.Where(p => p.HighScore > 1).OrderByDescending(p => player.HighScore)
                    .ToList()
                    .ForEach
                    (x => Console.WriteLine($"{x.Name}'s stats: Hp: {x.Hp}, Attack: {x.Attack}, Defense: {x.Defense}, Lvl(Xp): {x.Lvl}({x.Xp}), HighScore: {x.HighScore}"));
                    Console.WriteLine("-------\n-------");
                    continue;

                }
                else if(playerActionArray[0]=="Leave"){

                    break;

                }

                if(player.Hp <= 0){

                    break;

                }
            }

            
        }
    }
}
