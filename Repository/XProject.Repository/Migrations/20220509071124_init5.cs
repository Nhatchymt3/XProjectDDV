using Microsoft.EntityFrameworkCore.Migrations;

namespace XProject.Repository.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TD_CUSTOMER_INFO_TD_SHARING_INFO_TD_SHARING_INFOId",
                table: "TD_CUSTOMER_INFO");

            migrationBuilder.DropForeignKey(
                name: "FK_TD_FILE_INFO_TD_SHARING_INFO_TD_SHARING_INFOId",
                table: "TD_FILE_INFO");

            migrationBuilder.DropForeignKey(
                name: "FK_TM_DD_MEMBER_TD_SHARING_INFO_TD_SHARING_INFOId",
                table: "TM_DD_MEMBER");

            migrationBuilder.DropIndex(
                name: "IX_TM_DD_MEMBER_TD_SHARING_INFOId",
                table: "TM_DD_MEMBER");

            migrationBuilder.DropIndex(
                name: "IX_TD_FILE_INFO_TD_SHARING_INFOId",
                table: "TD_FILE_INFO");

            migrationBuilder.DropIndex(
                name: "IX_TD_CUSTOMER_INFO_TD_SHARING_INFOId",
                table: "TD_CUSTOMER_INFO");

            migrationBuilder.DropColumn(
                name: "TD_SHARING_INFOId",
                table: "TM_DD_MEMBER");

            migrationBuilder.DropColumn(
                name: "TD_SHARING_INFOId",
                table: "TD_FILE_INFO");

            migrationBuilder.DropColumn(
                name: "TD_SHARING_INFOId",
                table: "TD_CUSTOMER_INFO");

            migrationBuilder.AddColumn<string>(
                name: "TM_DD_MEMBERsId",
                table: "TD_SHARING_INFO",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "File_Sharing_ID",
                table: "TD_FILE_INFO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "File_Sharing_ID",
                table: "TD_CUSTOMER_INFO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TD_SHARING_INFO_TM_DD_MEMBERsId",
                table: "TD_SHARING_INFO",
                column: "TM_DD_MEMBERsId");

            migrationBuilder.CreateIndex(
                name: "IX_TD_FILE_INFO_File_Sharing_ID",
                table: "TD_FILE_INFO",
                column: "File_Sharing_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TD_CUSTOMER_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO",
                column: "File_Sharing_ID",
                unique: true,
                filter: "[File_Sharing_ID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TD_CUSTOMER_INFO_TD_SHARING_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO",
                column: "File_Sharing_ID",
                principalTable: "TD_SHARING_INFO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TD_FILE_INFO_TD_SHARING_INFO_File_Sharing_ID",
                table: "TD_FILE_INFO",
                column: "File_Sharing_ID",
                principalTable: "TD_SHARING_INFO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TD_SHARING_INFO_TM_DD_MEMBER_TM_DD_MEMBERsId",
                table: "TD_SHARING_INFO",
                column: "TM_DD_MEMBERsId",
                principalTable: "TM_DD_MEMBER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TD_CUSTOMER_INFO_TD_SHARING_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO");

            migrationBuilder.DropForeignKey(
                name: "FK_TD_FILE_INFO_TD_SHARING_INFO_File_Sharing_ID",
                table: "TD_FILE_INFO");

            migrationBuilder.DropForeignKey(
                name: "FK_TD_SHARING_INFO_TM_DD_MEMBER_TM_DD_MEMBERsId",
                table: "TD_SHARING_INFO");

            migrationBuilder.DropIndex(
                name: "IX_TD_SHARING_INFO_TM_DD_MEMBERsId",
                table: "TD_SHARING_INFO");

            migrationBuilder.DropIndex(
                name: "IX_TD_FILE_INFO_File_Sharing_ID",
                table: "TD_FILE_INFO");

            migrationBuilder.DropIndex(
                name: "IX_TD_CUSTOMER_INFO_File_Sharing_ID",
                table: "TD_CUSTOMER_INFO");

            migrationBuilder.DropColumn(
                name: "TM_DD_MEMBERsId",
                table: "TD_SHARING_INFO");

            migrationBuilder.AddColumn<string>(
                name: "TD_SHARING_INFOId",
                table: "TM_DD_MEMBER",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "File_Sharing_ID",
                table: "TD_FILE_INFO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TD_SHARING_INFOId",
                table: "TD_FILE_INFO",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "File_Sharing_ID",
                table: "TD_CUSTOMER_INFO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TD_SHARING_INFOId",
                table: "TD_CUSTOMER_INFO",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TM_DD_MEMBER_TD_SHARING_INFOId",
                table: "TM_DD_MEMBER",
                column: "TD_SHARING_INFOId");

            migrationBuilder.CreateIndex(
                name: "IX_TD_FILE_INFO_TD_SHARING_INFOId",
                table: "TD_FILE_INFO",
                column: "TD_SHARING_INFOId");

            migrationBuilder.CreateIndex(
                name: "IX_TD_CUSTOMER_INFO_TD_SHARING_INFOId",
                table: "TD_CUSTOMER_INFO",
                column: "TD_SHARING_INFOId");

            migrationBuilder.AddForeignKey(
                name: "FK_TD_CUSTOMER_INFO_TD_SHARING_INFO_TD_SHARING_INFOId",
                table: "TD_CUSTOMER_INFO",
                column: "TD_SHARING_INFOId",
                principalTable: "TD_SHARING_INFO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TD_FILE_INFO_TD_SHARING_INFO_TD_SHARING_INFOId",
                table: "TD_FILE_INFO",
                column: "TD_SHARING_INFOId",
                principalTable: "TD_SHARING_INFO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TM_DD_MEMBER_TD_SHARING_INFO_TD_SHARING_INFOId",
                table: "TM_DD_MEMBER",
                column: "TD_SHARING_INFOId",
                principalTable: "TD_SHARING_INFO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
