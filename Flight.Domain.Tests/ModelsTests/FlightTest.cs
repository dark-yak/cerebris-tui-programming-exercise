namespace Flight.Domain.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tui.Flight.Domain.Models;
    using Tui.Flight.Domain.Services;
    using Xunit;
    using Xunit.Extensions;

    public class FlightTests
    {
        [Theory]
        [MemberData(nameof(TestComputeFuelConsumptionData)) ]        
        public void TestComputeFuelConsumption(Flight flight, Double expectedFuelConsumption)
        {
            // Arrange (nothing to do)

            // Act
            double computedFuelConsumption = flight.ComputeFuelConsumption();

            // Assert
            Assert.Equal((Int32)computedFuelConsumption, (Int32)expectedFuelConsumption);
        }

        public static IEnumerable<Object[]> TestComputeFuelConsumptionData
        {
            get
                {
                return new List<Object[]> {
                        new Object[]
                        {
                            new Flight(
                                new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999),
                                new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971),
                                new Aircraft("OO-JAA", "FREE FLIGHT", 0, 0) // Super aircraft, no consumption at all
                                ),
                            0
                        },
                        new Object[]
                        {
                            new Flight(
                                new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999),
                                new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971),
                                new Aircraft("OO-SPC", "SPACE SHUTTLE", 0, 100) // Only consumption at takeoff then nothing in space
                                ),
                            100
                        },
                        new Object[]
                        {
                            new Flight(
                                new Airport("HND", "Tokyo Haneda International Airport (Japan)", 35.552299, 139.779999),
                                new Airport("LAX", "Los Angeles International Airport (United States)", 33.94250107, -118.4079971),
                                new Aircraft("OO-JAA", "VICTORY", 10, 100) // Standard aircraft
                                ),
                            5475.50 /* Distance */ * 10.0 + 100.0
                        }
                };
            }
        }
    }
}
