using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aumentosueldo4030347.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _sueldo;
        public string Sueldo
        {
            get { return _sueldo; }
            set
            {
                _sueldo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sueldo)));
            }
        }

        public ICommand CalcularSueldoCommand => new Command(async () =>
        {
            if (decimal.TryParse(Sueldo, out decimal sueldo))
            {
                decimal nuevoSueldo = sueldo < 1000 ? sueldo * 1.15m : sueldo * 1.12m;
                await Application.Current.MainPage.Navigation.PushAsync(new ResultPage(nuevoSueldo));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese un sueldo válido.", "OK");
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
