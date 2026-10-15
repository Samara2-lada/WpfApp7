using System;
using System.Collections.Generic;
using System.Text;
using WpfApp7;
namespace BusApp
{
    public class Bus : IComparable<Bus>
    {
        public string Brand {  get; set; }
        public int MaxSpeed {  get; set; }
        public int PassengerCapacity { get; set; }
        public int RouteNumber { get; set; }

        public Bus (string brand, int maxSpeed, int passengerCapacity, int routeNumber)
        {
            Brand = brand;
            MaxSpeed = maxSpeed;
            PassengerCapacity = passengerCapacity;
            RouteNumber = routeNumber;
        }
        public Bus() : this("Неизвестно", 0, 0, 0) { }
        public string GetInfo()
        {
            return $"Автобус: {Brand}, Маршрут №{RouteNumber}," +
                   $"Вместимость: {PassengerCapacity} чел.," +
                   $"Макс. скорость: {MaxSpeed} км/ч";
        }
        public int GetPassengerCapacity()
        {
            return PassengerCapacity;
        }
        public int CompareTo(Bus other)
        {
            if (other == null) return 1;
            return PassengerCapacity.CompareTo(other.PassengerCapacity);
        }
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
