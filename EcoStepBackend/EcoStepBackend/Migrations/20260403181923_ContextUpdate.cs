using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoStepBackend.Migrations
{
    /// <inheritdoc />
    public partial class ContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlasticWasteKg",
                table: "WasteData",
                newName: "PlasticWasteOz");

            migrationBuilder.RenameColumn(
                name: "PaperWasteKg",
                table: "WasteData",
                newName: "PaperWasteOz");

            migrationBuilder.RenameColumn(
                name: "OtherWasteKg",
                table: "WasteData",
                newName: "OtherWasteOz");

            migrationBuilder.RenameColumn(
                name: "MetalWasteKg",
                table: "WasteData",
                newName: "MetalWasteOz");

            migrationBuilder.RenameColumn(
                name: "GlassWasteKg",
                table: "WasteData",
                newName: "GlassWasteOz");

            migrationBuilder.RenameColumn(
                name: "FoodWasteKg",
                table: "WasteData",
                newName: "FoodWasteOz");

            migrationBuilder.RenameColumn(
                name: "IsWaterOk",
                table: "User",
                newName: "WaterCondition");

            migrationBuilder.RenameColumn(
                name: "IsTrainOk",
                table: "User",
                newName: "TrainCondition");

            migrationBuilder.RenameColumn(
                name: "IsPublicTransportOk",
                table: "User",
                newName: "PublicTransportCondition");

            migrationBuilder.RenameColumn(
                name: "IsPlasticWasteOk",
                table: "User",
                newName: "PlasticWasteCondition");

            migrationBuilder.RenameColumn(
                name: "IsPlasticRecycledOk",
                table: "User",
                newName: "PlasticRecycledCondition");

            migrationBuilder.RenameColumn(
                name: "IsPaperWasteOk",
                table: "User",
                newName: "PaperWasteCondition");

            migrationBuilder.RenameColumn(
                name: "IsPaperRecycledOk",
                table: "User",
                newName: "PaperRecycledCondition");

            migrationBuilder.RenameColumn(
                name: "IsOtherWasteOk",
                table: "User",
                newName: "OtherWasteCondition");

            migrationBuilder.RenameColumn(
                name: "IsMetalWasteOk",
                table: "User",
                newName: "MetalWasteCondition");

            migrationBuilder.RenameColumn(
                name: "IsMetalRecycledOk",
                table: "User",
                newName: "MetalRecycledCondition");

            migrationBuilder.RenameColumn(
                name: "IsGlassWasteOk",
                table: "User",
                newName: "GlassWasteCondition");

            migrationBuilder.RenameColumn(
                name: "IsGlassRecycledOk",
                table: "User",
                newName: "GlassRecycledCondition");

            migrationBuilder.RenameColumn(
                name: "IsFoodWasteOk",
                table: "User",
                newName: "FoodWasteCondition");

            migrationBuilder.RenameColumn(
                name: "IsFoodPlantOk",
                table: "User",
                newName: "FoodPlantCondition");

            migrationBuilder.RenameColumn(
                name: "IsFoodMeatOk",
                table: "User",
                newName: "FoodMeatCondition");

            migrationBuilder.RenameColumn(
                name: "IsElectricityOk",
                table: "User",
                newName: "ElectricityCondition");

            migrationBuilder.RenameColumn(
                name: "IsCarPropaneOk",
                table: "User",
                newName: "CarPropaneCondition");

            migrationBuilder.RenameColumn(
                name: "IsCarPetrolOk",
                table: "User",
                newName: "CarPetrolCondition");

            migrationBuilder.RenameColumn(
                name: "IsCarMethaneOk",
                table: "User",
                newName: "CarMethaneCondition");

            migrationBuilder.RenameColumn(
                name: "IsCarHydrogenOk",
                table: "User",
                newName: "CarHydrogenCondition");

            migrationBuilder.RenameColumn(
                name: "IsCarHybridOk",
                table: "User",
                newName: "CarHybridCondition");

            migrationBuilder.RenameColumn(
                name: "IsCarElectricOk",
                table: "User",
                newName: "CarElectricCondition");

            migrationBuilder.RenameColumn(
                name: "IsCarDieselOk",
                table: "User",
                newName: "CarDieselCondition");

            migrationBuilder.RenameColumn(
                name: "IsAirplaneOk",
                table: "User",
                newName: "AirplaneCondition");

            migrationBuilder.RenameColumn(
                name: "TrainDistanceKm",
                table: "TransportData",
                newName: "TrainDistanceMiles");

            migrationBuilder.RenameColumn(
                name: "PublicTransportDistanceKm",
                table: "TransportData",
                newName: "PublicTransportDistanceMiles");

            migrationBuilder.RenameColumn(
                name: "CarDistanceKmPropane",
                table: "TransportData",
                newName: "CarDistanceMilesPropane");

            migrationBuilder.RenameColumn(
                name: "CarDistanceKmPetrol",
                table: "TransportData",
                newName: "CarDistanceMilesPetrol");

            migrationBuilder.RenameColumn(
                name: "CarDistanceKmMethane",
                table: "TransportData",
                newName: "CarDistanceMilesMethane");

            migrationBuilder.RenameColumn(
                name: "CarDistanceKmHydrogen",
                table: "TransportData",
                newName: "CarDistanceMilesHydrogen");

            migrationBuilder.RenameColumn(
                name: "CarDistanceKmHybrid",
                table: "TransportData",
                newName: "CarDistanceMilesHybrid");

            migrationBuilder.RenameColumn(
                name: "CarDistanceKmElectric",
                table: "TransportData",
                newName: "CarDistanceMilesElectric");

            migrationBuilder.RenameColumn(
                name: "CarDistanceKmDiesel",
                table: "TransportData",
                newName: "CarDistanceMilesDiesel");

            migrationBuilder.RenameColumn(
                name: "AirplaneDistanceKm",
                table: "TransportData",
                newName: "AirplaneDistanceMiles");

            migrationBuilder.RenameColumn(
                name: "PlantEatenKg",
                table: "FoodData",
                newName: "PlantEatenOz");

            migrationBuilder.RenameColumn(
                name: "MeatEatenKg",
                table: "FoodData",
                newName: "MeatEatenOz");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlasticWasteOz",
                table: "WasteData",
                newName: "PlasticWasteKg");

            migrationBuilder.RenameColumn(
                name: "PaperWasteOz",
                table: "WasteData",
                newName: "PaperWasteKg");

            migrationBuilder.RenameColumn(
                name: "OtherWasteOz",
                table: "WasteData",
                newName: "OtherWasteKg");

            migrationBuilder.RenameColumn(
                name: "MetalWasteOz",
                table: "WasteData",
                newName: "MetalWasteKg");

            migrationBuilder.RenameColumn(
                name: "GlassWasteOz",
                table: "WasteData",
                newName: "GlassWasteKg");

            migrationBuilder.RenameColumn(
                name: "FoodWasteOz",
                table: "WasteData",
                newName: "FoodWasteKg");

            migrationBuilder.RenameColumn(
                name: "WaterCondition",
                table: "User",
                newName: "IsWaterOk");

            migrationBuilder.RenameColumn(
                name: "TrainCondition",
                table: "User",
                newName: "IsTrainOk");

            migrationBuilder.RenameColumn(
                name: "PublicTransportCondition",
                table: "User",
                newName: "IsPublicTransportOk");

            migrationBuilder.RenameColumn(
                name: "PlasticWasteCondition",
                table: "User",
                newName: "IsPlasticWasteOk");

            migrationBuilder.RenameColumn(
                name: "PlasticRecycledCondition",
                table: "User",
                newName: "IsPlasticRecycledOk");

            migrationBuilder.RenameColumn(
                name: "PaperWasteCondition",
                table: "User",
                newName: "IsPaperWasteOk");

            migrationBuilder.RenameColumn(
                name: "PaperRecycledCondition",
                table: "User",
                newName: "IsPaperRecycledOk");

            migrationBuilder.RenameColumn(
                name: "OtherWasteCondition",
                table: "User",
                newName: "IsOtherWasteOk");

            migrationBuilder.RenameColumn(
                name: "MetalWasteCondition",
                table: "User",
                newName: "IsMetalWasteOk");

            migrationBuilder.RenameColumn(
                name: "MetalRecycledCondition",
                table: "User",
                newName: "IsMetalRecycledOk");

            migrationBuilder.RenameColumn(
                name: "GlassWasteCondition",
                table: "User",
                newName: "IsGlassWasteOk");

            migrationBuilder.RenameColumn(
                name: "GlassRecycledCondition",
                table: "User",
                newName: "IsGlassRecycledOk");

            migrationBuilder.RenameColumn(
                name: "FoodWasteCondition",
                table: "User",
                newName: "IsFoodWasteOk");

            migrationBuilder.RenameColumn(
                name: "FoodPlantCondition",
                table: "User",
                newName: "IsFoodPlantOk");

            migrationBuilder.RenameColumn(
                name: "FoodMeatCondition",
                table: "User",
                newName: "IsFoodMeatOk");

            migrationBuilder.RenameColumn(
                name: "ElectricityCondition",
                table: "User",
                newName: "IsElectricityOk");

            migrationBuilder.RenameColumn(
                name: "CarPropaneCondition",
                table: "User",
                newName: "IsCarPropaneOk");

            migrationBuilder.RenameColumn(
                name: "CarPetrolCondition",
                table: "User",
                newName: "IsCarPetrolOk");

            migrationBuilder.RenameColumn(
                name: "CarMethaneCondition",
                table: "User",
                newName: "IsCarMethaneOk");

            migrationBuilder.RenameColumn(
                name: "CarHydrogenCondition",
                table: "User",
                newName: "IsCarHydrogenOk");

            migrationBuilder.RenameColumn(
                name: "CarHybridCondition",
                table: "User",
                newName: "IsCarHybridOk");

            migrationBuilder.RenameColumn(
                name: "CarElectricCondition",
                table: "User",
                newName: "IsCarElectricOk");

            migrationBuilder.RenameColumn(
                name: "CarDieselCondition",
                table: "User",
                newName: "IsCarDieselOk");

            migrationBuilder.RenameColumn(
                name: "AirplaneCondition",
                table: "User",
                newName: "IsAirplaneOk");

            migrationBuilder.RenameColumn(
                name: "TrainDistanceMiles",
                table: "TransportData",
                newName: "TrainDistanceKm");

            migrationBuilder.RenameColumn(
                name: "PublicTransportDistanceMiles",
                table: "TransportData",
                newName: "PublicTransportDistanceKm");

            migrationBuilder.RenameColumn(
                name: "CarDistanceMilesPropane",
                table: "TransportData",
                newName: "CarDistanceKmPropane");

            migrationBuilder.RenameColumn(
                name: "CarDistanceMilesPetrol",
                table: "TransportData",
                newName: "CarDistanceKmPetrol");

            migrationBuilder.RenameColumn(
                name: "CarDistanceMilesMethane",
                table: "TransportData",
                newName: "CarDistanceKmMethane");

            migrationBuilder.RenameColumn(
                name: "CarDistanceMilesHydrogen",
                table: "TransportData",
                newName: "CarDistanceKmHydrogen");

            migrationBuilder.RenameColumn(
                name: "CarDistanceMilesHybrid",
                table: "TransportData",
                newName: "CarDistanceKmHybrid");

            migrationBuilder.RenameColumn(
                name: "CarDistanceMilesElectric",
                table: "TransportData",
                newName: "CarDistanceKmElectric");

            migrationBuilder.RenameColumn(
                name: "CarDistanceMilesDiesel",
                table: "TransportData",
                newName: "CarDistanceKmDiesel");

            migrationBuilder.RenameColumn(
                name: "AirplaneDistanceMiles",
                table: "TransportData",
                newName: "AirplaneDistanceKm");

            migrationBuilder.RenameColumn(
                name: "PlantEatenOz",
                table: "FoodData",
                newName: "PlantEatenKg");

            migrationBuilder.RenameColumn(
                name: "MeatEatenOz",
                table: "FoodData",
                newName: "MeatEatenKg");
        }
    }
}
