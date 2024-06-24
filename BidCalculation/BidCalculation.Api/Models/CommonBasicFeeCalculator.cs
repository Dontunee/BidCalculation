namespace BidCalculation.Api.Models;

public class CommonBasicFeeCalculator : ICommonBasicFeeCalculator
{
    public decimal CalculateBasicFee(decimal basePrice)
    {
        decimal fee = basePrice * 0.10m;
        return Math.Clamp(fee, 10, 50);
    }
}

public class LuxuryBasicFeeCalculator : ILuxuryBasicFeeCalculator
{
    public decimal CalculateBasicFee(decimal basePrice)
    {
        decimal fee = basePrice * 0.10m;
        return Math.Clamp(fee, 25, 200);
    }
}

public class CommonSpecialFeeCalculator : ICommonSpecialFeeCalculator
{
    public decimal CalculateSpecialFee(decimal basePrice)
    {
        return basePrice * 0.02m;
    }
}

public class LuxurySpecialFeeCalculator : ILuxurySpecialFeeCalculator
{
    public decimal CalculateSpecialFee(decimal basePrice)
    {
        return basePrice * 0.04m;
    }
}

public class AssociationFeeCalculator : IAssociationFeeCalculator
{
    public decimal CalculateAssociationFee(decimal basePrice)
    {
        if (basePrice <= 500)
        {
            return 5;
        }
        if (basePrice <= 1000)
        {
            return 10;
        }
        if (basePrice <= 3000)
        {
            return 15;
        }
        return 20;
    }
}



