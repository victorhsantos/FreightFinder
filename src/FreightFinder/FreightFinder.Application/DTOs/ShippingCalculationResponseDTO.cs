namespace FreightFinder.Application.DTOs
{
    public class ShippingCalculationResponseDTO
    {
        public decimal ShippingCost { get; set; }  // Estimated shipping cost
        public int DeliveryTime { get; set; }  // Delivery time in business days
        public decimal? InsuranceCost { get; set; }  // Additional cost for insurance, if applicable
        public string ServiceType { get; set; } = default!;  // Confirmed service type used
    }

}
