namespace FreightFinder.Integration.MelhorEnvio.Models
{
    public class ShipmentRequest
    {
        public FromAddress from { get; set; } = default!;
        public ToAddress to { get; set; } = default!;
        public PackageDetails package { get; set; } = default!;
    }

    public class FromAddress
    {
        public string postal_code { get; set; } = default!;
    }

    public class ToAddress
    {
        public string postal_code { get; set; } = default!;
    }

    public class PackageDetails
    {
        public int height { get; set; }
        public int width { get; set; }
        public int length { get; set; }
        public double weight { get; set; }
    }


}
