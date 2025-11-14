namespace MyApp
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblStatus;
        private Label lblUpdateInfo;
        private ProgressBar progressBar;
        private Button btnUpdate;
        private Button btnCancel;
        private PictureBox pictureBox;

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
            this.lblStatus = new Label();
            this.lblUpdateInfo = new Label();
            this.progressBar = new ProgressBar();
            this.btnUpdate = new Button();
            this.btnCancel = new Button();
            this.pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(20, 20, 30);
            this.ClientSize = new Size(500, 350);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblUpdateInfo);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "TM OS - Обновления";
            this.TopMost = true;
            
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new Point(20, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new Size(64, 64);
            this.pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            
            // Создаем иконку обновления
            CreateUpdateIcon();
            
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.lblStatus.ForeColor = Color.White;
            this.lblStatus.Location = new Point(100, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(380, 25);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Инициализация проверки обновлений...";
            
            // 
            // lblUpdateInfo
            // 
            this.lblUpdateInfo.AutoSize = false;
            this.lblUpdateInfo.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblUpdateInfo.ForeColor = Color.LightGray;
            this.lblUpdateInfo.Location = new Point(20, 100);
            this.lblUpdateInfo.Name = "lblUpdateInfo";
            this.lblUpdateInfo.Size = new Size(460, 150);
            this.lblUpdateInfo.TabIndex = 2;
            this.lblUpdateInfo.Text = "";
            
            // 
            // progressBar
            // 
            this.progressBar.Location = new Point(20, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(460, 23);
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = Color.FromArgb(0, 120, 215);
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.Location = new Point(300, 300);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(90, 30);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.FromArgb(60, 60, 70);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(400, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
        }
        
        private void CreateUpdateIcon()
        {
            // Создаем простую иконку обновления
            Bitmap icon = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(icon))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                
                // Круглая стрелка обновления
                Pen bluePen = new Pen(Color.FromArgb(0, 120, 215), 4);
                
                // Рисуем круговую стрелку
                g.DrawArc(bluePen, 8, 8, 48, 48, -90, 270);
                
                // Стрелка
                Point[] arrowPoints = {
                    new Point(56, 8),
                    new Point(48, 0),
                    new Point(48, 16)
                };
                g.FillPolygon(new SolidBrush(Color.FromArgb(0, 120, 215)), arrowPoints);
                
                bluePen.Dispose();
            }
            
            this.pictureBox.Image = icon;
        }
    }
}