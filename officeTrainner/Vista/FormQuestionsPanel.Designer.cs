namespace Vista
{
    partial class FormQuestionsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuestionsPanel));
            this.BtnCerrar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCerrar.BorderRadius = 0;
            this.BtnCerrar.ButtonText = "Cerrar";
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.DisabledColor = System.Drawing.Color.Gray;
            this.BtnCerrar.Iconcolor = System.Drawing.Color.Transparent;
            this.BtnCerrar.Iconimage = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Iconimage")));
            this.BtnCerrar.Iconimage_right = null;
            this.BtnCerrar.Iconimage_right_Selected = null;
            this.BtnCerrar.Iconimage_Selected = null;
            this.BtnCerrar.IconMarginLeft = 0;
            this.BtnCerrar.IconMarginRight = 0;
            this.BtnCerrar.IconRightVisible = true;
            this.BtnCerrar.IconRightZoom = 0D;
            this.BtnCerrar.IconVisible = false;
            this.BtnCerrar.IconZoom = 90D;
            this.BtnCerrar.IsTab = false;
            this.BtnCerrar.Location = new System.Drawing.Point(989, 101);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.BtnCerrar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.BtnCerrar.OnHoverTextColor = System.Drawing.Color.White;
            this.BtnCerrar.selected = false;
            this.BtnCerrar.Size = new System.Drawing.Size(172, 28);
            this.BtnCerrar.TabIndex = 0;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCerrar.Textcolor = System.Drawing.Color.White;
            this.BtnCerrar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FormQuestionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 141);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuestionsPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQuestionsPanel";
            this.Load += new System.EventHandler(this.FormQuestionsPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton BtnCerrar;
    }
}