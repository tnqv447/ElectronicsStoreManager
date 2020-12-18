using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AppCore.Models
{
    public class StorageChecker
    {
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public StorageChecker(int itemId, int amount, DateTime date)
        {
            ItemId = itemId;
            Amount = amount;
            OrderDate = date;
        }
    }
    public struct ComboChild
    {
        public Item Item { get; set; }
        public int Amount { get; set; }

        public ComboChild(Item item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
    public struct ItemType
    {
        public ITEM_TYPE Type { get; set; }
        public string TypeName { get; set; }

        public ItemType(ITEM_TYPE type, string typeName)
        {
            Type = type;
            TypeName = typeName;
        }
    }
    public struct OrderStatus
    {
        public ORDER_STATUS? Status { get; set; }
        public string StatusName { get; set; }

        public OrderStatus(ORDER_STATUS? status, string statusName)
        {
            Status = status;
            StatusName = statusName;
        }
    }
    public class ListEnum
    {
        public static IList<ItemType> GetListItemType(){
            var list = new List<ItemType>();

            list.Add(new ItemType(ITEM_TYPE.HOUSEWARE, EnumConverter.Convert(ITEM_TYPE.HOUSEWARE)));
            list.Add(new ItemType(ITEM_TYPE.LAPTOP, EnumConverter.Convert(ITEM_TYPE.LAPTOP)));
            list.Add(new ItemType(ITEM_TYPE.SMART_PHONE, EnumConverter.Convert(ITEM_TYPE.SMART_PHONE)));
            list.Add(new ItemType(ITEM_TYPE.MONITOR, EnumConverter.Convert(ITEM_TYPE.MONITOR)));
            list.Add(new ItemType(ITEM_TYPE.TV, EnumConverter.Convert(ITEM_TYPE.TV)));
            list.Add(new ItemType(ITEM_TYPE.MOUSE_AND_KEYBOARD, EnumConverter.Convert(ITEM_TYPE.MOUSE_AND_KEYBOARD)));
            list.Add(new ItemType(ITEM_TYPE.PC, EnumConverter.Convert(ITEM_TYPE.PC)));
            list.Add(new ItemType(ITEM_TYPE.COMPUTER_COMPONENTS, EnumConverter.Convert(ITEM_TYPE.COMPUTER_COMPONENTS)));
            list.Add(new ItemType(ITEM_TYPE.OFFICE_DEVICES, EnumConverter.Convert(ITEM_TYPE.OFFICE_DEVICES)));
            list.Add(new ItemType(ITEM_TYPE.INTERNET_DEVICES, EnumConverter.Convert(ITEM_TYPE.INTERNET_DEVICES)));
            list.Add(new ItemType(ITEM_TYPE.SOUND_DEVICES, EnumConverter.Convert(ITEM_TYPE.SOUND_DEVICES)));
            list.Add(new ItemType(ITEM_TYPE.MISC, EnumConverter.Convert(ITEM_TYPE.MISC)));
            
            return list;
        }
        public static IList<OrderStatus> GetListOrderStatus(bool forSearch = false){
            var list = new List<OrderStatus>();
            if(forSearch) list.Add(new OrderStatus(null, "All"));
            list.Add(new OrderStatus(ORDER_STATUS.NEW, EnumConverter.Convert(ORDER_STATUS.NEW)));
            list.Add(new OrderStatus(ORDER_STATUS.CHECKED, EnumConverter.Convert(ORDER_STATUS.CHECKED)));
            list.Add(new OrderStatus(ORDER_STATUS.DELIVERING, EnumConverter.Convert(ORDER_STATUS.DELIVERING)));
            list.Add(new OrderStatus(ORDER_STATUS.DELIVERED, EnumConverter.Convert(ORDER_STATUS.DELIVERED)));
            list.Add(new OrderStatus(ORDER_STATUS.CANCELLED, EnumConverter.Convert(ORDER_STATUS.CANCELLED)));
            list.Add(new OrderStatus(ORDER_STATUS.CANCELLED_DELIVERY, EnumConverter.Convert(ORDER_STATUS.CANCELLED_DELIVERY)));
            
            return list;
        }
    }
    public class EnumConverter
    {
        public static string Convert(CUSTOMER_STATUS status)
        {
            switch (status)
            {
                case CUSTOMER_STATUS.ACTIVE: return "Activated";
                case CUSTOMER_STATUS.DISABLED: return "Blocked";
                default: return "";
            }
        }
        public static string Convert(ITEM_STATUS status)
        {
            switch (status)
            {
                case ITEM_STATUS.ACTIVE: return "Activated";
                case ITEM_STATUS.DISABLED: return "Blocked";
                default: return "";
            }
        }
        public static string Convert(ORDER_STATUS status)
        {
            switch (status)
            {
                case ORDER_STATUS.NEW: return "Order received";
                case ORDER_STATUS.CHECKED: return "Processed";
                case ORDER_STATUS.DELIVERING: return "Shipping";
                case ORDER_STATUS.DELIVERED: return "Completed";
                case ORDER_STATUS.CANCELLED: return "Canceled";
                case ORDER_STATUS.CANCELLED_DELIVERY: return "Cancelled shipping";
                default: return "";
            }
        }
        public static string Convert(SEX sex)
        {
            switch (sex)
            {
                case SEX.FEMALE: return "Female";
                case SEX.MALE: return "Male";
                case SEX.OTHER: return "Others";
                default: return "";
            }
        }
        public static string Convert(ITEM_TYPE type)
        {
            switch (type)
            {
                case ITEM_TYPE.MISC: return "Others";
                case ITEM_TYPE.COMBO: return "Combo";
                case ITEM_TYPE.HOUSEWARE: return "Electric Houseware";
                case ITEM_TYPE.LAPTOP: return "Laptop";
                case ITEM_TYPE.SMART_PHONE: return "Smart Phone";
                case ITEM_TYPE.MONITOR: return "Computer Screen";
                case ITEM_TYPE.TV: return "TV";
                case ITEM_TYPE.MOUSE_AND_KEYBOARD: return "Mouse and Keyboard";
                case ITEM_TYPE.PC: return "Desktop";
                case ITEM_TYPE.COMPUTER_COMPONENTS: return "Computer Components";
                case ITEM_TYPE.OFFICE_DEVICES: return "Office Equipment";
                case ITEM_TYPE.INTERNET_DEVICES: return "Network equipment, wifi";
                case ITEM_TYPE.SOUND_DEVICES: return "Audio Devices";
                default: return "";
            }
        }
    }
    public enum ITEM_TYPE
    {
        [Display(Name = "Other")]
        MISC,
        [Display(Name = "Combo")]
        COMBO,
        [Display(Name = "Houseware")]
        HOUSEWARE,
        [Display(Name = "Laptop")]
        LAPTOP,
        [Display(Name = "Smart Phone")]
        SMART_PHONE,
        [Display(Name = "Computer Screen")]
        MONITOR,
        [Display(Name = "TV")]
        TV,
        [Display(Name = "Mouse and Keyboard")]
        MOUSE_AND_KEYBOARD,
        [Display(Name = "Desktop")]
        PC,
        [Display(Name = "Computer Components")]
        COMPUTER_COMPONENTS,
        [Display(Name = "Office Equipment")]
        OFFICE_DEVICES,
        [Display(Name = "Network equipment, wifi")]
        INTERNET_DEVICES,
        [Display(Name = "Audio Devices")]
        SOUND_DEVICES
    }

    public enum ORDER_STATUS
    {
        NEW,
        CHECKED,
        DELIVERING,
        DELIVERED,
        CANCELLED,
        CANCELLED_DELIVERY
    }
    public enum SEX
    {
        MALE,
        FEMALE,
        OTHER
    }
    public enum CUSTOMER_STATUS
    {
        ACTIVE,
        DISABLED
    }
    public enum ITEM_STATUS
    {
        ACTIVE,
        DISABLED
    }


}