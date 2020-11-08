using FluentAssertions;
using NUnit.Framework;
using StarWars.Common.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace StarWars.Common.Tests.Extensions
{
    [TestFixture]
    public class ExpressionExtensionsTests
    {
        [Test]
        public void GetExpressionPath_Should_Return_Path_As_String()
        {
            // Arrange
            Expression<Func<TestModel, object>> expression = TestModel.ListObjectExpression;

            // Act
            string result = expression.GetExpressionPath();

            // Assert
            result.Should().Be("Elements.Object");
        }

        [Test]
        public void ShouldEqual_Should_Create_Equality_Expression()
        {
            // Arrange
            int expectedEqualityValue = 5;

            var testModel = new TestModel() { Key = expectedEqualityValue };

            // Act
            Expression<Func<TestModel, bool>> equalityExpression = TestModel.KeyExpression.ShouldEqual(expectedEqualityValue);

            bool result = equalityExpression.Compile().Invoke(testModel);

            // Assert
            result.Should().BeTrue();
        }
    }
}