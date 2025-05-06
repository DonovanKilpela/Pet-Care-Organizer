using Xunit;
using Pet_Care_Organizer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pet_Care_OrganizerTests.Models
{
    public class DailyTasksModelTests
    {
        private List<ValidationResult> ValidateModel(DailyTasks model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void Model_Valid_When_AllPropertiesAreValid()
        {
            var model = new DailyTasks
            {
                Description = "Feed the cat",
                StatusId = "Done"
            };

            var results = ValidateModel(model);

            Assert.Empty(results);
        }

        [Fact]
        public void Model_Invalid_When_DescriptionMissing()
        {
            var model = new DailyTasks
            {
                Description = "",
                StatusId = "Done"
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Description"));
        }

        [Fact]
        public void Model_Invalid_When_DescriptionTooShort()
        {
            var model = new DailyTasks
            {
                Description = "A", // Too short
                StatusId = "Done"
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Description"));
        }

        [Fact]
        public void Model_Invalid_When_DescriptionTooLong()
        {
            var model = new DailyTasks
            {
                Description = new string('A', 201), // Too long
                StatusId = "Done"
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Description"));
        }

        [Fact]
        public void Model_Invalid_When_StatusIdMissing()
        {
            var model = new DailyTasks
            {
                Description = "Feed the cat",
                StatusId = ""
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("StatusId"));
        }

        [Fact]
        public void Model_Invalid_When_StatusIdTooLong()
        {
            var model = new DailyTasks
            {
                Description = "Feed the cat",
                StatusId = "ThisIsWayTooLong" // >10 chars
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("StatusId"));
        }
    }
}
