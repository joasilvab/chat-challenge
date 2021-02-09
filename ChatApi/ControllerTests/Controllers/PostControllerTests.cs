using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Controllers;
using ChatApi.Models;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ChatApiTests.Controllers
{
    public class PostControllerTests
    {
        private Mock<IPostService> postServiceMock;
        private PostController controller;

        [SetUp]
        public void Setup()
        {
            postServiceMock = new Mock<IPostService>();
            controller = new PostController(postServiceMock.Object);
        }

        [Test]
        public async Task GetPosts_OK()
        {
            //Arrange
            var postsList = new List<PostRequest>
            {
                new PostRequest { Id = 1, Message = "Hi!", Timestamp = new DateTime(), Username = "User1" },
                new PostRequest { Id = 2, Message = "Hello!", Timestamp = new DateTime(), Username = "User2" }
            };
            postServiceMock.Setup(x => x.GetPosts()).ReturnsAsync(postsList);
            //Act
            var result = await controller.GetPosts();
            //Assert
            Assert.IsNotNull(result.Result is OkResult);
            Assert.AreEqual(2, result.Value.Count);
        }
    }
}