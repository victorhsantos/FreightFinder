namespace FreightFinder.Integration.MelhorEnvio.Models
{
    using System.Collections.Generic;

    public class ShipmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Price { get; set; } = default!;
        public string CustomPrice { get; set; } = default!;
        public string Discount { get; set; } = default!;
        public string Currency { get; set; } = default!;
        public int DeliveryTime { get; set; }
        public DeliveryRange DeliveryRange { get; set; } = default!;
        public int CustomDeliveryTime { get; set; }
        public DeliveryRange CustomDeliveryRange { get; set; } = default!;
        public List<Package> Packages { get; set; } = default!;
        public AdditionalServices AdditionalServices { get; set; } = default!;
        public Additional Additional { get; set; } = default!;
        public Company Company { get; set; } = default!;
        public string Error { get; set; } = default!; // Pode ser nulo, dependendo da resposta
    }

    public class DeliveryRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Package
    {
        public string Price { get; set; } = default!;
        public string Discount { get; set; } = default!;
        public string Format { get; set; } = default!;
        public string Weight { get; set; } = default!;
        public string InsuranceValue { get; set; } = default!;
        public Dimensions Dimensions { get; set; } = default!;
    }

    public class Dimensions
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }

    public class AdditionalServices
    {
        public bool Receipt { get; set; }
        public bool OwnHand { get; set; }
        public bool Collect { get; set; }
    }

    public class Additional
    {
        public Unit Unit { get; set; } = default!;
    }

    public class Unit
    {
        public int Price { get; set; }
        public int Delivery { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Picture { get; set; } = default!;
    }


}
