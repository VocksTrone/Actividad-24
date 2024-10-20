using Actividad_24;

bool generalContinue = true;
PriorityStack urgentRepairs = new PriorityStack();
ReparationQueue routineRepairs = new ReparationQueue();

while (generalContinue)
{
    try
    {
        SwitchFirstMenu();
    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nERROR!, Datos Inválidos");
        Console.ResetColor();
        Console.ReadKey();
    }
}
int FirstMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("--- Taller Mecánico ---");
    Console.ResetColor();
    Console.WriteLine("\n1. Registrar Vehículo");
    Console.WriteLine("2. Reparar Vehículo");
    Console.WriteLine("3. Mostrar Vehículos");
    Console.WriteLine("4. Salir");
    Console.Write("\nIngrese una Opción: ");
    int firstOption = int.Parse(Console.ReadLine());
    return firstOption;
}
bool GoOut()
{
    Console.WriteLine("\nUsted está Cerrando el Programa");
    generalContinue = false;
    return generalContinue;
}
void SwitchFirstMenu()
{
    switch (FirstMenu())
    {
        case 1:
            Vehicles.AddVehicle(ref urgentRepairs, ref routineRepairs);
            break;
        case 2:
            Vehicles.AttendVehicle(ref urgentRepairs, ref routineRepairs);
            break;
        case 3:
            Vehicles.ShowAllVehicles(ref urgentRepairs, ref routineRepairs);
            break;
        case 4:
            GoOut();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ingrese una Opción Válida (1 - 4)");
            Console.ResetColor();
            Console.ReadKey();
            break;
    }
}
