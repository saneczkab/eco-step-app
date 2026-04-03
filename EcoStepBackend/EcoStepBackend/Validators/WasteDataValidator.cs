namespace EcoStepBackend.Validators;

public class WasteDataValidator : ISurveyDataValidator<WasteData>
{
    public void Validate(User user, WasteData data, double days)
    {
        var foodWasteOzDay = data.FoodWasteOz / days;
        if (foodWasteOzDay > 0)
            user.FoodWasteCondition = SurveyValidationHelper
                .EvaluateCondition(foodWasteOzDay, WasteData.FoodWasteMaxOzDay);

        var otherWasteOzDay = data.OtherWasteOz / days;
        if (otherWasteOzDay > 0)
            user.OtherWasteCondition = SurveyValidationHelper
                .EvaluateCondition(otherWasteOzDay, WasteData.OtherWasteMaxOzDay);

        var plasticWasteOzDay = data.PlasticWasteOz / days;
        if (plasticWasteOzDay > 0)
            user.PlasticWasteCondition = SurveyValidationHelper
                .EvaluateCondition(plasticWasteOzDay, WasteData.PlasticWasteMaxOzDay);

        var glassWasteOzDay = data.GlassWasteOz / days;
        if (glassWasteOzDay > 0)
            user.GlassWasteCondition = SurveyValidationHelper
                .EvaluateCondition(glassWasteOzDay, WasteData.GlassWasteMaxOzDay);

        var paperWasteOzDay = data.PaperWasteOz / days;
        if (paperWasteOzDay > 0)
            user.PaperWasteCondition = SurveyValidationHelper
                .EvaluateCondition(paperWasteOzDay, WasteData.PaperWasteMaxOzDay);

        var metalWasteOzDay = data.MetalWasteOz / days;
        if (metalWasteOzDay > 0)
            user.MetalWasteCondition = SurveyValidationHelper
                .EvaluateCondition(metalWasteOzDay, WasteData.MetalWasteMaxOzDay);

        ValidateRecycledWaste(user, data, days);
    }

    private static void ValidateRecycledWaste(User user, WasteData data, double days)
    {
        var plasticRecycledPercentDay = data.PlasticRecycledPercent / days;
        user.PlasticRecycledCondition = SurveyValidationHelper
            .EvaluateCondition(100 - plasticRecycledPercentDay, WasteData.PlasticRecycledPercentDayMin);

        var glassRecycledPercentDay = data.GlassRecycledPercent / days;
        user.GlassRecycledCondition = SurveyValidationHelper
            .EvaluateCondition(100 - glassRecycledPercentDay, WasteData.GlassRecycledPercentDayMin);

        var paperRecycledPercentDay = data.PaperRecycledPercent / days;
        user.PaperRecycledCondition = SurveyValidationHelper
            .EvaluateCondition(100 - paperRecycledPercentDay, WasteData.PaperRecycledPercentDayMin);

        var metalRecycledPercentDay = data.MetalRecycledPercent / days;
        user.MetalRecycledCondition = SurveyValidationHelper
            .EvaluateCondition(100 - metalRecycledPercentDay, WasteData.MetalRecycledPercentDayMin);
    }
}
