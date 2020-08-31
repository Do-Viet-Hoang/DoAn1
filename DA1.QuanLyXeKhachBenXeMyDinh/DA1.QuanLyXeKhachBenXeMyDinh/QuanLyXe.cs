using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace DA1.QuanLyXeKhachBenXeMyDinh
{
    class Xe
    {
        private string bienSoxe, loTrinh, nhaXe, dienThoai, tgXb, tgVb;
        private int soGhe;
        public Xe()
        {
            bienSoxe = "";
            loTrinh = "";
            nhaXe = "";
            dienThoai = "";
            tgXb = "";
            tgVb = "";
            soGhe = 0;
        }
        public Xe(String xe)
        {
            string[] tmp = xe.Split('#');
            this.bienSoxe = tmp[0];
            this.nhaXe = tmp[1];
            this.dienThoai = tmp[2];
            this.loTrinh = tmp[3];
            this.soGhe = int.Parse(tmp[4]);
            this.tgXb = tmp[5];
            this.tgVb = tmp[6];
        }
        public String BienSoXe
        {
            get { return bienSoxe; }
            set
            {
                if (value != "")
                    bienSoxe = value;
            }
        }
        public int SoGhe
        {
            get { return soGhe; }
            set
            {
                if (value <= 45)
                    soGhe = value;
            }
        }
        public string LoTrinh
        {
            get { return loTrinh; }
            set
            {
                if (value != "")
                    loTrinh = value;
            }
        }
        public string NhaXe
        {
            get { return nhaXe; }
            set
            {
                if (value != "")
                    nhaXe = value;
            }
        }
        public string DienThoai
        {
            get { return dienThoai; }
            set
            {
                if (value != "")
                    dienThoai = value;
            }
        }
        public string TgXb
        {
            get { return tgXb; }
            set
            {
                if (value != "")
                    tgXb = value;
            }
        }
        public string TgVb
        {
            get { return tgVb; }
            set
            {
                if (value != "")
                    tgVb = value;
            }
        }
        public bool ktSdt(string soDt)
        {
            string pattern = @"0\d{9,10}";
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            bool valid = false;
            if (string.IsNullOrEmpty(soDt))
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(soDt);
            }
            return valid;
        }
        public bool ktThoiGian(string thoiGian)
        {
            Boolean valid = true;
            try
            {
                DateTime.ParseExact(thoiGian, "hh:mm", null);
            }
            catch
            {
                valid = false;
            }
            return valid;
        }
        public void nhap()
        {
            do
            {
                Console.Write("Nhập biển số xe:");
                bienSoxe = Console.ReadLine().Trim();
                Console.Write("Nhập nhà xe:");
                nhaXe = Console.ReadLine();
            } while (bienSoxe == "" || nhaXe == "" );
            do
            {
                Console.Write("Nhập số điện thoại:");
                dienThoai = Console.ReadLine();
                Console.Write("Nhập lộ trình:");
                loTrinh = Console.ReadLine();
            } while (ktSdt(dienThoai) == false || loTrinh == "");
            do
            {
                Console.Write("Nhập số ghế:");
                soGhe = int.Parse(Console.ReadLine());
            } while (soGhe < 0 || soGhe > 45);
            do
            {
                Console.Write("Nhập thời gian Xuất bến (Giờ / phút):");
                tgXb = Console.ReadLine();
                Console.Write("Nhập thời gian Về bến (Giờ / phút):");
                tgVb = Console.ReadLine();
            } while (ktThoiGian(tgVb) == false || ktThoiGian(TgXb) == false);
        }
        public void update()
        {
            do
            {
                Console.Write("Nhập nhà xe:");
                NhaXe = Console.ReadLine();
                Console.Write("Nhập số điện thoại:");
                DienThoai = Console.ReadLine();
                Console.Write("Nhập lộ trình:");
                LoTrinh = Console.ReadLine();
            } while (LoTrinh == "" || DienThoai == "" || NhaXe == "");
            do
            {
                Console.Write("Nhập số ghế:");
                SoGhe = int.Parse(Console.ReadLine());
            } while (SoGhe < 0 || SoGhe > 45);
            do
            {
                Console.Write("Nhập thời gian xuất bến (Giờ / phút):");
                TgXb = Console.ReadLine();
                Console.Write("Nhập thời gian về bến (Giờ / phút):");
                TgVb = Console.ReadLine();
            } while (ktThoiGian(TgXb) == false || ktThoiGian(TgVb) == false);
        }
        public void hien()
        {
            Console.WriteLine(bienSoxe + '\t' + nhaXe + '\t' + dienThoai + '\t' + loTrinh + '\t'
           + soGhe + '\t' + tgXb + '\t' + tgVb);
        }
        public String toString()
        {
            return bienSoxe + '#' + nhaXe + '#' + dienThoai + '#' + loTrinh + '#'
           + soGhe + '#' + tgXb + '#' + tgVb;
        }
    }
    class QuanLyXe
    {
        public List<Xe> lstQuanlyXe;
        public QuanLyXe()
        {
            lstQuanlyXe = new List<Xe>();
        }
        public void writeFile(List<Xe> lstQuanlyXe)
        {
            StreamWriter sw = new StreamWriter("Xe.txt");
            foreach (Xe v in lstQuanlyXe) 
            {
                sw.WriteLine(v.toString());

            }
            sw.Close();
        }
        public void writeFile(string fileName, Xe xe)
        {
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.Unicode);
            sw.WriteLine(xe.toString());
            sw.Close();
        }
        public void readFile(String fileName)
        {
            lstQuanlyXe = new List<Xe>();
            StreamReader sr = new StreamReader(fileName);
            String tmp;
            Xe xe;
            while (sr.EndOfStream == false)
            {
                tmp = sr.ReadLine().Trim();
                if (tmp == "") continue;
                xe = new Xe(tmp);
                lstQuanlyXe.Add(xe);
            }
            sr.Close();
        }
        public Xe TimKiemTheoBienSoXe(string bsx)
        {
            foreach (Xe xe in lstQuanlyXe)
            {
                if (xe.BienSoXe.Equals(bsx))
                    return xe;
            }
            return null;
        }
        public void UpDaTeBsx()
        {
            string bsx;
            Console.Write("Nhập biển số xe cần cập nhật:");
            bsx = Console.ReadLine();
            Xe xe = TimKiemTheoBienSoXe(bsx);
            if (xe == null)
                Console.WriteLine("Không có biển số xe nào là:" + bsx);
            else
                xe.update();
            {
                Console.WriteLine("CẬP NHẬT THÀNH CÔNG!");
            }
        }
        public List<Xe> TimKiemTheoLoTrinh(string lt)
        {
            List<Xe> lstketqua = new List<Xe>();
            foreach (Xe xe in lstQuanlyXe)
            {
                if (xe.LoTrinh.Contains(lt))
                    lstketqua.Add(xe);
            }
            return lstketqua;
        }
        public List<Xe> TimKiemTheoThoiGianXB(string xb)
        {
            List<Xe> lsxb = new List<Xe>();
            foreach (Xe xe in lstQuanlyXe)
            {
                if (xe.TgXb.Contains(xb))
                    lsxb.Add(xe);
            }
            return lsxb;
        }
        public List<Xe> TimKiemTheoTenNhaXe(string ten)
        {
            List<Xe> name = new List<Xe>();
            foreach (Xe xe in lstQuanlyXe)
            {
                if (xe.NhaXe.Contains(ten))
                    name.Add(xe);
            }
            return name;
        }
        public void them(Xe xe)
        {
            if (TimKiemTheoBienSoXe(xe.BienSoXe) != null)
                Console.WriteLine(" Err: Da ton tai xe co bien so xe " + xe.BienSoXe + " trong he thong");
            else
            {
                lstQuanlyXe.Add(xe);
                writeFile("Xe.txt", xe);
            }
        }
        public void nhap()
        {
            int next;
            Xe xe;
            do
            {
                xe = new Xe();
                xe.nhap();
                them(xe);
                Console.Write("Nhap 1 de tiep tuc, de ket thuc nhap so khac!");
                next = int.Parse(Console.ReadLine());
            } while (next == 1);
        }
        public void hien()
        {
            Console.WriteLine("Co tat ca {0} xe", lstQuanlyXe.Count);
            Console.WriteLine("STT  BienSoXe    NhaXe         DienThoai        LoTrinh               SoGhe                    TGXuatBen            s     TGVeBen");
            int i = 1;
            foreach (Xe xe in lstQuanlyXe)
            {
                Console.WriteLine(String.Format("{0,-5}{1,-12}{2,-14}{3,-17}{4,-22}{5,-25}{6,-26}{7,-327}", i, xe.BienSoXe, xe.NhaXe, xe.DienThoai, xe.LoTrinh, xe.SoGhe, xe.TgXb, xe.TgVb));
                i = i + 1;
            }
        }
        public void xoa()
        {
            string bsx;
            Console.Write("Nhap Bien Xe can xoa:");
            bsx = Console.ReadLine();
            Xe m = null;
            for (int i = 0; i < lstQuanlyXe.Count; i++)
            {
                if (lstQuanlyXe[i].BienSoXe.Equals(bsx))
                {
                    m = lstQuanlyXe[i];
                    break;
                }
            }
            lstQuanlyXe.Remove(m);
            writeFile(lstQuanlyXe);
            Console.WriteLine("XOA THANH CONG !");
        }
        public void hienBSX(Xe xe)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("XE CAN TIM KIEM LA:");
            Console.WriteLine("BienSoXe        NhaXe   DienThoai          LoTrinh              SoGhe      TGXuatBen              TGVeBen");
            Console.WriteLine((String.Format(xe.BienSoXe + '\t' + xe.NhaXe + '\t' + xe.DienThoai + '\t' + xe.LoTrinh + '\t'
           + xe.SoGhe + '\t' + xe.TgXb + '\t' + xe.TgVb)));
        }
        public void hienList(List<Xe> tmp)
        {
            foreach (Xe xe in tmp)
            {
                Console.WriteLine("XEM CAN TIM KIEM LA:");
                Console.WriteLine("BienSoXe        NhaXe   DienThoai          LoTrinh              SoGhe      TGXuatBen              TGVeBen");
                Console.WriteLine((String.Format(xe.BienSoXe + '\t' + xe.NhaXe + '\t' + xe.DienThoai + '\t' + xe.LoTrinh + '\t'
               + xe.SoGhe + '\t' + xe.TgXb + '\t' + xe.TgVb)));
            }
        }
    }
}
