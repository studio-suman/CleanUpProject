
namespace CleanUpProject
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
            this.ChromeChkbox = new System.Windows.Forms.CheckBox();
            this.EdgeChkbox = new System.Windows.Forms.CheckBox();
            this.WinChkbox = new System.Windows.Forms.CheckBox();
            this.cleanbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ChromeChkbox
            // 
            this.ChromeChkbox.AutoSize = true;
            this.ChromeChkbox.Checked = true;
            this.ChromeChkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChromeChkbox.Location = new System.Drawing.Point(6, 23);
            this.ChromeChkbox.Name = "ChromeChkbox";
            this.ChromeChkbox.Size = new System.Drawing.Size(130, 17);
            this.ChromeChkbox.TabIndex = 0;
            this.ChromeChkbox.Text = "Clear Chrome Browser";
            this.ChromeChkbox.UseVisualStyleBackColor = true;
            // 
            // EdgeChkbox
            // 
            this.EdgeChkbox.AutoSize = true;
            this.EdgeChkbox.Checked = true;
            this.EdgeChkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EdgeChkbox.Location = new System.Drawing.Point(6, 46);
            this.EdgeChkbox.Name = "EdgeChkbox";
            this.EdgeChkbox.Size = new System.Drawing.Size(119, 17);
            this.EdgeChkbox.TabIndex = 1;
            this.EdgeChkbox.Text = "Clear Edge Browser";
            this.EdgeChkbox.UseVisualStyleBackColor = true;
            // 
            // WinChkbox
            // 
            this.WinChkbox.AutoSize = true;
            this.WinChkbox.Checked = true;
            this.WinChkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WinChkbox.Location = new System.Drawing.Point(6, 69);
            this.WinChkbox.Name = "WinChkbox";
            this.WinChkbox.Size = new System.Drawing.Size(154, 17);
            this.WinChkbox.TabIndex = 2;
            this.WinChkbox.Text = "Clear User/Windows Temp";
            this.WinChkbox.UseVisualStyleBackColor = true;
            // 
            // cleanbtn
            // 
            this.cleanbtn.Location = new System.Drawing.Point(185, 96);
            this.cleanbtn.Name = "cleanbtn";
            this.cleanbtn.Size = new System.Drawing.Size(75, 23);
            this.cleanbtn.TabIndex = 3;
            this.cleanbtn.Text = "Clean";
            this.cleanbtn.UseVisualStyleBackColor = true;
            this.cleanbtn.Click += new System.EventHandler(this.cleanbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WinChkbox);
            this.groupBox1.Controls.Add(this.cleanbtn);
            this.groupBox1.Controls.Add(this.EdgeChkbox);
            this.groupBox1.Controls.Add(this.ChromeChkbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 126);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Size After Deletion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Size Before Deletion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CleanUpProject.Properties.Resources.broom_icon;
            this.pictureBox1.Location = new System.Drawing.Point(396, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(351, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(434, 69);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 286);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Clean Up Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChromeChkbox;
        private System.Windows.Forms.CheckBox EdgeChkbox;
        private System.Windows.Forms.CheckBox WinChkbox;
        private System.Windows.Forms.Button cleanbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

