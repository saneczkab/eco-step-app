namespace EcoStepBackend.Validators;

public static class SurveyValidationHelper
{
    public static Condition EvaluateCondition(double value, double dailyNorm)
    {
        if (value < dailyNorm)
            return Condition.Good;
        if (value < dailyNorm * 1.1)
            return Condition.Ok;
        return Condition.Bad;
    }
}
