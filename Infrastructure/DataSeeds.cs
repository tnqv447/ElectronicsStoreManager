using System.Linq;
using AppCore.Models;
using System;
using AppCore.Interfaces;

namespace Infrastructure
{
    public class DataSeeds
    {
        public static void Initialize(ElectronicsStoreContext context, IUnitOfWork unitOfWork)
        {
            context.Database.EnsureCreated();

            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    // name, price, des, amount
                    // 1
                    new Item("Apple Macbook Air 2020 - 13 Inchs (i3-10th/ 8GB/ 256GB)", ITEM_TYPE.LAPTOP, 24000000, "Bàn phím cắt kéo. Retina display with True Tone", 4, 2),
                    // 2
                    new Item("Laptop Asus VivoBook 14 A412FA-EK1188T (Core i3-10110U/ 4GB/ 256GB SSD/ 14 FHD/ Win10)", ITEM_TYPE.LAPTOP, 11049000, "CPU: Intel Core i3-10110U 2.1GHz up to 4.1GHz 4MB. RAM: 4GB DDR4 2400MHz (1x SO-DIMM socket, up to 12GB SDRAM). Ổ cứng: 256GB SSD M.2 PCIE G3X2, x1 slot 2.5\" SATA (HDD/SSD). Card đồ họa: Intel UHD Graphics. Màn hình: 14\" FHD (1920 x 1080) Anti-Glare with 45% NTSC, NanoEdge", 4, 2),
                    // 3
                    new Item("Chuột Có Dây Logitech B100", ITEM_TYPE.MOUSE_AND_KEYBOARD, 69000, "Thiết kế thân thiện. Nút bấm nhạy. Độ phân giải 800dpi. Dễ dàng sử dụng", 10, 2),
                    // 4
                    new Item("Bàn Phím Có Dây Dell KB216", ITEM_TYPE.MOUSE_AND_KEYBOARD, 153000, "Cổng giao tiếp USB. Màu đen bóng. Có đường thoát nước lớn hơn giúp việc thoát nước dễ dàng nhanh chóng, không đọng nước trên bàn phím. Dây 2m", 20, 3),
                    // 5
                    new Item("Chuột Không Dây Apple Magic Mouse 2 (Silver) ", ITEM_TYPE.MOUSE_AND_KEYBOARD, 1899000, "Thiết kế tối ưu hoá cho cảm giác cầm thoải mái nhất. Chuột không dây kết nối bluetooth chính hãng Apple", 8, 3),
                    // 6
                    new Item("Camera chống trộm Xiaomi Mi Home 360°", ITEM_TYPE.COMPUTER_COMPONENTS, 619000, "Kích thước nhỏ gọn, dễ dàng lắp đặt. Độ phân giải: 2 Megapixel (1920 x 1080p) hình ảnh sắc nét. Xoay ngang / dọc: 360 độ / 135 độ", 5),
                    // 7
                    new Item("Ổ Cứng SSD Kingston A400 (120GB)", ITEM_TYPE.COMPUTER_COMPONENTS, 473000, "Nhanh hơn 10 lần so với ổ cứng truyền thống. Chịu va đập. Lý tưởng cho máy tính để bàn và máy tính xách ta. Độ rung hoạt động: 2.17G tối đa (7 - 800Hz)", 7),
                    // 8
                    new Item("Bàn phím máy vi tính Bosston 808 LED", ITEM_TYPE.MOUSE_AND_KEYBOARD, 108000, "Phím cao cấp với độ đàn hồi cao, phím bấm êm. Trang bị LED nền màu sắc nổi bật. Độ bền phím trên 10.000.000 lượt nhấn. Kết nối USB, dây dẫn dài 1.5m", 9, 4),
                    // 9
                    new Item("Tai nghe gaming chụp tai (Headphone Gaming) cho game thủ cao cấp A66", ITEM_TYPE.SOUND_DEVICES, 699000, "Kích thước loa: 50mm. Độ nhạy: 42 +/- 3dB. Dải tần: 15 Hz-20KHz", 11, 6),
                    // 10
                    new Item("USB 3.0 SanDisk Ultra CZ48 16GB", ITEM_TYPE.OFFICE_DEVICES, 92000, "Dung lượng: 16GB. Kết nối: USB 3.0", 25, 5),
                    // 11 combo
                    new Item("Combo Appple Mac và USB", ITEM_TYPE.COMBO, 24020000, "Gồm Apple Macbook Air 2020 - 13 Inchs và USB 3.0 SanDisk Ultra CZ48 16GB", 2),
                    // 12 combo
                    new Item("Combo Bàn phím Dell và Chuột Apple Magic", ITEM_TYPE.COMBO, 2000000, "Gồm Bàn Phím Có Dây Dell và Chuột Không Dây Apple Magic Mouse 2", 3),
                    // 13 combo
                    new Item("Combo Bàn phím, tai nghe và USB", ITEM_TYPE.COMBO, 800000, "Gồm Bàn phím máy vi tính Bosston 808 LED, Tai nghe gaming chụp tai và USB 3.0 SanDisk Ultra CZ48 16GB", 4),
                    // 14 combo
                    new Item("Combo Laptop Asus và Chuột Logitech B100", ITEM_TYPE.COMBO, 11080000, "Gồm Laptop Asus VivoBook 14 A412FA-EK1188T và Chuột Có Dây Logitech B100", 2)

                );

                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer("Nguyễn Văn Anh", "0123789456", "145 anee", SEX.MALE, "cus1", "12345"),
                    new Customer("Lê Cần Ba", "0987789456", "2385 asnee", SEX.MALE, "cus2", "12345"),
                    new Customer("Nguyễn Nhi Anh", "0123789147", "236 aneerr", SEX.FEMALE, "cus3", "12345"),
                    new Customer("Trần Thị Bích", "0123258456", "789 cnehr", SEX.FEMALE, "cus4", "12345"),
                    new Customer("Huỳnh Minh Huy ", "0278258456", "426 djeggdr", SEX.MALE, "cus5", "12345")
                );

                context.SaveChanges();
            }

            // Order Combo
            if (!context.ItemRelations.Any())
            {
                context.ItemRelations.AddRange(
                    new ItemRelation(11, 1),
                    new ItemRelation(11, 10),

                    new ItemRelation(12, 4),
                    new ItemRelation(12, 5),

                    new ItemRelation(13, 8),
                    new ItemRelation(13, 9),
                    new ItemRelation(13, 10),

                    new ItemRelation(14, 2),
                    new ItemRelation(14, 3)

                );
                context.SaveChanges();
            }

            // Order
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order(1, new DateTime(2020, 11, 12, 8, 8, 8)),
                    new Order(2, new DateTime(2020, 11, 30, 4, 4, 4)),
                    new Order(1, new DateTime(2020, 12, 1, 6, 6, 6)),
                    new Order(3, new DateTime(2020, 12, 6, 7, 7, 7)),
                    new Order(2, new DateTime(2020, 12, 13, 11, 12, 12))
                );
                context.SaveChanges();
            }


            if (!context.OrderDetails.Any())
            {
                context.OrderDetails.AddRange(
                    // orderid, itemid, amount, itemname, unitprice
                    new OrderDetail(1, 1, 1, "Apple Macbook Air 2020 - 13 Inchs (i3-10th/ 8GB/ 256GB)", 24000000),

                    new OrderDetail(2, 2, 1, "Laptop Asus VivoBook 14 A412FA-EK1188T (Core i3-10110U/ 4GB/ 256GB SSD/ 14 FHD/ Win10)", 11049000),
                    new OrderDetail(2, 3, 2, "Chuột Có Dây Logitech B100", 69000),

                    new OrderDetail(3, 6, 2, "Camera chống trộm Xiaomi Mi Home 360°", 619000),
                    new OrderDetail(3, 11, 1, "Combo Appple Mac và USB", 24020000), // combo 11, id 5

                    new OrderDetail(4, 13, 1, "Combo Bàn phím, tai nghe và USB", 800000), // combo 13 with id 6

                    new OrderDetail(5, 14, 1, "Combo Laptop Asus và Chuột Logitech B100", 11080000), // combo 14 with id 7
                    new OrderDetail(5, 10, 3, "USB 3.0 SanDisk Ultra CZ48 16GB ", 92000)

                // count 8
                );
                context.SaveChanges();
            }

            if (!context.SubOrderDetails.Any())
            {
                // orderid, itemid, amount, itemname, unitprice
                context.SubOrderDetails.AddRange(
                    // order 3
                    new SubOrderDetail(5, 1, 1, "Apple Macbook Air 2020 - 13 Inchs (i3-10th/ 8GB/ 256GB)", 24000000),
                    new SubOrderDetail(5, 10, 1, "USB 3.0 SanDisk Ultra CZ48 16GB", 92000),
                    // order 4
                    new SubOrderDetail(6, 8, 1, "Bàn phím máy vi tính Bosston 808 LED", 108000),
                    new SubOrderDetail(6, 9, 1, "Tai nghe gaming chụp tai (Headphone Gaming) cho game thủ cao cấp A66", 699000),
                    new SubOrderDetail(6, 10, 1, "USB 3.0 SanDisk Ultra CZ48 16GB ", 92000),
                    // order 5
                    new SubOrderDetail(7, 3, 1, "Laptop Asus VivoBook 14 A412FA-EK1188T (Core i3-10110U/ 4GB/ 256GB SSD/ 14 FHD/ Win10)", 11049000),
                    new SubOrderDetail(7, 3, 1, "Chuột Có Dây Logitech B100", 69000)
                );
                context.SaveChanges();
            }

        }
    }
}