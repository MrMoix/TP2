using System.Diagnostics.CodeAnalysis;

namespace Image
{
    [ExcludeFromCodeCoverage]
    partial class FormImageEdge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageEdge));
            this.buttonLoad = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.listBoxYFilter = new System.Windows.Forms.ListBox();
            this.listBoxXFilter = new System.Windows.Forms.ListBox();
            this.labelXFilter = new System.Windows.Forms.Label();
            this.labelYFilter = new System.Windows.Forms.Label();
            this.buttonApplyFilters = new System.Windows.Forms.Button();
            this.labelOrignalImage = new System.Windows.Forms.Label();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.labelResultImage = new System.Windows.Forms.Label();
            this.groupBoxDetectionFilter = new System.Windows.Forms.GroupBox();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.buttonSwapFilter = new System.Windows.Forms.Button();
            this.buttonMosaicFilter = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxSaveImage = new System.Windows.Forms.TextBox();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.labelEnterValidName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.groupBoxDetectionFilter.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(45, 537);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPreview.Image")));
            this.pictureBoxPreview.Location = new System.Drawing.Point(45, 80);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(552, 428);
            this.pictureBoxPreview.TabIndex = 1;
            this.pictureBoxPreview.TabStop = false;
            // 
            // listBoxYFilter
            // 
            
            this.listBoxYFilter.FormattingEnabled = true;
            this.listBoxYFilter.Items.AddRange(new object[] {
            "",
            "Laplacian3x3",
            "Laplacian5x5",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.listBoxYFilter.Location = new System.Drawing.Point(172, 44);
            this.listBoxYFilter.Name = "listBoxYFilter";
            this.listBoxYFilter.Size = new System.Drawing.Size(120, 95);
            this.listBoxYFilter.TabIndex = 2;
            // 
            // listBoxXFilter
            // 
            
            this.listBoxXFilter.FormattingEnabled = true;
            this.listBoxXFilter.Items.AddRange(new object[] {
            "",
            "Laplacian3x3",
            "Laplacian5x5",
            "Sobel3x3Horizontal",
            "Sobel3x3Vertical",
            "Prewitt3x3Horizontal",
            "Prewitt3x3Vertical",
            "Kirsch3x3Horizontal",
            "Kirsch3x3Vertical"});
            this.listBoxXFilter.Location = new System.Drawing.Point(26, 44);
            this.listBoxXFilter.Name = "listBoxXFilter";
            this.listBoxXFilter.Size = new System.Drawing.Size(120, 95);
            this.listBoxXFilter.TabIndex = 3;
            // 
            // labelXFilter
            // 
            this.labelXFilter.AutoSize = true;
            this.labelXFilter.Location = new System.Drawing.Point(26, 25);
            this.labelXFilter.Name = "labelXFilter";
            this.labelXFilter.Size = new System.Drawing.Size(39, 13);
            this.labelXFilter.TabIndex = 4;
            this.labelXFilter.Text = "X Filter";
            // 
            // labelYFilter
            // 
            this.labelYFilter.AutoSize = true;
            this.labelYFilter.Location = new System.Drawing.Point(169, 25);
            this.labelYFilter.Name = "labelYFilter";
            this.labelYFilter.Size = new System.Drawing.Size(39, 13);
            this.labelYFilter.TabIndex = 4;
            this.labelYFilter.Text = "Y Filter";
            // 
            // buttonApplyFilters
            // 
           
            this.buttonApplyFilters.Location = new System.Drawing.Point(1011, 671);
            this.buttonApplyFilters.Name = "buttonApplyFilters";
            this.buttonApplyFilters.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyFilters.TabIndex = 5;
            this.buttonApplyFilters.Text = "Apply Filters";
            this.buttonApplyFilters.UseVisualStyleBackColor = true;
            this.buttonApplyFilters.Click += new System.EventHandler(this.buttonApplyFilters_Click);
            // 
            // labelOrignalImage
            // 
            this.labelOrignalImage.AutoSize = true;
            this.labelOrignalImage.Location = new System.Drawing.Point(46, 38);
            this.labelOrignalImage.Name = "labelOrignalImage";
            this.labelOrignalImage.Size = new System.Drawing.Size(74, 13);
            this.labelOrignalImage.TabIndex = 7;
            this.labelOrignalImage.Text = "Original Image";
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Location = new System.Drawing.Point(619, 80);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(552, 428);
            this.pictureBoxResult.TabIndex = 1;
            this.pictureBoxResult.TabStop = false;
            // 
            // labelResultImage
            // 
            this.labelResultImage.AutoSize = true;
            this.labelResultImage.Location = new System.Drawing.Point(616, 38);
            this.labelResultImage.Name = "labelResultImage";
            this.labelResultImage.Size = new System.Drawing.Size(81, 13);
            this.labelResultImage.TabIndex = 7;
            this.labelResultImage.Text = "Edge Detection";
            // 
            // groupBoxDetectionFilter
            // 
            this.groupBoxDetectionFilter.Controls.Add(this.listBoxXFilter);
            this.groupBoxDetectionFilter.Controls.Add(this.listBoxYFilter);
            this.groupBoxDetectionFilter.Controls.Add(this.labelXFilter);
            this.groupBoxDetectionFilter.Controls.Add(this.labelYFilter);
            this.groupBoxDetectionFilter.Location = new System.Drawing.Point(671, 537);
            this.groupBoxDetectionFilter.Name = "groupBoxDetectionFilter";
            this.groupBoxDetectionFilter.Size = new System.Drawing.Size(318, 157);
            this.groupBoxDetectionFilter.TabIndex = 8;
            this.groupBoxDetectionFilter.TabStop = false;
            this.groupBoxDetectionFilter.Text = "Edge Detection Filters";
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.buttonSwapFilter);
            this.groupBoxFilters.Controls.Add(this.buttonMosaicFilter);
            this.groupBoxFilters.Location = new System.Drawing.Point(211, 537);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(200, 139);
            this.groupBoxFilters.TabIndex = 9;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            // 
            // buttonSwapFilter
            // 
            this.buttonSwapFilter.Location = new System.Drawing.Point(53, 83);
            this.buttonSwapFilter.Name = "buttonSwapFilter";
            this.buttonSwapFilter.Size = new System.Drawing.Size(98, 30);
            this.buttonSwapFilter.TabIndex = 41;
            this.buttonSwapFilter.Text = "Swap Filter";
            this.buttonSwapFilter.UseVisualStyleBackColor = true;
            this.buttonSwapFilter.Click += new System.EventHandler(this.buttonSwapFilter_Click);
            // 
            // buttonMosaicFilter
            // 
            this.buttonMosaicFilter.Location = new System.Drawing.Point(53, 25);
            this.buttonMosaicFilter.Name = "buttonMosaicFilter";
            this.buttonMosaicFilter.Size = new System.Drawing.Size(98, 30);
            this.buttonMosaicFilter.TabIndex = 30;
            this.buttonMosaicFilter.Text = "Magic Mosaic";
            this.buttonMosaicFilter.UseVisualStyleBackColor = true;
            this.buttonMosaicFilter.Click += new System.EventHandler(this.buttonMosaicFilter_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(432, 653);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 10;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxSaveImage
            // 
            this.textBoxSaveImage.Location = new System.Drawing.Point(1019, 528);
            this.textBoxSaveImage.Name = "textBoxSaveImage";
            this.textBoxSaveImage.Size = new System.Drawing.Size(100, 20);
            this.textBoxSaveImage.TabIndex = 39;
            this.textBoxSaveImage.TextChanged += new System.EventHandler(this.textBoxSave_TextChanged);
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(1125, 525);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(75, 25);
            this.buttonSaveImage.TabIndex = 38;
            this.buttonSaveImage.Text = "Save Image";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // labelEnterValidName
            // 
            this.labelEnterValidName.AutoSize = true;
            this.labelEnterValidName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelEnterValidName.ForeColor = System.Drawing.Color.Red;
            this.labelEnterValidName.Location = new System.Drawing.Point(1015, 562);
            this.labelEnterValidName.Name = "labelEnterValidName";
            this.labelEnterValidName.Size = new System.Drawing.Size(190, 20);
            this.labelEnterValidName.TabIndex = 40;
            this.labelEnterValidName.Text = "Please enter a valid name";
            this.labelEnterValidName.Visible = false;
            // 
            // FormImageEdge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 725);
            this.Controls.Add(this.labelEnterValidName);
            this.Controls.Add(this.textBoxSaveImage);
            this.Controls.Add(this.buttonSaveImage);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.groupBoxDetectionFilter);
            this.Controls.Add(this.labelResultImage);
            this.Controls.Add(this.labelOrignalImage);
            this.Controls.Add(this.buttonApplyFilters);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.buttonLoad);
            this.Name = "FormImageEdge";
            this.Text = "Single Color Edge Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.groupBoxDetectionFilter.ResumeLayout(false);
            this.groupBoxDetectionFilter.PerformLayout();
            this.groupBoxFilters.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        public System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.ListBox listBoxYFilter;
        private System.Windows.Forms.ListBox listBoxXFilter;
        private System.Windows.Forms.Label labelXFilter;
        private System.Windows.Forms.Label labelYFilter;
        private System.Windows.Forms.Button buttonApplyFilters;
        private System.Windows.Forms.Label labelOrignalImage;
        public System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label labelResultImage;
        private System.Windows.Forms.GroupBox groupBoxDetectionFilter;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.Button buttonSwapFilter;
        private System.Windows.Forms.Button buttonMosaicFilter;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxSaveImage;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Label labelEnterValidName;
    }
}

