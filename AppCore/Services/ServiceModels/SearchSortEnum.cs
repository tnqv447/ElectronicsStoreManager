namespace AppCore.Services
{
    public enum SORT_ORDER
    {
        ASCENDING,
        DESCENDING
    }
    public enum SORT_TYPE
    {
        //general
        ID,
        STATUS,

        //for customer and item
        NAME,
        
        //for customer
        SEX,

        //for order
        ORDER_DATE,
        SUM_PRICE,

        //for item
        UNIT_PRICE
    }
}