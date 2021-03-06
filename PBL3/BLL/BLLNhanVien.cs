using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PBL3.BLL
{
    public class BLLNhanVien
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
            try
            {
                if (db.NhanVien.Find(id) != null)
                {
                    Add = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Add;
        }

        public bool Delete(string id)
        {
            try
            {
                db.NhanVien.Find(id).IsDeleted = true;
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
                string id_max = db.NhanVien.Select(p => p.id_NhanVien).ToList().Max();
                if (id_max == null)
                {
                    id_next = "NV001";
                }
                else
                {
                    int max = Convert.ToInt32(id_max.Substring(id_max.Length - 3));
                    max++;
                    id_next = "NV" + ("000" + max).Substring(("000" + max).Length - 3);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id_next;
        }
        public bool ExecuteAddUpdate(NhanVien t)
        {
            try
            {
                if (checkAddUpdate(t.id_NhanVien))
                {
                    db.NhanVien.Add(new NhanVien
                    {
                        id_NhanVien = t.id_NhanVien,
                        TenNhanVien = t.TenNhanVien,
                        NgaySinh = t.NgaySinh.Date,
                        GioiTinh = t.GioiTinh,
                        SoDienThoai = t.SoDienThoai,
                        DiaChi = t.DiaChi,
                        Username = t.id_NhanVien,
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
                    nv.NgaySinh = t.NgaySinh.Date;
                    nv.Username = t.Username;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool ResetAccount(string id)
        {
            try
            {
                db.NhanVien.Find(id).Password = "123456";
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public List<NhanVien_View> GetAll()
        {
            List<NhanVien_View> list = new List<NhanVien_View>();
            try
            {
                list = db.NhanVien
                .Where(p => p.IsDeleted == false)
                .Select(p => new NhanVien_View
                {
                    id_NhanVien = p.id_NhanVien,
                    TenNhanVien = p.TenNhanVien,
                    NgaySinh = p.NgaySinh,
                    GioiTinh = p.GioiTinh ? "Nam" : "Nữ",
                    SoDienThoai = p.SoDienThoai,
                    DiaChi = p.DiaChi
                })
                .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public NhanVien GetById(string id)
        {
            NhanVien nhanVien = new NhanVien();
            try
            {
                nhanVien = db.NhanVien.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return nhanVien;
        }

        public string checkLogin(string username, string password)
        {
            string quyen = "";
            try
            {
                QLCHTAN db = new QLCHTAN();
                var query = db.NhanVien.Where(p => p.IsDeleted == false && p.Username == username && p.Password == password).FirstOrDefault();
                if (query != null)
                {
                    quyen = query.ChucVu;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return quyen.Trim();
        }
        public string GetIDByUsername(string username)
        {
            string id = "";
            try
            {
                QLCHTAN db = new QLCHTAN();
                var query = db.NhanVien.Where(p => p.Username == username).FirstOrDefault();
                if (query != null)
                {
                    id = query.id_NhanVien;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id.Trim();
        }
        public List<NhanVien_View> SearchById(string txt)
        {
            List<NhanVien_View> list = new List<NhanVien_View>();
            try
            {
                list = db.NhanVien
                .Where(p => p.IsDeleted == false && p.id_NhanVien.ToLower().Contains(txt.ToLower()))
                .Select(p => new NhanVien_View
                {
                    id_NhanVien = p.id_NhanVien,
                    TenNhanVien = p.TenNhanVien,
                    NgaySinh = p.NgaySinh,
                    GioiTinh = p.GioiTinh ? "Nam" : "Nữ",
                    SoDienThoai = p.SoDienThoai,
                    DiaChi = p.DiaChi
                })
                .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public List<NhanVien_View> SearchByTenNhanVien(string txt)
        {
            List<NhanVien_View> list = new List<NhanVien_View>();
            try
            {
                list = db.NhanVien
                    .Where(p => p.IsDeleted == false && p.TenNhanVien.ToLower().Contains(txt.ToLower()))
                    .Select(p => new NhanVien_View
                    {
                        id_NhanVien = p.id_NhanVien,
                        TenNhanVien = p.TenNhanVien,
                        NgaySinh = p.NgaySinh,
                        GioiTinh = p.GioiTinh ? "Nam" : "Nữ",
                        SoDienThoai = p.SoDienThoai,
                        DiaChi = p.DiaChi
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public List<NhanVien_View> SearchBySoDienThoai(string txt)
        {
            List<NhanVien_View> list = new List<NhanVien_View>();
            try
            {
                list = db.NhanVien
                .Where(p => p.IsDeleted == false && p.SoDienThoai.ToLower().Contains(txt.ToLower()))
                .Select(p => new NhanVien_View
                {
                    id_NhanVien = p.id_NhanVien,
                    TenNhanVien = p.TenNhanVien,
                    NgaySinh = p.NgaySinh,
                    GioiTinh = p.GioiTinh ? "Nam" : "Nữ",
                    SoDienThoai = p.SoDienThoai,
                    DiaChi = p.DiaChi
                })
                .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public List<NhanVien_View> SearchByDiaChi(string txt)
        {
            List<NhanVien_View> list = new List<NhanVien_View>();
            try
            {
                list = db.NhanVien
                .Where(p => p.IsDeleted == false && p.DiaChi.ToLower().Contains(txt.ToLower()))
                .Select(p => new NhanVien_View
                {
                    id_NhanVien = p.id_NhanVien,
                    TenNhanVien = p.TenNhanVien,
                    NgaySinh = p.NgaySinh,
                    GioiTinh = p.GioiTinh ? "Nam" : "Nữ",
                    SoDienThoai = p.SoDienThoai,
                    DiaChi = p.DiaChi
                })
                .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}
