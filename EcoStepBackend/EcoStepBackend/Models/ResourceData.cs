namespace EcoStepBackend;

public class ResourceData
{
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public double WaterConsumptionL { get; set; }
    public double ElectricityConsumptionKWtH { get; set; }

    public const double WaterConsumptionMaxLDay = 140;
    public const double ElectricityConsumptionMaxKWtHDay = 10;
}
