namespace BidCalculation.Api.Models;

public interface IBasicFeeCalculator
{
    decimal CalculateBasicFee(decimal basePrice);
}

public interface ICommonBasicFeeCalculator : IBasicFeeCalculator { }

public interface ILuxuryBasicFeeCalculator : IBasicFeeCalculator { }

public interface ISpecialFeeCalculator
{
    decimal CalculateSpecialFee(decimal basePrice);
}


public interface ICommonSpecialFeeCalculator : ISpecialFeeCalculator { }

public interface ILuxurySpecialFeeCalculator : ISpecialFeeCalculator { }

public interface IAssociationFeeCalculator
{
    decimal CalculateAssociationFee(decimal basePrice);
}
