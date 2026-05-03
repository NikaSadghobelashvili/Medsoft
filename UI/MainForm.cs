using Medbay.WinForms.UI;

namespace Medbay.WinForms
{
    public partial class MainForm : Form
    {
        private readonly Application.PatientService _service = new();
        public MainForm()
        {
            InitializeComponent();
        }
        private void ConfigureGrid()
        {
            dgvPatients.Columns["ID"].HeaderText = "ID";
            dgvPatients.Columns["FullName"].HeaderText = "პაციენტის გვარი/სახელი";
            dgvPatients.Columns["Dob"].HeaderText = "დაბ თარიღი";
            dgvPatients.Columns["GenderName"].HeaderText = "სქესი";
            dgvPatients.Columns["Phone"].HeaderText = "მობ ნომერი";
            dgvPatients.Columns["Address"].HeaderText = "მისამართი";
            dgvPatients.Columns["GenderID"].Visible = false; // თუ არ გჭირდება
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvPatients.DataSource = _service.List();
            ConfigureGrid();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("გთხოვთ მონიშნოთ პაციენტი");
                return;
            }
            var idObj = dgvPatients.SelectedRows[0].Cells["ID"].Value;
            if (idObj == null || idObj == DBNull.Value)
            {
                MessageBox.Show("მონიშნული ჩანაწერის ID ვერ მოიძებნა");
                return;
            }
            var id = Convert.ToInt32(idObj);
            var result = MessageBox.Show(
                "გსურთ მონიშნული ჩანაწერის წაშლა?",
                "დადასტურება",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result != DialogResult.Yes)
                return;
            _service.Delete(id);
            dgvPatients.DataSource = _service.List();
            ConfigureGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var f = new PatientForm();
            if (f.ShowDialog() == DialogResult.OK)
                dgvPatients.DataSource = _service.List();
                ConfigureGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("გთხოვთ მონიშნოთ პაციენტი");
                return;
            }
            var row = dgvPatients.SelectedRows[0];
            if (row.DataBoundItem is not Domain.Patient p)
            {
                MessageBox.Show("მონაცემის წაკითხვა ვერ მოხერხდა");
                return;
            }
            using var f = new PatientForm();
            f.SetEditPatient(p);
            if (f.ShowDialog(this) == DialogResult.OK)
                dgvPatients.DataSource = _service.List();
                ConfigureGrid();
        }
    }

}

