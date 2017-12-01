namespace WindowsFormsApplication4
{
    partial class Form1
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
            this.txtCharacterSet = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.btnChangeFont = new System.Windows.Forms.Button();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.lblFont = new System.Windows.Forms.Label();
            this.lblCharacterSet = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkIncludeBitFontCharacterClass = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.useFixedWidth = new System.Windows.Forms.CheckBox();
            this.fixedWidth = new System.Windows.Forms.NumericUpDown();
            this.fixedHeight = new System.Windows.Forms.NumericUpDown();
            this.useFixedHeight = new System.Windows.Forms.CheckBox();
            this.fixedOffsetY = new System.Windows.Forms.NumericUpDown();
            this.chkFixedOffsetY = new System.Windows.Forms.CheckBox();
            this.fixedOffsetX = new System.Windows.Forms.NumericUpDown();
            this.chkFixedOffsetX = new System.Windows.Forms.CheckBox();
            this.rbModern = new System.Windows.Forms.RadioButton();
            this.rbLegacy = new System.Windows.Forms.RadioButton();
            this.lblFontType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fixedWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedOffsetX)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCharacterSet
            // 
            this.txtCharacterSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCharacterSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtCharacterSet.Location = new System.Drawing.Point(22, 171);
            this.txtCharacterSet.MaximumSize = new System.Drawing.Size(65323, 140);
            this.txtCharacterSet.MinimumSize = new System.Drawing.Size(666, 82);
            this.txtCharacterSet.Multiline = true;
            this.txtCharacterSet.Name = "txtCharacterSet";
            this.txtCharacterSet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCharacterSet.Size = new System.Drawing.Size(666, 101);
            this.txtCharacterSet.TabIndex = 0;
            this.txtCharacterSet.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-={}|[]" +
    "\\:\";\'<>?,./~` ";
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGenerateCode.Location = new System.Drawing.Point(546, 287);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(142, 37);
            this.btnGenerateCode.TabIndex = 1;
            this.btnGenerateCode.Text = "Generate Code";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChangeFont
            // 
            this.btnChangeFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnChangeFont.Location = new System.Drawing.Point(657, 41);
            this.btnChangeFont.Name = "btnChangeFont";
            this.btnChangeFont.Size = new System.Drawing.Size(31, 27);
            this.btnChangeFont.TabIndex = 2;
            this.btnChangeFont.Text = "...";
            this.btnChangeFont.UseVisualStyleBackColor = true;
            this.btnChangeFont.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtFont
            // 
            this.txtFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtFont.Location = new System.Drawing.Point(303, 41);
            this.txtFont.Name = "txtFont";
            this.txtFont.Size = new System.Drawing.Size(348, 27);
            this.txtFont.TabIndex = 5;
            this.txtFont.Text = "Microsoft Sans Serif, 16pt";
            // 
            // lblFont
            // 
            this.lblFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFont.AutoSize = true;
            this.lblFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblFont.Location = new System.Drawing.Point(300, 19);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(90, 18);
            this.lblFont.TabIndex = 6;
            this.lblFont.Text = "Source Font";
            // 
            // lblCharacterSet
            // 
            this.lblCharacterSet.AutoSize = true;
            this.lblCharacterSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCharacterSet.Location = new System.Drawing.Point(22, 150);
            this.lblCharacterSet.Name = "lblCharacterSet";
            this.lblCharacterSet.Size = new System.Drawing.Size(99, 18);
            this.lblCharacterSet.TabIndex = 7;
            this.lblCharacterSet.Text = "Character Set";
            // 
            // txtClass
            // 
            this.txtClass.AcceptsReturn = true;
            this.txtClass.AcceptsTab = true;
            this.txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtClass.HideSelection = false;
            this.txtClass.Location = new System.Drawing.Point(22, 363);
            this.txtClass.Multiline = true;
            this.txtClass.Name = "txtClass";
            this.txtClass.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtClass.Size = new System.Drawing.Size(666, 238);
            this.txtClass.TabIndex = 8;
            this.txtClass.WordWrap = false;
            // 
            // lblClass
            // 
            this.lblClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblClass.Location = new System.Drawing.Point(22, 340);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(119, 18);
            this.lblClass.TabIndex = 9;
            this.lblClass.Text = "C# Source Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblName.Location = new System.Drawing.Point(26, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 18);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtName.Location = new System.Drawing.Point(26, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(256, 27);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "MyFont";
            // 
            // chkIncludeBitFontCharacterClass
            // 
            this.chkIncludeBitFontCharacterClass.AutoSize = true;
            this.chkIncludeBitFontCharacterClass.Checked = true;
            this.chkIncludeBitFontCharacterClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeBitFontCharacterClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkIncludeBitFontCharacterClass.Location = new System.Drawing.Point(29, 296);
            this.chkIncludeBitFontCharacterClass.Name = "chkIncludeBitFontCharacterClass";
            this.chkIncludeBitFontCharacterClass.Size = new System.Drawing.Size(218, 21);
            this.chkIncludeBitFontCharacterClass.TabIndex = 12;
            this.chkIncludeBitFontCharacterClass.Text = "Include BitFontCharacter class";
            this.chkIncludeBitFontCharacterClass.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPreview.Location = new System.Drawing.Point(398, 287);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(142, 37);
            this.btnPreview.TabIndex = 13;
            this.btnPreview.Text = "Preview...";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // useFixedWidth
            // 
            this.useFixedWidth.AutoSize = true;
            this.useFixedWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.useFixedWidth.Location = new System.Drawing.Point(303, 86);
            this.useFixedWidth.Name = "useFixedWidth";
            this.useFixedWidth.Size = new System.Drawing.Size(100, 21);
            this.useFixedWidth.TabIndex = 14;
            this.useFixedWidth.Text = "Fixed Width";
            this.useFixedWidth.UseVisualStyleBackColor = true;
            this.useFixedWidth.CheckedChanged += new System.EventHandler(this.useFixedWidth_CheckedChanged);
            // 
            // fixedWidth
            // 
            this.fixedWidth.Enabled = false;
            this.fixedWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.fixedWidth.Location = new System.Drawing.Point(421, 83);
            this.fixedWidth.Name = "fixedWidth";
            this.fixedWidth.Size = new System.Drawing.Size(49, 27);
            this.fixedWidth.TabIndex = 16;
            this.fixedWidth.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // fixedHeight
            // 
            this.fixedHeight.Enabled = false;
            this.fixedHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.fixedHeight.Location = new System.Drawing.Point(608, 83);
            this.fixedHeight.Name = "fixedHeight";
            this.fixedHeight.Size = new System.Drawing.Size(49, 27);
            this.fixedHeight.TabIndex = 18;
            this.fixedHeight.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // useFixedHeight
            // 
            this.useFixedHeight.AutoSize = true;
            this.useFixedHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.useFixedHeight.Location = new System.Drawing.Point(490, 86);
            this.useFixedHeight.Name = "useFixedHeight";
            this.useFixedHeight.Size = new System.Drawing.Size(105, 21);
            this.useFixedHeight.TabIndex = 17;
            this.useFixedHeight.Text = "Fixed Height";
            this.useFixedHeight.UseVisualStyleBackColor = true;
            this.useFixedHeight.CheckedChanged += new System.EventHandler(this.useFixedHeight_CheckedChanged);
            // 
            // fixedOffsetY
            // 
            this.fixedOffsetY.Enabled = false;
            this.fixedOffsetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.fixedOffsetY.Location = new System.Drawing.Point(608, 116);
            this.fixedOffsetY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.fixedOffsetY.Name = "fixedOffsetY";
            this.fixedOffsetY.Size = new System.Drawing.Size(49, 27);
            this.fixedOffsetY.TabIndex = 22;
            // 
            // chkFixedOffsetY
            // 
            this.chkFixedOffsetY.AutoSize = true;
            this.chkFixedOffsetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkFixedOffsetY.Location = new System.Drawing.Point(490, 119);
            this.chkFixedOffsetY.Name = "chkFixedOffsetY";
            this.chkFixedOffsetY.Size = new System.Drawing.Size(115, 21);
            this.chkFixedOffsetY.TabIndex = 21;
            this.chkFixedOffsetY.Text = "Fixed Offset Y";
            this.chkFixedOffsetY.UseVisualStyleBackColor = true;
            this.chkFixedOffsetY.CheckedChanged += new System.EventHandler(this.chkFixedOffsetX_CheckedChanged);
            // 
            // fixedOffsetX
            // 
            this.fixedOffsetX.Enabled = false;
            this.fixedOffsetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.fixedOffsetX.Location = new System.Drawing.Point(421, 116);
            this.fixedOffsetX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.fixedOffsetX.Name = "fixedOffsetX";
            this.fixedOffsetX.Size = new System.Drawing.Size(49, 27);
            this.fixedOffsetX.TabIndex = 20;
            // 
            // chkFixedOffsetX
            // 
            this.chkFixedOffsetX.AutoSize = true;
            this.chkFixedOffsetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkFixedOffsetX.Location = new System.Drawing.Point(303, 119);
            this.chkFixedOffsetX.Name = "chkFixedOffsetX";
            this.chkFixedOffsetX.Size = new System.Drawing.Size(115, 21);
            this.chkFixedOffsetX.TabIndex = 19;
            this.chkFixedOffsetX.Text = "Fixed Offset X";
            this.chkFixedOffsetX.UseVisualStyleBackColor = true;
            this.chkFixedOffsetX.CheckedChanged += new System.EventHandler(this.chkFixedOffsetX_CheckedChanged);
            // 
            // rbModern
            // 
            this.rbModern.AutoSize = true;
            this.rbModern.Checked = true;
            this.rbModern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbModern.Location = new System.Drawing.Point(29, 108);
            this.rbModern.Name = "rbModern";
            this.rbModern.Size = new System.Drawing.Size(74, 21);
            this.rbModern.TabIndex = 23;
            this.rbModern.TabStop = true;
            this.rbModern.Text = "Modern";
            this.rbModern.UseVisualStyleBackColor = true;
            this.rbModern.CheckedChanged += new System.EventHandler(this.rbModern_CheckedChanged);
            // 
            // rbLegacy
            // 
            this.rbLegacy.AutoSize = true;
            this.rbLegacy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbLegacy.Location = new System.Drawing.Point(130, 108);
            this.rbLegacy.Name = "rbLegacy";
            this.rbLegacy.Size = new System.Drawing.Size(72, 21);
            this.rbLegacy.TabIndex = 24;
            this.rbLegacy.TabStop = true;
            this.rbLegacy.Text = "Legacy";
            this.rbLegacy.UseVisualStyleBackColor = true;
            this.rbLegacy.CheckedChanged += new System.EventHandler(this.rbModern_CheckedChanged);
            // 
            // lblFontType
            // 
            this.lblFontType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontType.AutoSize = true;
            this.lblFontType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblFontType.Location = new System.Drawing.Point(26, 85);
            this.lblFontType.Name = "lblFontType";
            this.lblFontType.Size = new System.Drawing.Size(156, 18);
            this.lblFontType.TabIndex = 25;
            this.lblFontType.Text = "Font Type to Generate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 613);
            this.Controls.Add(this.lblFontType);
            this.Controls.Add(this.rbLegacy);
            this.Controls.Add(this.rbModern);
            this.Controls.Add(this.fixedOffsetY);
            this.Controls.Add(this.chkFixedOffsetY);
            this.Controls.Add(this.fixedOffsetX);
            this.Controls.Add(this.chkFixedOffsetX);
            this.Controls.Add(this.fixedHeight);
            this.Controls.Add(this.useFixedHeight);
            this.Controls.Add(this.fixedWidth);
            this.Controls.Add(this.useFixedWidth);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.chkIncludeBitFontCharacterClass);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.lblCharacterSet);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.txtFont);
            this.Controls.Add(this.btnChangeFont);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.txtCharacterSet);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "BitFont - Monochrome Font C# Class Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fixedWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixedOffsetX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCharacterSet;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Button btnChangeFont;
        private System.Windows.Forms.TextBox txtFont;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label lblCharacterSet;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkIncludeBitFontCharacterClass;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox useFixedWidth;
        private System.Windows.Forms.NumericUpDown fixedWidth;
        private System.Windows.Forms.NumericUpDown fixedHeight;
        private System.Windows.Forms.CheckBox useFixedHeight;
        private System.Windows.Forms.NumericUpDown fixedOffsetY;
        private System.Windows.Forms.CheckBox chkFixedOffsetY;
        private System.Windows.Forms.NumericUpDown fixedOffsetX;
        private System.Windows.Forms.CheckBox chkFixedOffsetX;
        private System.Windows.Forms.RadioButton rbModern;
        private System.Windows.Forms.RadioButton rbLegacy;
        private System.Windows.Forms.Label lblFontType;
    }
}

