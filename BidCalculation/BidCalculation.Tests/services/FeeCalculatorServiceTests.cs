using BidCalculation.Api.Models;
using BidCalculation.Api.Services;

namespace BidCalculation.Tests.services;

  [TestFixture]
    public class FeeCalculatorServiceTests
    {
        private FeeCalculatorService _feeCalculatorService;

        [SetUp]
        public void SetUp()
        {
            var commonBasicFeeCalculator = new CommonBasicFeeCalculator();
            var luxuryBasicFeeCalculator = new LuxuryBasicFeeCalculator();
            var commonSpecialFeeCalculator = new CommonSpecialFeeCalculator();
            var luxurySpecialFeeCalculator = new LuxurySpecialFeeCalculator();
            var associationFeeCalculator = new AssociationFeeCalculator();
            
            _feeCalculatorService = new FeeCalculatorService(
                commonBasicFeeCalculator,
                luxuryBasicFeeCalculator,
                commonSpecialFeeCalculator,
                luxurySpecialFeeCalculator,
                associationFeeCalculator
            );
        }

        [Test]
        [TestCase(398, "Common", 39.80, 7.96, 5.00, 100.00, 550.76)]
        [TestCase(501, "Common", 50.00, 10.02, 10.00, 100.00, 671.02)]
        [TestCase(57, "Common", 10.00, 1.14, 5.00, 100.00, 173.14)]
        [TestCase(1800, "Luxury", 180.00, 72.00, 15.00, 100.00, 2167.00)]
        [TestCase(1100, "Common", 50.00, 22.00, 15.00, 100.00, 1287.00)]
        [TestCase(1000000, "Luxury", 200.00, 40000.00, 20.00, 100.00, 1040320.00)]
        public void CalculateFees_ValidInputs_CorrectCalculation(
            decimal basePrice, string vehicleType,
            decimal expectedBasicFee, decimal expectedSpecialFee,
            decimal expectedAssociationFee, decimal expectedStorageFee,
            decimal expectedTotalPrice)
        {
            // Arrange
            Vehicle vehicle = vehicleType == "Common"
                ? new CommonVehicle { BasePrice = basePrice }
                : new LuxuryVehicle { BasePrice = basePrice } as Vehicle;

            // Act
            var calculatedVehicle = _feeCalculatorService.CalculateFees(vehicle);

            // Assert
            Assert.That(calculatedVehicle.BasicFee, Is.EqualTo(expectedBasicFee));
            Assert.That(calculatedVehicle.SpecialFee, Is.EqualTo(expectedSpecialFee));
            Assert.That(calculatedVehicle.AssociationFee, Is.EqualTo(expectedAssociationFee));
            Assert.That(calculatedVehicle.StorageFee, Is.EqualTo(expectedStorageFee));
            Assert.That(calculatedVehicle.TotalPrice, Is.EqualTo(expectedTotalPrice));
        }
    }