namespace Book_RestApi_NET6.Resources
{
    public class GlobalClass
    {

        public static string ResMessageOk => "Resquest Is Sucessfully Correctly"; 
        public static  string ResMessageBadRequest => "An Error Occurred While Making The Request";
        public static string ResMessagePostError => "An error occurred while trying to save the book";
        public static string ResMessagePost => "Book Created Succesfully";
        public static string ResMessagePutError => "An error occurred while trying to update the book";
        public static string ResMessagePut => "book updated successfully";
        public static string ResMessageDeleteError => "An error occurred while trying to delete the book";
        public static string ResMessageDelete => "book deleted successfully";
        public static string RutaApiExterna => "https://fakerestapi.azurewebsites.net/api/v1/Books";
    }
}
