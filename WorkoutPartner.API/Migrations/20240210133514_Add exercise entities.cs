using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPartner.API.Migrations
{
    /// <inheritdoc />
    public partial class Addexerciseentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightUnit",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlanSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlanSchema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlanSchema_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRecord_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSchema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Schema = table.Column<string>(type: "TEXT", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSchema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseSchema_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSchema_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseSchemaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FilledSchema = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseRecord_ExerciseSchema_ExerciseSchemaId",
                        column: x => x.ExerciseSchemaId,
                        principalTable: "ExerciseSchema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSchemaWorkoutPlanSchema",
                columns: table => new
                {
                    ExerciseSchemaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkoutPlanSchemaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSchemaWorkoutPlanSchema", x => new { x.ExerciseSchemaId, x.WorkoutPlanSchemaId });
                    table.ForeignKey(
                        name: "FK_ExerciseSchemaWorkoutPlanSchema_ExerciseSchema_ExerciseSchemaId",
                        column: x => x.ExerciseSchemaId,
                        principalTable: "ExerciseSchema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSchemaWorkoutPlanSchema_WorkoutPlanSchema_WorkoutPlanSchemaId",
                        column: x => x.WorkoutPlanSchemaId,
                        principalTable: "WorkoutPlanSchema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseRecordWorkoutRecord",
                columns: table => new
                {
                    ExerciseRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkoutRecordId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRecordWorkoutRecord", x => new { x.ExerciseRecordId, x.WorkoutRecordId });
                    table.ForeignKey(
                        name: "FK_ExerciseRecordWorkoutRecord_ExerciseRecord_ExerciseRecordId",
                        column: x => x.ExerciseRecordId,
                        principalTable: "ExerciseRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseRecordWorkoutRecord_WorkoutRecord_WorkoutRecordId",
                        column: x => x.WorkoutRecordId,
                        principalTable: "WorkoutRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_EquipmentId",
                table: "Exercise",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRecord_ExerciseSchemaId",
                table: "ExerciseRecord",
                column: "ExerciseSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRecordWorkoutRecord_WorkoutRecordId",
                table: "ExerciseRecordWorkoutRecord",
                column: "WorkoutRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSchema_ExerciseId",
                table: "ExerciseSchema",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSchema_UserId",
                table: "ExerciseSchema",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSchemaWorkoutPlanSchema_WorkoutPlanSchemaId",
                table: "ExerciseSchemaWorkoutPlanSchema",
                column: "WorkoutPlanSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanSchema_UserId",
                table: "WorkoutPlanSchema",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecord_UserId",
                table: "WorkoutRecord",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseRecordWorkoutRecord");

            migrationBuilder.DropTable(
                name: "ExerciseSchemaWorkoutPlanSchema");

            migrationBuilder.DropTable(
                name: "ExerciseRecord");

            migrationBuilder.DropTable(
                name: "WorkoutRecord");

            migrationBuilder.DropTable(
                name: "WorkoutPlanSchema");

            migrationBuilder.DropTable(
                name: "ExerciseSchema");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WeightUnit",
                table: "AspNetUsers");
        }
    }
}
