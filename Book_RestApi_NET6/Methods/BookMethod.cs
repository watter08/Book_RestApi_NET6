using Book_RestApi_NET6.Models;
using Newtonsoft.Json;
using System.Text;

namespace Book_RestApi_NET6.Methods
{
    public class BookMethod
    {
        HttpClient httpClient;
        public List<Book> GetBook(string path , int id)
        {
            var book = new List<Book>();
            httpClient = new HttpClient();            
            var request = httpClient.GetAsync($"{path}/{id}").Result;
            var result = request.Content.ReadAsStringAsync().Result;
            book.Add(JsonConvert.DeserializeObject<Book>(result));
            return request.IsSuccessStatusCode ? book : null;
        }

        public List<Book> GetListBook(string path)
        {
            httpClient = new HttpClient();            
            var request = httpClient.GetAsync(path).Result;
            var result = request.Content.ReadAsStringAsync().Result;
            return request.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<Book>>(result) : null;
        }

        public async Task<bool> PostBook(string path, Book book)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(book);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(path, data);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutBook(string path, int id ,  Book book)
        {
            httpClient = new HttpClient();            
            var stringContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{path}/{id}", stringContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBook(string path, int id)
        {
            var book = new List<Book>();
            httpClient = new HttpClient();            
            var request = httpClient.DeleteAsync($"{path}/{id}").Result;
            var result = request.Content.ReadAsStringAsync().Result;
            book.Add(JsonConvert.DeserializeObject<Book>(result));
            return request.IsSuccessStatusCode;
        }
    }
}
