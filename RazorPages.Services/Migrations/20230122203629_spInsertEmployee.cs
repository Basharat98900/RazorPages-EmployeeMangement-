using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages.Services.Migrations
{
    public partial class spInsertEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = "Create proc spInsertEmployee\r\n@Name varchar(100),\r\n@Email varchar(100),\r\n@Department varchar(100),\r\n@PhotoPath varchar(100)\r\nas begin \r\n\tInsert into Employees(Name,Email,Department,PhotoPath)\r\n\tValues(@Name,@Email,@Department,@PhotoPath)\r\nEnd";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
