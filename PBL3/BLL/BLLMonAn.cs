﻿using PBL3.DTO;
using System;
using System.IO;
using System.Linq;

namespace PBL3.BLL
{
    public class BLLMonAn : BLLInterface<MonAn>
    {
        QLCHTAN db = new QLCHTAN();

        private string _imageFilePath = @".\image\";

        public string DefaultImage
        {
            get
            {
                return @".\image\default.jpg";
            }
            private set { }
        }

        private static BLLMonAn _Instance;

        public static BLLMonAn Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLLMonAn();
                }
                return _Instance;
            }
            private set { }
        }

        private BLLMonAn()
        {

        }

        public bool checkAddUpdate(string id)
        {
            bool Add = true;
            if (db.MonAn.Find(id) != null)
            {
                Add = false;
            }
            return Add;
        }

        public void Delete(string id)
        {
            db.MonAn.Remove(db.MonAn.Find(id));
            db.SaveChanges();
            string[] files = Directory.GetFiles(_imageFilePath, id + ".*");
            foreach (string f in files)
            {
                File.Delete(f);
            }
        }

        public string AutoGeneratedId()
        {
            string id_next = "";
            string id_max = db.MonAn.Select(p => p.id_MonAn).ToList().Max();
            if (id_max == null)
            {
                id_next = "MA001";
            }
            else
            {
                int max = Convert.ToInt32(id_max.Substring(id_max.Length - 3));
                max++;
                id_next = "MA" + ("000" + max).Substring(("000" + max).Length - 3);
            }
            return id_next;
        }

        public string CopyImageFile(string sourceFile, string newFileName)
        {
            string extension = ".jpg";
            string newFilePath = Path.Combine(_imageFilePath, newFileName + extension);
            Directory.CreateDirectory(_imageFilePath);
            if (String.Compare(Path.GetFullPath(sourceFile).TrimEnd('\\'), Path.GetFullPath(newFilePath).TrimEnd('\\')) == 0)
            {
                return newFilePath;
            }
            File.Copy(sourceFile, newFilePath, true);
            return newFilePath;
        }

        public void ExecuteAddUpdate(MonAn t)
        {

            if (checkAddUpdate(t.id_MonAn))
            {
                String id = AutoGeneratedId();
                db.MonAn.Add(new MonAn
                {
                    id_MonAn = id,
                    TenMonAn = t.TenMonAn,
                    GiaNhap = t.GiaNhap,
                    GiaBan = t.GiaBan,
                    SoLuong = 0,
                    imagePath = CopyImageFile(t.imagePath, id),
                });
                db.SaveChanges();
            }
            else
            {
                MonAn ma = db.MonAn.Find(t.id_MonAn);
                ma.TenMonAn = t.TenMonAn;
                ma.GiaNhap = t.GiaNhap;
                ma.GiaBan = t.GiaBan;
                ma.SoLuong = t.SoLuong;
                ma.imagePath = CopyImageFile(t.imagePath, t.id_MonAn);
                db.SaveChanges();
            }
        }

        public dynamic GetAll()
        {
            return db.MonAn.Select(p => new { p.id_MonAn, p.TenMonAn, p.GiaNhap, p.GiaBan }).ToList();
        }

        public dynamic GetAll2()
        {
            return db.MonAn.Select(p => p).ToList();
        }

        public MonAn GetById(string id)
        {
            return db.MonAn.Find(id);
        }
        public dynamic GetMonAn()
        {
            return db.MonAn.Select(p => new { p.TenMonAn, p.SoLuong, p.GiaNhap ,p.GiaBan }).ToList();
        }
        public MonAn GetmonByten(string ten)
        {
            return db.MonAn.Where(p => p.TenMonAn == ten).FirstOrDefault();
        }
        public void Sell(string id_MonAn, int soLuong)
        {
            MonAn monAn = GetById(id_MonAn);
            ExecuteAddUpdate(new MonAn {
                id_MonAn = monAn.id_MonAn,
                TenMonAn = monAn.TenMonAn,
                GiaBan = monAn.GiaBan,
                GiaNhap = monAn.GiaNhap,
                SoLuong = monAn.SoLuong - soLuong,
                imagePath = monAn.imagePath,
            });
        }
    }
}
