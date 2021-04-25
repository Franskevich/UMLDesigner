
namespace UMLDesigner
{
    partial class FormForText
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxProperties = new System.Windows.Forms.TextBox();
            this.textBoxField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxMethods = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.buttonColor = new System.Windows.Forms.Button();
            this.trackBarWidth = new System.Windows.Forms.TrackBar();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonFont = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(14, 53);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(385, 51);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxProperties
            // 
            this.textBoxProperties.Location = new System.Drawing.Point(14, 145);
            this.textBoxProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxProperties.Multiline = true;
            this.textBoxProperties.Name = "textBoxProperties";
            this.textBoxProperties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProperties.Size = new System.Drawing.Size(385, 117);
            this.textBoxProperties.TabIndex = 1;
            this.textBoxProperties.TextChanged += new System.EventHandler(this.textBoxProperties_TextChanged);
            // 
            // textBoxField
            // 
            this.textBoxField.Location = new System.Drawing.Point(14, 307);
            this.textBoxField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxField.Multiline = true;
            this.textBoxField.Name = "textBoxField";
            this.textBoxField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxField.Size = new System.Drawing.Size(385, 137);
            this.textBoxField.TabIndex = 2;
            this.textBoxField.TextChanged += new System.EventHandler(this.textBoxField_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Properties:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fields:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Methods:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(221, 744);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(178, 47);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxMethods
            // 
            this.textBoxMethods.Location = new System.Drawing.Point(14, 488);
            this.textBoxMethods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMethods.Multiline = true;
            this.textBoxMethods.Name = "textBoxMethods";
            this.textBoxMethods.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMethods.Size = new System.Drawing.Size(385, 187);
            this.textBoxMethods.TabIndex = 10;
            this.textBoxMethods.TextChanged += new System.EventHandler(this.textBoxMethods_TextChanged);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(14, 684);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(96, 52);
            this.buttonColor.TabIndex = 11;
            this.buttonColor.Text = "Color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // trackBarWidth
            // 
            this.trackBarWidth.Location = new System.Drawing.Point(14, 744);
            this.trackBarWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarWidth.Minimum = 1;
            this.trackBarWidth.Name = "trackBarWidth";
            this.trackBarWidth.Size = new System.Drawing.Size(189, 56);
            this.trackBarWidth.TabIndex = 12;
            this.trackBarWidth.Value = 1;
            this.trackBarWidth.Scroll += new System.EventHandler(this.trackBarWidth_Scroll);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDelete.Location = new System.Drawing.Point(221, 684);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(178, 52);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(117, 684);
            this.buttonFont.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(86, 52);
            this.buttonFont.TabIndex = 14;
            this.buttonFont.Text = "Font";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // FormForText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 813);
            this.Controls.Add(this.buttonFont);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.trackBarWidth);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.textBoxMethods);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxField);
            this.Controls.Add(this.textBoxProperties);
            this.Controls.Add(this.textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormForText";
            this.Text = "FormForText";
            this.Load += new System.EventHandler(this.FormForText_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxProperties;
        private System.Windows.Forms.TextBox textBoxField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxMethods;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.TrackBar trackBarWidth;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonFont;
    }
}