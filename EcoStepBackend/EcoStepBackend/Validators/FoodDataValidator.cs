namespace EcoStepBackend.Validators;

public class FoodDataValidator : ISurveyDataValidator<FoodData>
{
    public void Validate(User user, FoodData data, double days)
    {
        var meatEatenOzDay = data.MeatEatenOz / days;
        if (meatEatenOzDay > 0)
            user.FoodMeatCondition = SurveyValidationHelper
                .EvaluateCondition(meatEatenOzDay, FoodData.MeatEatenMaxOzDay);

        var plantEatenOzDay = data.PlantEatenOz / days;
        if (plantEatenOzDay > 0)
            user.FoodPlantCondition = SurveyValidationHelper
                .EvaluateCondition(plantEatenOzDay, FoodData.PlantEatenMaxOzDay);
    }
}
