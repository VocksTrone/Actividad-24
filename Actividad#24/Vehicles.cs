using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_24
{
    public class Vehicles
    {
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ReparationType { get; set; }
        public string Priority { get; set; }
        public Vehicles Next { get; set; }
        public Vehicles(string plate, string brand, string model, string reparationtype, string priority)
        {
            Plate = plate;
            Brand = brand;
            Model = model;
            ReparationType = reparationtype;
            Priority = priority;
            Next = null;
        }
        public static void AddVehicle(ref PriorityStack vehiclesStack, ref ReparationQueue vehiclesQueue)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Registrar Vehículo ---");
            Console.ResetColor();
            string plate;
            bool booleanVerification = true;
            while (booleanVerification)
            {
                Console.Write("\nPlaca: ");
                plate = Console.ReadLine();
                if (vehiclesStack.Contains(plate) || vehiclesQueue.Contains(plate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlaca Actualmente Registrada");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\nMarca: ");
                    string brand = Console.ReadLine();
                    Console.Write("\nModelo: ");
                    string model = Console.ReadLine();
                    Console.Write("\nTipo de Reparación: ");
                    string reparationtype = Console.ReadLine();
                    string priority;
                    bool boolPriority = true;
                    while (boolPriority)
                    {
                        Console.Write("\nPrioridad (Urgente / Rutinaria): ");
                        priority = Console.ReadLine();
                        if (priority.Equals("Urgente", StringComparison.OrdinalIgnoreCase) ||
                            priority.Equals("Rutinaria", StringComparison.OrdinalIgnoreCase))
                        {
                            Vehicles newVehicle = new Vehicles(plate, brand, model, reparationtype, priority);
                            if (priority.Equals("Urgente", StringComparison.OrdinalIgnoreCase))
                            {
                                vehiclesStack.Stack(newVehicle);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nVehículo Registrado");
                                Console.ResetColor();
                                boolPriority = false;
                                booleanVerification = false;
                            }
                            else if (priority.Equals("Rutinaria", StringComparison.OrdinalIgnoreCase))
                            {
                                vehiclesQueue.Enqueue(newVehicle);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nVehículo Registrado");
                                Console.ResetColor();
                                boolPriority = false;
                                booleanVerification = false;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPrioridad Inválida");
                            Console.ResetColor();
                        }
                    }
                }
            }
            Console.ReadKey();
        }
        public static void RepairVehicle(ref PriorityStack urgentRepairs, ref ReparationQueue routineRepairs)
        {
            if (urgentRepairs.IsEmpty() && routineRepairs.IsEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSin Vehículos para Atender");
                Console.ResetColor();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Reparar Vehículo ---");
                Console.ResetColor();
                Vehicles attendedVehicle = urgentRepairs.IsEmpty() ? routineRepairs.Dequeue() : urgentRepairs.Unstack();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nVehículo Atendido:");
                Console.ResetColor();
                Console.WriteLine($"\nPlaca: {attendedVehicle.Plate} \nMarca: {attendedVehicle.Brand} \nModelo: {attendedVehicle.Model} " +
                $"\nTipo de Reparación: {attendedVehicle.ReparationType} \nPrioridad: {attendedVehicle.Priority}");
            }
            Console.ReadKey();
        }
        public static void ShowAllVehicles(ref PriorityStack urgentRepairs, ref ReparationQueue routineRepairs)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Mostrar Vehículos ---");
            Console.ResetColor();
            if (urgentRepairs.IsEmpty() && routineRepairs.IsEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo Hay Vehículos en el Taller");
                Console.ResetColor();
            }
            else
            {
                urgentRepairs.ShowStack();
                routineRepairs.ShowQueue();
            }
            Console.ReadKey();
        }
    }
}