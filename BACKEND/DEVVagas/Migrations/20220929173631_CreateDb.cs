using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVVagas.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeUser = table.Column<int>(type: "int", nullable: false),
                    ProfileEnterprise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeUser = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    GitHubOrGitlabOrPortfolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seniority = table.Column<int>(type: "int", nullable: true),
                    Recruiter_TypeUser = table.Column<int>(type: "int", nullable: true),
                    Recruiter_ContactId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonModels_CompanyModels_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonModels_ContactModels_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonModels_ContactModels_Recruiter_ContactId",
                        column: x => x.Recruiter_ContactId,
                        principalTable: "ContactModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecruiter = table.Column<int>(type: "int", nullable: false),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Seniority = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remote = table.Column<bool>(type: "bit", nullable: false),
                    Presential = table.Column<bool>(type: "bit", nullable: false),
                    TypeContracts = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    RecruiterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyModels_CompanyModels_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VacancyModels_PersonModels_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "PersonModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidateVacancy",
                columns: table => new
                {
                    CandidatesId = table.Column<int>(type: "int", nullable: false),
                    VacanciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateVacancy", x => new { x.CandidatesId, x.VacanciesId });
                    table.ForeignKey(
                        name: "FK_CandidateVacancy_PersonModels_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "PersonModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateVacancy_VacancyModels_VacanciesId",
                        column: x => x.VacanciesId,
                        principalTable: "VacancyModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnologiesModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JavaScript = table.Column<bool>(type: "bit", nullable: false),
                    Python = table.Column<bool>(type: "bit", nullable: false),
                    Java = table.Column<bool>(type: "bit", nullable: false),
                    PHP = table.Column<bool>(type: "bit", nullable: false),
                    CSharp = table.Column<bool>(type: "bit", nullable: false),
                    CMaisMais = table.Column<bool>(type: "bit", nullable: false),
                    TypeScript = table.Column<bool>(type: "bit", nullable: false),
                    Ruby = table.Column<bool>(type: "bit", nullable: false),
                    C = table.Column<bool>(type: "bit", nullable: false),
                    Swift = table.Column<bool>(type: "bit", nullable: false),
                    R = table.Column<bool>(type: "bit", nullable: false),
                    ObjectiveC = table.Column<bool>(type: "bit", nullable: false),
                    Scala = table.Column<bool>(type: "bit", nullable: false),
                    Shell = table.Column<bool>(type: "bit", nullable: false),
                    Go = table.Column<bool>(type: "bit", nullable: false),
                    PowerShell = table.Column<bool>(type: "bit", nullable: false),
                    Kotlin = table.Column<bool>(type: "bit", nullable: false),
                    Rust = table.Column<bool>(type: "bit", nullable: false),
                    Dart = table.Column<bool>(type: "bit", nullable: false),
                    Angular = table.Column<bool>(type: "bit", nullable: false),
                    Vue = table.Column<bool>(type: "bit", nullable: false),
                    Emberjs = table.Column<bool>(type: "bit", nullable: false),
                    React = table.Column<bool>(type: "bit", nullable: false),
                    NodeJs = table.Column<bool>(type: "bit", nullable: false),
                    Express = table.Column<bool>(type: "bit", nullable: false),
                    AdonisJs = table.Column<bool>(type: "bit", nullable: false),
                    DOTNETFramework = table.Column<bool>(type: "bit", nullable: false),
                    DOTNETCore = table.Column<bool>(type: "bit", nullable: false),
                    ASPNET = table.Column<bool>(type: "bit", nullable: false),
                    ASPNETCore = table.Column<bool>(type: "bit", nullable: false),
                    Xamarim = table.Column<bool>(type: "bit", nullable: false),
                    EntityFramework = table.Column<bool>(type: "bit", nullable: false),
                    Dapper = table.Column<bool>(type: "bit", nullable: false),
                    ADONET = table.Column<bool>(type: "bit", nullable: false),
                    Bootstrap = table.Column<bool>(type: "bit", nullable: false),
                    UiKit = table.Column<bool>(type: "bit", nullable: false),
                    Laravel = table.Column<bool>(type: "bit", nullable: false),
                    CodeIgniter = table.Column<bool>(type: "bit", nullable: false),
                    Symfony = table.Column<bool>(type: "bit", nullable: false),
                    CakePHP = table.Column<bool>(type: "bit", nullable: false),
                    Spring = table.Column<bool>(type: "bit", nullable: false),
                    Django = table.Column<bool>(type: "bit", nullable: false),
                    RubyOnRails = table.Column<bool>(type: "bit", nullable: false),
                    Vuetify = table.Column<bool>(type: "bit", nullable: false),
                    Oracle = table.Column<bool>(type: "bit", nullable: false),
                    SQLServer = table.Column<bool>(type: "bit", nullable: false),
                    MySql = table.Column<bool>(type: "bit", nullable: false),
                    PostgreSQL = table.Column<bool>(type: "bit", nullable: false),
                    MongoDB = table.Column<bool>(type: "bit", nullable: false),
                    NoSQL = table.Column<bool>(type: "bit", nullable: false),
                    AWS = table.Column<bool>(type: "bit", nullable: false),
                    Azure = table.Column<bool>(type: "bit", nullable: false),
                    OracleCloud = table.Column<bool>(type: "bit", nullable: false),
                    GoogleCloud = table.Column<bool>(type: "bit", nullable: false),
                    IBMCloud = table.Column<bool>(type: "bit", nullable: false),
                    CloudStigma = table.Column<bool>(type: "bit", nullable: false),
                    Outros = table.Column<bool>(type: "bit", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: true),
                    VacancyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologiesModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnologiesModels_PersonModels_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "PersonModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnologiesModels_VacancyModels_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VacancyModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVacancy_VacanciesId",
                table: "CandidateVacancy",
                column: "VacanciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonModels_CompanyId",
                table: "PersonModels",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonModels_ContactId",
                table: "PersonModels",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonModels_Recruiter_ContactId",
                table: "PersonModels",
                column: "Recruiter_ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnologiesModels_CandidateId",
                table: "TechnologiesModels",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnologiesModels_VacancyId",
                table: "TechnologiesModels",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyModels_CompanyId",
                table: "VacancyModels",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyModels_RecruiterId",
                table: "VacancyModels",
                column: "RecruiterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateVacancy");

            migrationBuilder.DropTable(
                name: "TechnologiesModels");

            migrationBuilder.DropTable(
                name: "VacancyModels");

            migrationBuilder.DropTable(
                name: "PersonModels");

            migrationBuilder.DropTable(
                name: "CompanyModels");

            migrationBuilder.DropTable(
                name: "ContactModels");
        }
    }
}
