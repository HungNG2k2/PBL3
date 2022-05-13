﻿using PBL3.DTO;
using System;
using System.IO;
using System.Linq;

namespace PBL3.BLL
{
    public class BLLMonAn : BLLInterface<MonAn>
    {
        QLCHTAN db = new QLCHTAN();

        private string imageFilePath = @"..\image\";

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
            string[] files = Directory.GetFiles(imageFilePath, id + ".*");
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
            string newFilePath = Path.Combine(imageFilePath, newFileName + extension);
            Directory.CreateDirectory(imageFilePath);
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
                    Gia = t.Gia,
                    imagePath = CopyImageFile(t.imagePath, id),
                });
                db.SaveChanges();
            }
            else
            {
                MonAn ma = db.MonAn.Find(t.id_MonAn);
                ma.TenMonAn = t.TenMonAn;
                ma.Gia = t.Gia;
                ma.imagePath = CopyImageFile(t.imagePath, t.id_MonAn);
                db.SaveChanges();
            }
        }

        public dynamic GetAll()
        {
            return db.MonAn.Select(p => new { p.id_MonAn, p.TenMonAn, p.Gia }).ToList();
        }

        public MonAn GetById(string id)
        {
            return db.MonAn.Find(id);
        }
    }
}
