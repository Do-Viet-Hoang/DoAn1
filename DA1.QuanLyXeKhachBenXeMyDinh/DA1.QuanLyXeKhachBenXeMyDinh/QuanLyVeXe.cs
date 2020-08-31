using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DA1.QuanLyXeKhachBenXeMyDinh
{
    class VeXe
    {
        private int giaVe, soLuongban;
        private Xe xe;
        private string tg;
        public VeXe()
        {
            xe = null;
            giaVe = 0;
            soLuongban = 0;
        }
        public VeXe(String ve)
        {
            string[] mp = ve.Split('#');
            this.tg = mp[0];
            this.xe = new Xe();
            this.xe.BienSoXe = mp[1];
            this.giaVe = int.Parse(mp[2]);
            this.soLuongban = int.Parse(mp[3]);
        }
        public int GiaVe
        {
            get { return giaVe; }
            set
            {
                if (value > 0)
                    giaVe = value;
            }
        }
        public int SoLuongBan
        {
            get { return soLuongban; }
            set
            {
                if (value > 0)
                    soLuongban = value;
            }
        }
        public Xe Xe
        {
            get { return xe; }
            set
            {
                if (value != null)
                    xe = value;
            }
        }
        public string Tg
        {
            get { return tg; }
            set
            {
                if (tg != "")
                    tg = value;
            }
        }
        public bool ktThoiGian(string thoiGian)
        {
            Boolean valid = true;
            try
            {
                DateTime.ParseExact(thoiGian, "dd/MM/yyyy", null);
            }
            catch
            {
                valid = false;
            }
            return valid;
        }
        public void Nhap()
        {
            do
            {
                Console.Write("Nhập ngày bán vé:");
                tg = Console.ReadLine();
            } while (ktThoiGian(tg) == false);
            do
            {
                Console.Write("Nhập giá vé:");
                giaVe = int.Parse(Console.ReadLine());
            } while (giaVe < 0);
            do
            {
                Console.Write("Nhập số lượng vé bán:");
                soLuongban = int.Parse(Console.ReadLine());
            } while (soLuongban < 0);

        }
        public void update()
        {
            do
            {
                Console.Write("Nhập thời gian bán vé:");
                Tg = Console.ReadLine();
            } while (ktThoiGian(Tg) == false);
            do
            {
                Console.Write("Nhập giá vé:");
                GiaVe = int.Parse(Console.ReadLine());
            } while (giaVe < 0);
            do
            {
                Console.Write("Nhập số lượng vé bán:");
                SoLuongBan = int.Parse(Console.ReadLine());
            } while (SoLuongBan < 0);
        }
        public void hien()
        {
            Console.WriteLine(tg + "\t" + xe.BienSoXe + '\t' + giaVe + '\t' + soLuongban);
        }
        public String toString()
        {
            return tg + '#' + xe.BienSoXe + '#' + giaVe + '#' + soLuongban;
        }
    }
    class ThongKe
    {
        public Xe xe;
        public int SoLuongVe;
        public double TongTien;

        public ThongKe(Xe xe, int SoLuongVe, double TongTien)
        {
            this.xe = xe;
            this.SoLuongVe = SoLuongVe;
            this.TongTien = TongTien;
        }
    }
    class QuanLyVeXe
    {
        private List<VeXe> lstQuanLyVeXe;

        public QuanLyVeXe()
        {

            lstQuanLyVeXe = new List<VeXe>();
        }
        public void writeFile(List<VeXe> lstQuanLyVeXe)
        {
            StreamWriter sw = new StreamWriter("VeXe.txt");
            foreach (VeXe v in lstQuanLyVeXe)
            {
                sw.WriteLine(v.toString());

            }
            sw.Close();
        }
        public void writeFile(string fileName, VeXe ve)
        {
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(ve.toString());
            sw.Close();
        }
        public void readFile(String fileName)
        {
            lstQuanLyVeXe = new List<VeXe>();
            StreamReader sr = new StreamReader(fileName);
            String tmp;
            VeXe ve;
            while (sr.EndOfStream == false)
            {
                tmp = sr.ReadLine().Trim();
                if (tmp == "") continue;
                ve = new VeXe(tmp);
                lstQuanLyVeXe.Add(ve);
            }
            sr.Close();
        }
        public VeXe TimKiemTheoBienSoXe(string bsx)
        {
            foreach (VeXe ve in lstQuanLyVeXe)
            {
                if (ve.Xe.BienSoXe.Equals(bsx))
                    return ve;
            }
            return null;
        }
        public void UpDaTeVeXe()
        {
            string bsx;
            Console.Write("Nhập biển số xe cần cập nhật:");
            bsx = Console.ReadLine();
            VeXe ve = TimKiemTheoBienSoXe(bsx);
            if (ve == null)
                Console.Write("Không có biển số xe nào là:" + bsx);
            else
                ve.update();
            {
                Console.WriteLine("CẬP NHẬT THÀNH CÔNG!");
            }
        }

        public void them(VeXe ve)
        {
            {
                lstQuanLyVeXe.Add(ve);
                writeFile("VeXe.txt", ve);
            }
        }
        public int TongTienVe(VeXe ve)
        {
            return ve.GiaVe * ve.SoLuongBan;
        }
        public ThongKe KiemTraBienSo(string bsx, List<ThongKe> list)
        {
            foreach (ThongKe tk in list)
            {
                if (tk.xe.BienSoXe == bsx) return tk;
            }
            return null;
        }
        public void DoanhThuNgay() // doanh thu xe theo ngày
        {
            int s = 0;
            Console.Write("Nhập ngày cần thống kê:");
            string timeTk = Console.ReadLine();
            List<ThongKe> listKt = new List<ThongKe>();
            foreach (VeXe ve in lstQuanLyVeXe)
            {
                if (ve.Tg != timeTk) continue;
                ThongKe kt = null;
                if ((kt = KiemTraBienSo(ve.Xe.BienSoXe, listKt)) != null)
                {
                    kt.SoLuongVe += ve.SoLuongBan;
                    kt.SoLuongVe += TongTienVe(ve);
                    s += TongTienVe(ve);
                }
                else
                {
                    listKt.Add(new ThongKe(ve.Xe, ve.SoLuongBan, TongTienVe(ve)));
                    s += TongTienVe(ve);
                }
            }
            Console.WriteLine("Ngày     " + timeTk);
            Console.WriteLine("Biển số xe   Số lượng    Tổng tiền");
            foreach (ThongKe tk in listKt)
            {
                Console.WriteLine(tk.xe.BienSoXe + "    " + tk.SoLuongVe + "    " + tk.TongTien);
            }
            Console.WriteLine("Tổng     " + s);
        }
        public void doanhthuthang() // thống kê doanh thu xe theo tháng
        {
            int s = 0;
            Console.Write("Nhập tháng cần thống kê:");
            string timeTk = Console.ReadLine();
            List<ThongKe> listKt = new List<ThongKe>();
            foreach (VeXe ve in lstQuanLyVeXe)
            {
                string[] tmp1 = timeTk.Split('/');
                string[] tmp2 = ve.Tg.Split('/');
                if (tmp1[0] != tmp2[1] || tmp1[1] != tmp2[2]) continue;

                ThongKe kt = null;
                if ((kt = KiemTraBienSo(ve.Xe.BienSoXe, listKt)) != null)
                {
                    kt.SoLuongVe += ve.SoLuongBan;
                    kt.SoLuongVe += TongTienVe(ve);
                    s += TongTienVe(ve);
                }
                else
                {
                    listKt.Add(new ThongKe(ve.Xe, ve.SoLuongBan, TongTienVe(ve)));
                    s += TongTienVe(ve);
                }
            }
            Console.WriteLine("Tháng     " + timeTk);
            Console.WriteLine("Biển số xe   Số lượng    Tổng tiền");
            foreach (ThongKe tk in listKt)
            {
                Console.WriteLine(tk.xe.BienSoXe + "    " + tk.SoLuongVe + "    " + tk.TongTien);
            }
            Console.WriteLine("Tổng     " + s);
        }
        public void doanhthunam()// thống kê doanh thu xe theo năm
        {
            int mSoLuong = 0;
            double mTongTien = 0;
            Console.Write("Nhập năm cần thống kê:");
            string timeTk = Console.ReadLine();
            List<ThongKe> listKt = new List<ThongKe>();
            Console.WriteLine("Năm:     " + timeTk);
            Console.WriteLine("Tháng    Số lượng    Tổng tiền");
            for (int i = 1; i <= 12; i++)
            {
                int SoLuong = 0;
                double TongTien = 0;
                foreach (VeXe ve in lstQuanLyVeXe)
                {
                    string[] tmp2 = ve.Tg.Split('/');
                    if (i.ToString() != tmp2[1] || timeTk != tmp2[2]) continue;
                    SoLuong += ve.SoLuongBan;
                    TongTien += TongTienVe(ve);
                    mSoLuong += ve.SoLuongBan;
                    mTongTien += TongTienVe(ve);
                }

                Console.WriteLine(i + "     " + SoLuong + "     " + TongTien);
            }
            Console.WriteLine("Tổng     " + mSoLuong + "     " + mTongTien);
        }
        public void doanhthubienso() // doanh thu theo biển số xe
        {
            int s = 0;
            Console.WriteLine("Biển số xe       Số lượng bán      Tổng tiền");
            foreach (VeXe ve in lstQuanLyVeXe)
            {
                if (ve.Xe.BienSoXe != null)
                {
                    s += TongTienVe(ve);
                    Console.WriteLine(ve.Xe.BienSoXe + "          " + ve.SoLuongBan + "               " + TongTienVe(ve));
                }
                else
                {
                    Console.WriteLine("KHÔNG TÌM THẤY!");
                }
            }
        }
        public void nhap()
        {
            VeXe ve;
            QuanLyXe ql = new QuanLyXe();
            ql.readFile("Xe.txt");
            {
                if (ql.lstQuanlyXe.Count == 0)
                {
                    Console.WriteLine("Không có xe nào trong hệ thống !");
                    Console.WriteLine("Ấn 6 để quay lại menu");
                }
                foreach (Xe xe in ql.lstQuanlyXe)
                {
                    Console.WriteLine("Nhập thông tin cho biển số xe: " + xe.BienSoXe);
                    ve = new VeXe();
                    ve.Xe = xe;
                    ve.Nhap();
                    them(ve);
                }
            }
        }
        public void hien()
        {
            Console.WriteLine("Co tat ca {0} xe", lstQuanLyVeXe.Count);
            Console.WriteLine("STT     ThoiGian        BienSoXe        GiaVe   SoLuong      TongTienBan");
            int i = 1;
            foreach (VeXe ve in lstQuanLyVeXe)
            {
                Console.WriteLine((String.Format(i + "\t" + ve.Tg + "\t" + ve.Xe.BienSoXe + "\t"
                + ve.GiaVe + "\t" + ve.SoLuongBan + "\t" + TongTienVe(ve))));
                i = i + 1;

            }
        }
        public void hienBsx(VeXe ve)
        {
            Console.WriteLine("XE CAN TIM KIEM LA:");
            Console.WriteLine("ThoiGian       BienSoXe        GiaVe     SoLuong");
            Console.WriteLine((String.Format(ve.Tg + "\t" + ve.Xe.BienSoXe + '\t' + ve.GiaVe + '\t' + ve.SoLuongBan)));
        }
        public void Xoa()
        {
            string biensoxe;
            Console.Write("Nhập biển số xe cần xoá:");
            biensoxe = Console.ReadLine();
            VeXe ve = null;
            for (int i = 0; i < lstQuanLyVeXe.Count; i++)
            {
                if (lstQuanLyVeXe[i].Xe.BienSoXe.Equals(biensoxe))
                    ve = lstQuanLyVeXe[i];
                break;
            }
            lstQuanLyVeXe.Remove(ve);
            writeFile(lstQuanLyVeXe);
            Console.WriteLine("XOÁ THÀNH CÔNG!");
        }
    }
}
