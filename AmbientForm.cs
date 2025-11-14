using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace MyApp
{
    public partial class AmbientForm : Form
    {
        private List<string> customTracks = new List<string>();
        private SoundPlayer? currentWavPlayer;
        private System.Diagnostics.Process? currentMp3Process; // Для MP3 через системный плеер
        private int currentTrackIndex = 0;
        private bool isPlaying = false;
        private System.Windows.Forms.Timer? playTimer;
        private bool isUsingMp3Player = false;
        
        public AmbientForm()
        {
            InitializeComponent();
            LoadCustomTracks();
            UpdateTrackList();
            
            // Таймер для автосмены треков
            playTimer = new System.Windows.Forms.Timer();
            playTimer.Interval = 120000; // 2 минуты
            playTimer.Tick += PlayTimer_Tick;
        }
        
        private void LoadCustomTracks()
        {
            try
            {
                string tracksDir = Path.Combine(Application.StartupPath, "CustomAmbient");
                if (Directory.Exists(tracksDir))
                {
                    string[] audioFiles = Directory.GetFiles(tracksDir, "*.*")
                        .Where(file => file.ToLower().EndsWith(".wav") || 
                                     file.ToLower().EndsWith(".mp3"))
                        .ToArray();
                    customTracks.AddRange(audioFiles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки треков: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void UpdateTrackList()
        {
            listBoxTracks.Items.Clear();
            
            // Добавляем только пользовательские треки
            foreach (string track in customTracks)
            {
                string fileName = Path.GetFileNameWithoutExtension(track);
                listBoxTracks.Items.Add(fileName);
            }
            
            // Если нет треков, показываем инструкцию
            if (customTracks.Count == 0)
            {
                listBoxTracks.Items.Add("❌ Нет треков");
                listBoxTracks.Items.Add("📝 Нажмите 'Добавить трек' чтобы");
                listBoxTracks.Items.Add("   добавить свою музыку");
                listBoxTracks.Enabled = false;
            }
            else
            {
                listBoxTracks.Enabled = true;
            }
        }
        
        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Аудио файлы|*.wav;*.mp3|WAV файлы|*.wav|MP3 файлы|*.mp3|Все файлы|*.*";
                openDialog.Title = "Выберите аудио файлы (WAV или MP3)";
                openDialog.Multiselect = true;
                
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string tracksDir = Path.Combine(Application.StartupPath, "CustomAmbient");
                    Directory.CreateDirectory(tracksDir);
                    
                    int addedCount = 0;
                    int errorCount = 0;
                    
                    foreach (string filePath in openDialog.FileNames)
                    {
                        try
                        {
                            string extension = Path.GetExtension(filePath).ToLower();
                            
                            // Проверяем формат файла
                            if (extension != ".wav" && extension != ".mp3")
                            {
                                lblStatus.Text = $"⚠️ Поддерживаются только WAV и MP3 файлы. Файл {Path.GetFileName(filePath)} пропущен.";
                                lblStatus.ForeColor = Color.Orange;
                                errorCount++;
                                continue;
                            }
                            
                            string fileName = Path.GetFileName(filePath);
                            string destPath = Path.Combine(tracksDir, fileName);
                            
                            if (!File.Exists(destPath))
                            {
                                File.Copy(filePath, destPath);
                                customTracks.Add(destPath);
                                addedCount++;
                            }
                            else
                            {
                                lblStatus.Text = $"Файл уже существует: {fileName}";
                                lblStatus.ForeColor = Color.Orange;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка копирования файла {Path.GetFileName(filePath)}: {ex.Message}", 
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorCount++;
                        }
                    }
                    
                    if (addedCount > 0)
                    {
                        lblStatus.Text = $"✅ Добавлено {addedCount} файлов";
                        lblStatus.ForeColor = Color.LightGreen;
                    }
                    else if (errorCount > 0)
                    {
                        lblStatus.Text = "❌ Не удалось добавить файлы. Используйте WAV или MP3 формат.";
                        lblStatus.ForeColor = Color.Red;
                    }
                    
                    UpdateTrackList();
                }
            }
        }
        
        private void btnRemoveTrack_Click(object sender, EventArgs e)
        {
            if (listBoxTracks.SelectedIndex >= 0 && customTracks.Count > 0)
            {
                int selectedIndex = listBoxTracks.SelectedIndex;
                
                if (selectedIndex < customTracks.Count)
                {
                    try
                    {
                        string trackPath = customTracks[selectedIndex];
                        if (File.Exists(trackPath))
                        {
                            File.Delete(trackPath);
                        }
                        customTracks.RemoveAt(selectedIndex);
                        
                        lblStatus.Text = "Трек удален";
                        lblStatus.ForeColor = Color.LightGreen;
                        UpdateTrackList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления файла: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                lblStatus.Text = "Выберите трек для удаления";
                lblStatus.ForeColor = Color.Orange;
            }
        }
        
        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                StopPlayback();
            }
            else
            {
                StartPlayback();
            }
        }
        
        private void StartPlayback()
        {
            if (listBoxTracks.Items.Count == 0) return;
            
            if (listBoxTracks.SelectedIndex >= 0)
            {
                currentTrackIndex = listBoxTracks.SelectedIndex;
            }
            
            PlayCurrentTrack();
            isPlaying = true;
            btnPlayPause.Text = "⏸️ Пауза";
            btnPlayPause.BackColor = Color.FromArgb(200, 100, 100);
            playTimer?.Start();
        }
        
        private void StopPlayback()
        {
            if (currentWavPlayer != null)
            {
                currentWavPlayer.Stop();
                currentWavPlayer.Dispose();
                currentWavPlayer = null;
            }
            
            if (currentMp3Process != null)
            {
                try
                {
                    if (!currentMp3Process.HasExited)
                    {
                        currentMp3Process.Kill();
                    }
                    currentMp3Process.Dispose();
                }
                catch { }
                currentMp3Process = null;
            }
            
            isUsingMp3Player = false;
            isPlaying = false;
            btnPlayPause.Text = "▶️ Играть";
            btnPlayPause.BackColor = Color.FromArgb(100, 150, 100);
            playTimer?.Stop();
            
            lblNowPlaying.Text = "Остановлено";
        }
        
        private void PlayCurrentTrack()
        {
            try
            {
                // Останавливаем текущее воспроизведение
                if (currentWavPlayer != null)
                {
                    currentWavPlayer.Stop();
                    currentWavPlayer.Dispose();
                    currentWavPlayer = null;
                }
                
                if (currentMp3Process != null)
                {
                    try
                    {
                        if (!currentMp3Process.HasExited)
                        {
                            currentMp3Process.Kill();
                        }
                        currentMp3Process.Dispose();
                    }
                    catch { }
                    currentMp3Process = null;
                }
                
                // Играем только пользовательские треки
                if (currentTrackIndex >= 0 && currentTrackIndex < customTracks.Count)
                {
                    string trackPath = customTracks[currentTrackIndex];
                    if (File.Exists(trackPath))
                    {
                        string extension = Path.GetExtension(trackPath).ToLower();
                        string fileName = Path.GetFileNameWithoutExtension(trackPath);
                        
                        if (extension == ".wav")
                        {
                            // Воспроизводим WAV через SoundPlayer
                            try
                            {
                                currentWavPlayer = new SoundPlayer(trackPath);
                                currentWavPlayer.LoadAsync();
                                currentWavPlayer.PlayLooping();
                                isUsingMp3Player = false;
                                
                                lblNowPlaying.Text = $"🎵 {fileName} (WAV)";
                                lblStatus.Text = "✅ Воспроизведение WAV";
                                lblStatus.ForeColor = Color.LightGreen;
                            }
                            catch (Exception ex)
                            {
                                lblStatus.Text = $"❌ Ошибка WAV: {ex.Message}";
                                lblStatus.ForeColor = Color.Red;
                                lblNowPlaying.Text = "❌ Поврежденный WAV файл";
                            }
                        }
                        else if (extension == ".mp3")
                        {
                            // Воспроизводим MP3 через системный плеер
                            try
                            {
                                currentMp3Process = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = trackPath,
                                    UseShellExecute = true,
                                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                                });
                                
                                if (currentMp3Process != null)
                                {
                                    isUsingMp3Player = true;
                                    lblNowPlaying.Text = $"🎵 {fileName} (MP3)";
                                    lblStatus.Text = "✅ Воспроизведение MP3 через системный плеер";
                                    lblStatus.ForeColor = Color.LightGreen;
                                }
                                else
                                {
                                    lblStatus.Text = "❌ Не удалось запустить MP3";
                                    lblStatus.ForeColor = Color.Orange;
                                    lblNowPlaying.Text = "❌ Ошибка запуска MP3";
                                }
                            }
                            catch (Exception ex)
                            {
                                lblStatus.Text = $"❌ Ошибка MP3: {ex.Message}";
                                lblStatus.ForeColor = Color.Red;
                                lblNowPlaying.Text = "❌ Ошибка MP3 плеера";
                            }
                        }
                        else
                        {
                            lblStatus.Text = "❌ Поддерживаются только WAV и MP3 файлы";
                            lblStatus.ForeColor = Color.Red;
                            lblNowPlaying.Text = "❌ Неподдерживаемый формат";
                        }
                    }
                    else
                    {
                        lblStatus.Text = "❌ Файл не найден";
                        lblStatus.ForeColor = Color.Red;
                        lblNowPlaying.Text = "❌ Файл не существует";
                    }
                }
                else
                {
                    lblNowPlaying.Text = "❌ Нет доступных треков";
                    lblStatus.Text = "Добавьте WAV или MP3 файлы для воспроизведения";
                    lblStatus.ForeColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"❌ Ошибка воспроизведения: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                lblNowPlaying.Text = "❌ Ошибка воспроизведения";
            }
        }
        
        private void PlayTimer_Tick(object? sender, EventArgs e)
        {
            // Переключаем на следующий трек
            if (checkBoxAutoNext.Checked)
            {
                btnNext_Click(this, e);
            }
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentTrackIndex = (currentTrackIndex + 1) % listBoxTracks.Items.Count;
            if (currentTrackIndex < listBoxTracks.Items.Count)
            {
                listBoxTracks.SelectedIndex = currentTrackIndex;
                if (isPlaying)
                {
                    PlayCurrentTrack();
                }
            }
        }
        
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentTrackIndex = currentTrackIndex <= 0 ? listBoxTracks.Items.Count - 1 : currentTrackIndex - 1;
            if (currentTrackIndex >= 0)
            {
                listBoxTracks.SelectedIndex = currentTrackIndex;
                if (isPlaying)
                {
                    PlayCurrentTrack();
                }
            }
        }
        
        private void listBoxTracks_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxTracks.SelectedIndex >= 0)
            {
                currentTrackIndex = listBoxTracks.SelectedIndex;
                PlayCurrentTrack();
                isPlaying = true;
                btnPlayPause.Text = "⏸️ Пауза";
                btnPlayPause.BackColor = Color.FromArgb(200, 100, 100);
            }
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            StopPlayback();
            playTimer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}