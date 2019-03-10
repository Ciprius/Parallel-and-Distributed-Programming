namespace Lab2
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
            this.StartBtn = new System.Windows.Forms.Button();
            this.MatrixPanel1 = new System.Windows.Forms.Panel();
            this.MatrixPanel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddtionPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.MatrixPanelMul1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.MatrixPanelMul2 = new System.Windows.Forms.Panel();
            this.MulPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.MulButton = new System.Windows.Forms.Button();
            this.TimeBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.ThreadRadioBtn1 = new System.Windows.Forms.RadioButton();
            this.ThreadRadioBtnn = new System.Windows.Forms.RadioButton();
            this.ThreadRadioBtnnXn = new System.Windows.Forms.RadioButton();
            this.AddThPoolBtn = new System.Windows.Forms.Button();
            this.MulThPoolBtn = new System.Windows.Forms.Button();
            this.AddTaskBtn = new System.Windows.Forms.Button();
            this.MulTaskBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(146, 40);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Add";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // MatrixPanel1
            // 
            this.MatrixPanel1.Location = new System.Drawing.Point(10, 69);
            this.MatrixPanel1.Name = "MatrixPanel1";
            this.MatrixPanel1.Size = new System.Drawing.Size(169, 111);
            this.MatrixPanel1.TabIndex = 1;
            // 
            // MatrixPanel2
            // 
            this.MatrixPanel2.Location = new System.Drawing.Point(204, 69);
            this.MatrixPanel2.Name = "MatrixPanel2";
            this.MatrixPanel2.Size = new System.Drawing.Size(169, 111);
            this.MatrixPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "=";
            // 
            // AddtionPanel
            // 
            this.AddtionPanel.Location = new System.Drawing.Point(398, 69);
            this.AddtionPanel.Name = "AddtionPanel";
            this.AddtionPanel.Size = new System.Drawing.Size(169, 111);
            this.AddtionPanel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time";
            // 
            // TimeBox
            // 
            this.TimeBox.Location = new System.Drawing.Point(444, 183);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(100, 20);
            this.TimeBox.TabIndex = 7;
            // 
            // MatrixPanelMul1
            // 
            this.MatrixPanelMul1.Location = new System.Drawing.Point(12, 267);
            this.MatrixPanelMul1.Name = "MatrixPanelMul1";
            this.MatrixPanelMul1.Size = new System.Drawing.Size(169, 111);
            this.MatrixPanelMul1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "*";
            // 
            // MatrixPanelMul2
            // 
            this.MatrixPanelMul2.Location = new System.Drawing.Point(204, 267);
            this.MatrixPanelMul2.Name = "MatrixPanelMul2";
            this.MatrixPanelMul2.Size = new System.Drawing.Size(169, 111);
            this.MatrixPanelMul2.TabIndex = 3;
            // 
            // MulPanel
            // 
            this.MulPanel.Location = new System.Drawing.Point(398, 267);
            this.MulPanel.Name = "MulPanel";
            this.MulPanel.Size = new System.Drawing.Size(169, 111);
            this.MulPanel.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "=";
            // 
            // MulButton
            // 
            this.MulButton.Location = new System.Drawing.Point(146, 238);
            this.MulButton.Name = "MulButton";
            this.MulButton.Size = new System.Drawing.Size(75, 23);
            this.MulButton.TabIndex = 10;
            this.MulButton.Text = "Mul";
            this.MulButton.UseVisualStyleBackColor = true;
            this.MulButton.Click += new System.EventHandler(this.MulButton_Click);
            // 
            // TimeBox1
            // 
            this.TimeBox1.Location = new System.Drawing.Point(444, 384);
            this.TimeBox1.Name = "TimeBox1";
            this.TimeBox1.Size = new System.Drawing.Size(100, 20);
            this.TimeBox1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Time";
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(581, 216);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(75, 23);
            this.GenerateBtn.TabIndex = 13;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // ThreadRadioBtn1
            // 
            this.ThreadRadioBtn1.AutoSize = true;
            this.ThreadRadioBtn1.Location = new System.Drawing.Point(588, 256);
            this.ThreadRadioBtn1.Name = "ThreadRadioBtn1";
            this.ThreadRadioBtn1.Size = new System.Drawing.Size(68, 17);
            this.ThreadRadioBtn1.TabIndex = 14;
            this.ThreadRadioBtn1.TabStop = true;
            this.ThreadRadioBtn1.Text = "1 Thread";
            this.ThreadRadioBtn1.UseVisualStyleBackColor = true;
            // 
            // ThreadRadioBtnn
            // 
            this.ThreadRadioBtnn.AutoSize = true;
            this.ThreadRadioBtnn.Location = new System.Drawing.Point(588, 280);
            this.ThreadRadioBtnn.Name = "ThreadRadioBtnn";
            this.ThreadRadioBtnn.Size = new System.Drawing.Size(73, 17);
            this.ThreadRadioBtnn.TabIndex = 15;
            this.ThreadRadioBtnn.TabStop = true;
            this.ThreadRadioBtnn.Text = "n Threads";
            this.ThreadRadioBtnn.UseVisualStyleBackColor = true;
            // 
            // ThreadRadioBtnnXn
            // 
            this.ThreadRadioBtnnXn.AutoSize = true;
            this.ThreadRadioBtnnXn.Location = new System.Drawing.Point(588, 304);
            this.ThreadRadioBtnnXn.Name = "ThreadRadioBtnnXn";
            this.ThreadRadioBtnnXn.Size = new System.Drawing.Size(86, 17);
            this.ThreadRadioBtnnXn.TabIndex = 16;
            this.ThreadRadioBtnnXn.TabStop = true;
            this.ThreadRadioBtnnXn.Text = "nXn Threads";
            this.ThreadRadioBtnnXn.UseVisualStyleBackColor = true;
            // 
            // AddThPoolBtn
            // 
            this.AddThPoolBtn.Location = new System.Drawing.Point(249, 40);
            this.AddThPoolBtn.Name = "AddThPoolBtn";
            this.AddThPoolBtn.Size = new System.Drawing.Size(75, 23);
            this.AddThPoolBtn.TabIndex = 17;
            this.AddThPoolBtn.Text = "Add Th Pool";
            this.AddThPoolBtn.UseVisualStyleBackColor = true;
            this.AddThPoolBtn.Click += new System.EventHandler(this.AddThPoolBtn_Click);
            // 
            // MulThPoolBtn
            // 
            this.MulThPoolBtn.Location = new System.Drawing.Point(249, 238);
            this.MulThPoolBtn.Name = "MulThPoolBtn";
            this.MulThPoolBtn.Size = new System.Drawing.Size(75, 23);
            this.MulThPoolBtn.TabIndex = 18;
            this.MulThPoolBtn.Text = "Mul Th Pool";
            this.MulThPoolBtn.UseVisualStyleBackColor = true;
            this.MulThPoolBtn.Click += new System.EventHandler(this.MulThPoolBtn_Click);
            // 
            // AddTaskBtn
            // 
            this.AddTaskBtn.Location = new System.Drawing.Point(354, 40);
            this.AddTaskBtn.Name = "AddTaskBtn";
            this.AddTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.AddTaskBtn.TabIndex = 19;
            this.AddTaskBtn.Text = "Add Task";
            this.AddTaskBtn.UseVisualStyleBackColor = true;
            this.AddTaskBtn.Click += new System.EventHandler(this.AddTaskBtn_Click);
            // 
            // MulTaskBtn
            // 
            this.MulTaskBtn.Location = new System.Drawing.Point(354, 238);
            this.MulTaskBtn.Name = "MulTaskBtn";
            this.MulTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.MulTaskBtn.TabIndex = 20;
            this.MulTaskBtn.Text = "Mul Task";
            this.MulTaskBtn.UseVisualStyleBackColor = true;
            this.MulTaskBtn.Click += new System.EventHandler(this.MulTaskBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 410);
            this.Controls.Add(this.MulTaskBtn);
            this.Controls.Add(this.AddTaskBtn);
            this.Controls.Add(this.MulThPoolBtn);
            this.Controls.Add(this.AddThPoolBtn);
            this.Controls.Add(this.ThreadRadioBtnnXn);
            this.Controls.Add(this.ThreadRadioBtnn);
            this.Controls.Add(this.ThreadRadioBtn1);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TimeBox1);
            this.Controls.Add(this.MulButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MulPanel);
            this.Controls.Add(this.MatrixPanelMul2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MatrixPanelMul1);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddtionPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MatrixPanel2);
            this.Controls.Add(this.MatrixPanel1);
            this.Controls.Add(this.StartBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Panel MatrixPanel1;
        private System.Windows.Forms.Panel MatrixPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel AddtionPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TimeBox;
        private System.Windows.Forms.Panel MatrixPanelMul1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel MatrixPanelMul2;
        private System.Windows.Forms.Panel MulPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button MulButton;
        private System.Windows.Forms.TextBox TimeBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.RadioButton ThreadRadioBtn1;
        private System.Windows.Forms.RadioButton ThreadRadioBtnn;
        private System.Windows.Forms.RadioButton ThreadRadioBtnnXn;
        private System.Windows.Forms.Button AddThPoolBtn;
        private System.Windows.Forms.Button MulThPoolBtn;
        private System.Windows.Forms.Button AddTaskBtn;
        private System.Windows.Forms.Button MulTaskBtn;
    }
}

