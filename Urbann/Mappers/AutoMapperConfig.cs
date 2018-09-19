using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urbann.Data;
using Urbann.Models;

namespace Urbann.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Place, PlaceDto>()
                //.ForPath(x => x.Address.Country, y => y.MapFrom(z => z.Address.Country.Name))
                //.ForPath(x => x.Address.City, y => y.MapFrom(z => z.Address.City))
                //.ForPath(x => x.Address.Street, y => y.MapFrom(z => z.Address.Street))
                //.ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Name))
                //.ForMember(x => x.Photos;

                cfg.CreateMap<Place, PlaceDto>()
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Name));
            
         
                
                cfg.CreateMap<Address, AddressDto>()
                .ForMember(x => x.Country, y => y.MapFrom(z => z.Country.Name));
                cfg.CreateMap<Photo, PhotoDto>()
                .ForMember(x =>x.Url, y => y.MapFrom(z => z.FileName));

                //.ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Category.Name))



                //cfg.CreateMap<Photo, PhotoDto>()
                //.ForMember(x =>x.Url, y => y.MapFrom(z => z.FileName));



            })
            .CreateMapper();
    }
}
