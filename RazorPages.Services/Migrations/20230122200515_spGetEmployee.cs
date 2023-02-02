using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages.Services.Migrations
{
    public partial class spGetEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SPgetEmployee = "Create Proc spGetEmployeeById @Id int as Begin Select * from Employees Where Id=@Id End";
            migrationBuilder.Sql(SPgetEmployee);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //string procedure = @"Drop procedure spGetEmployeeById";
            //migrationBuilder.Sql(procedure);
        }
    }
}
