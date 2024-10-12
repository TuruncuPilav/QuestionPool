using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Member_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Surname = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Gender = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Member___3214EC07E72715B9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_QuestionType_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Questio__3214EC0743B8C0C0", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Library_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Category = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Library__3214EC075A9DE112", x => x.Id);
                    table.ForeignKey(
                        name: "FK___Library___Membe__4316F928",
                        column: x => x.MemberId,
                        principalTable: "_Member_",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_MemberSecurity_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___MemberS__3214EC07C9F16973", x => x.Id);
                    table.ForeignKey(
                        name: "FK___MemberSe__Membe__398D8EEE",
                        column: x => x.MemberId,
                        principalTable: "_Member_",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_MemberSettings_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    LastEditedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Role = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, defaultValue: "student"),
                    Language = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, defaultValue: "tr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___MemberS__3214EC072B548DCF", x => x.Id);
                    table.ForeignKey(
                        name: "FK___MemberSe__Membe__3C69FB99",
                        column: x => x.MemberId,
                        principalTable: "_Member_",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_LibraryMembers_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, defaultValue: "Student"),
                    AddedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Library__3214EC07E9134980", x => x.Id);
                    table.ForeignKey(
                        name: "FK___LibraryM__Libra__4F7CD00D",
                        column: x => x.LibraryId,
                        principalTable: "_Library_",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK___LibraryM__Membe__5070F446",
                        column: x => x.MemberId,
                        principalTable: "_Member_",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_LibrarySettings_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryId = table.Column<int>(type: "int", nullable: true),
                    Visibility = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    LastEditedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Library__3214EC07E775123C", x => x.Id);
                    table.ForeignKey(
                        name: "FK___LibraryS__Libra__45F365D3",
                        column: x => x.LibraryId,
                        principalTable: "_Library_",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_Question_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    LibraryId = table.Column<int>(type: "int", nullable: true),
                    QuestionType = table.Column<int>(type: "int", nullable: true),
                    Question = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    TrueAnswer = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FalseAnswer2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FalseAnswer3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FalseAnswer4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FalseAnswer5 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    QuestionImg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Questio__3214EC0784C711DD", x => x.Id);
                    table.ForeignKey(
                        name: "FK___Question__Libra__5629CD9C",
                        column: x => x.LibraryId,
                        principalTable: "_Library_",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK___Question__Membe__5535A963",
                        column: x => x.MemberId,
                        principalTable: "_Member_",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK___Question__Quest__571DF1D5",
                        column: x => x.QuestionType,
                        principalTable: "_QuestionType_",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "_QuestionSettings_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    LastEditedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Questio__3214EC07EE5BF4AB", x => x.Id);
                    table.ForeignKey(
                        name: "FK___Question__Quest__59FA5E80",
                        column: x => x.QuestionId,
                        principalTable: "_Question_",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX__Library__MemberId",
                table: "_Library_",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX__LibraryMembers__LibraryId",
                table: "_LibraryMembers_",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX__LibraryMembers__MemberId",
                table: "_LibraryMembers_",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX__LibrarySettings__LibraryId",
                table: "_LibrarySettings_",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX__MemberSecurity__MemberId",
                table: "_MemberSecurity_",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX__MemberSettings__MemberId",
                table: "_MemberSettings_",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX__Question__LibraryId",
                table: "_Question_",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX__Question__MemberId",
                table: "_Question_",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX__Question__QuestionType",
                table: "_Question_",
                column: "QuestionType");

            migrationBuilder.CreateIndex(
                name: "IX__QuestionSettings__QuestionId",
                table: "_QuestionSettings_",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_LibraryMembers_");

            migrationBuilder.DropTable(
                name: "_LibrarySettings_");

            migrationBuilder.DropTable(
                name: "_MemberSecurity_");

            migrationBuilder.DropTable(
                name: "_MemberSettings_");

            migrationBuilder.DropTable(
                name: "_QuestionSettings_");

            migrationBuilder.DropTable(
                name: "_Question_");

            migrationBuilder.DropTable(
                name: "_Library_");

            migrationBuilder.DropTable(
                name: "_QuestionType_");

            migrationBuilder.DropTable(
                name: "_Member_");
        }
    }
}
