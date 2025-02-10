namespace AdvSql
{
    partial class frmPos
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
            txtEmployeeID = new TextBox();
            txtEmployeeName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblNetPrice = new Label();
            groupBox1 = new GroupBox();
            lsvProducts = new ListView();
            txtTotal = new TextBox();
            txtQuantity = new TextBox();
            txtUnitPrice = new TextBox();
            txtProductName = new TextBox();
            txtProductID = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnAdd = new Button();
            btnClear = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(100, 9);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(81, 27);
            txtEmployeeID.TabIndex = 0;
            txtEmployeeID.KeyDown += txtEmployeeID_KeyDown;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(262, 9);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(197, 27);
            txtEmployeeName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "รหัสพนักงาน";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(199, 12);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 3;
            label2.Text = "ชื่อ-สกุล";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(696, 12);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 6;
            label3.Text = "รวมเป็นเงิน";
            // 
            // lblNetPrice
            // 
            lblNetPrice.BackColor = SystemColors.ActiveCaption;
            lblNetPrice.Font = new Font("Ancient", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNetPrice.Location = new Point(696, 38);
            lblNetPrice.Name = "lblNetPrice";
            lblNetPrice.Size = new Size(210, 48);
            lblNetPrice.TabIndex = 7;
            lblNetPrice.Text = "0.00";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lsvProducts);
            groupBox1.Controls.Add(txtTotal);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(txtProductID);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(11, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(664, 477);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "รายการสั่งซื้อ";
            // 
            // lsvProducts
            // 
            lsvProducts.Location = new Point(33, 85);
            lsvProducts.Name = "lsvProducts";
            lsvProducts.Size = new Size(596, 377);
            lsvProducts.TabIndex = 19;
            lsvProducts.UseCompatibleStateImageBehavior = false;
            lsvProducts.DoubleClick += lsvProducts_DoubleClick;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(531, 41);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(98, 27);
            txtTotal.TabIndex = 29;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(440, 41);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(68, 27);
            txtQuantity.TabIndex = 28;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(299, 41);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(110, 27);
            txtUnitPrice.TabIndex = 27;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(153, 41);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(125, 27);
            txtProductName.TabIndex = 26;
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(34, 41);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(100, 27);
            txtProductID.TabIndex = 25;
            txtProductID.KeyDown += txtProductID_KeyDown;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(542, 18);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 24;
            label10.Text = "รวมเป็นเงิน";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(449, 18);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 23;
            label9.Text = "จำนวน";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(321, 18);
            label8.Name = "label8";
            label8.Size = new Size(62, 20);
            label8.TabIndex = 22;
            label8.Text = "ราคาขาย";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(187, 18);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 21;
            label7.Text = "ชื่อสินค้า ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 18);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 20;
            label6.Text = "รหัสสินค้า";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(696, 123);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "เพิ่ม";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(696, 171);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 21;
            btnClear.Text = "เคลียร์";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(696, 245);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(138, 29);
            btnSave.TabIndex = 22;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(696, 293);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(138, 29);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "ยกเลิกรายการสั่งซื้อ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmPos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 562);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Controls.Add(lblNetPrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmployeeName);
            Controls.Add(txtEmployeeID);
            Name = "frmPos";
            Text = "frmPos";
            Load += frmPos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmployeeID;
        private TextBox txtEmployeeName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblNetPrice;
        private GroupBox groupBox1;
        private ListView lsvProducts;
        private TextBox txtTotal;
        private TextBox txtQuantity;
        private TextBox txtUnitPrice;
        private TextBox txtProductName;
        private TextBox txtProductID;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button btnAdd;
        private Button btnClear;
        private Button btnSave;
        private Button btnCancel;
    }
}