namespace WinFormsApp1
{
    partial class Form2
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
            dataGridView = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            textBoxFilePath = new TextBox();
            button_im_f1 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(302, 43);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(472, 359);
            dataGridView.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(202, 131);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "файл";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(322, 11);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 2;
            label1.Text = "Просмотр данных с файла:";
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(12, 75);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(265, 23);
            textBoxFilePath.TabIndex = 3;
            // 
            // button_im_f1
            // 
            button_im_f1.Location = new Point(202, 379);
            button_im_f1.Name = "button_im_f1";
            button_im_f1.Size = new Size(75, 23);
            button_im_f1.TabIndex = 4;
            button_im_f1.Text = "Передать";
            button_im_f1.UseVisualStyleBackColor = true;
            button_im_f1.Click += button_im_f1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 43);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 5;
            label2.Text = "Путь к файлу:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(button_im_f1);
            Controls.Add(textBoxFilePath);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView);
            Name = "Form2";
            Text = "Загрузка файла";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button button1;
        private Label label1;
        private TextBox textBoxFilePath;
        private Button button_im_f1;
        private Label label2;
    }
}