namespace Task1;

public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("===== Tworzenie statków =====");
                ContainerShip ship1 = new ContainerShip("Ocean Titan", 25, 10, 500);
                ContainerShip ship2 = new ContainerShip("Sea Voyager", 20, 8, 400);

                Console.WriteLine("\n===== Tworzenie kontenerów =====");
                GasContainer gasContainer = new GasContainer(2000, 10000, 5, 30,40);
                LiquidContainer liquidContainerSafe = new LiquidContainer(1500, 8000, false,50,20);
                LiquidContainer liquidContainerDangerous = new LiquidContainer(1600, 7000, true, 20,40);
                RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(1800, 5000, "mięso", -18,40,20);

                Console.WriteLine("\n===== Ładowanie ładunku do kontenerów =====");
                gasContainer.LoadCargo(400);
                liquidContainerSafe.LoadCargo(6000);
                liquidContainerDangerous.LoadCargo(3000);
                refrigeratedContainer.LoadProduct("mięso", 4000);

                Console.WriteLine("\n===== Załadunek kontenerów na statek =====");
                ship1.LoadContainer(gasContainer);
                ship1.LoadContainer(liquidContainerSafe);
                ship1.LoadContainer(refrigeratedContainer);

                Console.WriteLine("\n===== Informacje o statku po załadunku =====");
                ship1.DisplayInfo();
                
                Console.WriteLine();
                
                Console.WriteLine("\n===== Przenoszenie kontenera na inny statek =====");
                ship1.TransferContainer(gasContainer.SerialNumber, ship2);

                Console.WriteLine("\n===== Informacje po transferze =====");
                ship1.DisplayInfo();
                
                Console.WriteLine();
                Console.WriteLine();

                ship2.DisplayInfo();

                Console.WriteLine("\n===== Wyładowanie kontenera =====\n");
                ship1.UnloadContainer(refrigeratedContainer.SerialNumber);

                
                GasContainer newGasContainer = new GasContainer(1000, 10000, 10, 20,10); // Nowy kontener
                Console.WriteLine("Dodano nowy kontener");
                ship2.ReplaceContainer(gasContainer.SerialNumber, newGasContainer);
                
                Console.WriteLine("\n===== Informacje końcowe =====");
                ship1.PrintContainers();
                Console.WriteLine();
                Console.WriteLine();
                ship2.PrintContainers();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
            }
        }
    }
