using System.Drawing;
using System.Windows.Forms;

namespace MyApp
{
    partial class AmbientForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelControls;
        private ListBox listBoxTracks;
        private Button btnAddTrack;
        private Button btnRemoveTrack;
        private Button btnPlayPause;
        private Button btnNext;
        private Button btnPrevious;
        private Label lblTitle;
        private Label lblNowPlaying;
        private Label lblStatus;
        private Label lblTrackList;
        private CheckBox checkBoxAutoNext;
        private Panel panelPlayer;

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
            this.panelControls = new Panel();
            this.listBoxTracks = new ListBox();
            this.btnAddTrack = new Button();
            this.btnRemoveTrack = new Button();
            this.btnPlayPause = new Button();
            this.btnNext = new Button();
            this.btnPrevious = new Button();
            this.lblTitle = new Label();
            this.lblNowPlaying = new Label();
            this.lblStatus = new Label();
            this.lblTrackList = new Label();
            this.checkBoxAutoNext = new CheckBox();
            this.panelPlayer = new Panel();
            
            this.SuspendLayout();
            
            // Form
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(20, 20, 30);
            this.ClientSize = new Size(700, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "🎵 Music Player - Только ваша музыка";
            
            // lblTitle
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(200, 200, 255);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(660, 30);
            this.lblTitle.Text = "🎵 Music Player - Только ваша музыка";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            // panelPlayer
            this.panelPlayer.BackColor = Color.FromArgb(25, 25, 35);
            this.panelPlayer.BorderStyle = BorderStyle.FixedSingle;
            this.panelPlayer.Location = new Point(20, 60);
            this.panelPlayer.Size = new Size(660, 100);
            
            // lblNowPlaying
            this.lblNowPlaying.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.lblNowPlaying.ForeColor = Color.FromArgb(150, 255, 150);
            this.lblNowPlaying.Location = new Point(10, 10);
            this.lblNowPlaying.Size = new Size(640, 25);
            this.lblNowPlaying.Text = "Добавьте свою музыку для начала работы";
            this.lblNowPlaying.TextAlign = ContentAlignment.MiddleCenter;
            
            // btnPrevious
            this.btnPrevious.BackColor = Color.FromArgb(60, 60, 80);
            this.btnPrevious.FlatStyle = FlatStyle.Flat;
            this.btnPrevious.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.btnPrevious.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnPrevious.Location = new Point(180, 45);
            this.btnPrevious.Size = new Size(80, 40);
            this.btnPrevious.Text = "⏮️ Пред";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += btnPrevious_Click;
            
            // btnPlayPause
            this.btnPlayPause.BackColor = Color.FromArgb(80, 120, 80);
            this.btnPlayPause.FlatStyle = FlatStyle.Flat;
            this.btnPlayPause.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.btnPlayPause.ForeColor = Color.White;
            this.btnPlayPause.Location = new Point(270, 45);
            this.btnPlayPause.Size = new Size(100, 40);
            this.btnPlayPause.Text = "▶️ Играть";
            this.btnPlayPause.UseVisualStyleBackColor = false;
            this.btnPlayPause.Click += btnPlayPause_Click;
            
            // btnNext
            this.btnNext.BackColor = Color.FromArgb(60, 60, 80);
            this.btnNext.FlatStyle = FlatStyle.Flat;
            this.btnNext.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.btnNext.ForeColor = Color.FromArgb(200, 200, 200);
            this.btnNext.Location = new Point(380, 45);
            this.btnNext.Size = new Size(80, 40);
            this.btnNext.Text = "⏭️ След";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += btnNext_Click;
            
            // checkBoxAutoNext
            this.checkBoxAutoNext.AutoSize = true;
            this.checkBoxAutoNext.Checked = true;
            this.checkBoxAutoNext.ForeColor = Color.FromArgb(180, 180, 180);
            this.checkBoxAutoNext.Location = new Point(480, 55);
            this.checkBoxAutoNext.Size = new Size(120, 19);
            this.checkBoxAutoNext.Text = "Автосмена (2мин)";
            this.checkBoxAutoNext.UseVisualStyleBackColor = true;
            
            // Добавляем инструкции
            var lblInstructions = new Label();
            lblInstructions.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblInstructions.ForeColor = Color.FromArgb(255, 200, 100);
            lblInstructions.Location = new Point(20, 180);
            lblInstructions.Size = new Size(660, 60);
            lblInstructions.Text = "📝 Инструкция:\n" +
                                  "1. Нажмите 'Добавить свою музыку' чтобы выбрать WAV файлы с компьютера\n" +
                                  "2. ⚠️ Поддерживается ТОЛЬКО формат WAV (MP3/WMA не работают)\n" +
                                  "3. Двойной клик по треку для воспроизведения";
            
            // lblTrackList
            this.lblTrackList.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.lblTrackList.ForeColor = Color.FromArgb(200, 200, 255);
            this.lblTrackList.Location = new Point(20, 250);
            this.lblTrackList.Size = new Size(200, 25);
            this.lblTrackList.Text = "📜 Ваши треки:";
            
            // listBoxTracks
            this.listBoxTracks.BackColor = Color.FromArgb(30, 30, 45);
            this.listBoxTracks.BorderStyle = BorderStyle.FixedSingle;
            this.listBoxTracks.Font = new Font("Microsoft Sans Serif", 11F);
            this.listBoxTracks.ForeColor = Color.FromArgb(200, 200, 200);
            this.listBoxTracks.ItemHeight = 22;
            this.listBoxTracks.Location = new Point(20, 280);
            this.listBoxTracks.Size = new Size(450, 220);
            this.listBoxTracks.DoubleClick += listBoxTracks_DoubleClick;
            
            // panelControls
            this.panelControls.BackColor = Color.FromArgb(25, 25, 35);
            this.panelControls.BorderStyle = BorderStyle.FixedSingle;
            this.panelControls.Location = new Point(490, 280);
            this.panelControls.Size = new Size(190, 220);
            
            // btnAddTrack
            this.btnAddTrack.BackColor = Color.FromArgb(80, 120, 200);
            this.btnAddTrack.FlatStyle = FlatStyle.Flat;
            this.btnAddTrack.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.btnAddTrack.ForeColor = Color.White;
            this.btnAddTrack.Location = new Point(15, 20);
            this.btnAddTrack.Size = new Size(160, 50);
            this.btnAddTrack.Text = "➕ Добавить\nсвою музыку";
            this.btnAddTrack.UseVisualStyleBackColor = false;
            this.btnAddTrack.Click += btnAddTrack_Click;
            
            // btnRemoveTrack
            this.btnRemoveTrack.BackColor = Color.FromArgb(150, 80, 80);
            this.btnRemoveTrack.FlatStyle = FlatStyle.Flat;
            this.btnRemoveTrack.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.btnRemoveTrack.ForeColor = Color.White;
            this.btnRemoveTrack.Location = new Point(15, 80);
            this.btnRemoveTrack.Size = new Size(160, 50);
            this.btnRemoveTrack.Text = "❌ Удалить\nвыбранный";
            this.btnRemoveTrack.UseVisualStyleBackColor = false;
            this.btnRemoveTrack.Click += btnRemoveTrack_Click;
            
            // lblStatus
            this.lblStatus.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblStatus.ForeColor = Color.FromArgb(150, 150, 150);
            this.lblStatus.Location = new Point(20, 520);
            this.lblStatus.Size = new Size(660, 60);
            this.lblStatus.Text = "💡 Важно: Используйте только WAV файлы! MP3 и другие форматы не поддерживаются.\n" +
                                 "Для конвертации MP3→WAV используйте онлайн конвертеры или программы типа Audacity.";
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            
            // Добавляем контролы на панели
            this.panelPlayer.Controls.Add(this.lblNowPlaying);
            this.panelPlayer.Controls.Add(this.btnPrevious);
            this.panelPlayer.Controls.Add(this.btnPlayPause);
            this.panelPlayer.Controls.Add(this.btnNext);
            this.panelPlayer.Controls.Add(this.checkBoxAutoNext);
            
            this.panelControls.Controls.Add(this.btnAddTrack);
            this.panelControls.Controls.Add(this.btnRemoveTrack);
            
            // Добавляем контролы на форму
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(lblInstructions);
            this.Controls.Add(this.lblTrackList);
            this.Controls.Add(this.listBoxTracks);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.lblStatus);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}