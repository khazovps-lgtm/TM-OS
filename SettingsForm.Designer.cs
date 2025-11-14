namespace MyApp;

partial class SettingsForm
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
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblWallpaper = new System.Windows.Forms.Label();
        this.btnGradientBlue = new System.Windows.Forms.Button();
        this.btnGradientPurple = new System.Windows.Forms.Button();
        this.btnGradientGreen = new System.Windows.Forms.Button();
        this.btnGradientRed = new System.Windows.Forms.Button();
        this.btnSolidBlack = new System.Windows.Forms.Button();
        this.btnSolidGray = new System.Windows.Forms.Button();
        this.btnCustomWallpaper = new System.Windows.Forms.Button();
        this.lblInfo = new System.Windows.Forms.Label();
        this.lblCursor = new System.Windows.Forms.Label();
        this.btnTonyCursor = new System.Windows.Forms.Button();
        this.btnRichardCursor = new System.Windows.Forms.Button();
        this.btnDefaultCursor = new System.Windows.Forms.Button();
        this.btnCustomCursor1 = new System.Windows.Forms.Button();
        this.btnCustomCursor2 = new System.Windows.Forms.Button();
        this.btnLoadCursor1 = new System.Windows.Forms.Button();
        this.btnLoadCursor2 = new System.Windows.Forms.Button();
        this.lblInstructions = new System.Windows.Forms.Label();
        this.scrollPanel = new System.Windows.Forms.Panel();
        this.lblUpdates = new System.Windows.Forms.Label();
        this.btnCheckUpdates = new System.Windows.Forms.Button();
        this.btnSelectVersion = new System.Windows.Forms.Button();
        this.lblCurrentVersion = new System.Windows.Forms.Label();
        this.lblUpdateStatus = new System.Windows.Forms.Label();
        this.SuspendLayout();
        
        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.Location = new System.Drawing.Point(80, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(200, 26);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Настройки TM OS";
        
        // lblWallpaper
        this.lblWallpaper.AutoSize = true;
        this.lblWallpaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.lblWallpaper.Location = new System.Drawing.Point(20, 70);
        this.lblWallpaper.Name = "lblWallpaper";
        this.lblWallpaper.Size = new System.Drawing.Size(150, 20);
        this.lblWallpaper.TabIndex = 1;
        this.lblWallpaper.Text = "Фоновые обои:";
        
        // btnGradientBlue
        this.btnGradientBlue.BackColor = Color.FromArgb(45, 45, 65);
        this.btnGradientBlue.ForeColor = Color.White;
        this.btnGradientBlue.Location = new System.Drawing.Point(20, 110);
        this.btnGradientBlue.Name = "btnGradientBlue";
        this.btnGradientBlue.Size = new System.Drawing.Size(120, 40);
        this.btnGradientBlue.TabIndex = 2;
        this.btnGradientBlue.Text = "Синий градиент";
        this.btnGradientBlue.UseVisualStyleBackColor = false;
        this.btnGradientBlue.Click += new System.EventHandler(this.btnGradientBlue_Click);
        
        // btnGradientPurple
        this.btnGradientPurple.BackColor = Color.FromArgb(65, 45, 85);
        this.btnGradientPurple.ForeColor = Color.White;
        this.btnGradientPurple.Location = new System.Drawing.Point(160, 110);
        this.btnGradientPurple.Name = "btnGradientPurple";
        this.btnGradientPurple.Size = new System.Drawing.Size(120, 40);
        this.btnGradientPurple.TabIndex = 3;
        this.btnGradientPurple.Text = "Фиолетовый";
        this.btnGradientPurple.UseVisualStyleBackColor = false;
        this.btnGradientPurple.Click += new System.EventHandler(this.btnGradientPurple_Click);
        
        // btnGradientGreen
        this.btnGradientGreen.BackColor = Color.FromArgb(45, 65, 45);
        this.btnGradientGreen.ForeColor = Color.White;
        this.btnGradientGreen.Location = new System.Drawing.Point(300, 110);
        this.btnGradientGreen.Name = "btnGradientGreen";
        this.btnGradientGreen.Size = new System.Drawing.Size(120, 40);
        this.btnGradientGreen.TabIndex = 4;
        this.btnGradientGreen.Text = "Зеленый";
        this.btnGradientGreen.UseVisualStyleBackColor = false;
        this.btnGradientGreen.Click += new System.EventHandler(this.btnGradientGreen_Click);
        
        // btnGradientRed
        this.btnGradientRed.BackColor = Color.FromArgb(65, 45, 45);
        this.btnGradientRed.ForeColor = Color.White;
        this.btnGradientRed.Location = new System.Drawing.Point(20, 170);
        this.btnGradientRed.Name = "btnGradientRed";
        this.btnGradientRed.Size = new System.Drawing.Size(120, 40);
        this.btnGradientRed.TabIndex = 5;
        this.btnGradientRed.Text = "Красный";
        this.btnGradientRed.UseVisualStyleBackColor = false;
        this.btnGradientRed.Click += new System.EventHandler(this.btnGradientRed_Click);
        
        // btnSolidBlack
        this.btnSolidBlack.BackColor = Color.Black;
        this.btnSolidBlack.ForeColor = Color.White;
        this.btnSolidBlack.Location = new System.Drawing.Point(160, 170);
        this.btnSolidBlack.Name = "btnSolidBlack";
        this.btnSolidBlack.Size = new System.Drawing.Size(120, 40);
        this.btnSolidBlack.TabIndex = 6;
        this.btnSolidBlack.Text = "Черный";
        this.btnSolidBlack.UseVisualStyleBackColor = false;
        this.btnSolidBlack.Click += new System.EventHandler(this.btnSolidBlack_Click);
        
        // btnSolidGray
        this.btnSolidGray.BackColor = Color.FromArgb(50, 50, 50);
        this.btnSolidGray.ForeColor = Color.White;
        this.btnSolidGray.Location = new System.Drawing.Point(300, 170);
        this.btnSolidGray.Name = "btnSolidGray";
        this.btnSolidGray.Size = new System.Drawing.Size(120, 40);
        this.btnSolidGray.TabIndex = 7;
        this.btnSolidGray.Text = "Серый";
        this.btnSolidGray.UseVisualStyleBackColor = false;
        this.btnSolidGray.Click += new System.EventHandler(this.btnSolidGray_Click);
        
        // btnCustomWallpaper
        this.btnCustomWallpaper.BackColor = Color.FromArgb(70, 70, 70);
        this.btnCustomWallpaper.ForeColor = Color.White;
        this.btnCustomWallpaper.Location = new System.Drawing.Point(20, 230);
        this.btnCustomWallpaper.Name = "btnCustomWallpaper";
        this.btnCustomWallpaper.Size = new System.Drawing.Size(400, 40);
        this.btnCustomWallpaper.TabIndex = 8;
        this.btnCustomWallpaper.Text = "📂 Выбрать свои обои из файла";
        this.btnCustomWallpaper.UseVisualStyleBackColor = false;
        this.btnCustomWallpaper.Click += new System.EventHandler(this.btnCustomWallpaper_Click);
        
        // lblInfo
        this.lblInfo.AutoSize = true;
        this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
        this.lblInfo.ForeColor = Color.Gray;
        this.lblInfo.Location = new System.Drawing.Point(20, 290);
        this.lblInfo.Name = "lblInfo";
        this.lblInfo.Size = new System.Drawing.Size(350, 15);
        this.lblInfo.TabIndex = 9;
        this.lblInfo.Text = "💾 Настройки автоматически сохраняются после изменения";
        
        // scrollPanel
        this.scrollPanel.AutoScroll = true;
        this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.scrollPanel.Location = new System.Drawing.Point(0, 0);
        this.scrollPanel.Name = "scrollPanel";
        this.scrollPanel.Size = new System.Drawing.Size(450, 500);
        this.scrollPanel.TabIndex = 0;
        
        // lblCursor
        this.lblCursor.AutoSize = true;
        this.lblCursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.lblCursor.Location = new System.Drawing.Point(20, 330);
        this.lblCursor.Name = "lblCursor";
        this.lblCursor.Size = new System.Drawing.Size(150, 20);
        this.lblCursor.TabIndex = 10;
        this.lblCursor.Text = "🖱️ Курсор";
        
        // btnTonyCursor
        this.btnTonyCursor.BackColor = Color.FromArgb(70, 70, 70);
        this.btnTonyCursor.ForeColor = Color.White;
        this.btnTonyCursor.Location = new System.Drawing.Point(20, 360);
        this.btnTonyCursor.Name = "btnTonyCursor";
        this.btnTonyCursor.Size = new System.Drawing.Size(400, 40);
        this.btnTonyCursor.TabIndex = 11;
        this.btnTonyCursor.Text = "🐯 Маска Тони (тигр)";
        this.btnTonyCursor.UseVisualStyleBackColor = false;
        this.btnTonyCursor.Click += new System.EventHandler(this.btnTonyCursor_Click);
        
        // btnRichardCursor
        this.btnRichardCursor.BackColor = Color.FromArgb(70, 70, 70);
        this.btnRichardCursor.ForeColor = Color.White;
        this.btnRichardCursor.Location = new System.Drawing.Point(20, 410);
        this.btnRichardCursor.Name = "btnRichardCursor";
        this.btnRichardCursor.Size = new System.Drawing.Size(400, 40);
        this.btnRichardCursor.TabIndex = 12;
        this.btnRichardCursor.Text = "🐓 Маска Ричарда (петух)";
        this.btnRichardCursor.UseVisualStyleBackColor = false;
        this.btnRichardCursor.Click += new System.EventHandler(this.btnRichardCursor_Click);
        
        // btnDefaultCursor
        this.btnDefaultCursor.BackColor = Color.FromArgb(70, 70, 70);
        this.btnDefaultCursor.ForeColor = Color.White;
        this.btnDefaultCursor.Location = new System.Drawing.Point(20, 460);
        this.btnDefaultCursor.Name = "btnDefaultCursor";
        this.btnDefaultCursor.Size = new System.Drawing.Size(400, 40);
        this.btnDefaultCursor.TabIndex = 13;
        this.btnDefaultCursor.Text = "🖱️ Обычный курсор (по умолчанию)";
        this.btnDefaultCursor.UseVisualStyleBackColor = false;
        this.btnDefaultCursor.Click += new System.EventHandler(this.btnDefaultCursor_Click);
        
        // btnCustomCursor1
        this.btnCustomCursor1.BackColor = Color.FromArgb(50, 70, 50);
        this.btnCustomCursor1.ForeColor = Color.White;
        this.btnCustomCursor1.Location = new System.Drawing.Point(20, 520);
        this.btnCustomCursor1.Name = "btnCustomCursor1";
        this.btnCustomCursor1.Size = new System.Drawing.Size(300, 40);
        this.btnCustomCursor1.TabIndex = 14;
        this.btnCustomCursor1.Text = "📁 Курсор 1 (не загружен)";
        this.btnCustomCursor1.UseVisualStyleBackColor = false;
        this.btnCustomCursor1.Click += new System.EventHandler(this.btnCustomCursor1_Click);
        
        // btnLoadCursor1
        this.btnLoadCursor1.BackColor = Color.FromArgb(50, 50, 70);
        this.btnLoadCursor1.ForeColor = Color.White;
        this.btnLoadCursor1.Location = new System.Drawing.Point(330, 520);
        this.btnLoadCursor1.Name = "btnLoadCursor1";
        this.btnLoadCursor1.Size = new System.Drawing.Size(90, 40);
        this.btnLoadCursor1.TabIndex = 15;
        this.btnLoadCursor1.Text = "Загрузить";
        this.btnLoadCursor1.UseVisualStyleBackColor = false;
        this.btnLoadCursor1.Click += new System.EventHandler(this.btnLoadCursor1_Click);
        
        // btnCustomCursor2
        this.btnCustomCursor2.BackColor = Color.FromArgb(50, 70, 50);
        this.btnCustomCursor2.ForeColor = Color.White;
        this.btnCustomCursor2.Location = new System.Drawing.Point(20, 570);
        this.btnCustomCursor2.Name = "btnCustomCursor2";
        this.btnCustomCursor2.Size = new System.Drawing.Size(300, 40);
        this.btnCustomCursor2.TabIndex = 16;
        this.btnCustomCursor2.Text = "📁 Курсор 2 (не загружен)";
        this.btnCustomCursor2.UseVisualStyleBackColor = false;
        this.btnCustomCursor2.Click += new System.EventHandler(this.btnCustomCursor2_Click);
        
        // btnLoadCursor2
        this.btnLoadCursor2.BackColor = Color.FromArgb(50, 50, 70);
        this.btnLoadCursor2.ForeColor = Color.White;
        this.btnLoadCursor2.Location = new System.Drawing.Point(330, 570);
        this.btnLoadCursor2.Name = "btnLoadCursor2";
        this.btnLoadCursor2.Size = new System.Drawing.Size(90, 40);
        this.btnLoadCursor2.TabIndex = 17;
        this.btnLoadCursor2.Text = "Загрузить";
        this.btnLoadCursor2.UseVisualStyleBackColor = false;
        this.btnLoadCursor2.Click += new System.EventHandler(this.btnLoadCursor2_Click);
        
        // lblInstructions
        this.lblInstructions.AutoSize = false;
        this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular);
        this.lblInstructions.ForeColor = Color.Black;
        this.lblInstructions.BackColor = Color.FromArgb(240, 240, 240);
        this.lblInstructions.Location = new System.Drawing.Point(20, 630);
        this.lblInstructions.Name = "lblInstructions";
        this.lblInstructions.Size = new System.Drawing.Size(400, 120);
        this.lblInstructions.TabIndex = 18;
        this.lblInstructions.Text = @"📋 КАК ЗАГРУЗИТЬ СВОЙ КУРСОР:

1. Найдите .cur файл или изображение (.png, .jpg, .bmp) курсора
2. Нажмите кнопку 'Загрузить' рядом с 'Курсор 1' или 'Курсор 2'
3. Выберите файл на компьютере
4. Теперь можете использовать свой полноцветный курсор!

💡 Совет: PNG изображения сохраняют все цвета!
🎨 Рекомендуемый размер: 32x32 пикселя для лучшего качества
🔍 Ищите курсоры на cursor.cc или создавайте в любом редакторе";
        
        // lblUpdates
        this.lblUpdates.AutoSize = false;
        this.lblUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
        this.lblUpdates.ForeColor = Color.White;
        this.lblUpdates.Location = new System.Drawing.Point(20, 770);
        this.lblUpdates.Name = "lblUpdates";
        this.lblUpdates.Size = new System.Drawing.Size(400, 30);
        this.lblUpdates.TabIndex = 19;
        this.lblUpdates.Text = "ОБНОВЛЕНИЯ";
        this.lblUpdates.TextAlign = ContentAlignment.MiddleLeft;
        
        // btnCheckUpdates
        this.btnCheckUpdates.BackColor = Color.FromArgb(0, 120, 215);
        this.btnCheckUpdates.FlatStyle = FlatStyle.Flat;
        this.btnCheckUpdates.ForeColor = Color.White;
        this.btnCheckUpdates.Location = new System.Drawing.Point(20, 810);
        this.btnCheckUpdates.Name = "btnCheckUpdates";
        this.btnCheckUpdates.Size = new System.Drawing.Size(120, 40);
        this.btnCheckUpdates.TabIndex = 20;
        this.btnCheckUpdates.Text = "Проверить";
        this.btnCheckUpdates.UseVisualStyleBackColor = false;
        this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
        
        // btnSelectVersion
        this.btnSelectVersion.BackColor = Color.FromArgb(60, 60, 70);
        this.btnSelectVersion.FlatStyle = FlatStyle.Flat;
        this.btnSelectVersion.ForeColor = Color.White;
        this.btnSelectVersion.Location = new System.Drawing.Point(150, 810);
        this.btnSelectVersion.Name = "btnSelectVersion";
        this.btnSelectVersion.Size = new System.Drawing.Size(120, 40);
        this.btnSelectVersion.TabIndex = 21;
        this.btnSelectVersion.Text = "Информация о версии";
        this.btnSelectVersion.UseVisualStyleBackColor = false;
        this.btnSelectVersion.Click += new System.EventHandler(this.btnSelectVersion_Click);
        
        // lblCurrentVersion
        this.lblCurrentVersion.AutoSize = false;
        this.lblCurrentVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
        this.lblCurrentVersion.ForeColor = Color.LightGray;
        this.lblCurrentVersion.Location = new System.Drawing.Point(20, 860);
        this.lblCurrentVersion.Name = "lblCurrentVersion";
        this.lblCurrentVersion.Size = new System.Drawing.Size(400, 20);
        this.lblCurrentVersion.TabIndex = 22;
        this.lblCurrentVersion.Text = "Текущая версия: TM OS v1.1";
        
        // lblUpdateStatus
        this.lblUpdateStatus.AutoSize = false;
        this.lblUpdateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
        this.lblUpdateStatus.ForeColor = Color.Yellow;
        this.lblUpdateStatus.Location = new System.Drawing.Point(20, 880);
        this.lblUpdateStatus.Name = "lblUpdateStatus";
        this.lblUpdateStatus.Size = new System.Drawing.Size(400, 20);
        this.lblUpdateStatus.TabIndex = 23;
        this.lblUpdateStatus.Text = "Нажмите 'Проверить' для поиска обновлений";
        
        // Увеличиваем размер скролла для новых элементов
        this.scrollPanel.AutoScrollMinSize = new Size(0, 920);
        
        // SettingsForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(450, 500);
        this.scrollPanel.Controls.Add(this.lblInstructions);
        this.scrollPanel.Controls.Add(this.lblUpdateStatus);
        this.scrollPanel.Controls.Add(this.lblCurrentVersion);
        this.scrollPanel.Controls.Add(this.btnSelectVersion);
        this.scrollPanel.Controls.Add(this.btnCheckUpdates);
        this.scrollPanel.Controls.Add(this.lblUpdates);
        this.scrollPanel.Controls.Add(this.btnLoadCursor2);
        this.scrollPanel.Controls.Add(this.btnCustomCursor2);
        this.scrollPanel.Controls.Add(this.btnLoadCursor1);
        this.scrollPanel.Controls.Add(this.btnCustomCursor1);
        this.scrollPanel.Controls.Add(this.btnDefaultCursor);
        this.scrollPanel.Controls.Add(this.btnRichardCursor);
        this.scrollPanel.Controls.Add(this.btnTonyCursor);
        this.scrollPanel.Controls.Add(this.lblCursor);
        this.scrollPanel.Controls.Add(this.lblInfo);
        this.scrollPanel.Controls.Add(this.btnCustomWallpaper);
        this.scrollPanel.Controls.Add(this.btnSolidGray);
        this.scrollPanel.Controls.Add(this.btnSolidBlack);
        this.scrollPanel.Controls.Add(this.btnGradientRed);
        this.scrollPanel.Controls.Add(this.btnGradientGreen);
        this.scrollPanel.Controls.Add(this.btnGradientPurple);
        this.scrollPanel.Controls.Add(this.btnGradientBlue);
        this.scrollPanel.Controls.Add(this.lblWallpaper);
        this.scrollPanel.Controls.Add(this.lblTitle);
        this.Controls.Add(this.scrollPanel);
        this.Name = "SettingsForm";
        this.Text = "Настройки TM OS";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblWallpaper;
    private System.Windows.Forms.Button btnGradientBlue;
    private System.Windows.Forms.Button btnGradientPurple;
    private System.Windows.Forms.Button btnGradientGreen;
    private System.Windows.Forms.Button btnGradientRed;
    private System.Windows.Forms.Button btnSolidBlack;
    private System.Windows.Forms.Button btnSolidGray;
    private System.Windows.Forms.Button btnCustomWallpaper;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.Label lblCursor;
    private System.Windows.Forms.Button btnTonyCursor;
    private System.Windows.Forms.Button btnRichardCursor;
    private System.Windows.Forms.Button btnDefaultCursor;
    private System.Windows.Forms.Button btnCustomCursor1;
    private System.Windows.Forms.Button btnCustomCursor2;
    private System.Windows.Forms.Button btnLoadCursor1;
    private System.Windows.Forms.Button btnLoadCursor2;
    private System.Windows.Forms.Label lblInstructions;
    private System.Windows.Forms.Panel scrollPanel;
    private System.Windows.Forms.Label lblUpdates;
    private System.Windows.Forms.Button btnCheckUpdates;
    private System.Windows.Forms.Button btnSelectVersion;
    private System.Windows.Forms.Label lblCurrentVersion;
    private System.Windows.Forms.Label lblUpdateStatus;
}