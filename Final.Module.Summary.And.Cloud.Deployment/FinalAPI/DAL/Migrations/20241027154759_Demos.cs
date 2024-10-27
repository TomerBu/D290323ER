using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Demos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3e065edb-0781-4626-8557-a0cefe64251c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8da57e76-47cf-4d38-be37-96d19eb042d7", "AQAAAAIAAYagAAAAENPJXy8nAmiaEjFewxxwEsOWv9V9BxibD8yctnjdgAGHuw/KsjXkFYohKG8WQTpEPw==", "e443a1a2-cfd2-4992-8d38-2635fa3f0a2d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fc4920df-235c-4cb1-88ce-d715c19f7e5d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02c0bfb4-92aa-48e1-8f8d-033dda8493a6", "AQAAAAIAAYagAAAAEFgwoitGr1A+kfQWiHS1v5n2FZlUy18/yakPxwleqI8HANdZ8APUdA5H+TfgpGow4A==", "2a97f33e-c7a2-45d5-91a3-c2c5f371aabe" });
        }
    }
}
