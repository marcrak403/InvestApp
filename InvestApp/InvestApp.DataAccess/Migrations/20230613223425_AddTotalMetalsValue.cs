using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalMetalsValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TotalAmountOfMetals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetalType = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    InvestedMoney = table.Column<double>(type: "float", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalAmountOfMetals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalAmountOfMetals_Users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmountOfMetals_AssignedToId",
                table: "TotalAmountOfMetals",
                column: "AssignedToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TotalAmountOfMetals");
        }
    }
}
