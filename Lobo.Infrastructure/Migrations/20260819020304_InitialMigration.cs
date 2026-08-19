using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lobo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    FULL_NAME = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    NATIONAL_ID = table.Column<string>(type: "VARCHAR", maxLength: 11, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    CONTACT_PHONE = table.Column<string>(type: "VARCHAR", maxLength: 11, nullable: false),
                    NEIGHBORHOOD = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    STATE = table.Column<string>(type: "VARCHAR", maxLength: 2, nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CUSTOMER_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROCESSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CUSTOMER_ID = table.Column<int>(type: "integer", nullable: false),
                    STATUS = table.Column<int>(type: "integer", nullable: false),
                    PROTOCOL_DATE = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    ACTION = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CHILD_PROCESS_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PROCESS_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TODOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PROCESS_ID = table.Column<int>(type: "integer", nullable: false),
                    TITLE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    COMPLETED = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TODO_PK", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "PROCESSES");

            migrationBuilder.DropTable(
                name: "TODOS");
        }
    }
}
