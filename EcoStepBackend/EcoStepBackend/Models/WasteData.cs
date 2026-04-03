namespace EcoStepBackend;

public class WasteData
{
    public int Id { get; set; }
    public int SurveyId { get; set; }

    public double FoodWasteOz { get; set; }
    public double OtherWasteOz { get; set; }

    public double PlasticWasteOz { get; set; }
    public double GlassWasteOz { get; set; }
    public double PaperWasteOz { get; set; }
    public double MetalWasteOz { get; set; }

    public double PlasticRecycledPercent { get; set; }
    public double GlassRecycledPercent { get; set; }
    public double PaperRecycledPercent { get; set; }
    public double MetalRecycledPercent { get; set; }

    public const double FoodWasteMaxOzDay = 10.58;
    public const double OtherWasteMaxOzDay = 7.05;
    public const double PlasticWasteMaxOzDay = 3.53;
    public const double GlassWasteMaxOzDay = 1.76;
    public const double PaperWasteMaxOzDay = 1.76;
    public const double MetalWasteMaxOzDay = 1.76;

    public const double PlasticRecycledPercentDayMin = 0.8;
    public const double GlassRecycledPercentDayMin = 0.8;
    public const double PaperRecycledPercentDayMin = 0.8;
    public const double MetalRecycledPercentDayMin = 0.8;
}
