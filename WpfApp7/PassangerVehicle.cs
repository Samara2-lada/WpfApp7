using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7
{
    public interface IPassangerVehicle
    {
        int PassangerCapacity { get; set; }
        int GetPassengerCapacity();
    }
}
