namespace FreightFinder.Application.DTOs
{
    public class ShippingCalculationRequestDTO
    {
        public string OriginZipCode { get; set; } = default!;
        public string DestinationZipCode { get; set; } = default!;
        public decimal Weight { get; set; }  // Weight in kg
        public string PackageFormat { get; set; } = default!;  // Options: 'Box', 'Roll', 'Envelope'
        public decimal Length { get; set; }  // Length in centimeters
        public decimal Height { get; set; }  // Height in centimeters
        public decimal Width { get; set; }  // Width in centimeters
        public decimal Diameter { get; set; }  // Diameter in centimeters (only for 'Roll')
        public string ServiceType { get; set; } = default!;  // Service type, e.g., 'SEDEX', 'PAC'
        public decimal? DeclaredValue { get; set; }  // Optional, declared value for insurance
        public bool ReceiptNotice { get; set; }  // Optional, if receipt notice is required
    }

}
