using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TacosFastFoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingDrinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TacosDB",
                table: "TacosDB");

            migrationBuilder.RenameTable(
                name: "TacosDB",
                newName: "Tacos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tacos",
                table: "Tacos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    Slushie = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tacos",
                table: "Tacos");

            migrationBuilder.RenameTable(
                name: "Tacos",
                newName: "TacosDB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TacosDB",
                table: "TacosDB",
                column: "Id");
        }
    }
}
