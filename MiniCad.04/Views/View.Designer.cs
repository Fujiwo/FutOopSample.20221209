namespace MiniCad.Views
{
    partial class View
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.DoubleBuffered = true;
            this.Name = "View";
            this.Size = new System.Drawing.Size(621, 490);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
