using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using DatabaseLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace test
{
    public class PlayerDataTest{
    private DbContextOptions<Database> _options;

        public PlayerDataTest(){

            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();

            _options = new DbContextOptionsBuilder<Database>()
            .UseSqlite(conn)
            .Options;

        }
        [Fact]
        public void ShouldCreateDatabase()
        {
            using var ctx = new Database(_options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }

        [Fact]
        public void ShouldCreateArmor()
        {
            using var ctx = new Database(_options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            Armor helmet = new Armor(){Name = "Thor's helmet", Defense = 2.00};
            Armor chestPlate = new Armor(){Name = "Thor's ChestPlate", Defense = 5.00};
            Armor leggings = new Armor(){Name = "Thor's leggings", Defense = 3.00};
            Armor boots = new Armor(){Name = "Thor's boots", Defense = 2.00};
            Armor[] armors = new Armor[]{helmet, chestPlate, leggings, boots};
            ctx.AddRange(armors);
            ctx.SaveChanges();
            ctx.Armors.Count().Should().Be(4);
        }

        [Fact]
        public void ShouldCreateBasicPlayer()
        {
        using var ctx = new Database(_options);
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
        Armor helmet = new Armor(){Name = "Thor's helmet", Defense = 2.00};
        Armor chestPlate = new Armor(){Name = "Thor's ChestPlate", Defense = 5.00};
        Armor leggings = new Armor(){Name = "Thor's leggings", Defense = 3.00};
        Armor boots = new Armor(){Name = "Thor's boots", Defense = 2.00};
        Armor[] armors = new Armor[]{helmet, chestPlate, leggings, boots};
        ctx.AddRange(armors);
        ctx.SaveChanges();
        ctx.Add(new Player("Kay01", "Kay", "sword"){
            Helmet = helmet,
            ChestPlate = chestPlate,
            Leggings = leggings,
            Boots = boots
        });
        ctx.SaveChanges();

        ctx.Players.Count().Should().Be(1);
        
        }

    }
}