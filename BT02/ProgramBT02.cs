using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT02
{
    //định nghĩa lớp sp
    class SanPham
    {
        private string _ten;
        private double _giamua;
        public SanPham() { }
        public SanPham(string ten,double giamua)
        {
            this._ten = ten;
            this._giamua = giamua;
        }
        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }
        public double GiaMua
        {
            get { return _giamua; }
            set
            {
                if (value >= 0)
                    _giamua = value;
            }
        }
        public virtual double TinhGiaBan()
        {
            return 0;
        }
        public virtual string InChiTiet()
        {
            return _ten;
        }
        public virtual void Nhap()
        {
            Console.Write("Bạn hãy nhập tên sản phẩm:");
            _ten = Console.ReadLine();
            Console.Write("Bạn hãy nhập tên giá mua:");
            _giamua = double.Parse(Console.ReadLine());
        }
    }
    //định nghĩa lớp socola
    class Socola : SanPham
    {
        private double _loinhuan;
        public Socola(): base() { }
        public Socola(string ten,double giamua): base (ten,giamua) { 
            _loinhuan=GiaMua * 0.2;
        }
        public override double TinhGiaBan()
        {
            return GiaMua + _loinhuan;
        }
        public override string InChiTiet()
        {
            return string.Format("Tên: {0} - Giá bán:{1: #,##0 đ}", Ten, TinhGiaBan()); 
        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuan = GiaMua * 0.2;
        }
    }
    //định nghĩa lớp nc ún
    class NuocUong : SanPham
    {
        private double _loinhuan;
        private double _chiphigiulanh;
        public NuocUong(): base() { }
        public NuocUong(string ten,double giamua): base(ten,giamua) 
        {
            _loinhuan = GiaMua * 0.15;
            _chiphigiulanh = GiaMua * 0.1;
        }
        public override double TinhGiaBan()
        {
            return GiaMua + _loinhuan+_chiphigiulanh;
        }
        public override string InChiTiet()
        {
            return string.Format("Tên: {0} - Giá bán:{1: #,##0 đ}",Ten, TinhGiaBan());
        }
        public override void Nhap()
        {
            base.Nhap();
            _loinhuan = GiaMua * 0.15;
            _chiphigiulanh = GiaMua * 0.1;
        }
    }
    class QuanLySanPham 
    {
        private string _ten;
        private SanPham[] dssp;
        private int n;
        public QuanLySanPham()
        {
            _ten = "Cửa hàng tạp hoá";
            dssp = new SanPham[100];
            n = 0;
        }
        public QuanLySanPham(int size)
        {
            _ten = "Cửa hàng tạp hoá";
            dssp = new SanPham[size];
            n = 0;
        }
        public void Nhap()
        {
            int chon;
            string hoilai;
            SanPham sp;
            while (true)
            {
                Console.Write("Bạn muốn chọn sản phẩm loại nào:(1.Socola  - 2.Nước uống):");
                chon = int.Parse(Console.ReadLine());
                switch(chon)
                {
                    case 1:
                        sp = new Socola();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                    case 2:
                        sp = new NuocUong();
                        sp.Nhap();
                        dssp[n++] = sp;
                        break;
                }
                Console.Write("Bạn có muốn tiếp tục không?(Y/N):");
                hoilai = Console.ReadLine();
                if (hoilai.ToLower().Equals("n"))
                    break;
            }
        }
        public void InDanhSachSP()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("***********Cửa hàng tạp hoá************");
            for(int i=0;i<n;i++)
            {
                Console.WriteLine(dssp[i].InChiTiet());
            }    
        }
    }
    class ProgramBT02
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLySanPham ql = new QuanLySanPham();
            Console.ForegroundColor = ConsoleColor.Green;
            ql.Nhap();           
            ql.InDanhSachSP();
            Console.ReadLine();
        }
    }
}
