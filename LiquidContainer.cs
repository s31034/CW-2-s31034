namespace Task1;

public class LiquidContainer : Container, IHazardNotifier
{
    private const double MaxFillPercentageDangerous = 0.5;
    private const double MaxFillPercentageSafe = 0.9;
    public bool IsDangerous { get; }

    public LiquidContainer(double emptyWeight, double maxLoadWeight, bool isDangerous)
        : base("L", emptyWeight, maxLoadWeight)
    {
        IsDangerous = isDangerous;
    }

    public override void LoadCargo(double weight)
    {
        double maxAllowedLoad = IsDangerous ? MaxLoadWeight * MaxFillPercentageDangerous : MaxLoadWeight * MaxFillPercentageSafe;
        if (CurrentLoadWeight + weight > maxAllowedLoad)
        {
            Notify("Próba przeładowania kontenera!");
            throw new OverfillException($"Przekroczono maksymalną dopuszczalną ładowność kontenera {SerialNumber}.");
        }
        base.LoadCargo(weight);
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine(IsDangerous ? "Ładunek niebezpieczny" : "Ładunek bezpieczny");
    }

    public void Notify(string message)
    {
        Console.WriteLine($"UWAGA! {SerialNumber} : {message}");
    }
}