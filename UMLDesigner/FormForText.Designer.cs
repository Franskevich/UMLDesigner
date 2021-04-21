
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxNameRectangle = new System.Windows.Forms.TextBox();
            this.textBoxFieldRectangle = new System.Windows.Forms.TextBox();
            this.textBoxPropertiesRectangle = new System.Windows.Forms.TextBox();
            this.textBoxMethodRectangle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(136, 520);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(94, 29);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 520);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxNameRectangle
            // 
            this.textBoxNameRectangle.Location = new System.Drawing.Point(12, 48);
            this.textBoxNameRectangle.Name = "textBoxNameRectangle";
            this.textBoxNameRectangle.Size = new System.Drawing.Size(276, 27);
            this.textBoxNameRectangle.TabIndex = 2;
            // 
            // textBoxFieldRectangle
            // 
            this.textBoxFieldRectangle.Location = new System.Drawing.Point(12, 149);
            this.textBoxFieldRectangle.Name = "textBoxFieldRectangle";
            this.textBoxFieldRectangle.Size = new System.Drawing.Size(276, 27);
            this.textBoxFieldRectangle.TabIndex = 3;
            // 
            // textBoxPropertiesRectangle
            // 
            this.textBoxPropertiesRectangle.Location = new System.Drawing.Point(12, 258);
            this.textBoxPropertiesRectangle.Name = "textBoxPropertiesRectangle";
            this.textBoxPropertiesRectangle.Size = new System.Drawing.Size(276, 27);
            this.textBoxPropertiesRectangle.TabIndex = 4;
            // 
            // textBoxMethodRectangle
            // 
            this.textBoxMethodRectangle.Location = new System.Drawing.Point(12, 386);
            this.textBoxMethodRectangle.Name = "textBoxMethodRectangle";
            this.textBoxMethodRectangle.Size = new System.Drawing.Size(276, 27);
            this.textBoxMethodRectangle.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Field:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Properties:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Method:";
            // 
            // FormForText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 564);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMethodRectangle);
            this.Controls.Add(this.textBoxPropertiesRectangle);
            this.Controls.Add(this.textBoxFieldRectangle);
            this.Controls.Add(this.textBoxNameRectangle);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormForText";
            this.Text = "FormForText";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxNameRectangle;
        private System.Windows.Forms.TextBox textBoxFieldRectangle;
        private System.Windows.Forms.TextBox textBoxPropertiesRectangle;
        private System.Windows.Forms.TextBox textBoxMethodRectangle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}