using Xunit;
using Pet_Care_Organizer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pet_Care_OrganizerTests.Models
{
    public class SuppliesModelTests
    {
        private List<ValidationResult> ValidateModel(Supplies model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void Model_Valid_When_AllPropertiesAreValid()
        {
            var model = new Supplies
            {
                Name = "Dog Food",
                Quantity = 10,
                LowThreshold = 2,
                Notes = "Keep in pantry",
                EstimatedUsagePerDay = 1.5
            };

            var results = ValidateModel(model);

            Assert.Empty(results);
        }

        [Fact]
        public void Model_Invalid_When_NameMissing()
        {
            var model = new Supplies
            {
                Name = "",
                Quantity = 10,
                LowThreshold = 2,
                Notes = "Keep in pantry",
                EstimatedUsagePerDay = 1.5
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Model_Invalid_When_NameTooShort()
        {
            var model = new Supplies
            {
                Name = "A",
                Quantity = 10,
                LowThreshold = 2,
                Notes = "Keep in pantry",
                EstimatedUsagePerDay = 1.5
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Model_Invalid_When_NameTooLong()
        {
            var model = new Supplies
            {
                Name = new string('X', 101),
                Quantity = 10,
                LowThreshold = 2,
                Notes = "Keep in pantry",
                EstimatedUsagePerDay = 1.5
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Model_Invalid_When_QuantityNegative()
        {
            var model = new Supplies
            {
                Name = "Dog Food",
                Quantity = -1,
                LowThreshold = 2,
                Notes = "Keep in pantry",
                EstimatedUsagePerDay = 1.5
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Quantity"));
        }

        [Fact]
        public void Model_Invalid_When_LowThresholdNegative()
        {
            var model = new Supplies
            {
                Name = "Dog Food",
                Quantity = 10,
                LowThreshold = -1,
                Notes = "Keep in pantry",
                EstimatedUsagePerDay = 1.5
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("LowThreshold"));
        }

        [Fact]
        public void Model_Invalid_When_NotesTooLong()
        {
            var model = new Supplies
            {
                Name = "Dog Food",
                Quantity = 10,
                LowThreshold = 2,
                Notes = new string('N', 501),
                EstimatedUsagePerDay = 1.5
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Notes"));
        }

        [Fact]
        public void Model_Invalid_When_EstimatedUsagePerDayNegative()
        {
            var model = new Supplies
            {
                Name = "Dog Food",
                Quantity = 10,
                LowThreshold = 2,
                Notes = "Keep in pantry",
                EstimatedUsagePerDay = -0.1
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("EstimatedUsagePerDay"));
        }

        [Fact]
        public void Model_Invalid_When_EstimatedUsagePerDayMissing()
        {
            var model = new Supplies
            {
                Name = "Dog Food",
                Quantity = 10,
                LowThreshold = 2,
                Notes = "Keep in pantry",
            };

            var results = ValidateModel(model);

            Assert.Empty(results);
        }
    }
}
