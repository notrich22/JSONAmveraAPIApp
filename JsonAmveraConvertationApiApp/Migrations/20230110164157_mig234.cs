using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSONAmveraAPIApp.Migrations
{
    /// <inheritdoc />
    public partial class mig234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastUpdateTime",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Requests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateTime",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Requests");
        }
    }
}
