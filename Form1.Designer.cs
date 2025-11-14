namespace MyApp;

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
        this.btnExit = new System.Windows.Forms.Button();
        this.btnRestart = new System.Windows.Forms.Button();
        this.btnCalculator = new System.Windows.Forms.Button();
        this.lblTitle = new System.Windows.Forms.Label();
        this.btnSettings = new System.Windows.Forms.Button();
        this.btnPaint = new System.Windows.Forms.Button();
        this.btnAmbient = new System.Windows.Forms.Button();
        this.btnTMarket = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // btnExit
        // 
        this.btnExit.Location = new System.Drawing.Point(20, 20);
        this.btnExit.Name = "btnExit";
        this.btnExit.Size = new System.Drawing.Size(150, 100);
        this.btnExit.TabIndex = 0;
        this.btnExit.Text = "Выход";
        this.btnExit.UseVisualStyleBackColor = true;
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        // 
        // btnRestart
        // 
        this.btnRestart.Location = new System.Drawing.Point(20, 130);
        this.btnRestart.Name = "btnRestart";
        this.btnRestart.Size = new System.Drawing.Size(300, 100);
        this.btnRestart.TabIndex = 1;
        this.btnRestart.Text = "Перезапуск";
        this.btnRestart.UseVisualStyleBackColor = true;
        this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
        // 
        // btnCalculator
        // 
        this.btnCalculator.Location = new System.Drawing.Point(180, 20);
        this.btnCalculator.Name = "btnCalculator";
        this.btnCalculator.Size = new System.Drawing.Size(200, 100);
        this.btnCalculator.TabIndex = 2;
        this.btnCalculator.Text = "Калькулятор";
        this.btnCalculator.UseVisualStyleBackColor = true;
        this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
        // 
        // btnSettings
        // 
        this.btnSettings.Location = new System.Drawing.Point(20, 240);
        this.btnSettings.Name = "btnSettings";
        this.btnSettings.Size = new System.Drawing.Size(200, 100);
        this.btnSettings.TabIndex = 4;
        this.btnSettings.Text = "Настройки";
        this.btnSettings.UseVisualStyleBackColor = true;
        this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
        // 
        // btnPaint
        // 
        this.btnPaint.BackColor = System.Drawing.Color.FromArgb(100, 150, 255);
        this.btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnPaint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnPaint.ForeColor = System.Drawing.Color.White;
        this.btnPaint.Location = new System.Drawing.Point(230, 240);
        this.btnPaint.Name = "btnPaint";
        this.btnPaint.Size = new System.Drawing.Size(160, 60);
        this.btnPaint.TabIndex = 6;
        this.btnPaint.Text = "🎨 Paint";
        this.btnPaint.UseVisualStyleBackColor = false;
        this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
        // 
        // btnAmbient
        // 
        this.btnAmbient.BackColor = System.Drawing.Color.FromArgb(120, 80, 160);
        this.btnAmbient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAmbient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        this.btnAmbient.ForeColor = System.Drawing.Color.White;
        this.btnAmbient.Location = new System.Drawing.Point(400, 240);
        this.btnAmbient.Name = "btnAmbient";
        this.btnAmbient.Size = new System.Drawing.Size(120, 60);
        this.btnAmbient.TabIndex = 7;
        this.btnAmbient.Text = "🎵 Ambient\nManager";
        this.btnAmbient.UseVisualStyleBackColor = false;
        this.btnAmbient.Click += new System.EventHandler(this.btnAmbient_Click);
        // 
        // btnTMarket
        // 
        this.btnTMarket.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
        this.btnTMarket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnTMarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        this.btnTMarket.ForeColor = System.Drawing.Color.White;
        this.btnTMarket.Location = new System.Drawing.Point(540, 240);
        this.btnTMarket.Name = "btnTMarket";
        this.btnTMarket.Size = new System.Drawing.Size(120, 60);
        this.btnTMarket.TabIndex = 8;
        this.btnTMarket.Text = "🛒 TMarket\nМагазин";
        this.btnTMarket.UseVisualStyleBackColor = false;
        this.btnTMarket.Click += new System.EventHandler(this.btnTMarket_Click);
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
        this.lblTitle.Location = new System.Drawing.Point(400, 30);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(150, 55);
        this.lblTitle.TabIndex = 3;
        this.lblTitle.Text = "TM OS";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Form1
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.btnTMarket);
        this.Controls.Add(this.btnAmbient);
        this.Controls.Add(this.btnSettings);
        this.Controls.Add(this.btnPaint);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.btnCalculator);
        this.Controls.Add(this.btnExit);
        this.Controls.Add(this.btnRestart);
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Form1";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Button btnRestart;
    private System.Windows.Forms.Button btnCalculator;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Button btnSettings;
    private System.Windows.Forms.Button btnPaint;
    private System.Windows.Forms.Button btnAmbient;
    private System.Windows.Forms.Button btnTMarket;
}
