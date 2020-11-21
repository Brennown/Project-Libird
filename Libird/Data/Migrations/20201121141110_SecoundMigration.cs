using Microsoft.EntityFrameworkCore.Migrations;

namespace Libird.Data.Migrations
{
    public partial class SecoundMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book_Account",
                table: "Book_Account");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "Fk_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                newName: "IX_Books_Fk_AuthorId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Book_Account",
                newName: "Fk_BookId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Book_Account",
                newName: "Fk_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Account_BookId",
                table: "Book_Account",
                newName: "IX_Book_Account_Fk_BookId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Accounts",
                newName: "Fk_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                newName: "IX_Accounts_Fk_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)");

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "Books",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(25)");

            migrationBuilder.AddColumn<int>(
                name: "BookAccountId",
                table: "Book_Account",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book_Account",
                table: "Book_Account",
                column: "BookAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Account_Fk_AccountId",
                table: "Book_Account",
                column: "Fk_AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book_Account",
                table: "Book_Account");

            migrationBuilder.DropIndex(
                name: "IX_Book_Account_Fk_AccountId",
                table: "Book_Account");

            migrationBuilder.DropColumn(
                name: "BookAccountId",
                table: "Book_Account");

            migrationBuilder.RenameColumn(
                name: "Fk_AuthorId",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Fk_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.RenameColumn(
                name: "Fk_BookId",
                table: "Book_Account",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Fk_AccountId",
                table: "Book_Account",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Account_Fk_BookId",
                table: "Book_Account",
                newName: "IX_Book_Account_BookId");

            migrationBuilder.RenameColumn(
                name: "Fk_UserId",
                table: "Accounts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_Fk_UserId",
                table: "Accounts",
                newName: "IX_Accounts_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "VARCHAR(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "Books",
                type: "VARCHAR(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book_Account",
                table: "Book_Account",
                columns: new[] { "AccountId", "BookId" });
        }
    }
}
