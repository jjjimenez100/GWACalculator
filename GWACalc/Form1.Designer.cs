namespace GWACalc
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.yearPane = new System.Windows.Forms.TabControl();
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboGrade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboUnits = new System.Windows.Forms.ComboBox();
            this.txtBoxSubject = new System.Windows.Forms.TextBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblGwa = new System.Windows.Forms.Label();
            this.lblTotGwa = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.functionsBox = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.functionsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 27);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(405, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings,
            this.menuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(116, 22);
            this.menuSettings.Text = "Settings";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(116, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(107, 22);
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // yearPane
            // 
            this.yearPane.Location = new System.Drawing.Point(1, 29);
            this.yearPane.Name = "yearPane";
            this.yearPane.SelectedIndex = 0;
            this.yearPane.Size = new System.Drawing.Size(285, 280);
            this.yearPane.TabIndex = 1;
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.btnCancel);
            this.controlBox.Controls.Add(this.btnSave);
            this.controlBox.Controls.Add(this.label2);
            this.controlBox.Controls.Add(this.comboGrade);
            this.controlBox.Controls.Add(this.label1);
            this.controlBox.Controls.Add(this.comboUnits);
            this.controlBox.Controls.Add(this.txtBoxSubject);
            this.controlBox.Enabled = false;
            this.controlBox.Location = new System.Drawing.Point(292, 131);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(114, 178);
            this.controlBox.TabIndex = 2;
            this.controlBox.TabStop = false;
            this.controlBox.Text = "User Data";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(59, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grade:";
            // 
            // comboGrade
            // 
            this.comboGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGrade.FormattingEnabled = true;
            this.comboGrade.Location = new System.Drawing.Point(51, 99);
            this.comboGrade.Name = "comboGrade";
            this.comboGrade.Size = new System.Drawing.Size(46, 21);
            this.comboGrade.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "# of Units:";
            // 
            // comboUnits
            // 
            this.comboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnits.FormattingEnabled = true;
            this.comboUnits.Location = new System.Drawing.Point(64, 63);
            this.comboUnits.Name = "comboUnits";
            this.comboUnits.Size = new System.Drawing.Size(33, 21);
            this.comboUnits.TabIndex = 1;
            // 
            // txtBoxSubject
            // 
            this.txtBoxSubject.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBoxSubject.Location = new System.Drawing.Point(6, 28);
            this.txtBoxSubject.Name = "txtBoxSubject";
            this.txtBoxSubject.Size = new System.Drawing.Size(91, 20);
            this.txtBoxSubject.TabIndex = 0;
            this.txtBoxSubject.Text = "Subject Name";
            this.txtBoxSubject.Click += new System.EventHandler(this.txtBoxSubject_Click);
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(297, 44);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(40, 13);
            this.lblCourse.TabIndex = 9;
            this.lblCourse.Text = "Course";
            // 
            // lblGwa
            // 
            this.lblGwa.AutoSize = true;
            this.lblGwa.Location = new System.Drawing.Point(298, 69);
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.Size = new System.Drawing.Size(36, 13);
            this.lblGwa.TabIndex = 10;
            this.lblGwa.Text = "GWA:";
            // 
            // lblTotGwa
            // 
            this.lblTotGwa.AutoSize = true;
            this.lblTotGwa.Location = new System.Drawing.Point(298, 91);
            this.lblTotGwa.Name = "lblTotGwa";
            this.lblTotGwa.Size = new System.Drawing.Size(72, 13);
            this.lblTotGwa.TabIndex = 11;
            this.lblTotGwa.Text = "Overall GWA:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(55, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(123, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(191, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(62, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // functionsBox
            // 
            this.functionsBox.Controls.Add(this.btnExport);
            this.functionsBox.Controls.Add(this.btnAdd);
            this.functionsBox.Controls.Add(this.btnDelete);
            this.functionsBox.Controls.Add(this.btnUpdate);
            this.functionsBox.Location = new System.Drawing.Point(12, 315);
            this.functionsBox.Name = "functionsBox";
            this.functionsBox.Size = new System.Drawing.Size(386, 54);
            this.functionsBox.TabIndex = 12;
            this.functionsBox.TabStop = false;
            this.functionsBox.Text = "Functions";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(259, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export .docx";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 375);
            this.Controls.Add(this.functionsBox);
            this.Controls.Add(this.lblTotGwa);
            this.Controls.Add(this.lblGwa);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.controlBox);
            this.Controls.Add(this.yearPane);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GWA Calculator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.controlBox.ResumeLayout(false);
            this.controlBox.PerformLayout();
            this.functionsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.TabControl yearPane;
        private System.Windows.Forms.GroupBox controlBox;
        private System.Windows.Forms.TextBox txtBoxSubject;
        private System.Windows.Forms.ComboBox comboUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboGrade;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblGwa;
        private System.Windows.Forms.Label lblTotGwa;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox functionsBox;
        private System.Windows.Forms.Button btnExport;
    }
}

