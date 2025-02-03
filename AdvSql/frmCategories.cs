using Microsoft.Data.SqlClient;
using System.Data;

namespace AdvSql
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
            this.Load += FrmCategories_Load;
            dgvCategories.CellMouseUp += DgvCategories_CellMouseUp;
        }

        private void DgvCategories_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            txtCategoryID.Text = dgvCategories.CurrentRow.Cells["categoryID"].Value.ToString();
            txtCategoryName.Text = dgvCategories.CurrentRow.Cells["categoryName"].Value.ToString();
            txtDescription.Text = dgvCategories.CurrentRow.Cells["Description"].Value.ToString();
        }

        SqlConnection conn;
        SqlDataAdapter da;
        SqlCommand com;

        private void FrmCategories_Load(object? sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            showdata();
        }

        private void showdata()
        {
            string sql = "Select * from Categories";
            com = new SqlCommand(sql, conn);
            da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvCategories.DataSource = ds.Tables[0];
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtCategoryID.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtCategoryName.Focus();
            txtCategoryID.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("������Ǵ�����ͧ����繤����ҧ", "�Դ��ͼԴ��Ҵ");
                return;
            }

            string sql = "Insert into Categories values(@categoryName, @Description)";
            com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@categoryName", txtCategoryName.Text.Trim());
            com.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            if (com.ExecuteNonQuery() > 0)
            {
                showdata();
                btnClearForm.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                MessageBox.Show("��ͧ���͡�����ŷ���ͧ���ź��͹", "�Դ��ͼԴ��Ҵ");
                return;
            }
            if (MessageBox.Show("��ͧ���ź�������","�ô�׹�ѹ",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string sql = "DELETE FROM Categories WHERE CategoryID = @categoryID";
            com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@categoryID", txtCategoryID.Text.Trim());
            try
            {
                if (com.ExecuteNonQuery() > 0)
                {
                    showdata();
                    btnClearForm.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�Դ��ͼԴ��Ҵ :" + Environment.NewLine + ex.Message, "�������öź��������");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                MessageBox.Show("��ͧ���͡�����ŷ���ͧ�����䢡�͹", "�Դ��ͼԴ��Ҵ");
                return;
            }
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("������Ǵ�����ͧ����繤����ҧ", "�Դ��ͼԴ��Ҵ");
                return;
            }

            string sql = "Update Categories set CategoryName = @categoryName, Description = @Description where CategoryID = @categoryID";
            com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@categoryName", txtCategoryName.Text.Trim());
            com.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            com.Parameters.AddWithValue("@categoryID", txtCategoryID.Text.Trim());
            if (com.ExecuteNonQuery() > 0)
            {
                showdata();
                btnClearForm.PerformClick();
            }
        }
    }
}
