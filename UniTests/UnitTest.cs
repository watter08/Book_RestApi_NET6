using Book_RestApi_NET6.Controllers;
using Book_RestApi_NET6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace UniTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public async Task TestGetBook()
        {

            BookController bookController = new BookController();
            var response = bookController.Get(1);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestGetListBook()
        {
            BookController bookController = new BookController();
            var response = bookController.Get();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestPostBook()
        {
            Book book = new Book()
            {
                id = 0,
                title = "Water",
                description = "El Mejor Programador en Javascript",
                pageCount = 4000,
                excerpt = "string",
                publishDate = "2022-04-02T09:18:13.667Z"

            };

            BookController bookController = new BookController();
            var response = await bookController.Post(book);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestPutBook()
        {
            Book book = new Book()
            {
                id=0,
                title="Water2",
                description="El Mejor Programador en Javascript de los mejores",
                pageCount= 7000,
                excerpt= "string",
                publishDate= "2022-04-02T09:18:13.667Z"

            };

            BookController bookController = new BookController();
            var response = await bookController.Put(1,book);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestDeleteBook()
        {

            BookController bookController = new BookController();
            var response = await bookController.Delete(1);

            Assert.IsNotNull(response);
        }

    }
}