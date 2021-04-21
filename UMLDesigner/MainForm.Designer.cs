
namespace UMLDesigner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAssociation = new System.Windows.Forms.Button();
            this.buttonInheritance = new System.Windows.Forms.Button();
            this.buttonImplementation = new System.Windows.Forms.Button();
            this.buttonAggregationFirst = new System.Windows.Forms.Button();
            this.buttonCompositionFirst = new System.Windows.Forms.Button();
            this.buttonAggregationSecond = new System.Windows.Forms.Button();
            this.buttonCompositionSecond = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonColor = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonClass = new System.Windows.Forms.Button();
            this.buttonInterface = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonStackClass = new System.Windows.Forms.Button();
            this.buttonEnum = new System.Windows.Forms.Button();
            this.buttonStructure = new System.Windows.Forms.Button();
            this.buttonDelegate = new System.Windows.Forms.Button();
            this.buttonСancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(118, 49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1334, 730);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonAssociation
            // 
            this.buttonAssociation.BackgroundImage = global::UMLDesigner.Properties.Resources.Association1;
            this.buttonAssociation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAssociation.Location = new System.Drawing.Point(149, 11);
            this.buttonAssociation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAssociation.Name = "buttonAssociation";
            this.buttonAssociation.Size = new System.Drawing.Size(50, 25);
            this.buttonAssociation.TabIndex = 1;
            this.buttonAssociation.UseVisualStyleBackColor = true;
            this.buttonAssociation.Click += new System.EventHandler(this.buttonAssociation_Click);
            // 
            // buttonInheritance
            // 
            this.buttonInheritance.BackgroundImage = global::UMLDesigner.Properties.Resources.Inheritance;
            this.buttonInheritance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInheritance.Location = new System.Drawing.Point(205, 11);
            this.buttonInheritance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInheritance.Name = "buttonInheritance";
            this.buttonInheritance.Size = new System.Drawing.Size(50, 25);
            this.buttonInheritance.TabIndex = 2;
            this.buttonInheritance.UseVisualStyleBackColor = true;
            this.buttonInheritance.Click += new System.EventHandler(this.buttonInheritance_Click);
            // 
            // buttonImplementation
            // 
            this.buttonImplementation.BackgroundImage = global::UMLDesigner.Properties.Resources.Implementation;
            this.buttonImplementation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonImplementation.Location = new System.Drawing.Point(261, 11);
            this.buttonImplementation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonImplementation.Name = "buttonImplementation";
            this.buttonImplementation.Size = new System.Drawing.Size(50, 25);
            this.buttonImplementation.TabIndex = 3;
            this.buttonImplementation.UseVisualStyleBackColor = true;
            this.buttonImplementation.Click += new System.EventHandler(this.buttonImplementation_Click);
            // 
            // buttonAggregationFirst
            // 
            this.buttonAggregationFirst.BackgroundImage = global::UMLDesigner.Properties.Resources.AggregationFirst;
            this.buttonAggregationFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAggregationFirst.Location = new System.Drawing.Point(317, 11);
            this.buttonAggregationFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAggregationFirst.Name = "buttonAggregationFirst";
            this.buttonAggregationFirst.Size = new System.Drawing.Size(50, 25);
            this.buttonAggregationFirst.TabIndex = 4;
            this.buttonAggregationFirst.UseVisualStyleBackColor = true;
            this.buttonAggregationFirst.Click += new System.EventHandler(this.buttonAggregationFirst_Click);
            // 
            // buttonCompositionFirst
            // 
            this.buttonCompositionFirst.BackgroundImage = global::UMLDesigner.Properties.Resources.CompositionFirst;
            this.buttonCompositionFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCompositionFirst.Location = new System.Drawing.Point(429, 11);
            this.buttonCompositionFirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCompositionFirst.Name = "buttonCompositionFirst";
            this.buttonCompositionFirst.Size = new System.Drawing.Size(50, 25);
            this.buttonCompositionFirst.TabIndex = 5;
            this.buttonCompositionFirst.UseVisualStyleBackColor = true;
            this.buttonCompositionFirst.Click += new System.EventHandler(this.buttonCompositionFirst_Click);
            // 
            // buttonAggregationSecond
            // 
            this.buttonAggregationSecond.BackgroundImage = global::UMLDesigner.Properties.Resources.AggregationSecond;
            this.buttonAggregationSecond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAggregationSecond.Location = new System.Drawing.Point(373, 11);
            this.buttonAggregationSecond.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAggregationSecond.Name = "buttonAggregationSecond";
            this.buttonAggregationSecond.Size = new System.Drawing.Size(50, 25);
            this.buttonAggregationSecond.TabIndex = 6;
            this.buttonAggregationSecond.UseVisualStyleBackColor = true;
            this.buttonAggregationSecond.Click += new System.EventHandler(this.buttonAggregationSecond_Click);
            // 
            // buttonCompositionSecond
            // 
            this.buttonCompositionSecond.BackgroundImage = global::UMLDesigner.Properties.Resources.CompositionSecond;
            this.buttonCompositionSecond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCompositionSecond.Location = new System.Drawing.Point(485, 11);
            this.buttonCompositionSecond.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCompositionSecond.Name = "buttonCompositionSecond";
            this.buttonCompositionSecond.Size = new System.Drawing.Size(50, 25);
            this.buttonCompositionSecond.TabIndex = 7;
            this.buttonCompositionSecond.UseVisualStyleBackColor = true;
            this.buttonCompositionSecond.Click += new System.EventHandler(this.buttonCompositionSecond_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonColor.Location = new System.Drawing.Point(118, 11);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(25, 25);
            this.buttonColor.TabIndex = 9;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(1331, 792);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(100, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // buttonClass
            // 
            this.buttonClass.Location = new System.Drawing.Point(12, 11);
            this.buttonClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClass.Name = "buttonClass";
            this.buttonClass.Size = new System.Drawing.Size(100, 25);
            this.buttonClass.TabIndex = 6;
            this.buttonClass.TabStop = false;
            this.buttonClass.Text = "Class";
            this.buttonClass.UseVisualStyleBackColor = true;
            this.buttonClass.Click += new System.EventHandler(this.buttonClass_Click);
            // 
            // buttonInterface
            // 
            this.buttonInterface.Location = new System.Drawing.Point(10, 98);
            this.buttonInterface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInterface.Name = "buttonInterface";
            this.buttonInterface.Size = new System.Drawing.Size(100, 25);
            this.buttonInterface.TabIndex = 11;
            this.buttonInterface.TabStop = false;
            this.buttonInterface.Text = "Interface";
            this.buttonInterface.UseVisualStyleBackColor = true;
            this.buttonInterface.Click += new System.EventHandler(this.buttonInterface_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClear.Location = new System.Drawing.Point(1402, 11);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(50, 25);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonStackClass
            // 
            this.buttonStackClass.Location = new System.Drawing.Point(10, 40);
            this.buttonStackClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStackClass.Name = "buttonStackClass";
            this.buttonStackClass.Size = new System.Drawing.Size(100, 25);
            this.buttonStackClass.TabIndex = 13;
            this.buttonStackClass.Text = "Stack class";
            this.buttonStackClass.UseVisualStyleBackColor = true;
            this.buttonStackClass.Click += new System.EventHandler(this.buttonStackClass_Click);
            // 
            // buttonEnum
            // 
            this.buttonEnum.Location = new System.Drawing.Point(10, 156);
            this.buttonEnum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEnum.Name = "buttonEnum";
            this.buttonEnum.Size = new System.Drawing.Size(100, 25);
            this.buttonEnum.TabIndex = 14;
            this.buttonEnum.Text = "Enumeration";
            this.buttonEnum.UseVisualStyleBackColor = true;
            this.buttonEnum.Click += new System.EventHandler(this.buttonEnum_Click);
            // 
            // buttonStructure
            // 
            this.buttonStructure.Location = new System.Drawing.Point(10, 69);
            this.buttonStructure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStructure.Name = "buttonStructure";
            this.buttonStructure.Size = new System.Drawing.Size(100, 25);
            this.buttonStructure.TabIndex = 15;
            this.buttonStructure.Text = "Structure";
            this.buttonStructure.UseVisualStyleBackColor = true;
            this.buttonStructure.Click += new System.EventHandler(this.buttonStructure_Click);
            // 
            // buttonDelegate
            // 
            this.buttonDelegate.Location = new System.Drawing.Point(11, 127);
            this.buttonDelegate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelegate.Name = "buttonDelegate";
            this.buttonDelegate.Size = new System.Drawing.Size(100, 25);
            this.buttonDelegate.TabIndex = 16;
            this.buttonDelegate.Text = "Delegate";
            this.buttonDelegate.UseVisualStyleBackColor = true;
            this.buttonDelegate.Click += new System.EventHandler(this.buttonDelegate_Click);
            // 
            // buttonСancel
            // 
            this.buttonСancel.Location = new System.Drawing.Point(1331, 11);
            this.buttonСancel.Name = "buttonСancel";
            this.buttonСancel.Size = new System.Drawing.Size(62, 23);
            this.buttonСancel.TabIndex = 17;
            this.buttonСancel.Text = "Cancel";
            this.buttonСancel.UseVisualStyleBackColor = true;
            this.buttonСancel.Click += new System.EventHandler(this.buttonСancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(554, 11);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(60, 25);
            this.buttonMove.TabIndex = 19;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 861);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonСancel);
            this.Controls.Add(this.buttonDelegate);
            this.Controls.Add(this.buttonStructure);
            this.Controls.Add(this.buttonEnum);
            this.Controls.Add(this.buttonStackClass);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonInterface);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonCompositionSecond);
            this.Controls.Add(this.buttonAggregationSecond);
            this.Controls.Add(this.buttonCompositionFirst);
            this.Controls.Add(this.buttonAggregationFirst);
            this.Controls.Add(this.buttonClass);
            this.Controls.Add(this.buttonImplementation);
            this.Controls.Add(this.buttonInheritance);
            this.Controls.Add(this.buttonAssociation);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAssociation;
        private System.Windows.Forms.Button buttonInheritance;
        private System.Windows.Forms.Button buttonImplementation;
        private System.Windows.Forms.Button buttonAggregationFirst;
        private System.Windows.Forms.Button buttonCompositionFirst;
        private System.Windows.Forms.Button buttonAggregationSecond;
        private System.Windows.Forms.Button buttonCompositionSecond;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonClass;
        private System.Windows.Forms.Button buttonInterface;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonStackClass;
        private System.Windows.Forms.Button buttonEnum;
        private System.Windows.Forms.Button buttonStructure;
        private System.Windows.Forms.Button buttonDelegate;
        private System.Windows.Forms.Button buttonСancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMove;
    }
}

