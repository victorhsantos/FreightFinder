namespace FreightFinder.Application.DTOs
{
    public class ShippingCalculationResponseDTO
    {
        public List<ShippingCalculationDetails> Shippings;
    }

    public class ShippingCalculationDetails
    {
        public string Name { get; set; } = default!;
        public string Price { get; set; } = default!;
        public string CustomPrice { get; set; } = default!;
        public string Discount { get; set; } = default!;
        public string Currency { get; set; } = default!;
        public int DeliveryTime { get; set; }
        public DeliveryRange DeliveryRange { get; set; } = default!;
        public int CustomDeliveryTime { get; set; }
        public DeliveryRange CustomDeliveryRange { get; set; } = default!;
        public Company Company { get; set; } = default!;
    }

    public class DeliveryRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Company
    {
        public string Name { get; set; } = default!;
        public string Picture { get; set; } = default!;
    }
}
