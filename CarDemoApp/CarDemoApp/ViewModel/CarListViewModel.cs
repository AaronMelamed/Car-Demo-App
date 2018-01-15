using CarDemoApp.Services;
using CarDemoApp.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CarDemoApp.Model.CarModel;

namespace CarDemoApp.ViewModel
{
    class CarListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<APICarModel> CarModelList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public Command CarTappedCommand { get; set; }

        public CarListViewModel(ObservableCollection<APICarModel> ModelList)
        {
            CarModelList = ModelList;
            CarTappedCommand = new Command(async (object eventArgs) => await CarTapped(eventArgs));

        }

        public async Task CarTapped(object eventArgs)
        {
            var args = eventArgs as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var carMake = (args.ItemData as APICarModel).MakeName;
            var carModel = (args.ItemData as APICarModel).ModelName;
            var pdf = PDFServices.CreatePDF(carMake, carModel);
            var CarDetailPage = new CarDetails();
            var CarDetailVM = new CarDetailViewModel(pdf);
            CarDetailPage.BindingContext = CarDetailVM;
            await Application.Current.MainPage.Navigation.PushAsync(CarDetailPage);
            
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
