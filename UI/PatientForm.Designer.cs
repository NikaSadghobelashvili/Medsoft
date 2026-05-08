namespace Medbay.WinForms.UI
{
    partial class PatientForm
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
            label1 = new Label();
            txtFullName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dtpDob = new DateTimePicker();
            cmbGender = new ComboBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            btnCancel = new Button();
            button2 = new Button();
            label6 = new Label();
            label7 = new Label();
            txtEmail = new TextBox();
            txtPersonalNumber = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 31);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "სახელი/გვარი";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(202, 24);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(125, 27);
            txtFullName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 79);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 2;
            label2.Text = "დაბ. თარიღი";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 130);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 3;
            label3.Text = "სქესი ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(80, 179);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 4;
            label4.Text = "მობ ნომერი";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 233);
            label5.Name = "label5";
            label5.Size = new Size(95, 20);
            label5.TabIndex = 5;
            label5.Text = "მისამართი ";
            // 
            // dtpDob
            // 
            dtpDob.Location = new Point(202, 79);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(250, 27);
            dtpDob.TabIndex = 6;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(202, 122);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(151, 28);
            cmbGender.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(208, 172);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(208, 230);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(40, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "გაუქმება ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // button2
            // 
            button2.Location = new Point(282, 370);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 11;
            button2.Text = "შენახვა";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(80, 284);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 12;
            label6.Text = "ელ ფოსტა";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(80, 326);
            label7.Name = "label7";
            label7.Size = new Size(127, 20);
            label7.TabIndex = 13;
            label7.Text = "პირადი ნომერი";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(208, 281);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 14;
            // 
            // txtPersonalNumber
            // 
            txtPersonalNumber.Location = new Point(228, 319);
            txtPersonalNumber.Name = "txtPersonalNumber";
            txtPersonalNumber.Size = new Size(125, 27);
            txtPersonalNumber.TabIndex = 15;
            // 
            // PatientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPersonalNumber);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(btnCancel);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(cmbGender);
            Controls.Add(dtpDob);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtFullName);
            Controls.Add(label1);
            Name = "PatientForm";
            Text = "PatientForm";
            Load += PatientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFullName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpDob;
        private ComboBox cmbGender;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnCancel;
        private Button button2;
        private Label label6;
        private Label label7;
        private TextBox txtEmail;
        private TextBox txtPersonalNumber;
    }
}