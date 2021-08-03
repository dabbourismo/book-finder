namespace BookFinder.Winform.BookForms
{
    partial class BookFormBase
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.btnExportToExcel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSearch = new Syncfusion.WinForms.Controls.SfButton();
            this.btnDelete = new Syncfusion.WinForms.Controls.SfButton();
            this.btnNew = new Syncfusion.WinForms.Controls.SfButton();
            this.btnEdit = new Syncfusion.WinForms.Controls.SfButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnImport = new Syncfusion.WinForms.Controls.SfButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Location = new System.Drawing.Point(170, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(591, 78);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "البحث";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(477, 32);
            this.txtSearch.BorderColor = System.Drawing.Color.LightGray;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtSearch.Location = new System.Drawing.Point(108, 25);
            this.txtSearch.MinimumSize = new System.Drawing.Size(8, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(477, 32);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ThemeStyle.CornerRadius = 0;
            this.txtSearch.UseBorderColorOnFocus = true;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.AllowEditing = false;
            this.sfDataGrid1.AllowFiltering = true;
            this.sfDataGrid1.AllowTriStateSorting = true;
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.AutoGenerateColumns = false;
            this.sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.sfDataGrid1.EnableDataVirtualization = true;
            this.sfDataGrid1.Location = new System.Drawing.Point(12, 100);
            this.sfDataGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            this.sfDataGrid1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sfDataGrid1.ShowRowHeader = true;
            this.sfDataGrid1.Size = new System.Drawing.Size(982, 614);
            this.sfDataGrid1.Style.HeaderStyle.BackColor = System.Drawing.Color.CadetBlue;
            this.sfDataGrid1.Style.HeaderStyle.Font.Bold = true;
            this.sfDataGrid1.Style.HeaderStyle.Font.Facename = "Segoe UI";
            this.sfDataGrid1.Style.HeaderStyle.Font.Size = 10F;
            this.sfDataGrid1.Style.HeaderStyle.TextColor = System.Drawing.Color.White;
            this.sfDataGrid1.Style.RowHeaderStyle.BackColor = System.Drawing.Color.CadetBlue;
            this.sfDataGrid1.Style.RowHeaderStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sfDataGrid1.Style.RowHeaderStyle.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            this.sfDataGrid1.Style.RowHeaderStyle.SelectionMarkerColor = System.Drawing.Color.Crimson;
            this.sfDataGrid1.Style.RowHeaderStyle.TextColor = System.Drawing.Color.White;
            this.sfDataGrid1.TabIndex = 8;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.sfDataGrid1_SelectionChanged);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.AccessibleName = "Button";
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnExportToExcel.ImageSize = new System.Drawing.Size(32, 32);
            this.btnExportToExcel.Location = new System.Drawing.Point(767, 16);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(74, 68);
            this.btnExportToExcel.Style.Image = global::BookFinder.Winform.Resource1.excel;
            this.btnExportToExcel.TabIndex = 13;
            this.btnExportToExcel.Text = "(F3) تصدير";
            this.btnExportToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnExportToExcel.ThemeName = "";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleName = "Button";
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.btnSearch.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSearch.Location = new System.Drawing.Point(6, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 41);
            this.btnSearch.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSearch.Style.Image = global::BookFinder.Winform.Resource1.magnifying_glass;
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "Button";
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnDelete.ImageSize = new System.Drawing.Size(32, 32);
            this.btnDelete.Location = new System.Drawing.Point(10, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 68);
            this.btnDelete.Style.Image = global::BookFinder.Winform.Resource1.icons8_delete_bin_32;
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "(Del) حذف";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleName = "Button";
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnNew.ImageSize = new System.Drawing.Size(32, 32);
            this.btnNew.Location = new System.Drawing.Point(924, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(74, 68);
            this.btnNew.Style.Image = global::BookFinder.Winform.Resource1.add__3_;
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "(F1) جديد";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnNew.ThemeName = "";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleName = "Button";
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnEdit.ImageSize = new System.Drawing.Size(32, 32);
            this.btnEdit.Location = new System.Drawing.Point(844, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(74, 68);
            this.btnEdit.Style.Image = global::BookFinder.Winform.Resource1.pencil;
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "(F2) تعديل";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnEdit.ThemeName = "";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::BookFinder.Winform.Resource1.loading3;
            this.pictureBox1.Location = new System.Drawing.Point(90, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.AccessibleName = "Button";
            this.btnImport.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnImport.ImageSize = new System.Drawing.Size(32, 32);
            this.btnImport.Location = new System.Drawing.Point(90, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(74, 68);
            this.btnImport.Style.Image = global::BookFinder.Winform.Resource1.excel;
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "(F4) استيراد";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnImport.ThemeName = "";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // BookFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnImport);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BookFormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookFormBase";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.WinForms.Controls.SfButton btnSearch;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearch;
        protected Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Syncfusion.WinForms.Controls.SfButton btnDelete;
        private Syncfusion.WinForms.Controls.SfButton btnNew;
        private Syncfusion.WinForms.Controls.SfButton btnEdit;
        private Syncfusion.WinForms.Controls.SfButton btnExportToExcel;
        private Syncfusion.WinForms.Controls.SfButton btnImport;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}