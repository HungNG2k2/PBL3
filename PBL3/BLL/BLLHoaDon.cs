﻿using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
namespace PBL3.BLL
{
    public class BLLHoaDon : BLLInterface<HoaDon>
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
            if (db.HoaDon.Find(id) != null)
            {
                Add = false;
            }
            return Add;
        }

        public void Delete(string id)
        {
            db.HoaDon.Find(id).IsDelete = true;
            db.SaveChanges();
        }
        public string AutoGeneratedId()
        {
            string id_next = "";
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
            return id_next;
        }
        public void ExecuteAddUpdate(HoaDon t)
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
        }

        public dynamic GetAll()
        {
            return db.HoaDon
                .Where(p => p.IsDelete == false)
                .Select(p => new { p.id_HoaDon, p.Order.NhanVien.TenNhanVien, p.Order.KhachHang.TenKhachHang, p.NgayLap, TongTien = p.Order.ChiTietOrder.Sum(ct => ct.GiaBan * ct.SoLuong) }).ToList();
        }

        public HoaDon GetById(string id)
        {
            return db.HoaDon.Find(id);
        }
        public void LapHoaDon(List<ChiTietOrder> chiTiets, string id_NhanVien, string id_KhachHang)
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
            BLLChiTietOrder.Instance.ExcuteListOrder(id_Order, chiTiets);
        }

        public dynamic ThongKe(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            var q = db.HoaDon
                .Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end)
                .GroupBy(hd => hd.NgayLap)
                .Select(gr => new
                {
                    Ngay = gr.Key,
                    SoLuongHoaDon = gr.Count(),
                    TongNhap = gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaNhap)),
                    TongBan = gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan)),
                    TienLoi = gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan)) - gr.Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaNhap)),
                });
            return q.ToList();
        }
        public DataSet ThongKeChart(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            DataSet ds = new DataSet();
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
            return ds;
        }
        public int GetSoHoaDon(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            return db.HoaDon.Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end).Count();
        }
        public double GetTongTien(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            return db.HoaDon.Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end).Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan * ct.SoLuong));
        }
        public double GetDoanhThu(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;
            return db.HoaDon.Where(hd => hd.IsDelete == false && hd.NgayLap >= start && hd.NgayLap <= end).Sum(hd => hd.Order.ChiTietOrder.Sum(ct => ct.GiaBan * ct.SoLuong - ct.GiaNhap * ct.SoLuong));
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
