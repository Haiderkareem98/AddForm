using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobForm.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Username = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedById = table.Column<Guid>(type: "char(36)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true),
                    DeletedById = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: true),
                    OriginalFileName = table.Column<string>(type: "longtext", nullable: true),
                    FileExtension = table.Column<string>(type: "longtext", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UploadDirectory = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedById = table.Column<Guid>(type: "char(36)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true),
                    DeletedById = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaFiles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaFiles_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaFiles_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    SecondName = table.Column<string>(type: "longtext", nullable: true),
                    ThirdName = table.Column<string>(type: "longtext", nullable: true),
                    Fourth_Name = table.Column<string>(type: "longtext", nullable: true),
                    Surname = table.Column<string>(type: "longtext", nullable: true),
                    Phone = table.Column<string>(type: "longtext", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: false),
                    ScientificSpecialization = table.Column<string>(type: "longtext", nullable: true),
                    Conservation = table.Column<int>(type: "int", nullable: false),
                    BirthYaer = table.Column<string>(type: "longtext", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    IdentifieName = table.Column<string>(type: "longtext", nullable: true),
                    IdentifieWorkPlace = table.Column<string>(type: "longtext", nullable: true),
                    Sessions = table.Column<string>(type: "longtext", nullable: true),
                    WorkplacesExperience = table.Column<string>(type: "longtext", nullable: true),
                    Notes = table.Column<string>(type: "longtext", nullable: true),
                    IsFamiliesMartyrsAndWounded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MartyrStatus = table.Column<string>(type: "longtext", nullable: true),
                    MechnicalInformation = table.Column<string>(type: "longtext", nullable: true),
                    ProposedAddition = table.Column<string>(type: "longtext", nullable: true),
                    CommunityCovenant = table.Column<string>(type: "longtext", nullable: true),
                    DegreeOfConfrontation = table.Column<int>(type: "int", nullable: false),
                    InterviewPurpose = table.Column<int>(type: "int", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedById = table.Column<Guid>(type: "char(36)", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true),
                    DeletedById = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_MediaFiles_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Job_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Job_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CreatedById",
                table: "Job",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Job_DeletedById",
                table: "Job",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Job_MediaFileId",
                table: "Job",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ModifiedById",
                table: "Job",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_CreatedById",
                table: "MediaFiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_DeletedById",
                table: "MediaFiles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ModifiedById",
                table: "MediaFiles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedById",
                table: "Users",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
