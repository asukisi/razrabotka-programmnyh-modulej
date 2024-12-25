namespace Repair
{
    partial class FeedbackForm
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
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxComment = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numericUpDownRating = new NumericUpDown();
            buttonSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(157, 54);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(120, 23);
            textBoxName.TabIndex = 0;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(157, 83);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(120, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxComment
            // 
            textBoxComment.Location = new Point(157, 141);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(120, 23);
            textBoxComment.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 57);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 4;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 83);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 5;
            label2.Text = "Почта";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 112);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 6;
            label3.Text = "Оценка";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 141);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 7;
            label4.Text = "Комментарий";
            // 
            // numericUpDownRating
            // 
            numericUpDownRating.Location = new Point(157, 112);
            numericUpDownRating.Name = "numericUpDownRating";
            numericUpDownRating.Size = new Size(120, 23);
            numericUpDownRating.TabIndex = 8;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(67, 179);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(210, 62);
            buttonSubmit.TabIndex = 9;
            buttonSubmit.Text = "Отправить";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // FeedbackForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSubmit);
            Controls.Add(numericUpDownRating);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxComment);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Name = "FeedbackForm";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private TextBox textBoxComment;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDownRating;
        private Button buttonSubmit;
    }
}