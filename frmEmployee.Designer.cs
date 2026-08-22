namespace EmployeeDetails
{
    partial class frmEmployee
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblGender;

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtGender;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.DataGridView dgvEmployees;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();

            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.TextBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.dgvEmployees = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();

            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(117, 86, 174);

            this.lblTitle.Location =
                new System.Drawing.Point(25, 20);

            this.lblTitle.Name = "lblTitle";

            this.lblTitle.Size =
                new System.Drawing.Size(321, 37);

            this.lblTitle.TabIndex = 0;

            this.lblTitle.Text =
                "Employee Management";

            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location =
                new System.Drawing.Point(30, 85);

            this.lblID.Name = "lblID";
            this.lblID.Size =
                new System.Drawing.Size(80, 17);

            this.lblID.TabIndex = 1;
            this.lblID.Text = "Employee ID";

            // 
            // txtID
            // 
            this.txtID.Location =
                new System.Drawing.Point(130, 82);

            this.txtID.Name = "txtID";

            this.txtID.Size =
                new System.Drawing.Size(200, 25);

            this.txtID.TabIndex = 2;

            // 
            // lblName
            // 
            this.lblName.AutoSize = true;

            this.lblName.Location =
                new System.Drawing.Point(30, 125);

            this.lblName.Name = "lblName";

            this.lblName.Size =
                new System.Drawing.Size(92, 17);

            this.lblName.TabIndex = 3;

            this.lblName.Text =
                "Employee Name";

            // 
            // txtName
            // 
            this.txtName.Location =
                new System.Drawing.Point(130, 122);

            this.txtName.Name =
                "txtName";

            this.txtName.Size =
                new System.Drawing.Size(200, 25);

            this.txtName.TabIndex = 4;

            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;

            this.lblAge.Location =
                new System.Drawing.Point(30, 165);

            this.lblAge.Name =
                "lblAge";

            this.lblAge.Size =
                new System.Drawing.Size(82, 17);

            this.lblAge.TabIndex = 5;

            this.lblAge.Text =
                "Employee Age";

            // 
            // txtAge
            // 
            this.txtAge.Location =
                new System.Drawing.Point(130, 162);

            this.txtAge.Name =
                "txtAge";

            this.txtAge.Size =
                new System.Drawing.Size(200, 25);

            this.txtAge.TabIndex = 6;

            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;

            this.lblContact.Location =
                new System.Drawing.Point(30, 205);

            this.lblContact.Name =
                "lblContact";

            this.lblContact.Size =
                new System.Drawing.Size(100, 17);

            this.lblContact.TabIndex = 7;

            this.lblContact.Text =
                "Employee Contact";

            // 
            // txtContact
            // 
            this.txtContact.Location =
                new System.Drawing.Point(130, 202);

            this.txtContact.Name =
                "txtContact";

            this.txtContact.Size =
                new System.Drawing.Size(200, 25);

            this.txtContact.TabIndex = 8;

            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;

            this.lblGender.Location =
                new System.Drawing.Point(30, 245);

            this.lblGender.Name =
                "lblGender";

            this.lblGender.Size =
                new System.Drawing.Size(95, 17);

            this.lblGender.TabIndex = 9;

            this.lblGender.Text =
                "Employee Gender";

            // 
            // txtGender
            // 
            this.txtGender.Location =
                new System.Drawing.Point(130, 242);

            this.txtGender.Name =
                "txtGender";

            this.txtGender.Size =
                new System.Drawing.Size(200, 25);

            this.txtGender.TabIndex = 10;

            // 
            // btnAdd
            // 
            this.btnAdd.BackColor =
                System.Drawing.Color.FromArgb(117, 86, 174);

            this.btnAdd.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAdd.ForeColor =
                System.Drawing.Color.White;

            this.btnAdd.Location =
                new System.Drawing.Point(360, 82);

            this.btnAdd.Name =
                "btnAdd";

            this.btnAdd.Size =
                new System.Drawing.Size(100, 35);

            this.btnAdd.TabIndex = 11;

            this.btnAdd.Text =
                "ADD";

            this.btnAdd.UseVisualStyleBackColor =
                false;

            this.btnAdd.Click +=
                new System.EventHandler(
                    this.btnAdd_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor =
                System.Drawing.Color.FromArgb(117, 86, 174);

            this.btnUpdate.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnUpdate.ForeColor =
                System.Drawing.Color.White;

            this.btnUpdate.Location =
                new System.Drawing.Point(470, 82);

            this.btnUpdate.Name =
                "btnUpdate";

            this.btnUpdate.Size =
                new System.Drawing.Size(100, 35);

            this.btnUpdate.TabIndex = 12;

            this.btnUpdate.Text =
                "UPDATE";

            this.btnUpdate.UseVisualStyleBackColor =
                false;

            this.btnUpdate.Click +=
                new System.EventHandler(
                    this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor =
                System.Drawing.Color.FromArgb(192, 57, 43);

            this.btnDelete.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnDelete.ForeColor =
                System.Drawing.Color.White;

            this.btnDelete.Location =
                new System.Drawing.Point(580, 82);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(100, 35);

            this.btnDelete.TabIndex = 13;

            this.btnDelete.Text =
                "DELETE";

            this.btnDelete.UseVisualStyleBackColor =
                false;

            this.btnDelete.Click +=
                new System.EventHandler(
                    this.btnDelete_Click);

            // 
            // btnClear
            // 
            this.btnClear.Location =
                new System.Drawing.Point(360, 125);

            this.btnClear.Name =
                "btnClear";

            this.btnClear.Size =
                new System.Drawing.Size(100, 35);

            this.btnClear.TabIndex = 14;

            this.btnClear.Text =
                "CLEAR";

            this.btnClear.UseVisualStyleBackColor =
                true;

            this.btnClear.Click +=
                new System.EventHandler(
                    this.btnClear_Click);

            // 
            // btnClose
            // 
            this.btnClose.Location =
                new System.Drawing.Point(470, 125);

            this.btnClose.Name =
                "btnClose";

            this.btnClose.Size =
                new System.Drawing.Size(100, 35);

            this.btnClose.TabIndex = 15;

            this.btnClose.Text =
                "CLOSE";

            this.btnClose.UseVisualStyleBackColor =
                true;

            this.btnClose.Click +=
                new System.EventHandler(
                    this.btnClose_Click);

            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows =
                false;

            this.dgvEmployees.AllowUserToDeleteRows =
                false;

            this.dgvEmployees.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvEmployees.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvEmployees.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvEmployees.Location =
                new System.Drawing.Point(30, 300);

            this.dgvEmployees.MultiSelect =
                false;

            this.dgvEmployees.Name =
                "dgvEmployees";

            this.dgvEmployees.ReadOnly =
                true;

            this.dgvEmployees.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvEmployees.Size =
                new System.Drawing.Size(740, 170);

            this.dgvEmployees.TabIndex = 16;

            this.dgvEmployees.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvEmployees_CellClick);

            this.dgvEmployees.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvEmployees_CellContentClick);

            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 17F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.White;

            this.ClientSize =
                new System.Drawing.Size(800, 500);

            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);

            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.lblGender);

            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lblContact);

            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.lblAge);

            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);

            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);

            this.Controls.Add(this.lblTitle);

            this.Font =
                new System.Drawing.Font(
                    "Nirmala UI",
                    9.75F,
                    System.Drawing.FontStyle.Bold);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.Name =
                "frmEmployee";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Employee Details";

            this.Load +=
                new System.EventHandler(
                    this.frmEmployee_Load);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvEmployees)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}