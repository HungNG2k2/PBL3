﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.BLL;
using PBL3.DTO;

namespace PBL3.View
{
    public partial class frmMenu : Form
    {
        public double total = 0;
        public int totalNumOrder = 0;
        public List<ItemFood> itemFoods;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
            var data = BLLMonAn.Instance.GetAll2();
            var list = new ItemFood[data.Count];
            int i = 0;
            itemFoods = new List<ItemFood>();
            foreach (var item in data)
            {
                list[i] = new ItemFood(item);
                list[i].itemValueChanged += frmMenu_itemValueChanged;
                itemFoods.Add(list[i]);
                i++;
            }
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(list);
            lbl_Tongtien.Text = "₫0";
            lbl_numOrder.Text = "0";
        }

        private void frmMenu_itemValueChanged(object sender, ItemFood.ItemValueChangedEventArgs e)
        {

            if (e.IsAdd)
            {
                total += e.Value;
                totalNumOrder += 1;
            }
            else
            {
                total -= e.Value;
                totalNumOrder -= 1;
            }
            if (total == 0)
            {
                lbl_Tongtien.Text = "₫0";
                lbl_numOrder.Text = "0";
            }
            else
            {
                lbl_numOrder.Text = totalNumOrder.ToString();
                lbl_Tongtien.Text = "₫" + total.ToString("#,#");
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lbl_numOrder.Text) > 0)
            {
                var list_order = new List<MonAn>();
                int i = 1;
                foreach (ItemFood item in flowLayoutPanel1.Controls)
                {
                    if (item.count > 0)
                    {
                        list_order.Add(new MonAn() {
                            id_MonAn = item.monAn.id_MonAn,
                            TenMonAn = item.monAn.TenMonAn,
                            Gia = item.monAn.Gia,
                            imagePath = item.monAn.imagePath,
                            SoLuong = item.count,
                        });
                        i++;
                    }
                }

                var frm = new frmOrder(list_order);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn món ăn.");
            }
        }
    }
}