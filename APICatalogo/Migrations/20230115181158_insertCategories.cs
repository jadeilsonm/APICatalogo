﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class insertCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories(Name, ImageUrl) Values('Bebidas','bebidas.jpg')");
            migrationBuilder.Sql("Insert into Categories(Name, ImageUrl) Values('Lanches','lanches.jpg')");
            migrationBuilder.Sql("Insert into Categories(Name, ImageUrl) Values('Sobremesas','sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
