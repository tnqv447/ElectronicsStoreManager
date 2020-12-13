using System.Linq;
using AppCore.Models;
using System;
namespace Infrastructure
{
    public class DataSeeds
    {
        public static void Initialize(ElectronicsStoreContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    // name, price, des, amount
                    // 1
                    new Item("Apple Macbook Air 2020 - 13 Inchs (i3-10th/ 8GB/ 256GB)", 24000000, "Bàn phím cắt kéo. Retina display with True Tone", 2),
                    // 2
                    new Item("Laptop Asus VivoBook 14 A412FA-EK1188T (Core i3-10110U/ 4GB/ 256GB SSD/ 14 FHD/ Win10)", 11049000, "CPU: Intel Core i3-10110U 2.1GHz up to 4.1GHz 4MB. RAM: 4GB DDR4 2400MHz (1x SO-DIMM socket, up to 12GB SDRAM). Ổ cứng: 256GB SSD M.2 PCIE G3X2, x1 slot 2.5\" SATA (HDD/SSD). Card đồ họa: Intel UHD Graphics. Màn hình: 14\" FHD (1920 x 1080) Anti-Glare with 45% NTSC, NanoEdge", 4),
                    // 3
                    new Item("Chuột Có Dây Logitech B100", 69000, "Thiết kế thân thiện. Nút bấm nhạy. Độ phân giải 800dpi. Dễ dàng sử dụng", 10),
                    // 4
                    new Item("Bàn Phím Có Dây Dell KB216", 153000, "Cổng giao tiếp USB. Màu đen bóng. Có đường thoát nước lớn hơn giúp việc thoát nước dễ dàng nhanh chóng, không đọng nước trên bàn phím. Dây 2m", 20),
                    // 5
                    new Item("Chuột Không Dây Apple Magic Mouse 2 (Silver) ", 1899000, "Thiết kế tối ưu hoá cho cảm giác cầm thoải mái nhất. Chuột không dây kết nối bluetooth chính hãng Apple", 8),
                    // 6
                    new Item("Camera chống trộm Xiaomi Mi Home 360°", 619000, "Kích thước nhỏ gọn, dễ dàng lắp đặt. Độ phân giải: 2 Megapixel (1920 x 1080p) hình ảnh sắc nét. Xoay ngang / dọc: 360 độ / 135 độ", 5),
                    // 7
                    new Item("Ổ Cứng SSD Kingston A400 (120GB)", 473000, "Nhanh hơn 10 lần so với ổ cứng truyền thống. Chịu va đập. Lý tưởng cho máy tính để bàn và máy tính xách ta. Độ rung hoạt động: 2.17G tối đa (7 - 800Hz)", 7),
                    // 8
                    new Item("Bàn phím máy vi tính Bosston 808 LED", 108000, "Phím cao cấp với độ đàn hồi cao, phím bấm êm. Trang bị LED nền màu sắc nổi bật. Độ bền phím trên 10.000.000 lượt nhấn. Kết nối USB, dây dẫn dài 1.5m", 9),
                    // 9
                    new Item("Tai nghe gaming chụp tai (Headphone Gaming) cho game thủ cao cấp A66", 699000, "Kích thước loa: 50mm. Độ nhạy: 42 +/- 3dB. Dải tần: 15 Hz-20KHz", 11),
                    // 10
                    new Item("USB 3.0 SanDisk Ultra CZ48 16GB ", 92000, "Dung lượng: 16GB. Kết nối: USB 3.0", 25)

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
                    new ItemRelation(1, 10),

                    new ItemRelation(4, 5),

                    new ItemRelation(9, 8),
                    new ItemRelation(9, 10),

                    new ItemRelation(2, 3)

                );
                context.SaveChanges();
            }

            // Order
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order(1, new DateTime(2020, 11, 12)),
                    new Order(2, new DateTime(2020, 11, 30)),
                    new Order(1, new DateTime(2020, 12, 1)),
                    new Order(3, new DateTime(2020, 12, 6)),
                    new Order(2, new DateTime(2020, 12, 13))
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
                    new OrderDetail(3, 4, 1, "Bàn Phím Có Dây Dell KB216", 153000), // combo 2 with id 5

                    new OrderDetail(4, 9, 1, "Tai nghe gaming chụp tai (Headphone Gaming) cho game thủ cao cấp A66", 699000), // combo 3,4 with id 6

                    new OrderDetail(5, 2, 1, "Laptop Asus VivoBook 14 A412FA-EK1188T (Core i3-10110U/ 4GB/ 256GB SSD/ 14 FHD/ Win10)", 11049000), // combo 5 with id 7
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
                    new SubOrderDetail(5, 5, 1, "Chuột Không Dây Apple Magic Mouse 2 (Silver) ", 1899000),
                    // order 4
                    new SubOrderDetail(6, 8, 1, "Bàn phím máy vi tính Bosston 808 LED", 108000),
                    new SubOrderDetail(6, 10, 1, "USB 3.0 SanDisk Ultra CZ48 16GB ", 92000),
                    // order 5
                    new SubOrderDetail(7, 3, 1, "Chuột Có Dây Logitech B100", 69000)
                );
                context.SaveChanges();
            }

        }
    }
}