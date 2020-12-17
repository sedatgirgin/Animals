using Microsoft.EntityFrameworkCore.Migrations;

namespace Animals.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccine_Animal_AnimalId",
                table: "AnimalVaccine");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccine_Vaccine_VaccineId",
                table: "AnimalVaccine");

            migrationBuilder.DropIndex(
                name: "IX_AnimalVaccine_AnimalId",
                table: "AnimalVaccine");

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "AnimalVaccine",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "AnimalVaccine",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalVaccine_AnimalId_VaccineId",
                table: "AnimalVaccine",
                columns: new[] { "AnimalId", "VaccineId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVaccine_Animal_AnimalId",
                table: "AnimalVaccine",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVaccine_Vaccine_VaccineId",
                table: "AnimalVaccine",
                column: "VaccineId",
                principalTable: "Vaccine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccine_Animal_AnimalId",
                table: "AnimalVaccine");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccine_Vaccine_VaccineId",
                table: "AnimalVaccine");

            migrationBuilder.DropIndex(
                name: "IX_AnimalVaccine_AnimalId_VaccineId",
                table: "AnimalVaccine");

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "AnimalVaccine",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "AnimalVaccine",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalVaccine_AnimalId",
                table: "AnimalVaccine",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVaccine_Animal_AnimalId",
                table: "AnimalVaccine",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVaccine_Vaccine_VaccineId",
                table: "AnimalVaccine",
                column: "VaccineId",
                principalTable: "Vaccine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
