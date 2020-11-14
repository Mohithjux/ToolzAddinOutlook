using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolzAddinOutlook.Properties;

namespace ToolzAddinOutlook
{
    public partial class ToolzSettings : Form
    {
        public ToolzSettings()
        {
            InitializeComponent();
        }

        public void GetSettings()
        {
            //           label2.Text = Properties.Settings.Default.zipfile_opt;
            if ( Properties.Settings.Default.zipfile_opt == "S")
            {
                File_SystemName.Checked = true;
                File_UserName.Checked = false;
            }
            else 
            {
                File_SystemName.Checked = false;
                File_UserName.Checked = true;
            }

            if (Properties.Settings.Default.passmail_opt == "D")
            {
                Pass_Default.Checked = true;
                Pass_Text.Checked = false;
                Pass_HTML.Checked = false;
            }
            else if (Properties.Settings.Default.passmail_opt == "T")
            {
                Pass_Default.Checked = false;
                Pass_Text.Checked = true;
                Pass_HTML.Checked = false;
            }
            else
            {
                Pass_Default.Checked = false;
                Pass_Text.Checked = false;
                Pass_HTML.Checked = true;
            }

            if (Properties.Settings.Default.send_opt == "M")
            {
                Send_Auto.Checked = false;
                Send_Manul.Checked = true;
            }
            else
            {
                Send_Auto.Checked = true;
                Send_Manul.Checked = false;
            }


        }

        private void ToolzSettings_Load(object sender, EventArgs e)
        {
            GetSettings();
        }

        public void Savesettings()
        {
            if (File_SystemName.Checked == true )
            {

                Properties.Settings.Default.zipfile_opt = "S";
            }
            else
            {
                Properties.Settings.Default.zipfile_opt = "M";
            }

            if (Pass_Default.Checked == true)
            {

                Properties.Settings.Default.passmail_opt = "D";
            }
            else if(Pass_Text.Checked == true)
            {
                Properties.Settings.Default.passmail_opt = "T";
            }
            else
            {
                Properties.Settings.Default.passmail_opt = "H";
            }

            if (Send_Auto.Checked == true)
            {
                Properties.Settings.Default.send_opt = "A";
            }
            else
            {
                Properties.Settings.Default.send_opt = "M";
            }

            Properties.Settings.Default.Save();
            MessageBox.Show("Settings are Saved");


        }
        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (File_SystemName.Checked == true)
            {

 //               Properties.Settings.Default.Zipfilename = "System";
            }
            else
            {

   //             Properties.Settings.Default.Zipfilename = "User";
            }

            if (Pass_Default.Checked == true)
            {

              //  Properties.Settings.Default.PasswordMail = "Default";


            }
            else
            {
                if(Pass_Text.Checked == true)
                {

                  //  Properties.Settings.Default.PasswordMail = "Text";
                }
                else
                {

                   // Properties.Settings.Default.PasswordMail = "HTML";
                }
            }

            if (Send_Auto.Checked == true)
            {
                //Properties.Settings.Default.Send= "Auto";
            }
            else
            {
                //Properties.Settings.Default.Send = "Manual";
            }
            //Properties.Settings.Default.Save();

            // MessageBox.Show("Settings are saved");
            Savesettings();
        }

        private void Send_Manul_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Send_Auto_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
