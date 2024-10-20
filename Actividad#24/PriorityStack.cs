using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_24
{
    public class PriorityStack
    {
        protected Vehicles Top;
        public PriorityStack()
        {
            Top = null;
        }
        public void Stack(Vehicles newCar)
        {
            newCar.Next = Top;
            Top = newCar;
        }
        public Vehicles Unstack()
        {
            if (Top == null)
            {
                return null;
            }
            else
            {
                Vehicles tempCar = Top;
                Top = Top.Next;
                return tempCar;
            }
        }
        public bool IsEmpty()
        {
            return Top == null;
        }
        public void ShowStack()
        {
            Vehicles current = Top;
            if (current == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSin Vehículos en Pila");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nVehículos en Pila de Urgencias");
                while (current != null)
                {
                    Console.WriteLine($"\nPlaca: {current.Plate} \nMarca: {current.Brand} \nModelo: {current.Model} " +
                        $"\nTipo de Reparación: {current.ReparationType}");
                    current = current.Next;
                }
            }
        }
        public bool Contains(string plate)
        {
            Vehicles current = Top;
            while (current != null)
            {
                if (current.Plate.Equals(plate, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}