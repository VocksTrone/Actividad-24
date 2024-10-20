using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_24
{
    public class ReparationQueue
    {
        protected Vehicles Front;
        protected Vehicles Final;
        public ReparationQueue()
        {
            Front = null;
            Final = null;
        }
        public void Enqueue(Vehicles newCar)
        {
            if (Final == null)
            {
                Front = newCar;
                Final = newCar;
            }
            else
            {
                Final.Next = newCar;
                Final = newCar;
            }
        }
        public Vehicles Dequeue()
        {
            if (Front == null) return null;

            Vehicles tempCar = Front;
            Front = Front.Next;

            if (Front == null) Final = null;

            return tempCar;
        }
        public bool IsEmpty()
        {
            return Front == null;
        }
        public void ShowQueue()
        {
            Vehicles current = Front;
            if (current == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSin Vehículos en Cola");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nVehículos en Cola de Rutinarias");
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
            Vehicles current = Front;
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
