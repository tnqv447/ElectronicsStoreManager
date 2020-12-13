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
        public static string Convert(ITEM_TYPE type)
        {
            switch (type)
            {
                case ITEM_TYPE.MISC : return "Khác";
                case ITEM_TYPE.COMBO: return "Combo";
                case ITEM_TYPE.HOUSEWARE: return "Đồ điện gia dụng";
                case ITEM_TYPE.LAPTOP: return "Laptop";
                case ITEM_TYPE.SMART_PHONE: return "Điện thoại thông minh";
                case ITEM_TYPE.MONITOR: return "Màn hình vi tính";
                case ITEM_TYPE.TV: return "TV";
                case ITEM_TYPE.MOUSE_AND_KEYBOARD: return "Chuột và vàn phím";
                case ITEM_TYPE.PC: return "Máy tính để bàn";
                case ITEM_TYPE.COMPUTER_COMPONENTS: return "Linh kiện máy tính";
                case ITEM_TYPE.OFFICE_DEVICES: return "Thiết bị văn phòng";
                case ITEM_TYPE.INTERNET_DEVICES: return "Thiết bị mạng, wifi";
                case ITEM_TYPE.SOUND_DEVICES: return "Thiết bị âm thanh";
                default: return "";
            }
        }
    }
    public enum ITEM_TYPE
    {
        MISC,
        COMBO,
        HOUSEWARE,
        LAPTOP,
        SMART_PHONE,
        MONITOR,
        TV,
        MOUSE_AND_KEYBOARD,
        PC,
        COMPUTER_COMPONENTS,
        OFFICE_DEVICES,
        INTERNET_DEVICES,
        SOUND_DEVICES
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