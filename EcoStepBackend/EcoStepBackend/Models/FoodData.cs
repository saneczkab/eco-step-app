namespace EcoStepBackend;

public class FoodData
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public double MeatEatenOz { get; set; }
    public double PlantEatenOz { get; set; }

    public const double MeatEatenMaxOzDay = 9.1;
    public const double PlantEatenMaxOzDay = 22.9;
}
