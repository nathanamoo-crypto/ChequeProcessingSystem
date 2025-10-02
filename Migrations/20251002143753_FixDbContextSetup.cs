using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChequeProcessingSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixDbContextSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Accounts_AccountId",
                table: "Cheques");

            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Accounts_AccountId1",
                table: "Cheques");

            migrationBuilder.DropIndex(
                name: "IX_Cheques_AccountId1",
                table: "Cheques");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Cheques");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Accounts_AccountId",
                table: "Cheques",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Accounts_AccountId",
                table: "Cheques");

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "Cheques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_AccountId1",
                table: "Cheques",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Accounts_AccountId",
                table: "Cheques",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Accounts_AccountId1",
                table: "Cheques",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
