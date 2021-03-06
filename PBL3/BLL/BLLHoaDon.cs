using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
namespace PBL3.BLL
{
    public class BLLHoaDon
    {
        QLCHTAN db = new QLCHTAN();
        private static BLLHoaDon _Instance;

        public static BLLHoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLHoaDon();
                }
                return _Instance;
            }
            private set { }
        }

        private BLLHoaDon()
        {

        }
        public bool checkAddUpdate(string id)
        {
            bool Add = true;
            try
            {
                if (db.HoaDon.Find(id) != null)
                {
                    Add = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return Add;
        }

        public bool Delete(string id)
        {
            try
            {
                db.HoaDon.Find(id).IsDelete = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public string AutoGeneratedId()
        {
            string id_next = "";
            try
            {
                string id_max = db.HoaDon.Select(p => p.id_HoaDon).ToList().Max();
                if (id_max == null)
                {
                    id_next = "HD001";
                }
                else
                {
                    int max = Convert.ToInt32(id_max.Substring(id_max.Length - 3));
                    max++;
                    id_next = "HD" + ("000" + max).Substring(("000" + max).Length - 3);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id_next;
        }
        public bool ExecuteAddUpdate(HoaDon t)
        {
            try
            {
                if (checkAddUpdate(t.id_Order))
                {
                    db.HoaDon.Add(new HoaDon
                    {
                        id_HoaDon = t.id_HoaDon,
                        id_Order = t.id_Order,
                        NgayLap = t.NgayLap.Date,
                    });
                    db.SaveChanges();
                }
                else
                {
                    HoaDon hd = db.HoaDon.Find(t.id_Order);
                    hd.NgayLap = t.NgayLap.Date;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        public List<HoaDon_View> GetAll()
        {
            List<HoaDon_View> list = new List<HoaDon_View>();
            try
            {
                list = db.HoaDon
                        .Where(p => p.IsDelete == false)
                        .Select(p => new HoaDon_View
                        {
                            id_HoaDon = p.id_HoaDon,
                            TenNhanVien = p.Order.NhanVien.TenNhanVien,
                            TenKhachHang = p.Order.KhachHang.TenKhachHang,
                            NgayLap = p.NgayLap,
                            TongTien = p.Order.ChiTietOrder.Sum(ct => ct.GiaBan * ct.SoLuong)
                        })
                        .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public HoaDon GetById(string id)
        {
            HoaDon hoaDon = new HoaDon();
            try
            {
                hoaDon = db.HoaDon.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return hoaDon;
        }
        public bool LapHoaDon(List<ChiTietOrder> chiTiets, string id_NhanVien, string id_KhachHang)
        {
            try
            {
                string id_Order = BLLOrder.Instance.AutoGeneratedId();
                double TongTien = 0;
                double TongNhap = 0;
                foreach (ChiTietOrder chiTiet in chiTiets)
                {
                    TongTien += chiTiet.SoLuong * chiTiet.GiaBan;
                    TongNhap += chiTiet.SoLuong * chiTiet.GiaNhap;
                    BLLMonAn.Instance.Sell(chiTiet.id_MonAn, chiTiet.SoLuong);
                }
                BLLOrder.Instance.ExecuteAddUpdate(new Order
                {
                    id_Order = id_Order,
                    id_KhachHang = id_KhachHang,
                    id_NhanVien = id_NhanVien,
                });
                this.ExecuteAddUpdate(new HoaDon
                {
                    id_HoaDon = this.AutoGeneratedId(),
                    id_Order = id_Order,
                    NgayLap = DateTime.Now
                });
                BLLChiTietOrder.Instance.ExecuteListOrder(id_Order, chiTiets);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<HoaDon_ViewThongKe> ThongKe(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            List<HoaDon_ViewThongKe> list = new List<HoaDon_ViewThongKe>();
            try
            {
                list = db.HoaDon
                        .Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end)
                        .GroupBy(hd => hd.NgayLap)
                        .Select(gr => new HoaDon_ViewThongKe
                        {
                            Ngay = gr.Key,
                            SoLuongHoaDon = gr.Count(),
                            TongNhap = gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaNhap)),
                            TongBan = gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan)),
                            TienLoi = gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan)) - gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaNhap)),
                        })
                        .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public DataSet ThongKeChart(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            DataSet ds = new DataSet();
            try
            {
                var q = db.HoaDon
                        .Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end)
                        .GroupBy(hd => hd.NgayLap)
                        .Select(gr => new
                        {
                            Ngay = gr.Key,
                            TienLoi = gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan)) - gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaNhap)),
                        });
                DataTable dt = new DataTable();
                dt.Columns.Add("Ngày");
                dt.Columns.Add("Tiền lời");
                foreach (var item in q)
                {
                    dt.Rows.Add(item.Ngay, item.TienLoi);
                }
                ds.Tables.Add(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
        public int GetSoHoaDon(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            int soHoaDon = 0;
            try
            {
                soHoaDon = db.HoaDon.Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end).Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return soHoaDon;
        }
        public double GetTongTien(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            double tongTien = 0;
            try
            {
                if (db.HoaDon.Select(hd => hd).Count() == 0)
                    tongTien = 0;
                else
                    tongTien = db.HoaDon
                        .Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end)
                        .Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan * ct.SoLuong));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return tongTien;
        }
        public double GetDoanhThu(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            double doanhThu = 0;
            try
            {
                if (db.HoaDon.Select(hd => hd).Count() == 0)
                    doanhThu = 0;
                else
                    doanhThu = db.HoaDon
                        .Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end)
                        .Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan * ct.SoLuong - ct.GiaNhap * ct.SoLuong));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return doanhThu;
        }
        public dynamic Top5()
        {
            var listID = db.HoaDon
                .Where(hd => hd.IsDelete == false)
                .Select(hd => hd.Order.ChiTietOrder)
                .SelectMany(ct => ct)
                .GroupBy(ct => ct.id_MonAn)
                .Select(gr => new
                {
                    id_MonAn = gr.Key,
                    SoLuong = gr.Sum(ct => ct.SoLuong)
                })
                .OrderByDescending(gr => gr.SoLuong)
                .Take(5);

            var listMonAn = db.MonAn.Where(ma => ma.IsDeleted == false)
                .AsEnumerable()
                .Join(listID, ma => ma.id_MonAn, gr => gr.id_MonAn, (ma, gr) => new
                {
                    TenMonAn = ma.TenMonAn,
                    SoLuong = gr.SoLuong,
                });

            return listMonAn.ToArray();
        }
    }
}
