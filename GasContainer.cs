namespace Task1;

public class GasContainer : Container, IHazardNotifier
{
    private const double MaxFillPercentage = 0.05;
    public double Pressure { get; }

    public GasContainer(double emptyWeight, double maxLoadWeight, double pressure, double heigth, double depth)
        : base("G", emptyWeight, maxLoadWeight, heigth, depth)
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double weight)
    {
        
        if (CurrentLoadWeight + weight > MaxLoadWeight)
        {
            Notify("Próba przeładowania kontenera!");
            throw new OverfillException($"Przekroczono dozwoloną pojemność kontenera {SerialNumber} (max 5% ładowności)");
        }
        base.LoadCargo(weight);
    }

    public override void UnloadCargo()
    {
        CurrentLoadWeight *= 0.05;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"UWAGA! {SerialNumber} : {message}");
    }
}