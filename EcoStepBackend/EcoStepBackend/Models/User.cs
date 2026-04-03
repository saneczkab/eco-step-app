namespace EcoStepBackend;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public required string PasswordHash { get; set; }
    public Household? Household { get; set; }
    public ICollection<Survey> Surveys { get; set; } = new List<Survey>();

    public Condition FoodMeatCondition { get; set; }
    public Condition FoodPlantCondition { get; set; }
    public Condition WaterCondition { get; set; }
    public Condition ElectricityCondition { get; set; }

    public Condition CarPetrolCondition { get; set; }
    public Condition CarDieselCondition { get; set; }
    public Condition CarElectricCondition { get; set; }
    public Condition CarHybridCondition { get; set; }
    public Condition CarHydrogenCondition { get; set; }
    public Condition CarMethaneCondition { get; set; }
    public Condition CarPropaneCondition { get; set; }

    public Condition PublicTransportCondition { get; set; }
    public Condition TrainCondition { get; set; }
    public Condition AirplaneCondition { get; set; }

    public Condition FoodWasteCondition { get; set; }
    public Condition OtherWasteCondition { get; set; }

    public Condition PlasticWasteCondition { get; set; }
    public Condition GlassWasteCondition { get; set; }
    public Condition PaperWasteCondition { get; set; }
    public Condition MetalWasteCondition { get; set; }

    public Condition PlasticRecycledCondition { get; set; }
    public Condition GlassRecycledCondition { get; set; }
    public Condition PaperRecycledCondition { get; set; }
    public Condition MetalRecycledCondition { get; set; }
}
