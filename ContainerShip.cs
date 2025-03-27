namespace Task1;

public class ContainerShip
{
    public string Name { get; }
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    private List<Container> Containers { get; }

    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight * 1000; // w tonach 
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
        {
            throw new InvalidOperationException($"Statek {Name} nie może przewozić więcej niż {MaxContainers} kontenerów.");
        }

        double totalWeight = Containers.Sum(c => c.EmptyWeight + c.CurrentLoadWeight);
        if (totalWeight + container.EmptyWeight + container.CurrentLoadWeight > MaxWeight)
        {
            throw new InvalidOperationException($"Przekroczono maksymalną wagę ładunku dla statku {Name}!");
        }

        Containers.Add(container);
        Console.WriteLine($"Załadowano kontener {container.SerialNumber} na statek {Name}.");
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new InvalidOperationException($"Kontener {serialNumber} nie znajduje się na statku {Name}.");
        }

        Containers.Remove(container);
        Console.WriteLine($"Usunięto kontener {serialNumber} ze statku {Name}.");
    }

    public void TransferContainer(string serialNumber, ContainerShip targetShip)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new InvalidOperationException($"Kontener {serialNumber} nie znajduje się na statku {Name}.");
        }

        UnloadContainer(serialNumber);
        targetShip.LoadContainer(container);
        Console.WriteLine($"Przeniesiono kontener {serialNumber} ze statku {Name} na statek {targetShip.Name}.");
    }
    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var existingContainer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (existingContainer == null)
        {
            throw new InvalidOperationException($"Kontener {serialNumber} nie znajduje się na statku {Name}.");
        }

        // Sprawdzamy, czy można załadować nowy kontener
        double totalWeight = Containers.Sum(c => c.EmptyWeight + c.CurrentLoadWeight);
        if (totalWeight + newContainer.EmptyWeight + newContainer.CurrentLoadWeight > MaxWeight)
        {
            throw new InvalidOperationException($"Przekroczono maksymalną wagę ładunku dla statku {Name} przy dodawaniu nowego kontenera.");
        }

        // Usuwamy stary kontener, a następnie dodajemy nowy
        Containers.Remove(existingContainer);
        Containers.Add(newContainer);
        Console.WriteLine($"Zastąpiono kontener {serialNumber} nowym kontenerem {newContainer.SerialNumber} na statku {Name}.");
    }
    public void PrintContainers()
    {
        int counter = 1;
        Console.WriteLine($"Kontenery na statku {Name}:");
        Console.WriteLine();
        if (Containers.Count == 0)
        {
            Console.WriteLine("Brak kontenerów.");
            return;
        }

        foreach (var container in Containers)
        {
            Console.WriteLine($"Kontener {counter++} na statku {Name}:");
            container.DisplayInfo();
            Console.WriteLine();

        }

    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Statek {Name}:");
        Console.WriteLine($"- Maksymalna prędkość: {MaxSpeed} węzłów");
        Console.WriteLine($"- Maksymalna liczba kontenerów: {MaxContainers}");
        Console.WriteLine($"- Maksymalna waga ładunku: {MaxWeight / 1000} ton");
        Console.WriteLine($"- Obecnie przewożone kontenery ({Containers.Count}):");

        foreach (var container in Containers)
        {
            container.DisplayInfo();
        }
    }
    

}