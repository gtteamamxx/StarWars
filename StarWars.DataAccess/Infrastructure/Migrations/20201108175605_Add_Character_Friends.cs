using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.DataAccess.Migrations
{
    public partial class Add_Character_Friends : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFriend");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterFriend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(nullable: false),
                    FriendCharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFriend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Characters_FriendCharacterId",
                        column: x => x.FriendCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriend_CharacterId",
                table: "CharacterFriend",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriend_FriendCharacterId",
                table: "CharacterFriend",
                column: "FriendCharacterId");
        }
    }
}