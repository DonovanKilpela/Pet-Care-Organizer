using Xunit;
using Pet_Care_Organizer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pet_Care_OrganizerTests.Models
{
    public class AppointmentsModelTests
    {
        private List<ValidationResult> ValidateModel(Appointments model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void Model_Valid_When_AllPropertiesAreValid()
        {
            var model = new Appointments
            {
                Date = DateTime.Now,
                Title = "Vet Visit"
            };

            var results = ValidateModel(model);

            Assert.Empty(results);
        }

        [Fact]
        public void Model_Invalid_When_TitleMissing()
        {
            var model = new Appointments
            {
                Date = DateTime.Now,
                Title = ""
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Title"));
        }

        [Fact]
        public void Model_Invalid_When_TitleTooShort()
        {
            var model = new Appointments
            {
                Date = DateTime.Now,
                Title = "A"
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Title"));
        }

        [Fact]
        public void Model_Invalid_When_TitleTooLong()
        {
            var model = new Appointments
            {
                Date = DateTime.Now,
                Title = new string('X', 101)
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Title"));
        }
    }
}
