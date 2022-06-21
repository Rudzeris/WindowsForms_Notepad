namespace TextReda
{
    partial class SRForm
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
            this.PrevB = new System.Windows.Forms.Button();
            this.NextB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReplaceAllB = new System.Windows.Forms.Button();
            this.ReplaceB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrevB
            // 
            this.PrevB.Location = new System.Drawing.Point(0, 71);
            this.PrevB.Name = "PrevB";
            this.PrevB.Size = new System.Drawing.Size(75, 23);
            this.PrevB.TabIndex = 0;
            this.PrevB.Text = "Prev";
            this.PrevB.UseVisualStyleBackColor = true;
            this.PrevB.Click += new System.EventHandler(this.PrevB_Click);
            // 
            // NextB
            // 
            this.NextB.Location = new System.Drawing.Point(125, 71);
            this.NextB.Name = "NextB";
            this.NextB.Size = new System.Drawing.Size(75, 23);
            this.NextB.TabIndex = 1;
            this.NextB.Text = "Next";
            this.NextB.UseVisualStyleBackColor = true;
            this.NextB.Click += new System.EventHandler(this.NextB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReplaceAllB);
            this.groupBox1.Controls.Add(this.ReplaceB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.PrevB);
            this.groupBox1.Controls.Add(this.NextB);
            this.groupBox1.Location = new System.Drawing.Point(74, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // ReplaceAllB
            // 
            this.ReplaceAllB.Location = new System.Drawing.Point(125, 100);
            this.ReplaceAllB.Name = "ReplaceAllB";
            this.ReplaceAllB.Size = new System.Drawing.Size(75, 23);
            this.ReplaceAllB.TabIndex = 8;
            this.ReplaceAllB.Text = "button2";
            this.ReplaceAllB.UseVisualStyleBackColor = true;
            this.ReplaceAllB.Click += new System.EventHandler(this.ReplaceAllB_Click);
            // 
            // ReplaceB
            // 
            this.ReplaceB.Location = new System.Drawing.Point(0, 100);
            this.ReplaceB.Name = "ReplaceB";
            this.ReplaceB.Size = new System.Drawing.Size(75, 23);
            this.ReplaceB.TabIndex = 7;
            this.ReplaceB.Text = "button1";
            this.ReplaceB.UseVisualStyleBackColor = true;
            this.ReplaceB.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // SRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.groupBox1);
            this.Name = "SRForm";
            this.Text = "SRForm";
            this.Resize += new System.EventHandler(this.SRForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrevB;
        private System.Windows.Forms.Button NextB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ReplaceB;
        private System.Windows.Forms.Button ReplaceAllB;
    }
}