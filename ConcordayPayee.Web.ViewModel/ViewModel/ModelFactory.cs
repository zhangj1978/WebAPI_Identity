using ConcordyaPayee.Core.Common;
using ConcordyaPayee.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcordayPayee.Web.ViewModel
{
    public class ModelFactory
    {
        #region BillItem
        public static BillItemModel Create(BillItem entity)
        {
            var dto = new BillItemModel();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Total = entity.Total;
            dto.PricePerUnit = entity.PricePerUnit;
            dto.Quantity = entity.Quantity;
            dto.BillId = entity.BillId;
            //dto.CreatedBy = entity.CreatedBy;
            //dto.CreatedOn = entity.CreatedOn;
            //dto.LastUpdatedBy = entity.LastUpdatedBy;
            //dto.LastUpdatedOn = entity.LastUpdatedOn;
            return dto;
        }

        public static BillItem Create(BillItemModel dto)
        {
            var entity = new BillItem();
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Total = dto.Total;
            entity.PricePerUnit = dto.PricePerUnit;
            entity.Quantity = dto.Quantity;
            entity.BillId = dto.BillId;
            //entity.CreatedBy = dto.CreatedBy;
            //entity.CreatedOn = dto.CreatedOn;
            //entity.LastUpdatedBy = dto.LastUpdatedBy;
            //entity.LastUpdatedOn = dto.LastUpdatedOn;
            return entity;
        }
        #endregion

        #region Bill
        public static Bill Create(BillModel dto)
        {
            var entity = new Bill();
            entity.Id = dto.Id;
            entity.BillNumber = dto.BillNumber;
            entity.BillDate = dto.BillDate;
            entity.DueDate = dto.DueDate;
            entity.Description = dto.Description;
            entity.TotalAmount = dto.Amount;
            entity.CreatedBy = dto.CreatedBy;
            entity.CreatedOn = dto.CreatedOn;
            entity.IsRecurring = dto.IsRecurring;
            entity.CreatedOn = dto.CreatedOn;
            entity.CreatedBy = dto.CreatedBy;
            entity.LastUpdatedBy = dto.LastUpdatedBy;
            entity.LastUpdatedOn = dto.LastUpdatedOn;
            entity.BillStatus = dto.Status;
            entity.VendorId = dto.Vendor.Id;
            entity.Vendor = Create(dto.Vendor);
            entity.CategoryId = dto.Category.Id;
            entity.Category = Create(dto.Category);
            
            if (dto.Items != null && dto.Items.Count > 0)
            {
                entity.BillItems = new List<BillItem>(dto.Items.Count);
                foreach (var dItem in dto.Items)
                {
                    var eItem = Create(dItem);
                    entity.BillItems.Add(eItem);
                }
            }
            else
            {
                entity.BillItems = null;
            }
            //TODO: recurring
            return entity;
        }

        public static BillModel Create(Bill entity)
        {
            var dto = new BillModel();
            dto.Id = entity.Id;
            dto.BillNumber = entity.BillNumber;
            dto.BillDate = entity.BillDate;
            dto.DueDate = entity.DueDate;
            dto.Description = entity.Description;
            dto.Amount = entity.TotalAmount;
            dto.Vendor = Create(entity.Vendor);
            dto.Category = Create(entity.Category);
            
            dto.CreatedBy = entity.CreatedBy;
            dto.CreatedOn = entity.CreatedOn;
            dto.IsRecurring = entity.IsRecurring;
            dto.LastUpdatedBy = entity.LastUpdatedBy;
            dto.LastUpdatedOn = entity.LastUpdatedOn;
            dto.Status = entity.BillStatus;

            if (entity.BillItems != null && entity.BillItems.Count >0)
            {
                dto.Items = new List<BillItemModel>(entity.BillItems.Count);
                foreach (var eItem in entity.BillItems)
                {
                    var dItem = Create(eItem);
                    dto.Items.Add(dItem);
                }
            }
            else
            {
                dto.Items = null;
            }
            //TODO: recurring

            return dto;
        }
        #endregion

        #region Recurring
        public static RecurringSetting Create(RecurringSettingModel dto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Category
        public static Category Create(CategoryModel dto)
        {
            AutoMapper.Mapper.CreateMap<CategoryModel, Category>();
            var e = AutoMapper.Mapper.Map<CategoryModel, Category>(dto);
            //var e = new Category();
            //e.Id = dto.Id;
            //e.Name = dto.Name;
            //e.ParentId = dto.ParentId;
            return e;
        }

        public static CategoryModel Create(Category e)
        {
            AutoMapper.Mapper.CreateMap<Category, CategoryModel>();
            var d = AutoMapper.Mapper.Map<Category, CategoryModel>(e);
            //var d = new CategoryModel();
            //d.Id = e.Id;
            //d.Name = e.Name;
            //d.ParentId = e.ParentId;
            return d;
        }
        #endregion

        #region Vendor
        public static Vendor Create(VendorModel d)
        {
            var e = new Vendor();
            e.Id = d.Id;
            e.Name = d.Name;
            return e;
        }

        public static VendorModel Create(Vendor e)
        {
            var d = new VendorModel();
            d.Id = e.Id;
            d.Name = e.Name;
            return d;
        }
        #endregion
    }
}