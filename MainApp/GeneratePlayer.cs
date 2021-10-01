using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
namespace MainApp
{

    public class GeneratePlayer{
        public static Player CreatePlayer(Database db, string username, string name){
            Player player;
            var p = db.Players.Where(p => p.Username == username).ToList();
            if( p.Count > 0){
                player = db.Players.Where(p => p.Username == username).First();
                player.Hp = 12;
                player.Xp =0;
                player.Lvl = 1;
                db.Update(player);
                db.SaveChanges();
            }else{
                player = new Player(username, name, "sword");
                db.Add(player);
                db.SaveChanges();
            }

            return player;
        }

    }

}
