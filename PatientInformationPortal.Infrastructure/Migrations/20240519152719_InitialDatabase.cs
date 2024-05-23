using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientInformationPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DiseaseId = table.Column<long>(type: "bigint", nullable: false),
                    Epilepsy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllergiesDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    AllergiesId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergiesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllergiesDetails_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllergiesDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NCDDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    NCDId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCDDetails_Diseases_NCDId",
                        column: x => x.NCDId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NCDDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8567), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Drugs - Penicillins" },
                    { 2L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8623), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Drugs - Others" },
                    { 3L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8626), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Animals" },
                    { 4L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8628), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Foods" },
                    { 5L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8630), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Ointments" },
                    { 6L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8633), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Plant" },
                    { 7L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8634), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Spray" },
                    { 8L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8636), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Others" },
                    { 9L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 446, DateTimeKind.Unspecified).AddTicks(8638), new TimeSpan(0, 6, 0, 0, 0)), null, null, "No Allergies" }
                });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 447, DateTimeKind.Unspecified).AddTicks(1044), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Asthma" },
                    { 2L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 447, DateTimeKind.Unspecified).AddTicks(1064), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Cancer" },
                    { 3L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 447, DateTimeKind.Unspecified).AddTicks(1066), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Disorders of ear" },
                    { 4L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 447, DateTimeKind.Unspecified).AddTicks(1068), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Disorders of eye" },
                    { 5L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 447, DateTimeKind.Unspecified).AddTicks(1070), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Mental Illness" },
                    { 6L, 1L, new DateTimeOffset(new DateTime(2024, 5, 19, 21, 27, 17, 447, DateTimeKind.Unspecified).AddTicks(1072), new TimeSpan(0, 6, 0, 0, 0)), null, null, "Oral Health problems" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_AllergiesId",
                table: "AllergiesDetails",
                column: "AllergiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_PatientId",
                table: "AllergiesDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_NCDId",
                table: "NCDDetails",
                column: "NCDId");

            migrationBuilder.CreateIndex(
                name: "IX_NCDDetails_PatientId",
                table: "NCDDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseaseId",
                table: "Patients",
                column: "DiseaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergiesDetails");

            migrationBuilder.DropTable(
                name: "NCDDetails");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Diseases");
        }
    }
}
