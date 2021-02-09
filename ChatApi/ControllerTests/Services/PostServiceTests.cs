using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChatApi.Domain;
using ChatApi.Models;
using ChatApi.Models.Automapper;
using ChatApi.Repositories;
using ChatApi.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace ChatApiTests.Services
{
    class PostServiceTests
    {
        private PostService service;
        private Mock<IPostRepository> postRepositoryMock;

        [SetUp]
        public void Setup()
        {
            postRepositoryMock = new Mock<IPostRepository>();
            Mock<IUserService> userServiceMock = new Mock<IUserService>();

            var inMemorySettings = new Dictionary<string, string> {
                {"postsQuantity", "50"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var postProfile = new PostProfile();
            var userProfile = new UserProfile();
            var mapperConfiguration = new MapperConfiguration(cfg => { 
                cfg.AddProfile(postProfile); 
                cfg.AddProfile(userProfile);
            });
            IMapper mapper = new Mapper(mapperConfiguration);

            service = new PostService(postRepositoryMock.Object,
                                      userServiceMock.Object,
                                      configuration,
                                      mapper);
        }

        [Test]
        public async Task GetPosts_Returns_two_OK() 
        {
            //Arrange
            var postsList = new List<Post>
            {
                new Post { Id = 1, Message = "Hi!", Timestamp = new DateTime(), User = new ChatApi.Domain.User { Username = "User1" } },
                new Post { Id = 2, Message = "Hello!", Timestamp = new DateTime(), User = new ChatApi.Domain.User { Username = "User2" } }
            };

            postRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(postsList);

            //Act
            var result = await service.GetPosts();

            //Assert
            Assert.AreEqual(2, result.Count);
            Assert.True(result.TrueForAll(r => r.Username != null));
        }

        [Test]
        public async Task GetPosts_Returns_zero_OK()
        {
            //Arrange
            var postsList = new List<Post>();

            postRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(postsList);

            //Act
            var result = await service.GetPosts();

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public async Task SavePost_OK()
        {
            //Arrange
            var newPost = new PostRequest
            {
                Message = "Hello!",
                Username = "User1"
            };

            //Act
            await service.SavePost(newPost);

            //Assert
            Assert.Pass();
        }
    }
}
