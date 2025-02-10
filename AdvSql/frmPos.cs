using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AdvSql
{
    public partial class frmPos : Form
    {
        public frmPos()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlTransaction tr;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmPos_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            ListViewFormat();
            ClearProductData();
        }

        private void ClearProductData()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtUnitPrice.Text = "0";
            txtQuantity.Text = "1";
            txtTotal.Text = "0";
        }

        private void ListViewFormat()
        {
            lsvProducts.Columns.Add("รหัสสินค้า", 100, HorizontalAlignment.Left);
            lsvProducts.Columns.Add("สินค้า", 150, HorizontalAlignment.Left);
            lsvProducts.Columns.Add("ราคา", 65, HorizontalAlignment.Right);
            lsvProducts.Columns.Add("จำนวนเงิน", 50, HorizontalAlignment.Right);
            lsvProducts.Columns.Add("รวมเป็นเงิน", 70, HorizontalAlignment.Right);
            lsvProducts.View = View.Details;
            lsvProducts.GridLines = true;
            lsvProducts.FullRowSelect = true;
        }
        private void clearEmployeeData()
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
        }
        private void CalculateTotal()
        {
            double total = Convert.ToDouble(txtUnitPrice.Text) * Convert.ToDouble(txtQuantity.Text);
            txtTotal.Text = total.ToString("#,##0.00");
            //txtProductID.Focus();
        }
        private void CalulateNetPrice()
        {
            int i = 0;
            double tmpNetPrice = 0.0;
            for (i = 0; i <= lsvProducts.Items.Count - 1; i++)
            {
                tmpNetPrice += Convert.ToDouble(lsvProducts.Items[i].SubItems[4].Text);
            }
            lblNetPrice.Text = tmpNetPrice.ToString("#,##0.00");
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "Select EmployeeID,Title+FirstName+ SPACE(2)+ LastName as empName"
                + " , Position from employees where employeeID = @employeeID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtEmployeeID.Text = dt.Rows[0][0].ToString();
                    txtEmployeeName.Text = dt.Rows[0][1].ToString();
                    txtProductID.Focus();
                }
                else
                {
                    clearEmployeeData();
                    txtEmployeeName.Focus();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "Select ProductID, ProductName,unitPrice"
                + " from products where productID = @ProductID";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    txtProductID.Text = dt.Rows[0][0].ToString();
                    txtProductName.Text = dt.Rows[0][1].ToString();
                    txtUnitPrice.Text = dt.Rows[0][2].ToString();
                    CalculateTotal();
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                }
                else
                {
                    MessageBox.Show("ไมพ่ บสนิคํา้นี้", "ผิดพลําด");
                    ClearProductData();
                    txtProductID.Focus();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == "") txtQuantity.Text = "1";
            if (Convert.ToInt16(txtQuantity.Text) == 0) txtQuantity.Text = "1";
            CalculateTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text.Trim() == "" || txtProductName.Text.Trim() == "")
            {
                txtProductID.Focus(); return;
            }
            if (Convert.ToInt16(txtQuantity.Text) == 0)
            {
                txtProductID.Focus(); return;
            }
            ListViewItem lvi;
            int i = 0; string tmpProductID = "";
            for (i = 0; i <= lsvProducts.Items.Count - 1; i++)
            {
                tmpProductID = lsvProducts.Items[i].SubItems[0].Text;
                if (txtProductID.Text.Trim() == tmpProductID)
                {
                    int qty = Convert.ToInt16(lsvProducts.Items[i].SubItems[3].Text)
                    + Convert.ToInt16(txtQuantity.Text);
                    double newTotal = Convert.ToDouble(lsvProducts.Items[i].SubItems[4].Text)
                    + Convert.ToDouble(txtTotal.Text); //**
                    lsvProducts.Items[i].SubItems[3].Text = qty.ToString();
                    lsvProducts.Items[i].SubItems[4].Text = newTotal.ToString("#,##0.00");
                    ClearProductData();
                    CalculateTotal();
                    CalulateNetPrice();
                    return;
                }
            }
            string[] anyData;
            anyData = new string[] { txtProductID.Text, txtProductName.Text, txtUnitPrice.Text, txtQuantity.Text, txtTotal.Text };
            lvi = new ListViewItem(anyData);
            lsvProducts.Items.Add(lvi);
            CalulateNetPrice(); ClearProductData(); btnSave.Enabled = true;
            txtProductID.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearProductData();
        }

        private void lsvProducts_DoubleClick(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i <= lsvProducts.SelectedItems.Count - 1; i++)
            {
                ListViewItem lvi = lsvProducts.SelectedItems[i];
                lsvProducts.Items.Remove(lvi);
            }
            CalulateNetPrice();
            txtProductID.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lsvProducts.Clear();
            clearEmployeeData();
            ClearProductData();
            ListViewFormat();
            lblNetPrice.Text = "0.00";
            txtEmployeeID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            int lastOrderID = 0;
            if (txtEmployeeID.Text.Trim() == "")
            {
                MessageBox.Show("โปรดระบุผู้ขายสินค้าก่อน", "มีข้อผิดพลาด");
                txtEmployeeID.Focus();
                return;
            }
            if (lsvProducts.Items.Count > 0)
            {
                if (MessageBox.Show("ต้องการบันบึกรายการสั่งซื้อหรือไม่", "กรุณายืนยัน", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
                {

                    conn.Open();
                    tr = conn.BeginTransaction();
                    string sql = "insert into Receipts(ReceiptDate,EmployeeID,TotalCash)"
                    + " values (getdate(),@EmployeeID,@TotalCash)";
                    SqlCommand comm = new SqlCommand(sql, conn, tr);
                    comm.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text.Trim());
                    comm.Parameters.AddWithValue("@TotalCash", lblNetPrice.Text);
                    comm.ExecuteNonQuery();
                    string sql1 = "select top 1 ReceiptID from Receipts order by ReceiptID desc";
                    SqlCommand comm1 = new SqlCommand(sql1, conn, tr);
                    SqlDataReader dr = comm1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        lastOrderID = dr.GetInt32(dr.GetOrdinal("ReceiptID"));
                    }
                    dr.Close();
                    msg += "ผู้ขาย: " + txtEmployeeName.Text + Environment.NewLine;
                    msg += "หมายเลขใบสั่งซื้อ: " + lastOrderID.ToString() + Environment.NewLine;
                    for (int i = 0; i <= lsvProducts.Items.Count - 1; i++)
                    {
                        string sql2 = "insert into Details(ReceiptID,ProductID,UnitPrice,Quantity)"
                        + " values(@ReceiptID,@ProductID,@UnitPrice,@Quantity)";
                        SqlCommand comm3 = new SqlCommand(sql2, conn, tr);
                        comm3.Parameters.AddWithValue("@ReceiptID", lastOrderID);
                        comm3.Parameters.AddWithValue("@ProductID", lsvProducts.Items[i].SubItems[0].Text);
                        comm3.Parameters.AddWithValue("@UnitPrice", lsvProducts.Items[i].SubItems[2].Text);
                        comm3.Parameters.AddWithValue("@Quantity", lsvProducts.Items[i].SubItems[3].Text);
                        comm3.ExecuteNonQuery();
                        msg += lsvProducts.Items[i].SubItems[0].Text + ", ";
                        msg += lsvProducts.Items[i].SubItems[1].Text + ", ";
                        msg += lsvProducts.Items[i].SubItems[2].Text + ", ";
                        msg += lsvProducts.Items[i].SubItems[3].Text + ", " + Environment.NewLine;
                    }
                    tr.Commit();
                    conn.Close();
                    msg += "\nยอดรวมทั้งหมด: " + lblNetPrice.Text;
                    MessageBox.Show(msg, "บันทึกรายการขายเรียบร้อยแล้ว");
                }
                btnCancel.PerformClick();
            }
        }
    }
}
