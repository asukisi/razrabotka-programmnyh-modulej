namespace Repair
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
            dataGridView1 = new DataGridView();
            ConnectButton = new Button();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            label4 = new Label();
            SearchButton = new Button();
            SearchByComboBox = new Button();
            label5 = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            pictureBox1 = new PictureBox();
            button4fd = new Button();
            button4 = new Button();
            comboBox2 = new ComboBox();
            comboBoxUsers = new ComboBox();
            btnDelete = new Button();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            скачатьToolStripMenuItem = new ToolStripMenuItem();
            получитьБонусToolStripMenuItem = new ToolStripMenuItem();
            завершитьТекущуюСессиюToolStripMenuItem = new ToolStripMenuItem();
            обратнаяСвязьToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(513, 283);
            dataGridView1.TabIndex = 0;
            // 
            // ConnectButton
            // 
            ConnectButton.Anchor = AnchorStyles.Left;
            ConnectButton.Location = new Point(12, 333);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(104, 23);
            ConnectButton.TabIndex = 1;
            ConnectButton.Text = "Отобразить";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // button1
            // 
            button1.Location = new Point(560, 275);
            button1.Name = "button1";
            button1.Size = new Size(104, 23);
            button1.TabIndex = 2;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(560, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(560, 26);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 4;
            label1.Text = "имя";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(560, 95);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(121, 23);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(560, 77);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 6;
            label2.Text = "id";
            // 
            // button2
            // 
            button2.Location = new Point(560, 362);
            button2.Name = "button2";
            button2.Size = new Size(104, 23);
            button2.TabIndex = 7;
            button2.Text = "Удалить все";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(560, 304);
            button3.Name = "button3";
            button3.Size = new Size(104, 23);
            button3.TabIndex = 8;
            button3.Text = "Заменить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "в ожидании", "в работе ", "выполнено" });
            comboBox1.Location = new Point(560, 173);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            comboBox1.Text = "Статус";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(560, 144);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(121, 23);
            textBox3.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(560, 126);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 12;
            label4.Text = "описание";
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Left;
            SearchButton.Location = new Point(12, 362);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(104, 23);
            SearchButton.TabIndex = 13;
            SearchButton.Text = "Поиск по айди";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += button4_Click;
            // 
            // SearchByComboBox
            // 
            SearchByComboBox.Anchor = AnchorStyles.Left;
            SearchByComboBox.Location = new Point(12, 391);
            SearchByComboBox.Name = "SearchByComboBox";
            SearchByComboBox.Size = new Size(104, 39);
            SearchByComboBox.TabIndex = 14;
            SearchByComboBox.Text = "Поиск по комбобокс";
            SearchByComboBox.UseVisualStyleBackColor = true;
            SearchByComboBox.Click += SearchByComboBox_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(12, 558);
            label5.Name = "label5";
            label5.Size = new Size(128, 15);
            label5.TabIndex = 15;
            label5.Text = "ООО \"Проект сервис\"";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = AnchorStyles.Bottom;
            dateTimePickerStart.Location = new Point(275, 552);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 16;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Anchor = AnchorStyles.Bottom;
            dateTimePickerEnd.Location = new Point(481, 552);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(325, 333);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // button4fd
            // 
            button4fd.Anchor = AnchorStyles.Left;
            button4fd.Location = new Point(12, 436);
            button4fd.Name = "button4fd";
            button4fd.Size = new Size(104, 41);
            button4fd.TabIndex = 19;
            button4fd.Text = "Показать qr code";
            button4fd.UseVisualStyleBackColor = true;
            button4fd.Click += button4fd_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(697, 552);
            button4.Name = "button4";
            button4.Size = new Size(104, 23);
            button4.TabIndex = 21;
            button4.Text = "Фильтровать";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "низкий", "средний", "высокий" });
            comboBox2.Location = new Point(560, 202);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 26;
            comboBox2.Text = "Приоритет";
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(560, 231);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(121, 23);
            comboBoxUsers.TabIndex = 28;
            comboBoxUsers.Text = "Исполнитель";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(560, 333);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(104, 23);
            btnDelete.TabIndex = 29;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, обратнаяСвязьToolStripMenuItem, справкаToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 31;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { скачатьToolStripMenuItem, получитьБонусToolStripMenuItem, завершитьТекущуюСессиюToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // скачатьToolStripMenuItem
            // 
            скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            скачатьToolStripMenuItem.Size = new Size(232, 22);
            скачатьToolStripMenuItem.Text = "Скачать";
            скачатьToolStripMenuItem.Click += скачатьToolStripMenuItem_Click;
            // 
            // получитьБонусToolStripMenuItem
            // 
            получитьБонусToolStripMenuItem.Name = "получитьБонусToolStripMenuItem";
            получитьБонусToolStripMenuItem.Size = new Size(232, 22);
            получитьБонусToolStripMenuItem.Text = "Получить бонус";
            получитьБонусToolStripMenuItem.Click += получитьБонусToolStripMenuItem_Click;
            // 
            // завершитьТекущуюСессиюToolStripMenuItem
            // 
            завершитьТекущуюСессиюToolStripMenuItem.Name = "завершитьТекущуюСессиюToolStripMenuItem";
            завершитьТекущуюСессиюToolStripMenuItem.Size = new Size(232, 22);
            завершитьТекущуюСессиюToolStripMenuItem.Text = "Завершить текущую сессию";
            завершитьТекущуюСессиюToolStripMenuItem.Click += завершитьТекущуюСессиюToolStripMenuItem_Click;
            // 
            // обратнаяСвязьToolStripMenuItem
            // 
            обратнаяСвязьToolStripMenuItem.Name = "обратнаяСвязьToolStripMenuItem";
            обратнаяСвязьToolStripMenuItem.Size = new Size(104, 20);
            обратнаяСвязьToolStripMenuItem.Text = "Обратная связь";
            обратнаяСвязьToolStripMenuItem.Click += обратнаяСвязьToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            справкаToolStripMenuItem.Click += справкаToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(12, 20);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 601);
            Controls.Add(btnDelete);
            Controls.Add(comboBoxUsers);
            Controls.Add(comboBox2);
            Controls.Add(button4);
            Controls.Add(button4fd);
            Controls.Add(pictureBox1);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(label5);
            Controls.Add(SearchByComboBox);
            Controls.Add(SearchButton);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(ConnectButton);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button ConnectButton;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Button SearchButton;
        private Button SearchByComboBox;
        private Label label5;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private PictureBox pictureBox1;
        private Button button4fd;
        private Button button4;
        private Label label7;
        private Label label6;
        private ComboBox comboBox2;
        private Button btnDelete;
        internal ComboBox comboBoxUsers;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem скачатьToolStripMenuItem;
        private ToolStripMenuItem получитьБонусToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem завершитьТекущуюСессиюToolStripMenuItem;
        private ToolStripMenuItem обратнаяСвязьToolStripMenuItem;
    }
}
