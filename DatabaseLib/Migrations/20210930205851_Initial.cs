using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseLib.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Defense = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Hp = table.Column<double>(type: "REAL", nullable: false),
                    Xp = table.Column<int>(type: "INTEGER", nullable: false),
                    Lvl = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<double>(type: "REAL", nullable: false),
                    Defense = table.Column<double>(type: "REAL", nullable: false),
                    HighScore = table.Column<int>(type: "INTEGER", nullable: false),
                    Weapon = table.Column<string>(type: "TEXT", nullable: true),
                    HelmetName = table.Column<string>(type: "TEXT", nullable: true),
                    ChestPlateName = table.Column<string>(type: "TEXT", nullable: true),
                    LeggingsName = table.Column<string>(type: "TEXT", nullable: true),
                    BootsName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Players_Armors_BootsName",
                        column: x => x.BootsName,
                        principalTable: "Armors",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Armors_ChestPlateName",
                        column: x => x.ChestPlateName,
                        principalTable: "Armors",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Armors_HelmetName",
                        column: x => x.HelmetName,
                        principalTable: "Armors",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Armors_LeggingsName",
                        column: x => x.LeggingsName,
                        principalTable: "Armors",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_BootsName",
                table: "Players",
                column: "BootsName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ChestPlateName",
                table: "Players",
                column: "ChestPlateName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_HelmetName",
                table: "Players",
                column: "HelmetName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LeggingsName",
                table: "Players",
                column: "LeggingsName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Armors");
        }
    }
}
