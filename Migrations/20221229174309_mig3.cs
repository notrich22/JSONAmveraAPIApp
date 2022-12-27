using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSONAmveraAPIApp.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HostName",
                table: "KnownHosts",
                newName: "UserAgent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAgent",
                table: "KnownHosts",
                newName: "HostName");
        }
    }
}
