﻿namespace PBL3.View
{
    partial class frmHoadon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.butDetail = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtNhanvienlap = new System.Windows.Forms.TextBox();
            this.txtmaKhachhang = new System.Windows.Forms.TextBox();
            this.txtMahoadon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.butDetail);
            this.panel2.Controls.Add(this.butSave);
            this.panel2.Controls.Add(this.butDelete);
            this.panel2.Controls.Add(this.butUpdate);
            this.panel2.Controls.Add(this.butAdd);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.txtNhanvienlap);
            this.panel2.Controls.Add(this.txtmaKhachhang);
            this.panel2.Controls.Add(this.txtMahoadon);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 326);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(448, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "Hóa đơn";
            // 
            // butDetail
            // 
            this.butDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDetail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butDetail.Location = new System.Drawing.Point(743, 236);
            this.butDetail.Name = "butDetail";
            this.butDetail.Size = new System.Drawing.Size(100, 60);
            this.butDetail.TabIndex = 12;
            this.butDetail.Text = "Chi tiết";
            this.butDetail.UseVisualStyleBackColor = true;
            // 
            // butSave
            // 
            this.butSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butSave.Location = new System.Drawing.Point(586, 236);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(100, 60);
            this.butSave.TabIndex = 11;
            this.butSave.Text = "Lưu";
            this.butSave.UseVisualStyleBackColor = true;
            // 
            // butDelete
            // 
            this.butDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butDelete.Location = new System.Drawing.Point(422, 236);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(100, 60);
            this.butDelete.TabIndex = 10;
            this.butDelete.Text = "Xóa";
            this.butDelete.UseVisualStyleBackColor = true;
            // 
            // butUpdate
            // 
            this.butUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butUpdate.Location = new System.Drawing.Point(266, 236);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(100, 60);
            this.butUpdate.TabIndex = 9;
            this.butUpdate.Text = "Sửa";
            this.butUpdate.UseVisualStyleBackColor = true;
            // 
            // butAdd
            // 
            this.butAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butAdd.Location = new System.Drawing.Point(111, 236);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(100, 60);
            this.butAdd.TabIndex = 8;
            this.butAdd.Text = "Thêm";
            this.butAdd.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(671, 164);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 27);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // txtNhanvienlap
            // 
            this.txtNhanvienlap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNhanvienlap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanvienlap.Location = new System.Drawing.Point(206, 159);
            this.txtNhanvienlap.Name = "txtNhanvienlap";
            this.txtNhanvienlap.Size = new System.Drawing.Size(233, 30);
            this.txtNhanvienlap.TabIndex = 6;
            // 
            // txtmaKhachhang
            // 
            this.txtmaKhachhang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtmaKhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmaKhachhang.Location = new System.Drawing.Point(671, 85);
            this.txtmaKhachhang.Name = "txtmaKhachhang";
            this.txtmaKhachhang.Size = new System.Drawing.Size(233, 30);
            this.txtmaKhachhang.TabIndex = 5;
            // 
            // txtMahoadon
            // 
            this.txtMahoadon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMahoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMahoadon.Location = new System.Drawing.Point(206, 85);
            this.txtMahoadon.Name = "txtMahoadon";
            this.txtMahoadon.Size = new System.Drawing.Size(233, 30);
            this.txtMahoadon.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(499, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngày lập";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(496, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã khách hàng";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(43, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhân viên lập";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(43, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(0, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 178);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách hóa đơn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(965, 155);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmHoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(971, 504);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmHoadon";
            this.Text = "frmHoadon";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butDetail;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtNhanvienlap;
        private System.Windows.Forms.TextBox txtmaKhachhang;
        private System.Windows.Forms.TextBox txtMahoadon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}