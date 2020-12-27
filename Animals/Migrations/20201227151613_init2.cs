using Microsoft.EntityFrameworkCore.Migrations;

namespace Animals.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_AnimalSpecies_SubSpeciesId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_AspNetUsers_UserId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalSpecies_Species_SpeciesIId",
                table: "AnimalSpecies");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccine_Animal_AnimalId",
                table: "AnimalVaccine");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccine_Vaccine_VaccineId",
                table: "AnimalVaccine");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_Animal_AnimalId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminder_ReminderType_ReminderTypeId",
                table: "Reminder");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccine_Species_SpeciesId",
                table: "Vaccine");

            migrationBuilder.DropForeignKey(
                name: "FK_Weight_Animal_AnimalId",
                table: "Weight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weight",
                table: "Weight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccine",
                table: "Vaccine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReminderType",
                table: "ReminderType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminder",
                table: "Reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalVaccine",
                table: "AnimalVaccine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalSpecies",
                table: "AnimalSpecies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animal",
                table: "Animal");

            migrationBuilder.RenameTable(
                name: "Weight",
                newName: "Weights");

            migrationBuilder.RenameTable(
                name: "Vaccine",
                newName: "Vaccines");

            migrationBuilder.RenameTable(
                name: "ReminderType",
                newName: "ReminderTypes");

            migrationBuilder.RenameTable(
                name: "Reminder",
                newName: "Reminders");

            migrationBuilder.RenameTable(
                name: "AnimalVaccine",
                newName: "AnimalVaccines");

            migrationBuilder.RenameTable(
                name: "AnimalSpecies",
                newName: "SubSpecies");

            migrationBuilder.RenameTable(
                name: "Animal",
                newName: "Animals");

            migrationBuilder.RenameIndex(
                name: "IX_Weight_AnimalId",
                table: "Weights",
                newName: "IX_Weights_AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccine_SpeciesId",
                table: "Vaccines",
                newName: "IX_Vaccines_SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_ReminderTypeId",
                table: "Reminders",
                newName: "IX_Reminders_ReminderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminder_AnimalId",
                table: "Reminders",
                newName: "IX_Reminders_AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalVaccine_VaccineId",
                table: "AnimalVaccines",
                newName: "IX_AnimalVaccines_VaccineId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalVaccine_AnimalId_VaccineId",
                table: "AnimalVaccines",
                newName: "IX_AnimalVaccines_AnimalId_VaccineId");

            migrationBuilder.RenameColumn(
                name: "SpeciesIId",
                table: "SubSpecies",
                newName: "SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalSpecies_SpeciesIId",
                table: "SubSpecies",
                newName: "IX_SubSpecies_SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_UserId",
                table: "Animals",
                newName: "IX_Animals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_SubSpeciesId",
                table: "Animals",
                newName: "IX_Animals_SubSpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weights",
                table: "Weights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccines",
                table: "Vaccines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReminderTypes",
                table: "ReminderTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalVaccines",
                table: "AnimalVaccines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubSpecies",
                table: "SubSpecies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_UserId",
                table: "Animals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_SubSpecies_SubSpeciesId",
                table: "Animals",
                column: "SubSpeciesId",
                principalTable: "SubSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVaccines_Animals_AnimalId",
                table: "AnimalVaccines",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVaccines_Vaccines_VaccineId",
                table: "AnimalVaccines",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Animals_AnimalId",
                table: "Reminders",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_ReminderTypes_ReminderTypeId",
                table: "Reminders",
                column: "ReminderTypeId",
                principalTable: "ReminderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSpecies_Species_SpeciesId",
                table: "SubSpecies",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Species_SpeciesId",
                table: "Vaccines",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weights_Animals_AnimalId",
                table: "Weights",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AspNetUsers_UserId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_SubSpecies_SubSpeciesId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccines_Animals_AnimalId",
                table: "AnimalVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVaccines_Vaccines_VaccineId",
                table: "AnimalVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Animals_AnimalId",
                table: "Reminders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_ReminderTypes_ReminderTypeId",
                table: "Reminders");

            migrationBuilder.DropForeignKey(
                name: "FK_SubSpecies_Species_SpeciesId",
                table: "SubSpecies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Species_SpeciesId",
                table: "Vaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_Weights_Animals_AnimalId",
                table: "Weights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weights",
                table: "Weights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vaccines",
                table: "Vaccines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubSpecies",
                table: "SubSpecies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReminderTypes",
                table: "ReminderTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminders",
                table: "Reminders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalVaccines",
                table: "AnimalVaccines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Weights",
                newName: "Weight");

            migrationBuilder.RenameTable(
                name: "Vaccines",
                newName: "Vaccine");

            migrationBuilder.RenameTable(
                name: "SubSpecies",
                newName: "AnimalSpecies");

            migrationBuilder.RenameTable(
                name: "ReminderTypes",
                newName: "ReminderType");

            migrationBuilder.RenameTable(
                name: "Reminders",
                newName: "Reminder");

            migrationBuilder.RenameTable(
                name: "AnimalVaccines",
                newName: "AnimalVaccine");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "Animal");

            migrationBuilder.RenameIndex(
                name: "IX_Weights_AnimalId",
                table: "Weight",
                newName: "IX_Weight_AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccines_SpeciesId",
                table: "Vaccine",
                newName: "IX_Vaccine_SpeciesId");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "AnimalSpecies",
                newName: "SpeciesIId");

            migrationBuilder.RenameIndex(
                name: "IX_SubSpecies_SpeciesId",
                table: "AnimalSpecies",
                newName: "IX_AnimalSpecies_SpeciesIId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminders_ReminderTypeId",
                table: "Reminder",
                newName: "IX_Reminder_ReminderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reminders_AnimalId",
                table: "Reminder",
                newName: "IX_Reminder_AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalVaccines_VaccineId",
                table: "AnimalVaccine",
                newName: "IX_AnimalVaccine_VaccineId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalVaccines_AnimalId_VaccineId",
                table: "AnimalVaccine",
                newName: "IX_AnimalVaccine_AnimalId_VaccineId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_UserId",
                table: "Animal",
                newName: "IX_Animal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_SubSpeciesId",
                table: "Animal",
                newName: "IX_Animal_SubSpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weight",
                table: "Weight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vaccine",
                table: "Vaccine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalSpecies",
                table: "AnimalSpecies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReminderType",
                table: "ReminderType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminder",
                table: "Reminder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalVaccine",
                table: "AnimalVaccine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animal",
                table: "Animal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_AnimalSpecies_SubSpeciesId",
                table: "Animal",
                column: "SubSpeciesId",
                principalTable: "AnimalSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_AspNetUsers_UserId",
                table: "Animal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalSpecies_Species_SpeciesIId",
                table: "AnimalSpecies",
                column: "SpeciesIId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_Animal_AnimalId",
                table: "Reminder",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminder_ReminderType_ReminderTypeId",
                table: "Reminder",
                column: "ReminderTypeId",
                principalTable: "ReminderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccine_Species_SpeciesId",
                table: "Vaccine",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weight_Animal_AnimalId",
                table: "Weight",
                column: "AnimalId",
                principalTable: "Animal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
