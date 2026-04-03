namespace EcoStepBackend.Validators;

public class TransportDataValidator : ISurveyDataValidator<TransportData>
{
    public void Validate(User user, TransportData data, double days)
    {
        var carPetrolMilesDay = data.CarDistanceMilesPetrol / days;
        if (carPetrolMilesDay > 0)
            user.CarPetrolCondition = SurveyValidationHelper
                .EvaluateCondition(carPetrolMilesDay, TransportData.CarDistancePetrolMaxMilesDay);

        var carDieselMilesDay = data.CarDistanceMilesDiesel / days;
        if (carDieselMilesDay > 0)
            user.CarDieselCondition = SurveyValidationHelper
                .EvaluateCondition(carDieselMilesDay, TransportData.CarDistanceDieselMaxMilesDay);

        var carElectricMilesDay = data.CarDistanceMilesElectric / days;
        if (carElectricMilesDay > 0)
            user.CarElectricCondition = SurveyValidationHelper
                .EvaluateCondition(carElectricMilesDay, TransportData.CarDistanceElectricMaxMilesDay);

        var carHybridMilesDay = data.CarDistanceMilesHybrid / days;
        if (carHybridMilesDay > 0)
            user.CarHybridCondition = SurveyValidationHelper
                .EvaluateCondition(carHybridMilesDay, TransportData.CarDistanceHybridMaxMilesDay);

        var carHydrogenMilesDay = data.CarDistanceMilesHydrogen / days;
        if (carHydrogenMilesDay > 0)
            user.CarHydrogenCondition = SurveyValidationHelper
                .EvaluateCondition(carHydrogenMilesDay, TransportData.CarDistanceHydrogenMaxMilesDay);

        var carMethaneMilesDay = data.CarDistanceMilesMethane / days;
        if (carMethaneMilesDay > 0)
            user.CarMethaneCondition = SurveyValidationHelper
                .EvaluateCondition(carMethaneMilesDay, TransportData.CarDistanceMethaneMaxMilesDay);

        var carPropaneMilesDay = data.CarDistanceMilesPropane / days;
        if (carPropaneMilesDay > 0)
            user.CarPropaneCondition = SurveyValidationHelper
                .EvaluateCondition(carPropaneMilesDay, TransportData.CarDistancePropaneMaxMilesDay);

        ValidatePublicTransport(user, data, days);
    }

    private static void ValidatePublicTransport(User user, TransportData data, double days)
    {
        var publicTransportMilesDay = data.PublicTransportDistanceMiles / days;
        if (publicTransportMilesDay > 0)
            user.PublicTransportCondition = SurveyValidationHelper
                .EvaluateCondition(publicTransportMilesDay, TransportData.PublicTransportDistanceMaxMilesDay);

        var trainMilesDay = data.TrainDistanceMiles / days;
        if (trainMilesDay > 0)
            user.TrainCondition = SurveyValidationHelper
                .EvaluateCondition(trainMilesDay, TransportData.TrainDistanceMaxMilesDay);

        var airplaneMilesDay = data.AirplaneDistanceMiles / days;
        if (airplaneMilesDay > 0)
            user.AirplaneCondition = SurveyValidationHelper
                .EvaluateCondition(airplaneMilesDay, TransportData.AirplaneDistanceMaxMilesDay);
    }
}
