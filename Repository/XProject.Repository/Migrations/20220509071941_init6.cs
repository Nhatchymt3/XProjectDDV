using Microsoft.EntityFrameworkCore.Migrations;

namespace XProject.Repository.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TD_CUSTOMER_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO");

            migrationBuilder.CreateIndex(
                name: "IX_TD_CUSTOMER_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO",
                column: "File_Sharing_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TD_CUSTOMER_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO");

            migrationBuilder.CreateIndex(
                name: "IX_TD_CUSTOMER_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO",
                column: "File_Sharing_ID",
                unique: true,
                filter: "[File_Sharing_ID] IS NOT NULL");
        }
    }
}
