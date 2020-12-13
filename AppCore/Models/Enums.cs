using System;
using System.Linq.Expressions;
namespace AppCore.Models
{
    public struct StorageChecker{
        public int ItemId { get; set; }
        public int Amount { get; set; }

        public StorageChecker(int itemId, int amount){
            ItemId = itemId;
            Amount = amount;
        }
    }
    public class EnumConverter
    {
        public static string Convert(CUSTOMER_STATUS status)
        {
            switch (status)
            {
                case CUSTOMER_STATUS.ACTIVE: return "Mở";
                case CUSTOMER_STATUS.DISABLED: return "Khóa";
                default: return "";
            }
        }
        public static string Convert(ITEM_STATUS status)
        {
            switch (status)
            {
                case ITEM_STATUS.ACTIVE: return "Mở";
                case ITEM_STATUS.DISABLED: return "Khóa";
                default: return "";
            }
        }
        public static string Convert(ORDER_STATUS status)
        {
            switch (status)
            {
                case ORDER_STATUS.NEW: return "Chờ xác nhận";
                case ORDER_STATUS.CHECKED: return "Đã xác nhận";
                case ORDER_STATUS.DELIVERING: return "Đang giao hàng";
                case ORDER_STATUS.DELIVERED: return "Đã giao hàng";
                default: return "";
            }
        }
        public static string Convert(SEX sex)
        {
            switch (sex)
            {
                case SEX.FEMALE: return "Nữ";
                case SEX.MALE: return "Nam";
                case SEX.OTHER: return "Khác";
                default: return "";
            }
        }
    }
    public enum ITEM_TYPE
    {
        
    }
    
    public enum ORDER_STATUS
    {
        NEW,
        CHECKED,
        DELIVERING,
        DELIVERED,
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