using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITITaskMVC.DAL.Migrations
{
	public partial class intital : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Instructors",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Specialization = table.Column<int>(type: "int", nullable: false),
					IsActive = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Instructors", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Courses",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					Category = table.Column<int>(type: "int", nullable: false),
					startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsActive = table.Column<bool>(type: "bit", nullable: false),
					InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Courses", x => x.Id);
					table.ForeignKey(
						name: "FK_Courses_Instructors_InstructorId",
						column: x => x.InstructorId,
						principalTable: "Instructors",
						principalColumn: "Id");
				});

			migrationBuilder.InsertData(
				table: "Instructors",
				columns: new[] { "Id", "Bio", "FirstName", "IsActive", "LastName", "Specialization" },
				values: new object[,]
				{
					{ new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Business Analyst", "Sara", true, "Smith", 2 },
					{ new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Expert in C# and ASP.NET", "John", true, "Doe", 0 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Courses_InstructorId",
				table: "Courses",
				column: "InstructorId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Courses");

			migrationBuilder.DropTable(
				name: "Instructors");
		}
	}
}
