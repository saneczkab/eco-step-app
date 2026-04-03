namespace EcoStepBackend.Validators;

public class ResourceDataValidator : ISurveyDataValidator<ResourceData>
{
    public void Validate(User user, ResourceData data, double days)
    {
        var waterConsumptionDay = data.WaterConsumptionL / days;
        if (waterConsumptionDay > 0)
            user.WaterCondition = SurveyValidationHelper
                .EvaluateCondition(waterConsumptionDay, ResourceData.WaterConsumptionMaxLDay);

        var electricityConsumptionDay = data.ElectricityConsumptionKWtH / days;
        if (electricityConsumptionDay > 0)
            user.ElectricityCondition = SurveyValidationHelper
                .EvaluateCondition(electricityConsumptionDay, ResourceData.ElectricityConsumptionMaxKWtHDay);
    }
}

