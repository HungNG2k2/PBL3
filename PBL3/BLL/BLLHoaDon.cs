﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

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
            db.HoaDon.Remove(db.HoaDon.Find(id));
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
                    NgayLap = t.NgayLap,
                });
                db.SaveChanges();
            }
            else
            {
                HoaDon hd = db.HoaDon.Find(t.id_Order);
                hd.NgayLap = t.NgayLap;
                db.SaveChanges();
            }
        }

        public dynamic GetAll()
        {
            return db.HoaDon.Select(p => p);
        }

        public HoaDon GetById(string id)
        {
            return db.HoaDon.Find(id);
        }
        public void LapHoaDon(List<MonAn> monAns, string id_NhanVien, string id_KhachHang)
        {
            string id_Order = BLLOrder.Instance.AutoGeneratedId();
            double TongTien = 0;
            foreach(MonAn monAn in monAns)
            {
                TongTien += monAn.SoLuong * monAn.Gia;
            }   
            BLLOrder.Instance.ExecuteAddUpdate(new Order
            {
                id_Order = id_Order,
                id_KhachHang = id_KhachHang,
                id_NhanVien = id_NhanVien,
                TongTien = TongTien
            });
            this.ExecuteAddUpdate(new HoaDon
            {
                id_HoaDon = this.AutoGeneratedId(),
                id_Order = id_Order,
                NgayLap = DateTime.Now.Date,
            });
            BLLChiTietOrder.Instance.ExcuteListMonAn(id_Order, monAns);
            foreach (MonAn item in monAns)
            {
                BLLMonAn.Instance.Sell(item.id_MonAn, item.SoLuong);
            }
        }
    }
}
