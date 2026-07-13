using System;
using System.Windows.Forms;

namespace MatrixScreensaver
{
    partial class SettingsForm : Form
    {
        private enum CharWidthSize { Small = 16, Medium = 18, Large = 20 }
        private enum FallSpeed { Slow = 1, Medium = 2, Fast = 3 }

        public SettingsForm()
        {
            InitializeComponent();
            ApplyLocalization();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var savedCharWidth = (CharWidthSize)Properties.Settings.Default.CharWidth;
            rbSizeSmall.Checked  = savedCharWidth == CharWidthSize.Small;
            rbSizeLarge.Checked  = savedCharWidth == CharWidthSize.Large;
            rbSizeMedium.Checked = savedCharWidth == CharWidthSize.Medium;

            var savedFallSpeed = (FallSpeed)Properties.Settings.Default.FallSpeed;
            rbSpeedSlow.Checked  =  savedFallSpeed == FallSpeed.Slow;
            rbSpeedFast.Checked  =  savedFallSpeed == FallSpeed.Fast;
            rbSpeedMedium.Checked = savedFallSpeed == FallSpeed.Medium;

            pbColorPreview.BackColor = Properties.Settings.Default.GlyphColor;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CharWidth = (int)(
                rbSizeSmall.Checked ? CharWidthSize.Small :
                rbSizeLarge.Checked ? CharWidthSize.Large :
                                      CharWidthSize.Medium);

            Properties.Settings.Default.FallSpeed = (int)(
                rbSpeedSlow.Checked ? FallSpeed.Slow :
                rbSpeedFast.Checked ? FallSpeed.Fast :
                                      FallSpeed.Medium);

            Properties.Settings.Default.GlyphColor = pbColorPreview.BackColor;

            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnSelectColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = pbColorPreview.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pbColorPreview.BackColor = colorDialog.Color;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ApplyLocalization()
        {
            Text = LocalizedStrings.SettingsForm_Title;
            gbSize.Text = LocalizedStrings.GbSize_Text;
            rbSizeSmall.Text = LocalizedStrings.RbSizeSmall_Text;
            rbSizeMedium.Text = LocalizedStrings.RbSizeMedium_Text;
            rbSizeLarge.Text = LocalizedStrings.RbSizeLarge_Text;
            gbSpeed.Text = LocalizedStrings.GbSpeed_Text;
            rbSpeedSlow.Text = LocalizedStrings.RbSpeedSlow_Text;
            rbSpeedMedium.Text = LocalizedStrings.RbSpeedMedium_Text;
            rbSpeedFast.Text = LocalizedStrings.RbSpeedFast_Text;
            gbColor.Text = LocalizedStrings.GbColor_Text;
            lblColor.Text = LocalizedStrings.LblColor_Text;
            btnSelectColor.Text = LocalizedStrings.BtnSelectColor_Text;
            btnOk.Text = LocalizedStrings.BtnOk_Text;
            btnCancel.Text = LocalizedStrings.BtnCancel_Text;
        }
    }
}
