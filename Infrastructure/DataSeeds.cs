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
                    new Item("Apple Macbook Air 2020 - 13 Inchs (i3-10th/ 8GB/ 256GB)", 24000000, "Bàn phím cắt kéo. Retina display with True Tone", 2),
                    new Item("Laptop Asus VivoBook 14 A412FA-EK1188T (Core i3-10110U/ 4GB/ 256GB SSD/ 14 FHD/ Win10)", 11049000, "CPU: Intel Core i3-10110U 2.1GHz up to 4.1GHz 4MB. RAM: 4GB DDR4 2400MHz (1x SO-DIMM socket, up to 12GB SDRAM). Ổ cứng: 256GB SSD M.2 PCIE G3X2, x1 slot 2.5\" SATA (HDD/SSD). Card đồ họa: Intel UHD Graphics. Màn hình: 14\" FHD (1920 x 1080) Anti-Glare with 45% NTSC, NanoEdge", 4),
                    new Item("Chuột Có Dây Logitech B100", 69000, "Thiết kế thân thiện. Nút bấm nhạy. Độ phân giải 800dpi. Dễ dàng sử dụng", 10),
                    new Item("Bàn Phím Có Dây Dell KB216", 153000, "Cổng giao tiếp USB. Màu đen bóng. Có đường thoát nước lớn hơn giúp việc thoát nước dễ dàng nhanh chóng, không đọng nước trên bàn phím. Dây 2m", 20),
                    new Item("Chuột Không Dây Apple Magic Mouse 2 (Silver) ", 1899000, "Thiết kế tối ưu hoá cho cảm giác cầm thoải mái nhất. Chuột không dây kết nối bluetooth chính hãng Apple", 8)
                );

                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer("Nguyễn Văn Anh", "0123789456", "145 anee", SEX.MALE, "cus1", "12345"),
                    new Customer("Lê Cần Ba", "0987789456", "2385 asnee", SEX.MALE, "cus2", "12345"),
                    new Customer("Nguyễn Nhi Anh", "0123789147", "236 aneerr", SEX.FEMALE, "cus3", "12345"),
                    new Customer("Trần Thị Bích", "0123258456", "789 cnehr", SEX.FEMALE, "cus4", "12345")
                );

                context.SaveChanges();
            }


        }
    }
}