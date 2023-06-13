using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddInvestedMoneyNewType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InvestedMoney",
                table: "TotalAmountOfCurrencies",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InvestedMoney",
                table: "TotalAmountOfCurrencies",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
