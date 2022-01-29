using Drivers.Controller;
using Drivers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        UniversalController controller;

        private List<Driver> driverList;

        public List<Driver> DriverList
        {
            get => driverList;
            set
            {
                driverList = value;
                OnPropertyChanged(nameof(DriverList));
            }
        }

        public MainWindowViewModel()
        {
            controller = new UniversalController();

            allDataLoader();
        }

        private async void allDataLoader()
        {
            await loadDriverList();
        }

        private async Task loadDriverList()
        {
            DriverList = await controller.Get<List<Driver>>("Drivers", "", "");
        }
    }
}
