using System.ComponentModel.DataAnnotations;

namespace Book_RestApi_NET6.Models
{
    public class Response<T>
    {
        private bool HashError { get; set; }
        private string Message { get; set; }
        private int StatusCode { get; set; }
        private List<T> Data { get; set; }

        public Response(bool HasError , string Message, Enum StatusCode, List<T> Data )
        {
            this.HashError = HasError;
            this.Message = Message;
            this.StatusCode = Convert.ToInt32(StatusCode);
            this.Data = Data;   
        }
        
        public object Result()
        {
            return new 
            {
                HasError = this.HashError,
                Message = this.Message,
                StatusCode = this.StatusCode,
                Data = this.Data,
            };
        }
    } 
}
