/***********************************
** WinFormsTestApp1.cs
** Author: Pooja Prasanna Nanjunda
** Email: poojananjunda1996@gmail.com
** Date: 04-12-2022
***********************************/

namespace WinFormsTestApp1
{
    /// <summary>
    /// Partial class for WinFormsTestApp1
    /// </summary>
    partial class WinFormsTestApp1
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
            this.Submitbutton = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InputLabel = new System.Windows.Forms.Label();
            this.OutputListBox = new System.Windows.Forms.ListBox();
            this.Outputlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Submitbutton
            // 
            this.Submitbutton.Location = new System.Drawing.Point(59, 114);
            this.Submitbutton.Name = "Submitbutton";
            this.Submitbutton.Size = new System.Drawing.Size(165, 60);
            this.Submitbutton.TabIndex = 0;
            this.Submitbutton.Text = "Submit";
            this.Submitbutton.UseVisualStyleBackColor = true;
            this.Submitbutton.Click += new System.EventHandler(this.Submitbutton_Click);
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(59, 60);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(242, 27);
            this.InputTextBox.TabIndex = 1;
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InputLabel.Location = new System.Drawing.Point(59, 26);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(72, 31);
            this.InputLabel.TabIndex = 2;
            this.InputLabel.Text = "Input";
            // 
            // OutputListBox
            // 
            this.OutputListBox.FormattingEnabled = true;
            this.OutputListBox.ItemHeight = 20;
            this.OutputListBox.Location = new System.Drawing.Point(59, 248);
            this.OutputListBox.Name = "OutputListBox";
            this.OutputListBox.Size = new System.Drawing.Size(742, 144);
            this.OutputListBox.TabIndex = 3;
            // 
            // Outputlabel
            // 
            this.Outputlabel.AutoSize = true;
            this.Outputlabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Outputlabel.Location = new System.Drawing.Point(59, 214);
            this.Outputlabel.Name = "Outputlabel";
            this.Outputlabel.Size = new System.Drawing.Size(91, 31);
            this.Outputlabel.TabIndex = 4;
            this.Outputlabel.Text = "Output";
            // 
            // WinFormsTestApp1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(877, 451);
            this.Controls.Add(this.Outputlabel);
            this.Controls.Add(this.OutputListBox);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.Submitbutton);
            this.Name = "WinFormsTestApp1";
            this.Text = "WinFormsTestApp1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Submitbutton;
        private TextBox InputTextBox;
        private Label InputLabel;
        private ListBox OutputListBox;
        private Label Outputlabel;
    }
}