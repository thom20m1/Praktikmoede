using Microsoft.EntityFrameworkCore.Migrations;

namespace Praktikmoede.Data.Migrations
{
    public partial class addMoedeDeltagerToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoedeDeltager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Initials = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MoedeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoedeDeltager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoedeDeltager_Moede_MoedeId",
                        column: x => x.MoedeId,
                        principalTable: "Moede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoedeDeltager_MoedeId",
                table: "MoedeDeltager",
                column: "MoedeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoedeDeltager");
        }
    }
}
