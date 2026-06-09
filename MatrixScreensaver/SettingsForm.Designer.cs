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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.gbSize.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.SuspendLayout();

            // gbSize
            this.gbSize.Controls.Add(this.rbSizeSmall);
            this.gbSize.Controls.Add(this.rbSizeMedium);
            this.gbSize.Controls.Add(this.rbSizeLarge);
            this.gbSize.Location = new System.Drawing.Point(12, 12);
            this.gbSize.Size = new System.Drawing.Size(260, 88);
            this.gbSize.Text = "Размер символов";

            // rbSizeSmall
            this.rbSizeSmall.Location = new System.Drawing.Point(6, 20);
            this.rbSizeSmall.Size = new System.Drawing.Size(240, 22);
            this.rbSizeSmall.Text = "Маленький";
            this.rbSizeSmall.UseVisualStyleBackColor = true;

            // rbSizeMedium
            this.rbSizeMedium.Location = new System.Drawing.Point(6, 44);
            this.rbSizeMedium.Size = new System.Drawing.Size(240, 22);
            this.rbSizeMedium.Text = "Средний";
            this.rbSizeMedium.UseVisualStyleBackColor = true;

            // rbSizeLarge
            this.rbSizeLarge.Location = new System.Drawing.Point(6, 68);
            this.rbSizeLarge.Size = new System.Drawing.Size(240, 22);
            this.rbSizeLarge.Text = "Большой";
            this.rbSizeLarge.UseVisualStyleBackColor = true;

            // gbSpeed
            this.gbSpeed.Controls.Add(this.rbSpeedSlow);
            this.gbSpeed.Controls.Add(this.rbSpeedMedium);
            this.gbSpeed.Controls.Add(this.rbSpeedFast);
            this.gbSpeed.Location = new System.Drawing.Point(12, 108);
            this.gbSpeed.Size = new System.Drawing.Size(260, 88);
            this.gbSpeed.Text = "Скорость";

            // rbSpeedSlow
            this.rbSpeedSlow.Location = new System.Drawing.Point(6, 20);
            this.rbSpeedSlow.Size = new System.Drawing.Size(240, 22);
            this.rbSpeedSlow.Text = "Медленная";
            this.rbSpeedSlow.UseVisualStyleBackColor = true;

            // rbSpeedMedium
            this.rbSpeedMedium.Location = new System.Drawing.Point(6, 44);
            this.rbSpeedMedium.Size = new System.Drawing.Size(240, 22);
            this.rbSpeedMedium.Text = "Средняя";
            this.rbSpeedMedium.UseVisualStyleBackColor = true;

            // rbSpeedFast
            this.rbSpeedFast.Location = new System.Drawing.Point(6, 68);
            this.rbSpeedFast.Size = new System.Drawing.Size(240, 22);
            this.rbSpeedFast.Text = "Быстрая";
            this.rbSpeedFast.UseVisualStyleBackColor = true;

            // btnOk
            this.btnOk.Location = new System.Drawing.Point(116, 205);
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Text = "Сохранить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(197, 205);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // SettingsForm
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.gbSpeed);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка Matrix Screensaver";

            this.gbSize.ResumeLayout(false);
            this.gbSpeed.ResumeLayout(false);
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
    }
}
