﻿using PBL3.DTO;
using System;
using System.Data.Entity;

namespace PBL3
{
    internal class CreateDB : DropCreateDatabaseAlways<QLCHTAN>
    {
        protected override void Seed(QLCHTAN context)
        {
            context.NhanVien.AddRange(new NhanVien[]
            {
                new NhanVien
                {
                    id_NhanVien = "NV000",
                    TenNhanVien = "Admin",
                    NgaySinh = new DateTime(2002,2,2),
                    GioiTinh = true,
                    SoDienThoai = "0123456789",
                    DiaChi = "Hội An",
                    Username = "Admin",
                    Password = "123456",
                    ChucVu = "QuanLy"
                },
                new NhanVien
                {
                    id_NhanVien = "NV001",
                    TenNhanVien = "Nguyễn Văn A",
                    NgaySinh = new DateTime(2002,2,2),
                    GioiTinh = true,
                    SoDienThoai = "0123456789",
                    DiaChi = "Hội An",
                    Username = "NV001",
                    Password = "123456",
                    ChucVu = "NhanVien"
                }
            });

            context.MonAn.AddRange(new MonAn[]
            {
                new MonAn { id_MonAn = "MA001", TenMonAn = "Gà chiên giòn", Gia = 30000,  imagePath = @".\image\MA001.jpg" },
                new MonAn { id_MonAn = "MA002", TenMonAn = "Gà sốt cay", Gia = 35000, imagePath = @".\image\MA002.jpg" },
                new MonAn { id_MonAn = "MA003", TenMonAn = "Khoai tây chiên lớn", Gia = 25000, imagePath = @".\image\MA003.jpg" },
                new MonAn { id_MonAn = "MA004", TenMonAn = "Khoai tây lắc vị BBQ lớn", Gia = 35000, imagePath = @".\image\MA004.jpg" },
                new MonAn { id_MonAn = "MA005", TenMonAn = "Khoai viên rong biển", Gia = 25000, imagePath = @".\image\MA005.jpg" },
                new MonAn { id_MonAn = "MA006", TenMonAn = "Burger bò phô mai đặc biệt", Gia = 52000, imagePath = @".\image\MA006.jpg" },
                new MonAn { id_MonAn = "MA007", TenMonAn = "Burger bò phô mai 2 lớp", Gia = 62000, imagePath = @".\image\MA007.jpg" },
                new MonAn { id_MonAn = "MA008", TenMonAn = "Burger bò hoàng gia đặc biệt", Gia = 82000, imagePath = @".\image\MA008.jpg" },
                new MonAn { id_MonAn = "MA009", TenMonAn = "Burger gà cay", Gia = 82000, imagePath = @".\image\MA009.jpg" },
                new MonAn { id_MonAn = "MA010", TenMonAn = "Burger gà sốt mayo", Gia = 62000, imagePath = @".\image\MA010.jpg" },
                new MonAn { id_MonAn = "MA011", TenMonAn = "Burger cá", Gia = 52000, imagePath = @".\image\MA011.jpg" },
                new MonAn { id_MonAn = "MA012", TenMonAn = "Bánh táo hương quế", Gia = 52000, imagePath = @".\image\MA012.jpg" },
                new MonAn { id_MonAn = "MA013", TenMonAn = "Pizza gà BBQ nướng dứa", Gia = 89000, imagePath = @".\image\MA013.jpg" },
                new MonAn { id_MonAn = "MA014", TenMonAn = "Pizza giăm bông & thịt xông khói", Gia = 89000, imagePath = @".\image\MA014.jpg"},
                new MonAn { id_MonAn = "MA015", TenMonAn = "Pizza thanh cua & xúc xích", Gia = 89000, imagePath = @".\image\MA015.jpg" }
            });

        }
    }
}
