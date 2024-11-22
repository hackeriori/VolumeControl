namespace VolumeControl
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            volumeLabel = new Label();
            label4 = new Label();
            nameLabel = new Label();
            muteCheck = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 118);
            label1.Name = "label1";
            label1.Size = new Size(109, 17);
            label1.TabIndex = 0;
            label1.Text = "'Alt' + '+'增加音量";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 135);
            label2.Name = "label2";
            label2.Size = new Size(105, 17);
            label2.TabIndex = 1;
            label2.Text = "'Alt' + '-'减少音量";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 63);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 2;
            label3.Text = "当前音量：";
            // 
            // volumeLabel
            // 
            volumeLabel.AutoSize = true;
            volumeLabel.Font = new Font("Microsoft YaHei UI", 14F);
            volumeLabel.Location = new Point(123, 59);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(23, 25);
            volumeLabel.TabIndex = 3;
            volumeLabel.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 4;
            label4.Text = "当前设备";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 29);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(0, 17);
            nameLabel.TabIndex = 5;
            // 
            // muteCheck
            // 
            muteCheck.AutoSize = true;
            muteCheck.Location = new Point(61, 83);
            muteCheck.Name = "muteCheck";
            muteCheck.Size = new Size(63, 21);
            muteCheck.TabIndex = 6;
            muteCheck.Text = "已静音";
            muteCheck.UseVisualStyleBackColor = true;
            muteCheck.CheckedChanged += muteCheck_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(242, 161);
            Controls.Add(muteCheck);
            Controls.Add(nameLabel);
            Controls.Add(label4);
            Controls.Add(volumeLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "音量控制";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label volumeLabel;
        private Label label4;
        private Label nameLabel;
        private CheckBox muteCheck;
    }
}
