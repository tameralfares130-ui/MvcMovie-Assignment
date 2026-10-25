using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using MvcMovie.Data;

#nullable disable
namespace MvcMovie.Migrations;
[DbContext(typeof(MvcMovieContext))]
[Migration("20261025000002_AddMovieRating")]
public partial class AddMovieRating : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(name: "Rating", table: "Movie", type: "nvarchar(5)",
            maxLength: 5, nullable: true);
    }
    protected override void Down(MigrationBuilder migrationBuilder) =>
        migrationBuilder.DropColumn(name: "Rating", table: "Movie");
}
