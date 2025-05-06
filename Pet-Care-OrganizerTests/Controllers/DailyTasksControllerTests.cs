using Xunit;
using Moq;
using Pet_Care_Organizer.Controllers;
using Pet_Care_Organizer.Models;
using Pet_Care_Organizer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class DailyTasksControllerTests
{
    private readonly Mock<IDailyTasksRepository> _mockRepo;
    private readonly Mock<IStatusRepository> _mockStatusRepo;
    private readonly DailyTasksController _controller;

    public DailyTasksControllerTests()
    {
        _mockRepo = new Mock<IDailyTasksRepository>();
        _mockStatusRepo = new Mock<IStatusRepository>();
        _controller = new DailyTasksController(_mockRepo.Object, _mockStatusRepo.Object);
    }

    [Fact]
    public void Index_ReturnsViewWithTasks()
    {
        var tasks = new List<DailyTasks> { new DailyTasks { Id = 1, Description = "Feed cat" } };
        _mockRepo.Setup(r => r.GetAll()).Returns(tasks);

        var result = _controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<DailyTasks>>(viewResult.Model);
        Assert.Single(model);
        Assert.Equal("Feed cat", model[0].Description);
    }

    [Fact]
    public void Create_Get_ReturnsViewWithStatusOptions()
    {
        var statuses = new List<Status> { new Status { Name = "Done" } };
        _mockStatusRepo.Setup(r => r.GetAll()).Returns(statuses);

        var result = _controller.Create();

        Assert.IsType<ViewResult>(result);
        Assert.Equal(statuses, _controller.ViewBag.StatusOptions);
    }

    [Fact]
    public void Create_Post_AddsTaskAndRedirects()
    {
        var task = new DailyTasks { Id = 1, Description = "Feed cat" };

        var result = _controller.Create(task);

        _mockRepo.Verify(r => r.Add(task), Times.Once);
        Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public void Edit_Get_TaskNotFound_ReturnsNotFound()
    {
        _mockRepo.Setup(r => r.GetById(1)).Returns((DailyTasks)null);

        var result = _controller.Edit(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Edit_Get_TaskFound_ReturnsViewWithModelAndStatusOptions()
    {
        var task = new DailyTasks { Id = 1, Description = "Feed cat" };
        var statuses = new List<Status> { new Status { Name = "Done" } };
        _mockRepo.Setup(r => r.GetById(1)).Returns(task);
        _mockStatusRepo.Setup(r => r.GetAll()).Returns(statuses);

        var result = _controller.Edit(1);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(task, viewResult.Model);
        Assert.Equal(statuses, _controller.ViewBag.StatusOptions);
    }

    [Fact]
    public void Edit_Post_UpdateFails_ReturnsNotFound()
    {
        var task = new DailyTasks { Id = 1, Description = "Feed cat" };
        _mockRepo.Setup(r => r.Update(task)).Returns(false);

        var result = _controller.Edit(task);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Edit_Post_UpdateSucceeds_Redirects()
    {
        var task = new DailyTasks { Id = 1, Description = "Feed cat" };
        _mockRepo.Setup(r => r.Update(task)).Returns(true);

        var result = _controller.Edit(task);

        Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public void Delete_Get_TaskNotFound_ReturnsNotFound()
    {
        _mockRepo.Setup(r => r.GetById(1)).Returns((DailyTasks)null);

        var result = _controller.Delete(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_Get_TaskFound_ReturnsViewWithModel()
    {
        var task = new DailyTasks { Id = 1, Description = "Feed cat" };
        _mockRepo.Setup(r => r.GetById(1)).Returns(task);

        var result = _controller.Delete(1);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(task, viewResult.Model);
    }

    [Fact]
    public void DeleteConfirmed_DeletesAndRedirects()
    {
        var result = _controller.DeleteConfirmed(1);

        _mockRepo.Verify(r => r.Delete(1), Times.Once);
        Assert.IsType<RedirectToActionResult>(result);
    }
}
