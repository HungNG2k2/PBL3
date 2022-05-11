﻿using PBL3.DTO;
using System;
using System.Linq;

namespace PBL3.BLL
{
    class BLLNhanVien
    {
        QLCHTAN db = new QLCHTAN();
        private static BLLNhanVien _Instance;

        public static BLLNhanVien Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLNhanVien();
                }
                return _Instance;
            }
            private set { }
        }

        private BLLNhanVien()
        {

        }

        public bool checkAddUpdate(string id)
        {
            bool Add = true;
            foreach (NhanVien i in db.NhanVien)
            {
                if (i.id_NhanVien == id)
                    Add = false;
            }
            return Add;
        }

        public void Delete(string id)
        {
            db.NhanVien.Remove(db.NhanVien.Find(id));
            db.SaveChanges();
        }

        public string AutoGeneratedId()
        {
            string id_next = "";
            string id_max = db.NhanVien.Select(p => p.id_NhanVien).ToList().Max();
            if(id_max == null)
            {
                id_next = "NV001";
            }
            else
            {
                int max = Convert.ToInt32(id_max.Substring(id_max.Length - 3));
                max++;
                id_next = "NV" + ("000" + max).Substring(("000" + max).Length - 3);
            }
            return id_next;
        }
        public void ExecuteAddUpdate(NhanVien t)
        {
            if (checkAddUpdate(t.id_NhanVien))
            {
                String id = AutoGeneratedId();
                db.NhanVien.Add(new NhanVien
                {
                    id_NhanVien = id,
                    TenNhanVien = t.TenNhanVien,
                    NgaySinh = t.NgaySinh,
                    GioiTinh = t.GioiTinh,
                    SoDienThoai = t.SoDienThoai,
                    DiaChi = t.DiaChi,
                    Username = id,
                    Password = "123456",
                    ChucVu = "NhanVien"
                });
                db.SaveChanges();
            }
            else
            {
                NhanVien nv = db.NhanVien.Find(t.id_NhanVien);
                nv.TenNhanVien = t.TenNhanVien;
                nv.DiaChi = t.DiaChi;
                nv.GioiTinh = t.GioiTinh;
                nv.SoDienThoai = t.SoDienThoai;
                nv.NgaySinh = t.NgaySinh;
                db.SaveChanges();
            }
        }

        public dynamic GetAll()
        {
            return db.NhanVien.ToList();
        }

        public dynamic GetById(string id)
        {
            return db.NhanVien.Find(id);
        }
    }
}