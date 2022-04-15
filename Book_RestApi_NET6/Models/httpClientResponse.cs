namespace Book_RestApi_NET6.Models
{
    public class httpClientResponse<T>
    {
        private bool HasError { get; set; }
        private List<T> Data { get; set; }
        private string Message { get; set; }

        public httpClientResponse(bool HasError ,string Message , List<T> Data)
        {
            this.HasError = HasError;
            this.Message = Message;
            this.Data = Data;
        }

        public object Result()
        {
            return new
            {
                HasError = this.HasError,
                Message = this.Message,
                Data = this.Data,
            };
        }

    }
}
