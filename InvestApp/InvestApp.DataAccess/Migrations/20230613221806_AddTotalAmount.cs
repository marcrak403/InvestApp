using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TotalAmountOfCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalAmountOfCurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalAmountOfCurrencies_Users_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmountOfCurrencies_AssignedToId",
                table: "TotalAmountOfCurrencies",
                column: "AssignedToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TotalAmountOfCurrencies");
        }
    }
}
