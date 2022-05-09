using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XProject.Repository.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TD_SHARING_INFO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dd_member_account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mode_code = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_flag = table.Column<bool>(type: "bit", nullable: true),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expiration_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_SHARING_INFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TD_CUSTOMER_INFO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    File_Sharing_ID = table.Column<int>(type: "int", nullable: false),
                    Customer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TD_SHARING_INFOId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_CUSTOMER_INFO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TD_CUSTOMER_INFO_TD_SHARING_INFO_TD_SHARING_INFOId",
                        column: x => x.TD_SHARING_INFOId,
                        principalTable: "TD_SHARING_INFO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TD_FILE_INFO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    File_Sharing_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File_Size = table.Column<int>(type: "int", nullable: true),
                    Upload_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TD_SHARING_INFOId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_FILE_INFO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TD_FILE_INFO_TD_SHARING_INFO_TD_SHARING_INFOId",
                        column: x => x.TD_SHARING_INFOId,
                        principalTable: "TD_SHARING_INFO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TM_DD_MEMBER",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permission = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimmitedDays = table.Column<int>(type: "int", nullable: true),
                    TD_SHARING_INFOId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TM_DD_MEMBER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TM_DD_MEMBER_TD_SHARING_INFO_TD_SHARING_INFOId",
                        column: x => x.TD_SHARING_INFOId,
                        principalTable: "TD_SHARING_INFO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TD_CUSTOMER_INFO_TD_SHARING_INFOId",
                table: "TD_CUSTOMER_INFO",
                column: "TD_SHARING_INFOId");

            migrationBuilder.CreateIndex(
                name: "IX_TD_FILE_INFO_TD_SHARING_INFOId",
                table: "TD_FILE_INFO",
                column: "TD_SHARING_INFOId");

            migrationBuilder.CreateIndex(
                name: "IX_TM_DD_MEMBER_TD_SHARING_INFOId",
                table: "TM_DD_MEMBER",
                column: "TD_SHARING_INFOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TD_CUSTOMER_INFO");

            migrationBuilder.DropTable(
                name: "TD_FILE_INFO");

            migrationBuilder.DropTable(
                name: "TM_DD_MEMBER");

            migrationBuilder.DropTable(
                name: "TD_SHARING_INFO");
        }
    }
}
