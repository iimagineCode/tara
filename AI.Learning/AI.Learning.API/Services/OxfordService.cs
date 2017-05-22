using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AI.Learning.API.Interfaces;
using AI.Learning.API.Models;
using Newtonsoft.Json;

namespace AI.Learning.API.Services
{
    public class OxfordService: IDictionaryService<DictionaryResult>
    {
        private const string BASE_URI = "https://od-api.oxforddictionaries.com/api/v1/entries";
        private const string APP_ID = "027cb941";
        private const string APP_KEY = "c0b4680e80ddf10b41f18b7458a70201";
        private const string LANGUAGE = "en";
        public async Task<DictionaryResult> Define(string word)
        {
            using (var client = new HttpClient())
            {
                DictionaryResult result = new DictionaryResult();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("app_id", APP_ID);
                client.DefaultRequestHeaders.Add("app_key", APP_KEY);
                using (var request = new HttpRequestMessage(HttpMethod.Get, BASE_URI + "/" + LANGUAGE + "/" + Sanitize(word)))
                {
                    var response = await client.SendAsync(request);
                    if(response.IsSuccessStatusCode)
                        result = JsonConvert.DeserializeObject<DictionaryResult>(await response.Content.ReadAsStringAsync());

                    return result;
                }
            }
        }

        private string Sanitize(string str)
        {
            var chars = str.Trim().ToCharArray();
            var word = chars.Where(c => !Char.IsDigit(c)
                                    && !Char.IsPunctuation(c)
                                    && !Char.IsSeparator(c)
                                    && !Char.IsSymbol(c)
                                    && !Char.IsDigit(c)
                                    && !Char.IsNumber(c))
                                    .ToArray<char>();
            return new string(word);
        }
    }
}