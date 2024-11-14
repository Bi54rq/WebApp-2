using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Addedstafftable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammeLeaderId",
                table: "Programmes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Staffing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffing", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_ProgrammeLeaderId",
                table: "Programmes",
                column: "ProgrammeLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programmes_Staffing_ProgrammeLeaderId",
                table: "Programmes",
                column: "ProgrammeLeaderId",
                principalTable: "Staffing",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programmes_Staffing_ProgrammeLeaderId",
                table: "Programmes");

            migrationBuilder.DropTable(
                name: "Staffing");

            migrationBuilder.DropIndex(
                name: "IX_Programmes_ProgrammeLeaderId",
                table: "Programmes");

            migrationBuilder.DropColumn(
                name: "ProgrammeLeaderId",
                table: "Programmes");
        }
    }
}
