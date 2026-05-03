using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medbay.WinForms.UI
{

    public partial class PatientForm : Form
    {
        private Domain.Patient? _editing;
        private readonly Application.PatientService _service = new();

        public PatientForm()
        {
            InitializeComponent();
        }
        public void SetEditPatient(Domain.Patient p)
        {
            _editing = p;

            txtFullName.Text = p.FullName;
            dtpDob.Value = p.Dob;
            txtPhone.Text = p.Phone ?? "";
            txtAddress.Text = p.Address ?? "";

        }
        private void PatientForm_Load(object sender, EventArgs e)
        {
            var genders = new Medbay.WinForms.Data.GenderRepository().List();
            cmbGender.DataSource = genders;
            cmbGender.DisplayMember = "GenderName";
            cmbGender.ValueMember = "GenderID";

            if (_editing != null)
                cmbGender.SelectedValue = _editing.GenderID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Domain.Patient
                {
                    FullName = txtFullName.Text,
                    Dob = dtpDob.Value.Date,
                    GenderID = Convert.ToInt32(cmbGender.SelectedValue),
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };
                if (_editing == null)
                {
                    _service.Add(p);
                }
                else
                {
                    p.ID = _editing.ID;
                    _service.Edit(p);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
