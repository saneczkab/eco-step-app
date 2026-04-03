namespace EcoStepBackend;

public class TransportData
{
    public int Id { get; set; }

    public int SurveyId { get; set; }
    public double PublicTransportDistanceMiles { get; set; }
    public double AirplaneDistanceMiles { get; set; }
    public double TrainDistanceMiles { get; set; }

    public double CarDistanceMilesPetrol { get; set; }
    public double CarDistanceMilesDiesel { get; set; }
    public double CarDistanceMilesElectric { get; set; }
    public double CarDistanceMilesHybrid { get; set; }
    public double CarDistanceMilesHydrogen { get; set; }
    public double CarDistanceMilesMethane { get; set; }
    public double CarDistanceMilesPropane { get; set; }

    public const double CarDistancePetrolMaxMilesDay = 17.4;
    public const double CarDistanceDieselMaxMilesDay = 19.9;
    public const double CarDistanceElectricMaxMilesDay = 67.7;
    public const double CarDistanceHybridMaxMilesDay = 33.6;
    public const double CarDistanceHydrogenMaxMilesDay = 67.7;
    public const double CarDistanceMethaneMaxMilesDay = 26.1;
    public const double CarDistancePropaneMaxMilesDay = 26.1;
    public const double PublicTransportDistanceMaxMilesDay = 32.3;
    public const double AirplaneDistanceMaxMilesDay = 17.4;
    public const double TrainDistanceMaxMilesDay = 82.6;
}
