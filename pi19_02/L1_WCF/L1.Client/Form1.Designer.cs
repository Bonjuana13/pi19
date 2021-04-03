namespace WindowsFormsApp1
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
      if (disposing && (components != null)) {
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
            this.GetInfo = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TestForDeserialize = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.EditFullArticle_But = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.WantToChangeFullArticle = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.NameEnc_label = new System.Windows.Forms.Label();
            this.RTBFullArticle = new System.Windows.Forms.RichTextBox();
            this.PartList_But = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SendPicture_But = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GetInfo
            // 
            this.GetInfo.Location = new System.Drawing.Point(6, 6);
            this.GetInfo.Name = "GetInfo";
            this.GetInfo.Size = new System.Drawing.Size(311, 117);
            this.GetInfo.TabIndex = 0;
            this.GetInfo.Text = "Тест энциклопедия";
            this.GetInfo.UseVisualStyleBackColor = true;
            this.GetInfo.Click += new System.EventHandler(this.GetInfo_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 129);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1023, 366);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // TestForDeserialize
            // 
            this.TestForDeserialize.Location = new System.Drawing.Point(718, 6);
            this.TestForDeserialize.Name = "TestForDeserialize";
            this.TestForDeserialize.Size = new System.Drawing.Size(311, 117);
            this.TestForDeserialize.TabIndex = 2;
            this.TestForDeserialize.Text = "Десериализация";
            this.TestForDeserialize.UseVisualStyleBackColor = true;
            this.TestForDeserialize.Click += new System.EventHandler(this.TestForDeserialize_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1858, 611);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.GetInfo);
            this.tabPage1.Controls.Add(this.TestForDeserialize);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1850, 582);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Тестовая";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(311, 117);
            this.button2.TabIndex = 3;
            this.button2.Text = "Тест полная статья";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SendPicture_But);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.EditFullArticle_But);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Controls.Add(this.WantToChangeFullArticle);
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.NameEnc_label);
            this.tabPage2.Controls.Add(this.RTBFullArticle);
            this.tabPage2.Controls.Add(this.PartList_But);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1850, 582);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Тест таблиц";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EditFullArticle_But
            // 
            this.EditFullArticle_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditFullArticle_But.Location = new System.Drawing.Point(1550, 8);
            this.EditFullArticle_But.Name = "EditFullArticle_But";
            this.EditFullArticle_But.Size = new System.Drawing.Size(275, 119);
            this.EditFullArticle_But.TabIndex = 12;
            this.EditFullArticle_But.Text = "Сохранить изменения";
            this.EditFullArticle_But.UseVisualStyleBackColor = true;
            this.EditFullArticle_But.Click += new System.EventHandler(this.EditFullArticle_But_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(287, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(526, 34);
            this.textBox1.TabIndex = 11;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.Location = new System.Drawing.Point(287, 48);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(526, 117);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            // 
            // WantToChangeFullArticle
            // 
            this.WantToChangeFullArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WantToChangeFullArticle.Location = new System.Drawing.Point(1180, 8);
            this.WantToChangeFullArticle.Name = "WantToChangeFullArticle";
            this.WantToChangeFullArticle.Size = new System.Drawing.Size(275, 119);
            this.WantToChangeFullArticle.TabIndex = 9;
            this.WantToChangeFullArticle.Text = "Хочу изменить статью";
            this.WantToChangeFullArticle.UseVisualStyleBackColor = true;
            this.WantToChangeFullArticle.Click += new System.EventHandler(this.WantToChangeFullArticle_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(819, 275);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(355, 301);
            this.dataGridView3.TabIndex = 8;
            this.dataGridView3.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellMouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(819, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 261);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 275);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(275, 301);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // NameEnc_label
            // 
            this.NameEnc_label.AutoSize = true;
            this.NameEnc_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameEnc_label.Location = new System.Drawing.Point(1210, 285);
            this.NameEnc_label.Name = "NameEnc_label";
            this.NameEnc_label.Size = new System.Drawing.Size(0, 29);
            this.NameEnc_label.TabIndex = 4;
            // 
            // RTBFullArticle
            // 
            this.RTBFullArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RTBFullArticle.Location = new System.Drawing.Point(287, 171);
            this.RTBFullArticle.Name = "RTBFullArticle";
            this.RTBFullArticle.ReadOnly = true;
            this.RTBFullArticle.Size = new System.Drawing.Size(526, 405);
            this.RTBFullArticle.TabIndex = 3;
            this.RTBFullArticle.Text = "";
            // 
            // PartList_But
            // 
            this.PartList_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PartList_But.Location = new System.Drawing.Point(6, 6);
            this.PartList_But.Name = "PartList_But";
            this.PartList_But.Size = new System.Drawing.Size(275, 119);
            this.PartList_But.TabIndex = 1;
            this.PartList_But.Text = "Открыть энциклопедию";
            this.PartList_But.UseVisualStyleBackColor = true;
            this.PartList_But.Click += new System.EventHandler(this.PartList_But_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(275, 138);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(1215, 520);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(526, 34);
            this.textBox2.TabIndex = 13;
            // 
            // SendPicture_But
            // 
            this.SendPicture_But.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendPicture_But.Location = new System.Drawing.Point(1346, 475);
            this.SendPicture_But.Name = "SendPicture_But";
            this.SendPicture_But.Size = new System.Drawing.Size(281, 39);
            this.SendPicture_But.TabIndex = 14;
            this.SendPicture_But.Text = "Send";
            this.SendPicture_But.UseVisualStyleBackColor = true;
            this.SendPicture_But.Click += new System.EventHandler(this.SendPicture_But_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1882, 628);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button GetInfo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button TestForDeserialize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button PartList_But;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox RTBFullArticle;
        private System.Windows.Forms.Label NameEnc_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button WantToChangeFullArticle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button EditFullArticle_But;
        private System.Windows.Forms.Button SendPicture_But;
        private System.Windows.Forms.TextBox textBox2;
    }
}

