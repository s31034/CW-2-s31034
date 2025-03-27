namespace Task1;

public abstract class Container
{
    public static int _counter = 0;
    
    public string SerialNumber { get;  set; }
    
    public double EmptyWeight { get;  set; }
    
    public double MaxLoadWeight { get;  set; }
    
    public double CurrentLoadWeight { get;  set; }
    
    public double Heigth {get; set; }
    
    public double Depth {get; set; }

    public Container(string prefix, double emptyWeight, double maxLoadWeight, double heigth ,double depth)
    {
        _counter++;
        SerialNumber = $"KON-{prefix}-{_counter}"; // ustawienia numeru seryjnego 
        EmptyWeight = emptyWeight;
        MaxLoadWeight = maxLoadWeight;
        CurrentLoadWeight = 0;
        Heigth = heigth;
        Depth = depth;
    }

    public virtual void LoadCargo(double weight)
    {
        if(CurrentLoadWeight + weight > MaxLoadWeight)
        {
            throw new OverflowException($"Przekroczono maksymalną pojemność kontenera {SerialNumber}");
        }
        CurrentLoadWeight += weight;
    }

    public virtual void UnloadCargo()
    {
        CurrentLoadWeight = 0;

    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Numer seryjny: {SerialNumber}, \n" +
                          $"Waga własna: {EmptyWeight} kg, \n" +
                          $"Maksymalna ładowność: {MaxLoadWeight} kg, \n" +
                          $"Obecny ładunek: {CurrentLoadWeight} kg");
    }
    
    
    
}