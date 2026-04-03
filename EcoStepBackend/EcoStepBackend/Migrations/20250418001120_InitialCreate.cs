using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoStepBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    IsFoodMeatOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFoodPlantOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWaterOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsElectricityOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarPetrolOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarDieselOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarElectricOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarHybridOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarHydrogenOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarMethaneOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCarPropaneOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPublicTransportOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsTrainOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAirplaneOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFoodWasteOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOtherWasteOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPlasticWasteOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGlassWasteOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPaperWasteOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMetalWasteOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPlasticRecycledOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGlassRecycledOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPaperRecycledOk = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMetalRecycledOk = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Household",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseType = table.Column<int>(type: "INTEGER", nullable: false),
                    HeatingType = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Household", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Household_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportedDays = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurveyId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeatEatenKg = table.Column<double>(type: "REAL", nullable: false),
                    PlantEatenKg = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodData_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurveyId = table.Column<int>(type: "INTEGER", nullable: false),
                    WaterConsumptionL = table.Column<double>(type: "REAL", nullable: false),
                    ElectricityConsumptionKWtH = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceData_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurveyId = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicTransportDistanceKm = table.Column<double>(type: "REAL", nullable: false),
                    AirplaneDistanceKm = table.Column<double>(type: "REAL", nullable: false),
                    TrainDistanceKm = table.Column<double>(type: "REAL", nullable: false),
                    CarDistanceKmPetrol = table.Column<double>(type: "REAL", nullable: false),
                    CarDistanceKmDiesel = table.Column<double>(type: "REAL", nullable: false),
                    CarDistanceKmElectric = table.Column<double>(type: "REAL", nullable: false),
                    CarDistanceKmHybrid = table.Column<double>(type: "REAL", nullable: false),
                    CarDistanceKmHydrogen = table.Column<double>(type: "REAL", nullable: false),
                    CarDistanceKmMethane = table.Column<double>(type: "REAL", nullable: false),
                    CarDistanceKmPropane = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportData_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WasteData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurveyId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodWasteKg = table.Column<double>(type: "REAL", nullable: false),
                    OtherWasteKg = table.Column<double>(type: "REAL", nullable: false),
                    PlasticWasteKg = table.Column<double>(type: "REAL", nullable: false),
                    GlassWasteKg = table.Column<double>(type: "REAL", nullable: false),
                    PaperWasteKg = table.Column<double>(type: "REAL", nullable: false),
                    MetalWasteKg = table.Column<double>(type: "REAL", nullable: false),
                    PlasticRecycledPercent = table.Column<double>(type: "REAL", nullable: false),
                    GlassRecycledPercent = table.Column<double>(type: "REAL", nullable: false),
                    PaperRecycledPercent = table.Column<double>(type: "REAL", nullable: false),
                    MetalRecycledPercent = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteData_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodData_SurveyId",
                table: "FoodData",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Household_UserId",
                table: "Household",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceData_SurveyId",
                table: "ResourceData",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Survey_UserId",
                table: "Survey",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportData_SurveyId",
                table: "TransportData",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WasteData_SurveyId",
                table: "WasteData",
                column: "SurveyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodData");

            migrationBuilder.DropTable(
                name: "Household");

            migrationBuilder.DropTable(
                name: "ResourceData");

            migrationBuilder.DropTable(
                name: "TransportData");

            migrationBuilder.DropTable(
                name: "WasteData");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
