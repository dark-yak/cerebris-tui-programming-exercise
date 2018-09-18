namespace Flight.Domain.Tests
{
    using System;
    using Tui.Flight.Domain.Services;
    using Xunit;

    public class DistanceServiceTests
    {
        // Based on https://gps-coordinates.org/distance-between-coordinates.php

        [Theory]
        [InlineData(40.7648, -73.9808, 48.859489, 2.320582, 'M', 3622.50)] // NYC - PARIS
        [InlineData(35.658611111111, 139.74555555556, 19.590615, -155.424133, 'M', 4048.83)] // TOKYO - HAWAI
        public void TestDistance(Double latitude1, Double longitude1, Double latitude2, Double longitude2, Char unit, double expectedDistance)
        {
            // Arrange
            DistanceService distanceService = new DistanceService();

            // Act
            double computedDistance = distanceService.Distance(latitude1, longitude1, latitude2, longitude2, unit);

            // Assert
            // Due to approximation, we roundup to the integer
            Assert.Equal((Int32)computedDistance, (Int32)expectedDistance);
        }
    }
}
