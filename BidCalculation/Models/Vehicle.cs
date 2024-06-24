namespace BidCalculation.Models;

public abstract class Vehicle
{
    public decimal BasePrice { get; set; }
    public decimal BasicFee { get; set; }
    public decimal SpecialFee { get; set; }
    public decimal AssociationFee { get; set; }
    public decimal StorageFee { get; set; } = 100;
    public decimal TotalPrice { get; set; }
}

public class CommonVehicle : Vehicle {}

public class LuxuryVehicle : Vehicle {}