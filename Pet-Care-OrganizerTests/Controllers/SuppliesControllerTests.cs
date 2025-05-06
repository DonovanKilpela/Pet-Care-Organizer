using Xunit;
using Moq;
using Pet_Care_Organizer.Controllers;
using Pet_Care_Organizer.Models;
using Pet_Care_Organizer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class SuppliesControllerTests
{
    private readonly Mock<ISuppliesRepository> _mockRepo;
    private readonly SuppliesController _controller;

    public SuppliesControllerTests()
    {
        _mockRepo = new Mock<ISuppliesRepository>();
        _controller = new SuppliesController(_mockRepo.Object);
    }

    [Fact]
    public void Index_ReturnsViewWithSupplies()
    {
        // Arrange
        var supplies = new List<Supplies> { new Supplies { Id = 1, Name = "Test" } };
        _mockRepo.Setup(r => r.GetAll()).Returns(supplies);

        // Act
        var result = _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<Supplies>>(viewResult.Model);
        Assert.Single(model);
        Assert.Equal("Test", model[0].Name);
    }

    [Fact]
    public void Create_Get_ReturnsView()
    {
        var result = _controller.Create();
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Create_Post_ValidModel_AddsAndRedirects()
    {
        var supply = new Supplies { Id = 1, Name = "Test" };
        var result = _controller.Create(supply);

        _mockRepo.Verify(r => r.Add(supply), Times.Once);
        Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public void Create_Post_InvalidModel_ReturnsViewWithModel()
    {
        _controller.ModelState.AddModelError("Name", "Required");
        var supply = new Supplies();
        var result = _controller.Create(supply);

        _mockRepo.Verify(r => r.Add(It.IsAny<Supplies>()), Times.Never);
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(supply, viewResult.Model);
    }

    [Fact]
    public void Edit_Get_NullId_ReturnsNotFound()
    {
        var result = _controller.Edit(null);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Edit_Get_NotFound_ReturnsNotFound()
    {
        _mockRepo.Setup(r => r.GetById(1)).Returns((Supplies)null);
        var result = _controller.Edit(1);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Edit_Get_Found_ReturnsViewWithModel()
    {
        var supply = new Supplies { Id = 1, Name = "Test" };
        _mockRepo.Setup(r => r.GetById(1)).Returns(supply);
        var result = _controller.Edit(1);
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(supply, viewResult.Model);
    }

    [Fact]
    public void Edit_Post_IdMismatch_ReturnsNotFound()
    {
        var supply = new Supplies { Id = 2, Name = "Test" };
        var result = _controller.Edit(1, supply);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Edit_Post_InvalidModel_ReturnsViewWithModel()
    {
        var supply = new Supplies { Id = 1, Name = "Test" };
        _controller.ModelState.AddModelError("Name", "Required");
        var result = _controller.Edit(1, supply);

        _mockRepo.Verify(r => r.Update(It.IsAny<Supplies>()), Times.Never);
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(supply, viewResult.Model);
    }

    [Fact]
    public void Edit_Post_UpdateFails_ReturnsNotFound()
    {
        var supply = new Supplies { Id = 1, Name = "Test" };
        _mockRepo.Setup(r => r.Update(supply)).Returns(false);
        var result = _controller.Edit(1, supply);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Edit_Post_UpdateSucceeds_Redirects()
    {
        var supply = new Supplies { Id = 1, Name = "Test" };
        _mockRepo.Setup(r => r.Update(supply)).Returns(true);
        var result = _controller.Edit(1, supply);
        Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public void Delete_Get_NullId_ReturnsNotFound()
    {
        var result = _controller.Delete(null);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_Get_NotFound_ReturnsNotFound()
    {
        _mockRepo.Setup(r => r.GetById(1)).Returns((Supplies)null);
        var result = _controller.Delete(1);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_Get_Found_ReturnsViewWithModel()
    {
        var supply = new Supplies { Id = 1, Name = "Test" };
        _mockRepo.Setup(r => r.GetById(1)).Returns(supply);
        var result = _controller.Delete(1);
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(supply, viewResult.Model);
    }

    [Fact]
    public void DeleteConfirmed_DeleteFails_ReturnsNotFound()
    {
        _mockRepo.Setup(r => r.Delete(1)).Returns(false);
        var result = _controller.DeleteConfirmed(1);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void DeleteConfirmed_DeleteSucceeds_Redirects()
    {
        _mockRepo.Setup(r => r.Delete(1)).Returns(true);
        var result = _controller.DeleteConfirmed(1);
        Assert.IsType<RedirectToActionResult>(result);
    }
}
