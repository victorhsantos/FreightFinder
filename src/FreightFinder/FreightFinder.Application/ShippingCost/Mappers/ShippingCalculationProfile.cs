using AutoMapper;
using FreightFinder.Application.DTOs;
using FreightFinder.Integration.MelhorEnvio.Models;

namespace FreightFinder.Application.ShippingCost.Mappers
{
    public class ShippingCalculationProfile : Profile
    {
        public ShippingCalculationProfile()
        {
            CreateMap<ShipmentResponse, ShippingCalculationDetails>()
                .ForPath(dest => dest.Name, o => o.MapFrom(src => src.Name))
                .ForPath(dest => dest.Price, o => o.MapFrom(src => src.Price))
                .ForPath(dest => dest.CustomPrice, o => o.MapFrom(src => src.CustomPrice))
                .ForPath(dest => dest.Discount, o => o.MapFrom(src => src.Discount))
                .ForPath(dest => dest.Currency, o => o.MapFrom(src => src.Currency))
                .ForPath(dest => dest.DeliveryTime, o => o.MapFrom(src => src.DeliveryTime))
                .ForPath(dest => dest.DeliveryRange, o => o.MapFrom(src => src.DeliveryRange))
                .ForPath(dest => dest.CustomDeliveryTime, o => o.MapFrom(src => src.CustomDeliveryTime))
                .ForPath(dest => dest.Company.Name, o => o.MapFrom(src => src.Company.Name))
                .ForPath(dest => dest.Company.Picture, o => o.MapFrom(src => src.Company.Picture));

            CreateMap<ShippingCalculationRequestDTO, ShipmentRequest>()
                .AddTransform<string>(s => string.IsNullOrEmpty(s) ? string.Empty : s)
                .ForPath(dest => dest.from.postal_code, o => o.MapFrom(src => src.Route.OriginPostalCode))
                .ForPath(dest => dest.to.postal_code, o => o.MapFrom(src => src.Route.DestinationPostalCode))
                .ForPath(dest => dest.package.width, o => o.MapFrom(src => src.Package.Width))
                .ForPath(dest => dest.package.height, o => o.MapFrom(src => src.Package.Height))
                .ForPath(dest => dest.package.length, o => o.MapFrom(src => src.Package.Length))
                .ForPath(dest => dest.package.weight, o => o.MapFrom(src => src.Package.Weight));
        }
    }
}
