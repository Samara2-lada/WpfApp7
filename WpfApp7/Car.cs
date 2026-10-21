using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7
// Интерфейс автомобиль
{
    public interface Car
    {
        string Brand { get; set; }
        int MaxSpeed { get; set; }
        String GetInfo();
    }
}
