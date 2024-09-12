using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class EstruturaDePrCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvocesProducts_Invoices_InvoiceId",
                table: "InvocesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InvocesProducts_Products_ProductId",
                table: "InvocesProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvocesProducts",
                table: "InvocesProducts");

            migrationBuilder.RenameTable(
                name: "InvocesProducts",
                newName: "InvoicesProducts");

            migrationBuilder.RenameIndex(
                name: "IX_InvocesProducts_ProductId",
                table: "InvoicesProducts",
                newName: "IX_InvoicesProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvocesProducts_InvoiceId",
                table: "InvoicesProducts",
                newName: "IX_InvoicesProducts_InvoiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicesProducts",
                table: "InvoicesProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesProducts_Invoices_InvoiceId",
                table: "InvoicesProducts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesProducts_Products_ProductId",
                table: "InvoicesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesProducts_Invoices_InvoiceId",
                table: "InvoicesProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesProducts_Products_ProductId",
                table: "InvoicesProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicesProducts",
                table: "InvoicesProducts");

            migrationBuilder.RenameTable(
                name: "InvoicesProducts",
                newName: "InvocesProducts");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesProducts_ProductId",
                table: "InvocesProducts",
                newName: "IX_InvocesProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesProducts_InvoiceId",
                table: "InvocesProducts",
                newName: "IX_InvocesProducts_InvoiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvocesProducts",
                table: "InvocesProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvocesProducts_Invoices_InvoiceId",
                table: "InvocesProducts",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvocesProducts_Products_ProductId",
                table: "InvocesProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
