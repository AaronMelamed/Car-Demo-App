using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDemoApp.Model
{
    partial class CarModel : CarBrand
    {
        public string ModelName { get; set; }
        public string ModelType { get; set; }

        public CarModel()
        {

        }
        public CarModel(string brandName, string modelName, string modelType)
        {
            BrandName = brandName;
            ModelName = modelName;
            ModelType = modelType;
        }

        //Model for API Call
        //

        public class CarModelList
        {
            List<CarModel> CarModels { get; set; }
        }
        public class APICarModel
        {

            [JsonProperty("Make_ID")]
            public int MakeID { get; set; }

            [JsonProperty("Make_Name")]
            public string MakeName { get; set; }

            [JsonProperty("Model_ID")]
            public int ModelID { get; set; }

            [JsonProperty("Model_Name")]
            public string ModelName { get; set; }
        }

        public class ModelListResults
        {

            [JsonProperty("Count")]
            public int Count { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("SearchCriteria")]
            public string SearchCriteria { get; set; }

            [JsonProperty("Results")]
            public IList<APICarModel> Results { get; set; }
        }
    }
}
