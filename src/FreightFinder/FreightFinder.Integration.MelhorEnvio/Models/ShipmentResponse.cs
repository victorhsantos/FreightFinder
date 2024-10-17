namespace FreightFinder.Integration.MelhorEnvio.Models
{
    using System.Collections.Generic;

    public class ShipmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string CustomPrice { get; set; }
        public string Discount { get; set; }
        public string Currency { get; set; }
        public int DeliveryTime { get; set; }
        public DeliveryRange DeliveryRange { get; set; }
        public int CustomDeliveryTime { get; set; }
        public DeliveryRange CustomDeliveryRange { get; set; }
        public List<Package> Packages { get; set; }
        public AdditionalServices AdditionalServices { get; set; }
        public Additional Additional { get; set; }
        public Company Company { get; set; }
        public string Error { get; set; } // Pode ser nulo, dependendo da resposta
    }

    public class DeliveryRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class Package
    {
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Format { get; set; }
        public string Weight { get; set; }
        public string InsuranceValue { get; set; }
        public Dimensions Dimensions { get; set; }
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
        public Unit Unit { get; set; }
    }

    public class Unit
    {
        public int Price { get; set; }
        public int Delivery { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }


}
