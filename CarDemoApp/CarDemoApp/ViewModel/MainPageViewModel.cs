using CarDemoApp.Model;
using CarDemoApp.Services;
using CarDemoApp.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CarDemoApp.Model.CarModel;

namespace CarDemoApp.ViewModel
{
    class MainPageViewModel
    {
        API CarAPI = new API();
        public static ObservableCollection<APICarModel> CarModelList { get; set; }
        public string CarBrand { get; set; }
        public ObservableCollection<CarBrand> CarBrandList { get; set; }
        public Command GetCarListCommand { get; set; }

        public MainPageViewModel()
        {
            CarBrandList = new ObservableCollection<CarBrand>();

            GetCarListCommand = new Command(async (object selectedBrand) => await GetCarList(selectedBrand));

            CarBrandList.Add(new CarBrand("Audi", "audi.png"));
            CarBrandList.Add(new CarBrand("BMW", "bmw.png"));
            CarBrandList.Add(new CarBrand("Mercedes", "merc.png"));
        }

        public async Task GetCarList(object selectedBrand)
        {
            var brand = (int)selectedBrand;
            CarBrand = CarBrandList[brand].BrandName;
            var CarListPage = new CarListPage();
            CarModelList = await CarAPI.GetCarModelsAsync(CarBrand);
            CarListPage.BindingContext = new CarListViewModel(CarModelList);
            await App.Current.MainPage.Navigation.PushAsync(CarListPage);
        }
    }
}
