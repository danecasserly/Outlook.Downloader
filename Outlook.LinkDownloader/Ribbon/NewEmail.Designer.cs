

namespace Outlook.Download.Addin
{
    partial class NewEmail : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NewEmail()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewEmail));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.GrpFileDownload = this.Factory.CreateRibbonGroup();
            this.btnConvertToAttach = this.Factory.CreateRibbonButton();
            this.lblStatus = this.Factory.CreateRibbonLabel();
            this.tab1.SuspendLayout();
            this.GrpFileDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabNewMailMessage";
            this.tab1.Groups.Add(this.GrpFileDownload);
            this.tab1.Label = "TabNewMailMessage";
            this.tab1.Name = "tab1";
            // 
            // GrpFileDownload
            // 
            this.GrpFileDownload.Items.Add(this.btnConvertToAttach);
            this.GrpFileDownload.Items.Add(this.lblStatus);
            this.GrpFileDownload.Label = "File Downloader";
            this.GrpFileDownload.Name = "GrpFileDownload";
            // 
            // btnConvertToAttach
            // 
            this.btnConvertToAttach.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertToAttach.Image")));
            this.btnConvertToAttach.Label = "Convert To Attachment";
            this.btnConvertToAttach.Name = "btnConvertToAttach";
            this.btnConvertToAttach.ShowImage = true;
            this.btnConvertToAttach.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConvertToAttach_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Label = "Status: Ready";
            this.lblStatus.Name = "lblStatus";
            // 
            // NewEmail
            // 
            this.Name = "NewEmail";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.NewEmail_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.GrpFileDownload.ResumeLayout(false);
            this.GrpFileDownload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpFileDownload;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConvertToAttach;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel lblStatus;
    }

    partial class ThisRibbonCollection
    {
        internal NewEmail NewEmail
        {
            get { return this.GetRibbon<NewEmail>(); }
        }
    }
}
