namespace L1.Server
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
            this.Start_But = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start_But
            // 
            this.Start_But.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Start_But.Location = new System.Drawing.Point(109, 145);
            this.Start_But.Name = "Start_But";
            this.Start_But.Size = new System.Drawing.Size(335, 197);
            this.Start_But.TabIndex = 0;
            this.Start_But.Text = "Start";
            this.Start_But.UseVisualStyleBackColor = false;
            this.Start_But.Click += new System.EventHandler(this.Start_But_Click);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Stop.Location = new System.Drawing.Point(632, 145);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(335, 197);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start_But);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button Start_But;
        private System.Windows.Forms.Button Stop;
    }
}

