namespace BidCalculation.services;
using Models;


    public class FeeCalculatorService(
        ICommonBasicFeeCalculator commonBasicFeeCalculator,
        ILuxuryBasicFeeCalculator luxuryBasicFeeCalculator,
        ICommonSpecialFeeCalculator commonSpecialFeeCalculator,
        ILuxurySpecialFeeCalculator luxurySpecialFeeCalculator,
        IAssociationFeeCalculator associationFeeCalculator)
    {
        private readonly IAssociationFeeCalculator _associationFeeCalculator = associationFeeCalculator;

        public Vehicle CalculateFees(Vehicle vehicle)
        {
            if (vehicle is CommonVehicle)
            {
                vehicle.BasicFee = commonBasicFeeCalculator.CalculateBasicFee(vehicle.BasePrice);
                vehicle.SpecialFee = commonSpecialFeeCalculator.CalculateSpecialFee(vehicle.BasePrice);
            }
            else if (vehicle is LuxuryVehicle)
            {
                vehicle.BasicFee = luxuryBasicFeeCalculator.CalculateBasicFee(vehicle.BasePrice);
                vehicle.SpecialFee = luxurySpecialFeeCalculator.CalculateSpecialFee(vehicle.BasePrice);
            }

            vehicle.AssociationFee = _associationFeeCalculator.CalculateAssociationFee(vehicle.BasePrice);
            vehicle.TotalPrice = vehicle.BasePrice + vehicle.BasicFee + vehicle.SpecialFee + vehicle.AssociationFee + vehicle.StorageFee;
            return vehicle;
        }
    }