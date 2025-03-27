namespace Task1;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }

    private static readonly Dictionary<string, double> RequiredTemperatures = new()
    {
        { "banany", 13.3 },
        { "ryby", -2.0 },
        { "mięso", -15.0 }
    };

    public RefrigeratedContainer(double emptyWeight, double maxLoadWeight, string productType, double temperature, double heigth, double depth)
        : base("C", emptyWeight, maxLoadWeight, heigth, depth)
    {
        if (!RequiredTemperatures.ContainsKey(productType.ToLower()))
        {
            throw new ArgumentException($"Nieznany produkt: {productType}");
        }

        if (temperature > RequiredTemperatures[productType.ToLower()])
        {
            throw new ArgumentException($"Temperatura dla {productType} musi być co najmniej {RequiredTemperatures[productType.ToLower()]}°C");
        }

        ProductType = productType.ToLower();
        Temperature = temperature;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Typ produktu: {ProductType}, Temperatura: {Temperature}°C");
    }

    public void LoadProduct(string productType, double weight)
    {
        if (productType.ToLower() != ProductType)
        {
            throw new InvalidOperationException($"Kontener {SerialNumber} może przechowywać tylko {ProductType}!");
        }
        base.LoadCargo(weight);
    }
}