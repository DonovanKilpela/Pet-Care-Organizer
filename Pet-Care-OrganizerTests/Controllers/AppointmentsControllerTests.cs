using Xunit;
using Moq;
using Pet_Care_Organizer.Controllers;
using Pet_Care_Organizer.Models;
using Pet_Care_Organizer.Repositories;
using Pet_Care_Organizer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class AppointmentsControllerTests
{
    private readonly Mock<IAppointmentRepository> _mockRepo;
    private readonly AppointmentsController _controller;

    public AppointmentsControllerTests()
    {
        _mockRepo = new Mock<IAppointmentRepository>();
        _controller = new AppointmentsController(_mockRepo.Object);
    }

    [Fact]
    public void Index_ReturnsView_WithCorrectModelAndDays()
    {
        // Arrange
        var appointments = new List<Appointments>
        {
            new Appointments { Id = 1, Title = "Vet" }
        };
        _mockRepo.Setup(r => r.GetAll()).Returns(appointments);

        // Act
        var result = _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<AppointmentsViewModel>(viewResult.Model);

        Assert.Equal(appointments, model.Appointments);
        Assert.Equal(8, model.Days.Count); // Today + 7 days
        Assert.True(model.Days[0].Date == DateTime.Now.Date);
        Assert.True(model.Days[7].Date == DateTime.Now.AddDays(7).Date);
    }

    [Fact]
    public void Index_ReturnsView_WithEmptyAppointments()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetAll()).Returns(new List<Appointments>());

        // Act
        var result = _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<AppointmentsViewModel>(viewResult.Model);

        Assert.Empty(model.Appointments);
        Assert.Equal(8, model.Days.Count);
    }

    [Fact]
    public void AddAppointment_ValidModel_CallsAddAndRedirects()
    {
        // Arrange
        var appointment = new Appointments { Id = 2, Title = "Grooming" };

        // Act
        var result = _controller.AddAppointment(appointment);

        // Assert
        _mockRepo.Verify(r => r.Add(appointment), Times.Once);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public void AddAppointment_InvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        _controller.ModelState.AddModelError("Title", "Required");
        var appointment = new Appointments();

        // Act
        var result = _controller.AddAppointment(appointment);

        // Assert
        _mockRepo.Verify(r => r.Add(It.IsAny<Appointments>()), Times.Never);
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(appointment, viewResult.Model);
    }
}
