namespace MatrixScreensaver
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.rbSizeSmall = new System.Windows.Forms.RadioButton();
            this.rbSizeMedium = new System.Windows.Forms.RadioButton();
            this.rbSizeLarge = new System.Windows.Forms.RadioButton();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.rbSpeedSlow = new System.Windows.Forms.RadioButton();
            this.rbSpeedMedium = new System.Windows.Forms.RadioButton();
            this.rbSpeedFast = new System.Windows.Forms.RadioButton();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.pbColorPreview = new System.Windows.Forms.Panel();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSize.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.gbColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.rbSizeSmall);
            this.gbSize.Controls.Add(this.rbSizeMedium);
            this.gbSize.Controls.Add(this.rbSizeLarge);
            this.gbSize.Location = new System.Drawing.Point(12, 12);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(260, 88);
            this.gbSize.Text = "Character Size";
            // 
            // rbSizeSmall
            // 
            this.rbSizeSmall.Location = new System.Drawing.Point(6, 20);
            this.rbSizeSmall.Name = "rbSizeSmall";
            this.rbSizeSmall.Size = new System.Drawing.Size(240, 22);
            this.rbSizeSmall.Text = "Small";
            this.rbSizeSmall.UseVisualStyleBackColor = true;
            // 
            // rbSizeMedium
            // 
            this.rbSizeMedium.Location = new System.Drawing.Point(6, 44);
            this.rbSizeMedium.Name = "rbSizeMedium";
            this.rbSizeMedium.Size = new System.Drawing.Size(240, 22);
            this.rbSizeMedium.Text = "Medium";
            this.rbSizeMedium.UseVisualStyleBackColor = true;
            // 
            // rbSizeLarge
            // 
            this.rbSizeLarge.Location = new System.Drawing.Point(6, 68);
            this.rbSizeLarge.Name = "rbSizeLarge";
            this.rbSizeLarge.Size = new System.Drawing.Size(240, 22);
            this.rbSizeLarge.Text = "Large";
            this.rbSizeLarge.UseVisualStyleBackColor = true;
            // 
            // gbSpeed
            // 
            this.gbSpeed.Controls.Add(this.rbSpeedSlow);
            this.gbSpeed.Controls.Add(this.rbSpeedMedium);
            this.gbSpeed.Controls.Add(this.rbSpeedFast);
            this.gbSpeed.Location = new System.Drawing.Point(12, 108);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.Size = new System.Drawing.Size(260, 88);
            this.gbSpeed.Text = "Speed";
            // 
            // rbSpeedSlow
            // 
            this.rbSpeedSlow.Location = new System.Drawing.Point(6, 20);
            this.rbSpeedSlow.Name = "rbSpeedSlow";
            this.rbSpeedSlow.Size = new System.Drawing.Size(240, 22);
            this.rbSpeedSlow.Text = "Slow";
            this.rbSpeedSlow.UseVisualStyleBackColor = true;
            // 
            // rbSpeedMedium
            // 
            this.rbSpeedMedium.Location = new System.Drawing.Point(6, 44);
            this.rbSpeedMedium.Name = "rbSpeedMedium";
            this.rbSpeedMedium.Size = new System.Drawing.Size(240, 22);
            this.rbSpeedMedium.Text = "Medium";
            this.rbSpeedMedium.UseVisualStyleBackColor = true;
            // 
            // rbSpeedFast
            // 
            this.rbSpeedFast.Location = new System.Drawing.Point(6, 68);
            this.rbSpeedFast.Name = "rbSpeedFast";
            this.rbSpeedFast.Size = new System.Drawing.Size(240, 22);
            this.rbSpeedFast.Text = "Fast";
            this.rbSpeedFast.UseVisualStyleBackColor = true;
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.lblColor);
            this.gbColor.Controls.Add(this.pbColorPreview);
            this.gbColor.Controls.Add(this.btnSelectColor);
            this.gbColor.Location = new System.Drawing.Point(12, 204);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(260, 52);
            this.gbColor.Text = "Color";
            // 
            // lblColor
            // 
            this.lblColor.Location = new System.Drawing.Point(10, 22);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(90, 22);
            this.lblColor.Text = "Character:";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbColorPreview
            // 
            this.pbColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColorPreview.Location = new System.Drawing.Point(102, 20);
            this.pbColorPreview.Name = "pbColorPreview";
            this.pbColorPreview.Size = new System.Drawing.Size(28, 22);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(136, 19);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(110, 23);
            this.btnSelectColor.Text = "Select...";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.BtnSelectColor_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(116, 270);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.gbSpeed);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matrix Screensaver Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.gbSize.ResumeLayout(false);
            this.gbSpeed.ResumeLayout(false);
            this.gbColor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.RadioButton rbSizeSmall;
        private System.Windows.Forms.RadioButton rbSizeMedium;
        private System.Windows.Forms.RadioButton rbSizeLarge;
        private System.Windows.Forms.GroupBox gbSpeed;
        private System.Windows.Forms.RadioButton rbSpeedSlow;
        private System.Windows.Forms.RadioButton rbSpeedMedium;
        private System.Windows.Forms.RadioButton rbSpeedFast;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Panel pbColorPreview;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}
