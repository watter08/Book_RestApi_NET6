using Book_RestApi_NET6.Methods;
using Book_RestApi_NET6.Models;
using Book_RestApi_NET6.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_RestApi_NET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookMethod bookMethod = new BookMethod();



        // GET: api/<Book>
        [HttpGet]
        public ActionResult<Response<Book>> Get()
        {
            Response<Book> DataResponse;
            try
            {
                List<Book> Books = bookMethod.GetListBook(GlobalClass.RutaApiExterna);
                DataResponse = new Response<Book>(false, GlobalClass.ResMessageOk, HttpStatusCode.OK, Books);
                return Ok(DataResponse.Result());
            }
            catch (Exception ex)
            {
                DataResponse = new Response<Book>(true, $"{GlobalClass.ResMessageBadRequest}  {ex.Message}", HttpStatusCode.BadRequest, null);
                return BadRequest(DataResponse.Result());
            }
        }

        // GET api/<Book>/5
        [HttpGet("{id}")]
        public ActionResult<Response<Book>> Get(int id)
        {
            Response<Book> DataResponse;
            try
            {
                List<Book> Books = bookMethod.GetBook(GlobalClass.RutaApiExterna, id);
                DataResponse = new Response<Book>(false, GlobalClass.ResMessageOk, HttpStatusCode.OK, Books);
                return Ok(DataResponse.Result());
            }
            catch (Exception ex)
            {
                DataResponse = new Response<Book>(true, $"{GlobalClass.ResMessageBadRequest}  {ex.Message}", HttpStatusCode.BadRequest, null);
                return BadRequest(DataResponse.Result());
            }
        }

        // POST api/<Book>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book book)
        {
            Response<Book> DataResponse;
            try
            {
                bool response = await bookMethod.PostBook(GlobalClass.RutaApiExterna, book);
                if (!response)
                    throw new Exception(GlobalClass.ResMessagePostError);
                DataResponse = new Response<Book>(false, GlobalClass.ResMessagePost, HttpStatusCode.OK, null);
                return Ok(DataResponse.Result());
            }
            catch (Exception ex)
            {
                DataResponse = new Response<Book>(true, $"{GlobalClass.ResMessagePostError}  {ex.Message}", HttpStatusCode.BadRequest, null);
                return BadRequest(DataResponse.Result());
            }
        }

        // PUT api/<Book>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Book book)
        {
            Response<Book> DataResponse;
            try
            {
                bool response = await bookMethod.PutBook(GlobalClass.RutaApiExterna, id, book);
                if (!response)
                    throw new Exception(GlobalClass.ResMessagePostError);
                DataResponse = new Response<Book>(false, GlobalClass.ResMessagePut, HttpStatusCode.OK, null);
                return Ok(DataResponse.Result());
            }
            catch (Exception ex)
            {
                DataResponse = new Response<Book>(true, $"{GlobalClass.ResMessagePutError}  {ex.Message}", HttpStatusCode.BadRequest, null);
                return BadRequest(DataResponse.Result());
            }
        }

        // DELETE api/<Book>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Response<Book> DataResponse;
            try
            {
              bool response = await bookMethod.DeleteBook(GlobalClass.RutaApiExterna, id);
                if (!response)
                    throw new Exception(GlobalClass.ResMessagePostError);
                DataResponse = new Response<Book>(false, GlobalClass.ResMessageDelete, HttpStatusCode.OK, null);
                return Ok(DataResponse.Result());

            }
            catch (Exception ex)
            {
                DataResponse = new Response<Book>(true, $"{GlobalClass.ResMessageDeleteError}  {ex.Message}", HttpStatusCode.BadRequest, null);
                return BadRequest(DataResponse.Result());
            }
        }

    }
}
