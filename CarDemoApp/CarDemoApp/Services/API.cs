using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using static CarDemoApp.Model.CarModel;

namespace CarDemoApp.Services
{
    class API
    {
        public async Task<ObservableCollection<APICarModel>> GetCarModelsAsync(string make)
        {
            HttpClient client = new HttpClient();

            ObservableCollection<APICarModel> CarList = new ObservableCollection<APICarModel>();

            var vehicleApi = new System.Uri(string.Format("http://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/{0}?format=json", make));
            try
            {
                HttpResponseMessage response = await client.GetAsync(vehicleApi);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var carModels = JsonConvert.DeserializeObject<ModelListResults>(responseContent);
                    foreach (APICarModel item in carModels.Results)
                    {
                        CarList.Add(item);
                    }

                }

                return CarList;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine(e);
                return CarList;
            }
            


        }
    }
}
