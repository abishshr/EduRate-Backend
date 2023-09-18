using EduRate.Api.Controllers;
using EduRate.Api.Interfaces;
using EduRate.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class ReviewControllerTests
{
    private readonly ReviewController _controller;
    private readonly Mock<IReviewService> _serviceMock = new Mock<IReviewService>();

    public ReviewControllerTests()
    {
        _controller = new ReviewController(_serviceMock.Object);
    }

    [Fact]
    public void AddComment_ValidComment_ReturnsOk()
    {
        _serviceMock.Setup(service => service.AddComment(It.IsAny<Comment>())).Returns(true);

        var result = _controller.AddComment(new Comment());

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void GetAllCommentsForModule_ValidModuleId_ReturnsOkWithComments()
    {
        var expectedComments = new List<Comment>
        {
            new Comment { /* Some properties here */ },
            // Add more dummy comments as needed
        };

        _serviceMock.Setup(service => service.GetAllCommentsForModule(It.IsAny<int>())).Returns(expectedComments);

        var result = _controller.GetAllCommentsForModule(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedComments, okResult.Value);
    }

    [Fact]
    public void GetRecentComments_ValidModuleId_ReturnsOkWithComments()
    {
        var expectedComments = new List<Comment>
        {
            new Comment { /* Some properties here */ },
            // Add more dummy comments as needed
        };

        _serviceMock.Setup(service => service.GetRecentComments(It.IsAny<int>())).Returns(expectedComments);

        var result = _controller.GetRecentComments(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedComments, okResult.Value);
    }
}