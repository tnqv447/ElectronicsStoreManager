using System;
using System.Linq.Expressions;
namespace AppCore.Models
{
    public struct StorageChecker
    {
        public int ItemId { get; set; }
        public int Amount { get; set; }

        public StorageChecker(int itemId, int amount)
        {
            ItemId = itemId;
            Amount = amount;
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
                case ITEM_TYPE.SMART_PHONE: return "Cell Phone";
                case ITEM_TYPE.MONITOR: return "Computer Screen";
                case ITEM_TYPE.TV: return "TV";
                case ITEM_TYPE.MOUSE_AND_KEYBOARD: return "Mouse and Keyboard";
                case ITEM_TYPE.PC: return "Desktop";
                case ITEM_TYPE.COMPUTER_COMPONENTS: return "Computer Components";
                case ITEM_TYPE.OFFICE_DEVICES: return "Office Equipment";
                case ITEM_TYPE.INTERNET_DEVICES: return "Network equipment, wifi";
                case ITEM_TYPE.SOUND_DEVICES: return "Audio equipments";
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