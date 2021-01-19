using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI.Models
{
    class Vehicle
    {
        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; }

        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        [JsonProperty("cost_in_credits")]
        public string CostInCredits { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("crew")]
        public string Crew { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("passengers")]
        public string Passengers { get; set; }

        [JsonProperty("pilots")]
        public List<object> Pilots { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("vehicle_class")]
        public string VehicleClass { get; set; }
    }
}
