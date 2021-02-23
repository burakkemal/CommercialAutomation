
namespace Ticari_Otomasyon
{
    partial class FaturaUrunDuzenleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaturaUrunDuzenleme));
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.btnsil = new DevExpress.XtraEditors.SimpleButton();
            this.btnguncelle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtfaturaid = new DevExpress.XtraEditors.TextEdit();
            this.txttutar = new DevExpress.XtraEditors.TextEdit();
            this.txtmiktar = new DevExpress.XtraEditors.TextEdit();
            this.txtfiyat = new DevExpress.XtraEditors.TextEdit();
            this.txtürünad = new DevExpress.XtraEditors.TextEdit();
            this.txtürünid = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtfaturaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtürünad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtürünid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.btnsil);
            this.groupControl5.Controls.Add(this.btnguncelle);
            this.groupControl5.Controls.Add(this.labelControl11);
            this.groupControl5.Controls.Add(this.labelControl8);
            this.groupControl5.Controls.Add(this.txtfaturaid);
            this.groupControl5.Controls.Add(this.txttutar);
            this.groupControl5.Controls.Add(this.txtmiktar);
            this.groupControl5.Controls.Add(this.txtfiyat);
            this.groupControl5.Controls.Add(this.txtürünad);
            this.groupControl5.Controls.Add(this.txtürünid);
            this.groupControl5.Controls.Add(this.labelControl6);
            this.groupControl5.Controls.Add(this.labelControl7);
            this.groupControl5.Controls.Add(this.labelControl5);
            this.groupControl5.Controls.Add(this.labelControl10);
            this.groupControl5.Location = new System.Drawing.Point(8, 5);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new System.Drawing.Size(266, 283);
            this.groupControl5.TabIndex = 1;
            this.groupControl5.Text = "groupControl5";
            // 
            // btnsil
            // 
            this.btnsil.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.Appearance.Options.UseFont = true;
            this.btnsil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsil.ImageOptions.Image")));
            this.btnsil.Location = new System.Drawing.Point(89, 201);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(173, 34);
            this.btnsil.TabIndex = 13;
            this.btnsil.Text = "Sil";
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnguncelle
            // 
            this.btnguncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnguncelle.Appearance.Options.UseFont = true;
            this.btnguncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnguncelle.ImageOptions.Image")));
            this.btnguncelle.Location = new System.Drawing.Point(89, 241);
            this.btnguncelle.Name = "btnguncelle";
            this.btnguncelle.Size = new System.Drawing.Size(173, 34);
            this.btnguncelle.TabIndex = 12;
            this.btnguncelle.Text = "Güncelle";
            this.btnguncelle.Click += new System.EventHandler(this.btnguncelle_Click);
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(26, 41);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(58, 18);
            this.labelControl11.TabIndex = 3;
            this.labelControl11.Text = "Ürün Ad:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(19, 11);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(65, 18);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "ÜRÜN ID:";
            // 
            // txtfaturaid
            // 
            this.txtfaturaid.Location = new System.Drawing.Point(89, 161);
            this.txtfaturaid.Name = "txtfaturaid";
            this.txtfaturaid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtfaturaid.Properties.Appearance.Options.UseFont = true;
            this.txtfaturaid.Size = new System.Drawing.Size(173, 24);
            this.txtfaturaid.TabIndex = 4;
            // 
            // txttutar
            // 
            this.txttutar.Location = new System.Drawing.Point(89, 128);
            this.txttutar.Name = "txttutar";
            this.txttutar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txttutar.Properties.Appearance.Options.UseFont = true;
            this.txttutar.Size = new System.Drawing.Size(173, 24);
            this.txttutar.TabIndex = 4;
            // 
            // txtmiktar
            // 
            this.txtmiktar.Location = new System.Drawing.Point(89, 68);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtmiktar.Properties.Appearance.Options.UseFont = true;
            this.txtmiktar.Size = new System.Drawing.Size(173, 24);
            this.txtmiktar.TabIndex = 4;
            // 
            // txtfiyat
            // 
            this.txtfiyat.Location = new System.Drawing.Point(89, 98);
            this.txtfiyat.Name = "txtfiyat";
            this.txtfiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtfiyat.Properties.Appearance.Options.UseFont = true;
            this.txtfiyat.Size = new System.Drawing.Size(173, 24);
            this.txtfiyat.TabIndex = 4;
            // 
            // txtürünad
            // 
            this.txtürünad.Location = new System.Drawing.Point(89, 35);
            this.txtürünad.Name = "txtürünad";
            this.txtürünad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtürünad.Properties.Appearance.Options.UseFont = true;
            this.txtürünad.Size = new System.Drawing.Size(173, 24);
            this.txtürünad.TabIndex = 4;
            // 
            // txtürünid
            // 
            this.txtürünid.Location = new System.Drawing.Point(89, 5);
            this.txtürünid.Name = "txtürünid";
            this.txtürünid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtürünid.Properties.Appearance.Options.UseFont = true;
            this.txtürünid.Size = new System.Drawing.Size(173, 24);
            this.txtürünid.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(3, 167);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 18);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "FATURA ID:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(43, 134);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 18);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "Tutar:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(48, 104);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 18);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Fiyat:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(40, 74);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(44, 18);
            this.labelControl10.TabIndex = 3;
            this.labelControl10.Text = "Miktar:";
            // 
            // FaturaUrunDuzenleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 292);
            this.Controls.Add(this.groupControl5);
            this.Name = "FaturaUrunDuzenleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FATURA ÜRÜN DÜZENLEME";
            this.Load += new System.EventHandler(this.FaturaUrunDuzenleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtfaturaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtürünad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtürünid.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtfaturaid;
        private DevExpress.XtraEditors.TextEdit txttutar;
        private DevExpress.XtraEditors.TextEdit txtmiktar;
        private DevExpress.XtraEditors.TextEdit txtfiyat;
        private DevExpress.XtraEditors.TextEdit txtürünad;
        private DevExpress.XtraEditors.TextEdit txtürünid;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SimpleButton btnguncelle;
        private DevExpress.XtraEditors.SimpleButton btnsil;
    }
}