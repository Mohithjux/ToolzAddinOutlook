namespace ToolzAddinOutlook
{
    partial class ToolzSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolzSettings));
            this.FileName_Group = new System.Windows.Forms.GroupBox();
            this.File_UserName = new System.Windows.Forms.RadioButton();
            this.File_SystemName = new System.Windows.Forms.RadioButton();
            this.PasswordItem_Group = new System.Windows.Forms.GroupBox();
            this.Pass_HTML = new System.Windows.Forms.RadioButton();
            this.Pass_Text = new System.Windows.Forms.RadioButton();
            this.Pass_Default = new System.Windows.Forms.RadioButton();
            this.SendingOption_Group = new System.Windows.Forms.GroupBox();
            this.Send_Manul = new System.Windows.Forms.RadioButton();
            this.Send_Auto = new System.Windows.Forms.RadioButton();
            this.Save = new System.Windows.Forms.Button();
            this.FileName_Group.SuspendLayout();
            this.PasswordItem_Group.SuspendLayout();
            this.SendingOption_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileName_Group
            // 
            this.FileName_Group.Controls.Add(this.File_UserName);
            this.FileName_Group.Controls.Add(this.File_SystemName);
            this.FileName_Group.Location = new System.Drawing.Point(5, 24);
            this.FileName_Group.Name = "FileName_Group";
            this.FileName_Group.Size = new System.Drawing.Size(603, 117);
            this.FileName_Group.TabIndex = 0;
            this.FileName_Group.TabStop = false;
            this.FileName_Group.Text = "File Name Options";
            this.FileName_Group.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // File_UserName
            // 
            this.File_UserName.AutoSize = true;
            this.File_UserName.Location = new System.Drawing.Point(355, 46);
            this.File_UserName.Name = "File_UserName";
            this.File_UserName.Size = new System.Drawing.Size(142, 19);
            this.File_UserName.TabIndex = 4;
            this.File_UserName.Text = "Ask me everytime";
            this.File_UserName.UseVisualStyleBackColor = true;
            this.File_UserName.CheckedChanged += new System.EventHandler(this.RadioButton5_CheckedChanged);
            // 
            // File_SystemName
            // 
            this.File_SystemName.AutoSize = true;
            this.File_SystemName.Checked = true;
            this.File_SystemName.Location = new System.Drawing.Point(48, 46);
            this.File_SystemName.Name = "File_SystemName";
            this.File_SystemName.Size = new System.Drawing.Size(188, 19);
            this.File_SystemName.TabIndex = 3;
            this.File_SystemName.TabStop = true;
            this.File_SystemName.Text = "Let system name ZIP file";
            this.File_SystemName.UseVisualStyleBackColor = true;
            this.File_SystemName.CheckedChanged += new System.EventHandler(this.RadioButton4_CheckedChanged);
            // 
            // PasswordItem_Group
            // 
            this.PasswordItem_Group.Controls.Add(this.Pass_HTML);
            this.PasswordItem_Group.Controls.Add(this.Pass_Text);
            this.PasswordItem_Group.Controls.Add(this.Pass_Default);
            this.PasswordItem_Group.Location = new System.Drawing.Point(5, 161);
            this.PasswordItem_Group.Name = "PasswordItem_Group";
            this.PasswordItem_Group.Size = new System.Drawing.Size(603, 117);
            this.PasswordItem_Group.TabIndex = 1;
            this.PasswordItem_Group.TabStop = false;
            this.PasswordItem_Group.Text = "Password Item Mail Format";
            this.PasswordItem_Group.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // Pass_HTML
            // 
            this.Pass_HTML.AutoSize = true;
            this.Pass_HTML.Location = new System.Drawing.Point(355, 53);
            this.Pass_HTML.Name = "Pass_HTML";
            this.Pass_HTML.Size = new System.Drawing.Size(66, 19);
            this.Pass_HTML.TabIndex = 2;
            this.Pass_HTML.Text = "HTML";
            this.Pass_HTML.UseVisualStyleBackColor = true;
            // 
            // Pass_Text
            // 
            this.Pass_Text.AutoSize = true;
            this.Pass_Text.Checked = true;
            this.Pass_Text.Location = new System.Drawing.Point(230, 53);
            this.Pass_Text.Name = "Pass_Text";
            this.Pass_Text.Size = new System.Drawing.Size(88, 19);
            this.Pass_Text.TabIndex = 1;
            this.Pass_Text.TabStop = true;
            this.Pass_Text.Text = "Plain text";
            this.Pass_Text.UseVisualStyleBackColor = true;
            // 
            // Pass_Default
            // 
            this.Pass_Default.AutoSize = true;
            this.Pass_Default.Location = new System.Drawing.Point(48, 54);
            this.Pass_Default.Name = "Pass_Default";
            this.Pass_Default.Size = new System.Drawing.Size(152, 19);
            this.Pass_Default.TabIndex = 0;
            this.Pass_Default.Text = "User default format";
            this.Pass_Default.UseVisualStyleBackColor = true;
            // 
            // SendingOption_Group
            // 
            this.SendingOption_Group.Controls.Add(this.Send_Manul);
            this.SendingOption_Group.Controls.Add(this.Send_Auto);
            this.SendingOption_Group.Location = new System.Drawing.Point(5, 303);
            this.SendingOption_Group.Name = "SendingOption_Group";
            this.SendingOption_Group.Size = new System.Drawing.Size(603, 117);
            this.SendingOption_Group.TabIndex = 2;
            this.SendingOption_Group.TabStop = false;
            this.SendingOption_Group.Text = "Sending Option";
            // 
            // Send_Manul
            // 
            this.Send_Manul.AutoSize = true;
            this.Send_Manul.Checked = true;
            this.Send_Manul.Location = new System.Drawing.Point(355, 54);
            this.Send_Manul.Name = "Send_Manul";
            this.Send_Manul.Size = new System.Drawing.Size(107, 19);
            this.Send_Manul.TabIndex = 5;
            this.Send_Manul.TabStop = true;
            this.Send_Manul.Text = "Manual send";
            this.Send_Manul.UseVisualStyleBackColor = true;
            this.Send_Manul.CheckedChanged += new System.EventHandler(this.Send_Manul_CheckedChanged);
            // 
            // Send_Auto
            // 
            this.Send_Auto.AutoSize = true;
            this.Send_Auto.Location = new System.Drawing.Point(48, 54);
            this.Send_Auto.Name = "Send_Auto";
            this.Send_Auto.Size = new System.Drawing.Size(93, 19);
            this.Send_Auto.TabIndex = 5;
            this.Send_Auto.Text = "Auto send";
            this.Send_Auto.UseVisualStyleBackColor = true;
            this.Send_Auto.CheckedChanged += new System.EventHandler(this.Send_Auto_CheckedChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(5, 440);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(603, 56);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save Settings";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ToolzSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 511);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SendingOption_Group);
            this.Controls.Add(this.PasswordItem_Group);
            this.Controls.Add(this.FileName_Group);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ToolzSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.ToolzSettings_Load);
            this.FileName_Group.ResumeLayout(false);
            this.FileName_Group.PerformLayout();
            this.PasswordItem_Group.ResumeLayout(false);
            this.PasswordItem_Group.PerformLayout();
            this.SendingOption_Group.ResumeLayout(false);
            this.SendingOption_Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FileName_Group;
        private System.Windows.Forms.GroupBox PasswordItem_Group;
        private System.Windows.Forms.GroupBox SendingOption_Group;
        private System.Windows.Forms.RadioButton File_SystemName;
        private System.Windows.Forms.RadioButton Pass_HTML;
        private System.Windows.Forms.RadioButton Pass_Text;
        private System.Windows.Forms.RadioButton Pass_Default;
        private System.Windows.Forms.RadioButton File_UserName;
        private System.Windows.Forms.RadioButton Send_Manul;
        private System.Windows.Forms.RadioButton Send_Auto;
        private System.Windows.Forms.Button Save;
    }
}