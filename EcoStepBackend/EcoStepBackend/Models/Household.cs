namespace EcoStepBackend;

public class Household
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public HouseType HouseType { get; set; }
    public HeatingType HeatingType { get; set; }
    public int ResidentCount { get; set; }
}
