namespace ToolzAddinOutlook
{
    partial class ToolzRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ToolzRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolzRibbon));
            this.Toolz = this.Factory.CreateRibbonTab();
            this.AttachmentCtrl = this.Factory.CreateRibbonGroup();
            this.ZipPass = this.Factory.CreateRibbonButton();
            this.ZipNoPass = this.Factory.CreateRibbonButton();
            this.Toolz.SuspendLayout();
            this.AttachmentCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolz
            // 
            this.Toolz.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Toolz.Groups.Add(this.AttachmentCtrl);
            this.Toolz.Label = "Toolz++";
            this.Toolz.Name = "Toolz";
            // 
            // AttachmentCtrl
            // 
            this.AttachmentCtrl.Items.Add(this.ZipPass);
            this.AttachmentCtrl.Items.Add(this.ZipNoPass);
            this.AttachmentCtrl.Label = "Attachments Control";
            this.AttachmentCtrl.Name = "AttachmentCtrl";
            // 
            // ZipPass
            // 
            this.ZipPass.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ZipPass.Description = "Compress All Attachements With Password";
            this.ZipPass.Image = ((System.Drawing.Image)(resources.GetObject("ZipPass.Image")));
            this.ZipPass.ImageName = "ZipPass";
            this.ZipPass.Label = "Zip With Password";
            this.ZipPass.Name = "ZipPass";
            this.ZipPass.ShowImage = true;
            this.ZipPass.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ZipPass_Click);
            // 
            // ZipNoPass
            // 
            this.ZipNoPass.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ZipNoPass.Description = "Compress all attachements without password";
            this.ZipNoPass.Image = ((System.Drawing.Image)(resources.GetObject("ZipNoPass.Image")));
            this.ZipNoPass.ImageName = "ZipNoPass";
            this.ZipNoPass.Label = "Zip Without Password";
            this.ZipNoPass.Name = "ZipNoPass";
            this.ZipNoPass.ScreenTip = "Compress all attachements without password";
            this.ZipNoPass.ShowImage = true;
            this.ZipNoPass.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ZipNoPass_Click);
            // 
            // ToolzRibbon
            // 
            this.Name = "ToolzRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.Toolz);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ToolzRibbon_Load);
            this.Toolz.ResumeLayout(false);
            this.Toolz.PerformLayout();
            this.AttachmentCtrl.ResumeLayout(false);
            this.AttachmentCtrl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab Toolz;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup AttachmentCtrl;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ZipPass;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ZipNoPass;
    }

    partial class ThisRibbonCollection
    {
        internal ToolzRibbon Ribbon1
        {
            get { return this.GetRibbon<ToolzRibbon>(); }
        }
    }
}
