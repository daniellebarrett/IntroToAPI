using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    class SWAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();


        // Async Method
        public async Task<Person> GetPersonAsync(string url)
        {
            //// Get Request
            //HttpResponseMessage response = await _httpClient.GetAsync(url);
            //if (response.IsSuccessStatusCoded)
            //{
            //    // was a success
            //    Person person = await response.Content.ReadAsAsync<Person>();
            //    return person;
            //}

            //// was not a success
            //return null;

            return await GetAsync<Person>(url);

        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            return response.IsSuccessStatusCode 
                ? await response.Content.ReadAsAsync<Vehicle>()
                : null;
        }

        public async Task<T> GetAsync<T>(string url)//where T:class -->says T has to be a class 100% of the time (cuz classes can be nullable, then can return null)
            //constraints allow us to give more info about the generic
            //constraints limit what programmers can do
            //cant accidently misuse this method or else it will break - this is a result of using the constraint
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                T content = await response.Content.ReadAsAsync<T>();
                return content;
            }

            //return null; this doesnt work bc T could be int and int is NEVER null? instead use default or use a constraint(line 42)
            return default;
        }

        public async Task<SearchResult<Person>> GetPersonSearchAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://swapi.dev/api/people?search=" + query);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<SearchResult<Person>>();
            return null;
        }

        public async Task<SearchResult<T>> GetSearchAsync<T>(string query, string category)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://swapi.dev/api/{category}?search={query}");

            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<SearchResult<T>>()
                : default;
        }

        public async Task<SearchResult<Vehicle>> GetVehicleSearchAsync(string query)
        {
            return await GetSearchAsync<Vehicle>(query, "vehicles");
        }
    }
}
