using AutoMapper;
using ConcordayPayee.Web.ViewModel;
using ConcordyaPayee.Data.Entity;
using ConcordyaPayee.Web.Api.Models;

namespace ConcordyaPayee.Web.Api.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryModel>();
            Mapper.CreateMap<Vendor, VendorModel>();
            Mapper.CreateMap<RecurringSetting, RecurringSettingModel>();
            Mapper.CreateMap<Bill, BillModel>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(source => source.TotalAmount))
                .ForMember(dest=>dest.Vendor, opt=>opt.MapFrom(source => source.Vendor))
                .ForMember(dest=> dest.Items, opt => opt.MapFrom(source => source.BillItems))
                .ForMember(dest => dest.RecurringSetting, opt => opt.MapFrom<RecurringSetting>(s => s.RecurringSetting));
            Mapper.CreateMap<BillItem, BillItemModel>();
        }
    }
}