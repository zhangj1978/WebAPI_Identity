using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ConcordyaPayee.Model.Entities;
using ConcordyaPayee.Web.Api.Models;

namespace ConcordyaPayee.Web.Api.Mappers
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoryModel, Category>();
            Mapper.CreateMap<VendorModel,Vendor>();
            Mapper.CreateMap<RecurringSettingModel, RecurringSetting>();
            Mapper.CreateMap<BillModel, Bill>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(source => source.Amount))
                .ForMember(dest => dest.BillItems, opt => opt.MapFrom(source => source.Items))
                .ForMember(dest => dest.Vendor, opt => opt.MapFrom<VendorModel>(s => s.Vendor))
                .ForMember(dest => dest.RecurringSetting, opt => opt.MapFrom<RecurringSettingModel>(s => s.RecurringSetting));
            Mapper.CreateMap<BillItemModel, BillItem>();
        }
    }
}