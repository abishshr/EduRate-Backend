using System;
using Xunit;
using Moq;
using EduRate.Api.Interfaces;
using EduRate.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EduRate.Api.Tests
{
    public class InteractionControllerTests
    {
        private readonly InteractionController _controller;
        private readonly Mock<IInteractionService> _interactionServiceMock;

        public InteractionControllerTests()
        {
            _interactionServiceMock = new Mock<IInteractionService>();
            _controller = new InteractionController(_interactionServiceMock.Object);
        }

        [Fact]
        public void UpvoteComment_ReturnsOkResult_WhenUpvoteIsSuccessful()
        {
            // Arrange
            _interactionServiceMock.Setup(service => service.UpvoteComment(It.IsAny<int>())).Returns(true);

            // Act
            var result = _controller.UpvoteComment(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpvoteComment_ReturnsBadRequest_WhenUpvoteIsUnsuccessful()
        {
            // Arrange
            _interactionServiceMock.Setup(service => service.UpvoteComment(It.IsAny<int>())).Returns(false);

            // Act
            var result = _controller.UpvoteComment(1);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DownvoteComment_ReturnsOkResult_WhenDownvoteIsSuccessful()
        {
            // Arrange
            _interactionServiceMock.Setup(service => service.DownvoteComment(It.IsAny<int>())).Returns(true);

            // Act
            var result = _controller.DownvoteComment(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DownvoteComment_ReturnsBadRequest_WhenDownvoteIsUnsuccessful()
        {
            // Arrange
            _interactionServiceMock.Setup(service => service.DownvoteComment(It.IsAny<int>())).Returns(false);

            // Act
            var result = _controller.DownvoteComment(1);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetCommentVotes_ReturnsOkResult_WithVotes()
        {
            // Arrange
            var expectedVoteCount = 10;
            _interactionServiceMock.Setup(service => service.GetCommentVotes(It.IsAny<int>())).Returns(expectedVoteCount);

            // Act
            var result = _controller.GetCommentVotes(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var responseObject = result.Value as dynamic;
            Assert.Equal(expectedVoteCount, (int)responseObject.votes);
        }
    }
}
