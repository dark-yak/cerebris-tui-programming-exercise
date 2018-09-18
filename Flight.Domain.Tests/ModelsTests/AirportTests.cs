namespace Flight.Domain.Tests
{
    using System;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Xunit;

    public class AirportTests
    {
        [Theory]
        [MemberData(nameof(TestDistanceData)) ]        
        public void TestDistance(Airport departureAirport, Airport destinationAirport, Double expectedDistance)
        {
            // Arrange (nothing to do)

            // Act
            double computedDistance1 = departureAirport.GetDistance(destinationAirport);
            double computedDistance2 = destinationAirport.GetDistance(departureAirport);

            // Assert
            // Due to approximation, we roundup to the integer
            Assert.Equal((Int32)computedDistance1, (Int32)expectedDistance);
            Assert.Equal((Int32)computedDistance2, (Int32)expectedDistance);
        }

        public static IEnumerable<Object[]> TestDistanceData
        {
            get
                {
                return new List<Object[]> {
                        new Object[]
                        {
                            new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999),
                            new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971),
                            5475.50
                        },
                        new Object[]
                        {
                            new Airport("CDG", "Charles de Gaulle International Airport (France)", 49.0127983093, 2.54999995232),
                            new Airport("DCA", "Ronald Reagan Washington National Airport (United States)", 38.8521, -77.037697),
                            3837.37
                        }
                        };
                
            }
        }
    }
}
