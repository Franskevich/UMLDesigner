
namespace UMLDesigner
{
    partial class Options
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBoxTypeArrow = new System.Windows.Forms.ComboBox();
            this.buttonColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.trackBarWidthLine = new System.Windows.Forms.TrackBar();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidthLine)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTypeArrow
            // 
            this.comboBoxTypeArrow.FormattingEnabled = true;
            this.comboBoxTypeArrow.Location = new System.Drawing.Point(89, 30);
            this.comboBoxTypeArrow.Name = "comboBoxTypeArrow";
            this.comboBoxTypeArrow.Size = new System.Drawing.Size(150, 23);
            this.comboBoxTypeArrow.TabIndex = 0;
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(12, 29);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(58, 70);
            this.buttonColor.TabIndex = 1;
            this.buttonColor.Text = "Color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type Arrow";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width Line";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(255, 29);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(59, 70);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // trackBarWidthLine
            // 
            this.trackBarWidthLine.Location = new System.Drawing.Point(89, 75);
            this.trackBarWidthLine.Minimum = 1;
            this.trackBarWidthLine.Name = "trackBarWidthLine";
            this.trackBarWidthLine.Size = new System.Drawing.Size(150, 45);
            this.trackBarWidthLine.TabIndex = 6;
            this.trackBarWidthLine.Value = 1;
            this.trackBarWidthLine.Scroll += new System.EventHandler(this.trackBarWidthLine_Scroll);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(90, 118);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(148, 26);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 155);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.trackBarWidthLine);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.comboBoxTypeArrow);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWidthLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBoxTypeArrow;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TrackBar trackBarWidthLine;
        private System.Windows.Forms.Button buttonOK;
    }
}