using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA1.QuanLyXeKhachBenXeMyDinh
{
    class Program
    {
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("\t\t                      ***************************************************************************       ");
            Console.WriteLine("\t\t                      *                                                                         *       ");
            Console.WriteLine("\t\t                      *                CHƯƠNG TRÌNH QUẢN LÝ XE KHÁCH BẾN XE MỸ ĐÌNH             *       ");
            Console.WriteLine("\t\t                      *                                                                         *       ");
            Console.WriteLine("\t\t                      *                          1.THÔNG TIN XE                                 *       ");
            Console.WriteLine("\t\t                      *                                                                         *       ");
            Console.WriteLine("\t\t                      *                          2.THÔNG TIN VÉ XE                              *       ");
            Console.WriteLine("\t\t                      *                                                                         *       ");
            Console.WriteLine("\t\t                      *                          3.TÌM KIẾM THÔNG TIN XE                        *       ");
            Console.WriteLine("\t\t                      *                                                                         *       ");
            Console.WriteLine("\t\t                      *                          4.THỐNG KÊ DOANH THU                           *       ");
            Console.WriteLine("\t\t                      *                                                                         *       ");
            Console.WriteLine("\t\t                      *                          0.THOÁT KHỎI CHƯƠNG TRÌNH !                    *       ");
            Console.WriteLine("\t\t                      *                                                                         *       ");
            Console.WriteLine("\t\t                      ***************************************************************************       ");
            int tmp;
            do
            {
                Console.Write("Mời bạn chọn chức năng:");
                tmp = int.Parse(Console.ReadLine());
                if (!(tmp <= 0 && tmp > 5))
                    Console.WriteLine("MỜI NHẬP LẠI!");
            } while (!(tmp >= 0 && tmp < 5));
            return tmp;
        }
        public int MenuXe()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t                          ********************                                 ");
            Console.WriteLine("\t\t\t                          *   QUẢN LÝ XE     *                                 ");
            Console.WriteLine("\t\t\t                          ********************                                 ");
            Console.WriteLine("\t\t\t     ****************************      *****************************           ");
            Console.WriteLine("\t\t\t     * 1.NHẬP THÔNG TIN XE      *      *  2.HIỆN THỊ THÔNG TIN XE  *           ");
            Console.WriteLine("\t\t\t     ****************************      *****************************           ");
            Console.WriteLine("\t\t\t     ****************************      *****************************           ");
            Console.WriteLine("\t\t\t     * 3.SỬA THÔNG TIN XE       *       *  4.XOÁ THÔNG TIN XE      *           ");
            Console.WriteLine("\t\t\t     ****************************      *****************************           ");
            Console.WriteLine("\t\t\t     ****************************      *****************************           ");
            Console.WriteLine("\t\t\t     * 5.QUAY LẠI MENU          *      *  6.THOÁT                  *           ");
            Console.WriteLine("\t\t\t     ****************************      *****************************           ");
            int tmp;
            do
            {
                Console.Write("Mời bạn chọn chức năng:");
                tmp = int.Parse(Console.ReadLine());
                if ((tmp <= 0 && tmp <= 6))
                    Console.WriteLine("MOI BAN NHAP LAI!");
            } while ((tmp <= 0 && tmp < 5));
            return tmp;
        }
        static int MenuVeXe()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t                            ***********************                                  ");
            Console.WriteLine("\t\t\t                            *    QUẢN LÝ VÉ XE    *                                  ");
            Console.WriteLine("\t\t\t                            ***********************                                  ");
            Console.WriteLine("\t\t\t                                                                                     ");
            Console.WriteLine("\t\t\t     *******************************      ********************************           ");
            Console.WriteLine("\t\t\t     * 1.NHẬP THÔNG TIN VÉ XE      *      *  2.HIỆN THỊ THÔNG TIN VÉ XE  *           ");
            Console.WriteLine("\t\t\t     *******************************      ********************************           ");
            Console.WriteLine("\t\t\t     *******************************      ********************************           ");
            Console.WriteLine("\t\t\t     * 3.SỬA THÔNG TIN VÉ XE       *      *  4.XOÁ THÔNG TIN VÉ XE       *           ");
            Console.WriteLine("\t\t\t     *******************************      ********************************           ");
            Console.WriteLine("\t\t\t     *******************************      ********************************           ");
            Console.WriteLine("\t\t\t     * 5.TÌM KIẾM THÔNG TIN VÉ XE  *      *  6.QUAY LẠI MENU             *           ");
            Console.WriteLine("\t\t\t     *******************************      ********************************           ");
            Console.WriteLine("\t\t\t                            ***********************                                  ");
            Console.WriteLine("\t\t\t                            *       7.THOÁT       *                                  ");
            Console.WriteLine("\t\t\t                            ***********************                                  ");
            int tmp;
            do
            {
                Console.Write("Mời bạn chọn chức năng:");
                tmp = int.Parse(Console.ReadLine());
                if ((tmp <= 0 && tmp > 7))
                    Console.WriteLine("MỜI BẠN NHẬP LẠI!");
            } while ((tmp <= 0 && tmp > 7));
            return tmp;
        }
        static int MenuTimkiem()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t                         *****************************************               ");
            Console.WriteLine("\t\t\t                         *        TÌM KIẾM THÔNG TIN XE          *               ");
            Console.WriteLine("\t\t\t                         *****************************************               ");
            Console.WriteLine("\t\t\t *************************************      ************************************ ");
            Console.WriteLine("\t\t\t *  1.TÌM KIẾM THEO BIỂN SỐ XE       *      *  2.TÌM KIẾM THEO NHÀ XE          * ");
            Console.WriteLine("\t\t\t *************************************      ************************************ ");
            Console.WriteLine("\t\t\t *************************************      ************************************ ");
            Console.WriteLine("\t\t\t *  3.TÌM KIẾM THEO LỘ TRÌNH         *      *  4.TÌM KIẾM THỜI GIAN XUẤT BẾN   * ");
            Console.WriteLine("\t\t\t *************************************      ************************************ ");
            Console.WriteLine("\t\t\t *************************************      ************************************ ");
            Console.WriteLine("\t\t\t *  5.QUAY LẠI MENU                  *      *  6.THOÁT                         * ");
            Console.WriteLine("\t\t\t *************************************      ************************************ ");
            int tmp;
            do
            {
                Console.Write("Mời bạn chọn chức năng:");
                tmp = int.Parse(Console.ReadLine());
                if ((tmp <= 0 && tmp > 7))
                    Console.WriteLine("MỜI BẠN NHẬP LẠI!");
            } while ((tmp <= 0 && tmp > 7));
            return tmp;
        }
        static int Menuthongke()
        {
            {
                Console.Clear();
                Console.WriteLine("\t\t\t                         *****************************************               ");
                Console.WriteLine("\t\t\t                         *         THỐNG KÊ DOANH THU            *               ");
                Console.WriteLine("\t\t\t                         *****************************************               ");
                Console.WriteLine("\t\t\t *************************************      ************************************ ");
                Console.WriteLine("\t\t\t *  1.THỐNG KÊ THEO BIỂN SỐ XE       *      *  2.THỐNG KÊ THEO NGÀY            * ");
                Console.WriteLine("\t\t\t *************************************      ************************************ ");
                Console.WriteLine("\t\t\t *************************************      ************************************ ");
                Console.WriteLine("\t\t\t *  3.THỐNG KÊ THEO THÁNG            *      *  4.THỐNG KÊ THEO NĂM            * ");
                Console.WriteLine("\t\t\t *************************************      ************************************ ");
                Console.WriteLine("\t\t\t *************************************      ************************************ ");
                Console.WriteLine("\t\t\t *  5.QUAY LẠI MENU                  *      *  6.THOÁT                         * ");
                Console.WriteLine("\t\t\t *************************************      ************************************ ");
                int tmp;
                do
                {
                    Console.Write("Mời bạn chọn chức năng:");
                    tmp = int.Parse(Console.ReadLine());
                    if ((tmp <= 0 && tmp > 7))
                        Console.WriteLine("MỜI BẠN NHẬP LẠI!");
                } while ((tmp <= 0 && tmp > 7));
                return tmp;
            }
        }
        public void xulyxe(ref QuanLyXe ql)
        {
            bool quaylai;
            do
            {
                int tt = MenuXe();
                quaylai = false;
                switch (tt)
                {
                    case 1: ql.nhap(); Console.ReadKey(); break;
                    case 2: ql.hien(); Console.ReadKey(); break;
                    case 3: ql.UpDaTeBsx(); Console.ReadKey(); break;
                    case 4: ql.xoa(); Console.ReadKey();break;
                    case 5: quaylai = true; break;
                    case 6: Environment.Exit(0); Console.ReadKey(); break;
                }
                Console.Clear();
            } while (quaylai == false);
        }
        public void xulyvexe(ref QuanLyVeXe ve)
        {
            bool back;
            do
            {
                int b = MenuVeXe();
                back = false;
                switch (b)
                {
                    case 1: ve.nhap(); Console.ReadKey();break;
                    case 2: ve.hien(); Console.ReadKey(); break;
                    case 3: ve.UpDaTeVeXe(); Console.ReadKey(); break;
                    case 4: ve.Xoa(); Console.ReadKey(); break;
                    case 5:
                        Console.Write("Nhập biển số xe cần tìm kiếm:");
                        string bsxV = Console.ReadLine();
                        VeXe vexe = ve.TimKiemTheoBienSoXe(bsxV);
                        if (ve == null)
                        {
                            Console.WriteLine("KHÔNG TÌM THẤY!");
                        }
                        ve.hienBsx(vexe);
                        Console.ReadKey(); break;
                    case 6: back = true; break;
                    case 7: Environment.Exit(0); Console.ReadKey(); break;
                }
                Console.Clear();
            } while (back == false);
        }
        public void xulytimkiem(ref QuanLyXe ql)
        {
            bool home;
            do
            {
                home = false;
                switch (MenuTimkiem())
                {
                    case 1:
                        Console.Write("Nhập biển số xe cần tìm kiếm:");
                        string bsx = Console.ReadLine();
                        Xe xe = ql.TimKiemTheoBienSoXe(bsx);
                        if (xe == null)
                        {
                            Console.WriteLine("KHÔNG TÌM THẤY!");
                        }
                        ql.hienBSX(xe);
                        Console.ReadKey(); break;
                    case 2:
                        Console.Write("Nhập tên nhà xe cần tìm kiếm:");
                        string ten = Console.ReadLine();
                        List<Xe> listtmp = ql.TimKiemTheoTenNhaXe(ten);
                        if (ten == null)
                        {
                            Console.WriteLine("KHÔNG TÌM THẤY!");
                        }
                        ql.hienList(listtmp);
                        Console.ReadKey(); break;
                    case 3:
                        Console.Write("Nhập lộ trình cần tìm kiếm:");
                        string lt = Console.ReadLine();
                        List<Xe> Lotrinh = ql.TimKiemTheoLoTrinh(lt);
                        if (lt == null)
                        {
                            Console.WriteLine("KHÔNG TÌM THẤY!");
                        }
                        ql.hienList(Lotrinh);
                        Console.ReadKey(); break;
                    case 4:
                        Console.Write("Nhập thời gian cần tìm kiếm:");
                        string tg = Console.ReadLine();
                        List<Xe> thoigian = ql.TimKiemTheoThoiGianXB(tg);
                        if (tg == null)
                        {
                            Console.WriteLine("KHÔNG TÌM THẤY!");
                        }
                        ql.hienList(thoigian);
                        Console.ReadKey(); break;
                    case 5: home = true; break;
                    case 6: Environment.Exit(0); Console.ReadKey(); break;
                }
            } while (home == false);
        }
        public void thongKe(ref QuanLyVeXe ve)
        {
            bool back;
            do
            {
                int b = Menuthongke();
                back = false;
                switch (b)
                {
                    case 1: ve.doanhthubienso(); Console.ReadKey(); break;
                    case 2: ve.DoanhThuNgay(); Console.ReadKey(); break;
                    case 3: ve.doanhthuthang(); Console.ReadKey(); break;
                    case 4: ve.doanhthunam(); Console.ReadKey(); break;
                    case 5: back = true; break;
                    case 6: Environment.Exit(0); Console.ReadKey(); break;
                }
                Console.Clear();
            } while (back == false);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            QuanLyXe ql = new QuanLyXe(); ql.readFile("Xe.txt");
            QuanLyVeXe ve = new QuanLyVeXe(); ve.readFile("VeXe.txt");
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            do
            {
                Console.Clear();
                switch (Menu())
                {
                    case 1:
                        Console.Clear();
                        p.xulyxe(ref ql);
                        break;
                    case 2:
                        Console.Clear();
                        p.xulyvexe(ref ve);
                        break;
                    case 3:
                        Console.Clear();
                        p.xulytimkiem(ref ql);
                        break;
                    case 4:
                        Console.Clear();
                        p.thongKe(ref ve);
                        break;
                    case 0: Environment.Exit(0); Console.ReadKey(); break;
                }
                Console.Clear();
            } while (true);
        }
    }
}
