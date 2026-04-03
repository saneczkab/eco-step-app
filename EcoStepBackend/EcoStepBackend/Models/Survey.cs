namespace EcoStepBackend;

public class Survey
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CompletedAt { get; set; }
    public required FoodData FoodData { get; set; } = new();
    public required WasteData WasteData { get; set; } = new();
    public required TransportData TransportData { get; set; } = new();
    public required ResourceData ResourceData { get; set; } = new();
    public double ReportedDays { get; set; } = new();
}
