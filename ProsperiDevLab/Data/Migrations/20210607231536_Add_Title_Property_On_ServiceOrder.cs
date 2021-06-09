using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsperiDevLab.Data.Migrations
{
    public partial class Add_Title_Property_On_ServiceOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ServiceOrders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ServiceOrders");
        }
    }
}
