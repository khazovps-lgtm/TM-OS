namespace MyApp
{
    partial class PaintForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBoxCanvas;
        private Panel toolPanel;
        private Button btnBrush;
        private Button btnEraser;
        private Button btnColorBlack;
        private Button btnColorRed;
        private Button btnColorBlue;
        private Button btnColorGreen;
        private Button btnColorYellow;
        private Button btnColorPurple;
        private Button btnCustomColor;
        private Label lblCurrentColor;
        private TrackBar trackBarBrushSize;
        private Label lblBrushSize;
        private Button btnClear;
        private Button btnSave;
        private Button btnLoad;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxCanvas = new PictureBox();
            this.toolPanel = new Panel();
            this.lblTitle = new Label();
            this.btnBrush = new Button();
            this.btnEraser = new Button();
            this.btnColorBlack = new Button();
            this.btnColorRed = new Button();
            this.btnColorBlue = new Button();
            this.btnColorGreen = new Button();
            this.btnColorYellow = new Button();
            this.btnColorPurple = new Button();
            this.btnCustomColor = new Button();
            this.lblCurrentColor = new Label();
            this.trackBarBrushSize = new TrackBar();
            this.lblBrushSize = new Label();
            this.btnClear = new Button();
            this.btnSave = new Button();
            this.btnLoad = new Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrushSize)).BeginInit();
            this.SuspendLayout();
            
            // PaintForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(20, 20, 30);
            this.ClientSize = new Size(1200, 700);
            this.Controls.Add(this.pictureBoxCanvas);
            this.Controls.Add(this.toolPanel);
            this.MinimumSize = new Size(1000, 600);
            this.Name = "PaintForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Paint - Редактор рисунков";
            this.WindowState = FormWindowState.Maximized;
            
            // pictureBoxCanvas
            this.pictureBoxCanvas.BackColor = Color.White;
            this.pictureBoxCanvas.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxCanvas.Location = new Point(220, 20);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new Size(960, 660);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.pictureBoxCanvas.MouseDown += new MouseEventHandler(this.pictureBoxCanvas_MouseDown);
            this.pictureBoxCanvas.MouseMove += new MouseEventHandler(this.pictureBoxCanvas_MouseMove);
            this.pictureBoxCanvas.MouseUp += new MouseEventHandler(this.pictureBoxCanvas_MouseUp);
            
            // toolPanel
            this.toolPanel.BackColor = Color.FromArgb(40, 40, 50);
            this.toolPanel.BorderStyle = BorderStyle.FixedSingle;
            this.toolPanel.Location = new Point(10, 20);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new Size(200, 660);
            this.toolPanel.TabIndex = 1;
            this.toolPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            
            // lblTitle
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(180, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎨 PAINT";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            // btnBrush
            this.btnBrush.BackColor = Color.LightBlue;
            this.btnBrush.FlatStyle = FlatStyle.Flat;
            this.btnBrush.ForeColor = Color.Black;
            this.btnBrush.Location = new Point(10, 60);
            this.btnBrush.Name = "btnBrush";
            this.btnBrush.Size = new Size(80, 35);
            this.btnBrush.TabIndex = 1;
            this.btnBrush.Text = "🖌️ Кисть";
            this.btnBrush.UseVisualStyleBackColor = false;
            this.btnBrush.Click += new EventHandler(this.btnBrush_Click);
            
            // btnEraser
            this.btnEraser.BackColor = Color.FromArgb(60, 60, 70);
            this.btnEraser.FlatStyle = FlatStyle.Flat;
            this.btnEraser.ForeColor = Color.White;
            this.btnEraser.Location = new Point(100, 60);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new Size(80, 35);
            this.btnEraser.TabIndex = 2;
            this.btnEraser.Text = "🧽 Ластик";
            this.btnEraser.UseVisualStyleBackColor = false;
            this.btnEraser.Click += new EventHandler(this.btnEraser_Click);
            
            // Color buttons
            this.btnColorBlack.BackColor = Color.Black;
            this.btnColorBlack.FlatStyle = FlatStyle.Flat;
            this.btnColorBlack.Location = new Point(10, 120);
            this.btnColorBlack.Name = "btnColorBlack";
            this.btnColorBlack.Size = new Size(25, 25);
            this.btnColorBlack.TabIndex = 3;
            this.btnColorBlack.UseVisualStyleBackColor = false;
            this.btnColorBlack.Click += new EventHandler(this.btnColorBlack_Click);
            
            this.btnColorRed.BackColor = Color.Red;
            this.btnColorRed.FlatStyle = FlatStyle.Flat;
            this.btnColorRed.Location = new Point(45, 120);
            this.btnColorRed.Name = "btnColorRed";
            this.btnColorRed.Size = new Size(25, 25);
            this.btnColorRed.TabIndex = 4;
            this.btnColorRed.UseVisualStyleBackColor = false;
            this.btnColorRed.Click += new EventHandler(this.btnColorRed_Click);
            
            this.btnColorBlue.BackColor = Color.Blue;
            this.btnColorBlue.FlatStyle = FlatStyle.Flat;
            this.btnColorBlue.Location = new Point(80, 120);
            this.btnColorBlue.Name = "btnColorBlue";
            this.btnColorBlue.Size = new Size(25, 25);
            this.btnColorBlue.TabIndex = 5;
            this.btnColorBlue.UseVisualStyleBackColor = false;
            this.btnColorBlue.Click += new EventHandler(this.btnColorBlue_Click);
            
            this.btnColorGreen.BackColor = Color.Green;
            this.btnColorGreen.FlatStyle = FlatStyle.Flat;
            this.btnColorGreen.Location = new Point(115, 120);
            this.btnColorGreen.Name = "btnColorGreen";
            this.btnColorGreen.Size = new Size(25, 25);
            this.btnColorGreen.TabIndex = 6;
            this.btnColorGreen.UseVisualStyleBackColor = false;
            this.btnColorGreen.Click += new EventHandler(this.btnColorGreen_Click);
            
            this.btnColorYellow.BackColor = Color.Yellow;
            this.btnColorYellow.FlatStyle = FlatStyle.Flat;
            this.btnColorYellow.Location = new Point(150, 120);
            this.btnColorYellow.Name = "btnColorYellow";
            this.btnColorYellow.Size = new Size(25, 25);
            this.btnColorYellow.TabIndex = 7;
            this.btnColorYellow.UseVisualStyleBackColor = false;
            this.btnColorYellow.Click += new EventHandler(this.btnColorYellow_Click);
            
            this.btnColorPurple.BackColor = Color.Purple;
            this.btnColorPurple.FlatStyle = FlatStyle.Flat;
            this.btnColorPurple.Location = new Point(10, 155);
            this.btnColorPurple.Name = "btnColorPurple";
            this.btnColorPurple.Size = new Size(25, 25);
            this.btnColorPurple.TabIndex = 8;
            this.btnColorPurple.UseVisualStyleBackColor = false;
            this.btnColorPurple.Click += new EventHandler(this.btnColorPurple_Click);
            
            // btnCustomColor
            this.btnCustomColor.BackColor = Color.FromArgb(60, 60, 70);
            this.btnCustomColor.FlatStyle = FlatStyle.Flat;
            this.btnCustomColor.ForeColor = Color.White;
            this.btnCustomColor.Location = new Point(45, 155);
            this.btnCustomColor.Name = "btnCustomColor";
            this.btnCustomColor.Size = new Size(130, 25);
            this.btnCustomColor.TabIndex = 9;
            this.btnCustomColor.Text = "🎨 Выбрать цвет";
            this.btnCustomColor.UseVisualStyleBackColor = false;
            this.btnCustomColor.Click += new EventHandler(this.btnCustomColor_Click);
            
            // lblCurrentColor
            this.lblCurrentColor.BackColor = Color.Black;
            this.lblCurrentColor.BorderStyle = BorderStyle.FixedSingle;
            this.lblCurrentColor.ForeColor = Color.White;
            this.lblCurrentColor.Location = new Point(10, 190);
            this.lblCurrentColor.Name = "lblCurrentColor";
            this.lblCurrentColor.Size = new Size(165, 30);
            this.lblCurrentColor.TabIndex = 10;
            this.lblCurrentColor.Text = "Цвет: Black";
            this.lblCurrentColor.TextAlign = ContentAlignment.MiddleCenter;
            
            // trackBarBrushSize
            this.trackBarBrushSize.Location = new Point(10, 250);
            this.trackBarBrushSize.Maximum = 20;
            this.trackBarBrushSize.Minimum = 1;
            this.trackBarBrushSize.Name = "trackBarBrushSize";
            this.trackBarBrushSize.Size = new Size(165, 56);
            this.trackBarBrushSize.TabIndex = 11;
            this.trackBarBrushSize.Value = 3;
            this.trackBarBrushSize.Scroll += new EventHandler(this.trackBarBrushSize_Scroll);
            
            // lblBrushSize
            this.lblBrushSize.ForeColor = Color.White;
            this.lblBrushSize.Location = new Point(10, 230);
            this.lblBrushSize.Name = "lblBrushSize";
            this.lblBrushSize.Size = new Size(165, 20);
            this.lblBrushSize.TabIndex = 12;
            this.lblBrushSize.Text = "Размер: 3px";
            this.lblBrushSize.TextAlign = ContentAlignment.MiddleCenter;
            
            // btnClear
            this.btnClear.BackColor = Color.FromArgb(220, 53, 69);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(10, 320);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(165, 35);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "🗑️ Очистить холст";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            
            // btnSave
            this.btnSave.BackColor = Color.FromArgb(40, 167, 69);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(10, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(165, 35);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "💾 Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            
            // btnLoad
            this.btnLoad.BackColor = Color.FromArgb(0, 120, 215);
            this.btnLoad.FlatStyle = FlatStyle.Flat;
            this.btnLoad.ForeColor = Color.White;
            this.btnLoad.Location = new Point(10, 420);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new Size(165, 35);
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Text = "📁 Загрузить";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
            
            // Add controls to toolPanel
            this.toolPanel.Controls.Add(this.lblTitle);
            this.toolPanel.Controls.Add(this.btnBrush);
            this.toolPanel.Controls.Add(this.btnEraser);
            this.toolPanel.Controls.Add(this.btnColorBlack);
            this.toolPanel.Controls.Add(this.btnColorRed);
            this.toolPanel.Controls.Add(this.btnColorBlue);
            this.toolPanel.Controls.Add(this.btnColorGreen);
            this.toolPanel.Controls.Add(this.btnColorYellow);
            this.toolPanel.Controls.Add(this.btnColorPurple);
            this.toolPanel.Controls.Add(this.btnCustomColor);
            this.toolPanel.Controls.Add(this.lblCurrentColor);
            this.toolPanel.Controls.Add(this.trackBarBrushSize);
            this.toolPanel.Controls.Add(this.lblBrushSize);
            this.toolPanel.Controls.Add(this.btnClear);
            this.toolPanel.Controls.Add(this.btnSave);
            this.toolPanel.Controls.Add(this.btnLoad);
            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrushSize)).EndInit();
            this.ResumeLayout(false);
        }
    }
}