using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System;
using BusApp;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Bus> _buses = new();
        public MainWindow()
        {
            InitializeComponent();
            lstBuses.ItemsSource = _buses;
            cmbFirst.ItemsSource = _buses;
            cmbSecond.ItemsSource = _buses;
        }
        //Кнопка добавить автобус
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                MessageBox.Show("Введите марку автобуса.");
                return;
            }
            if(!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Неккоректная вместимость.");
                return;
            }
            if (!int.TryParse(txtSpeed.Text, out int speed) || speed <= 0)
            {
                MessageBox.Show("Неккоректная скорость.");
                return;
            }
            if (!int.TryParse(txtRoute.Text, out int route) || route <= 0)
            {
                MessageBox.Show("Неккоректный номер.");
                return;
            }
            var bus = new Bus(txtBrand.Text.Trim(), speed, capacity, route);
            _buses.Add(bus);
            txtResult.Text = $"Добавлено: {bus.GetInfo()}";
        }
        //Убрать автобус
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            int index = lstBuses.SelectedIndex;
            if (index < 0 || index >= _buses.Count)
            {
                MessageBox.Show("Выберите автобус для удаления.");
                return;
            }
            Bus bus = _buses[index];
            _buses.RemoveAt(index);
            txtResult.Text = $"Удалено: {bus.Brand}";
        }
        //Сортировка автобуса по кличеству мест
        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            var sorted = _buses.OrderBy(b => b).ToList();
            _buses.Clear();
            foreach (var b in sorted)
                _buses.Add(b);
            txtResult.Text = "Список отсортирован по вместимости пассажиров";

        }
        //Сравнение автобусов
        private void btncompare_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFirst.SelectedItem is not Bus first || cmbSecond.SelectedItem is not Bus second)
            {
                MessageBox.Show("Выберите два автобуса для сравнения.");
                return;
            }
            int result = first.CompareTo(second);
            if (result > 0)
                txtResult.Text = $"{first.Brand} ({first.PassengerCapacity} чел.) вместительнее, чем {second.Brand} ({second.PassengerCapacity} чел.)";
            else if (result < 0)
                txtResult.Text = $"{first.Brand} ({first.PassengerCapacity} чел.) менее вместителен, чем {second.Brand} ({second.PassengerCapacity} чел.)";
            else
                txtResult.Text = $"{first.Brand} ({first.PassengerCapacity} чел.) одинаковы по вместительности {second.Brand} ({second.PassengerCapacity} чел.)";
        }
        //Выход
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //О программе
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа 7, Вариант 3 Создать интерфейсы - автомобиль, пассажирский транспорт.  Создать класс \r\nавтобус. Класс должен включать конструктор, функцию для формирования строки \r\nинформации об автобусе. Сравнение производить по вместимости пассажиров. ");
        }
    }
}