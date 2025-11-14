using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.IO;
using MyApp.Properties;

namespace MyApp;

public partial class SettingsForm : Form
{
    private Form1 parentForm;

    public SettingsForm(Form1 parent)
    {
        parentForm = parent;
        InitializeComponent();
        this.Text = "Настройки TM OS";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
        
        // Устанавливаем сохраненный курсор для формы и всех элементов
        ApplySavedCursor();
        
        // Обновляем текст кнопок пользовательских курсоров
        UpdateCustomCursorButtons();
    }

    private void UpdateCustomCursorButtons()
    {
        // Обновляем текст кнопки Курсор 1
        string cursor1Path = Properties.Settings.Default.CustomCursor1Path;
        string cursor1Name = Properties.Settings.Default.CustomCursor1Name;
        if (!string.IsNullOrEmpty(cursor1Path) && File.Exists(cursor1Path))
        {
            btnCustomCursor1.Text = $"✨ {cursor1Name}";
            btnCustomCursor1.BackColor = Color.FromArgb(70, 100, 70);
        }
        else
        {
            btnCustomCursor1.Text = "📁 Курсор 1 (не загружен)";
            btnCustomCursor1.BackColor = Color.FromArgb(50, 70, 50);
        }

        // Обновляем текст кнопки Курсор 2
        string cursor2Path = Properties.Settings.Default.CustomCursor2Path;
        string cursor2Name = Properties.Settings.Default.CustomCursor2Name;
        if (!string.IsNullOrEmpty(cursor2Path) && File.Exists(cursor2Path))
        {
            btnCustomCursor2.Text = $"✨ {cursor2Name}";
            btnCustomCursor2.BackColor = Color.FromArgb(70, 100, 70);
        }
        else
        {
            btnCustomCursor2.Text = "📁 Курсор 2 (не загружен)";
            btnCustomCursor2.BackColor = Color.FromArgb(50, 70, 50);
        }
    }

    private void ApplySavedCursor()
    {
        try
        {
            string cursorType = Properties.Settings.Default.CursorType;
            Cursor selectedCursor;
            
            switch (cursorType)
            {
                case "Richard":
                    selectedCursor = Form1.CreateRichardMaskCursorStatic();
                    break;
                case "Tony":
                    selectedCursor = Form1.CreateTonyMaskCursorStatic();
                    break;
                case "Custom1":
                    selectedCursor = LoadCustomCursorFromPath(Properties.Settings.Default.CustomCursor1Path);
                    break;
                case "Custom2":
                    selectedCursor = LoadCustomCursorFromPath(Properties.Settings.Default.CustomCursor2Path);
                    break;
                case "Default":
                default:
                    selectedCursor = Cursors.Default;
                    break;
            }
            
            Form1.SetCursorForAllControls(this, selectedCursor);
        }
        catch
        {
            // Если возникла ошибка, используем дефолтный курсор
            this.Cursor = Cursors.Default;
        }
    }

    private Cursor LoadCustomCursorFromPath(string cursorPath)
    {
        try
        {
            if (!string.IsNullOrEmpty(cursorPath) && File.Exists(cursorPath))
            {
                string fileExtension = Path.GetExtension(cursorPath).ToLower();
                
                if (fileExtension == ".cur" || fileExtension == ".ani")
                {
                    // Загружаем готовый курсор
                    return new Cursor(cursorPath);
                }
                else
                {
                    // Конвертируем изображение в курсор с сохранением цветов
                    return Form1.CreateCursorFromImageStatic(cursorPath);
                }
            }
        }
        catch
        {
            // Если файл поврежден или недоступен
        }
        
        // Возвращаем дефолтный курсор если не удалось загрузить
        return Cursors.Default;
    }

    private void btnGradientBlue_Click(object sender, EventArgs e)
    {
        parentForm.SetGradientBackground(Color.FromArgb(25, 25, 35), Color.FromArgb(45, 45, 65));
        this.Close();
    }

    private void btnGradientPurple_Click(object sender, EventArgs e)
    {
        parentForm.SetGradientBackground(Color.FromArgb(35, 25, 45), Color.FromArgb(65, 45, 85));
        this.Close();
    }

    private void btnGradientGreen_Click(object sender, EventArgs e)
    {
        parentForm.SetGradientBackground(Color.FromArgb(25, 35, 25), Color.FromArgb(45, 65, 45));
        this.Close();
    }

    private void btnGradientRed_Click(object sender, EventArgs e)
    {
        parentForm.SetGradientBackground(Color.FromArgb(35, 25, 25), Color.FromArgb(65, 45, 45));
        this.Close();
    }

    private void btnSolidBlack_Click(object sender, EventArgs e)
    {
        parentForm.SetSolidBackground(Color.Black);
        this.Close();
    }

    private void btnSolidGray_Click(object sender, EventArgs e)
    {
        parentForm.SetSolidBackground(Color.FromArgb(50, 50, 50));
        this.Close();
    }

    private void btnCustomWallpaper_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new();
        openFileDialog.Title = "Выберите изображение для обоев";
        openFileDialog.Filter = "Изображения|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Все файлы|*.*";
        openFileDialog.FilterIndex = 1;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using Image img = Image.FromFile(openFileDialog.FileName);
                SetCustomWallpaper(img);
                
                // Автоматически сохраняем настройки
                Properties.Settings.Default.CustomWallpaperPath = openFileDialog.FileName;
                Properties.Settings.Default.WallpaperType = "Custom";
                Properties.Settings.Default.Save();
                
                MessageBox.Show("Обои успешно установлены и сохранены!", "TM OS", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void SetCustomWallpaper(Image image)
    {
        // Устанавливаем изображение как фон
        parentForm.BackgroundImage = new Bitmap(image);
        parentForm.BackgroundImageLayout = ImageLayout.Stretch;
        
        // Убираем градиентный фон
        parentForm.BackColor = Color.Black;
        
        // Перерисовываем форму, чтобы текст отобразился поверх изображения
        parentForm.Invalidate();
    }

    private void btnTonyCursor_Click(object sender, EventArgs e)
    {
        // Устанавливаем курсор маски Тони для главной формы
        Cursor tonyMaskCursor = Form1.CreateTonyMaskCursorStatic();
        Form1.SetCursorForAllControls(parentForm, tonyMaskCursor);
        
        // Применяем курсор ко всем открытым формам TM OS
        ApplyCursorToAllOpenForms(tonyMaskCursor);
        
        // Сохраняем настройку курсора
        Properties.Settings.Default.CursorType = "Tony";
        Properties.Settings.Default.Save();
        
        MessageBox.Show("Курсор маски Тони установлен!", "TM OS", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnRichardCursor_Click(object sender, EventArgs e)
    {
        // Устанавливаем курсор маски Ричарда для главной формы
        Cursor richardMaskCursor = Form1.CreateRichardMaskCursorStatic();
        Form1.SetCursorForAllControls(parentForm, richardMaskCursor);
        
        // Применяем курсор ко всем открытым формам TM OS
        ApplyCursorToAllOpenForms(richardMaskCursor);
        
        // Сохраняем настройку курсора
        Properties.Settings.Default.CursorType = "Richard";
        Properties.Settings.Default.Save();
        
        MessageBox.Show("Курсор маски Ричарда установлен!", "TM OS", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDefaultCursor_Click(object sender, EventArgs e)
    {
        // Устанавливаем обычный курсор для главной формы
        Form1.SetCursorForAllControls(parentForm, Cursors.Default);
        
        // Применяем курсор ко всем открытым формам TM OS
        ApplyCursorToAllOpenForms(Cursors.Default);
        
        // Сохраняем настройку курсора
        Properties.Settings.Default.CursorType = "Default";
        Properties.Settings.Default.Save();
        
        MessageBox.Show("Обычный курсор установлен!", "TM OS", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ApplyCursorToAllOpenForms(Cursor cursor)
    {
        // Применяем курсор ко всем открытым формам приложения
        foreach (Form openForm in Application.OpenForms)
        {
            if (openForm != null)
            {
                Form1.SetCursorForAllControls(openForm, cursor);
            }
        }
    }
    
    private void btnLoadCursor1_Click(object sender, EventArgs e)
    {
        LoadCustomCursor(1);
    }

    private void btnLoadCursor2_Click(object sender, EventArgs e)
    {
        LoadCustomCursor(2);
    }

    private void btnCustomCursor1_Click(object sender, EventArgs e)
    {
        ApplyCustomCursor(1);
    }

    private void btnCustomCursor2_Click(object sender, EventArgs e)
    {
        ApplyCustomCursor(2);
    }

    private void LoadCustomCursor(int cursorNumber)
    {
        using OpenFileDialog openFileDialog = new();
        openFileDialog.Title = $"Выберите файл курсора для слота {cursorNumber}";
        openFileDialog.Filter = "Файлы курсоров|*.cur;*.ani|Изображения|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Все файлы|*.*";
        openFileDialog.FilterIndex = 1;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                Cursor newCursor;
                string fileExtension = Path.GetExtension(openFileDialog.FileName).ToLower();
                
                if (fileExtension == ".cur" || fileExtension == ".ani")
                {
                    // Загружаем готовый курсор
                    newCursor = new Cursor(openFileDialog.FileName);
                }
                else
                {
                    // Конвертируем изображение в курсор с сохранением цветов
                    newCursor = CreateCursorFromImage(openFileDialog.FileName);
                }

                // Проверяем, что курсор корректный
                newCursor.Dispose();

                // Запрашиваем имя для курсора
                string cursorName = PromptForCursorName(cursorNumber, Path.GetFileNameWithoutExtension(openFileDialog.FileName));
                
                // Сохраняем путь и имя курсора
                if (cursorNumber == 1)
                {
                    Properties.Settings.Default.CustomCursor1Path = openFileDialog.FileName;
                    Properties.Settings.Default.CustomCursor1Name = cursorName;
                }
                else
                {
                    Properties.Settings.Default.CustomCursor2Path = openFileDialog.FileName;
                    Properties.Settings.Default.CustomCursor2Name = cursorName;
                }
                
                Properties.Settings.Default.Save();
                UpdateCustomCursorButtons();
                
                MessageBox.Show($"Курсор '{cursorName}' успешно загружен в слот {cursorNumber}!\n\n💡 Изображения автоматически конвертируются в полноцветные курсоры.", "TM OS", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке курсора: {ex.Message}\n\nПопробуйте использовать изображение формата PNG или JPG.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private string PromptForCursorName(int cursorNumber, string defaultName)
    {
        string input = Microsoft.VisualBasic.Interaction.InputBox(
            $"Введите название для курсора {cursorNumber}:",
            "Название курсора",
            defaultName);
        
        return string.IsNullOrEmpty(input) ? $"Курсор {cursorNumber}" : input;
    }

    private void ApplyCustomCursor(int cursorNumber)
    {
        try
        {
            string cursorPath = cursorNumber == 1 
                ? Properties.Settings.Default.CustomCursor1Path 
                : Properties.Settings.Default.CustomCursor2Path;
            
            string cursorName = cursorNumber == 1 
                ? Properties.Settings.Default.CustomCursor1Name 
                : Properties.Settings.Default.CustomCursor2Name;

            if (string.IsNullOrEmpty(cursorPath) || !File.Exists(cursorPath))
            {
                MessageBox.Show($"Курсор {cursorNumber} не загружен. Сначала загрузите файл курсора.", "TM OS", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Загружаем и применяем пользовательский курсор
            Cursor customCursor = new Cursor(cursorPath);
            Form1.SetCursorForAllControls(parentForm, customCursor);
            ApplyCursorToAllOpenForms(customCursor);

            // Сохраняем настройку
            Properties.Settings.Default.CursorType = $"Custom{cursorNumber}";
            Properties.Settings.Default.Save();

            MessageBox.Show($"Курсор '{cursorName}' установлен!", "TM OS", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при применении курсора: {ex.Message}", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Cursor CreateCursorFromImage(string imagePath)
    {
        return Form1.CreateCursorFromImageStatic(imagePath);
    }
    
    private async void btnCheckUpdates_Click(object sender, EventArgs e)
    {
        try
        {
            lblUpdateStatus.Text = "🔍 Проверка обновлений...";
            lblUpdateStatus.ForeColor = Color.Yellow;
            btnCheckUpdates.Enabled = false;
            
            // Проверка с таймаутом 20 секунд
            var timeoutTimer = new System.Windows.Forms.Timer();
            timeoutTimer.Interval = 20000; // 20 секунд = 20000 мс
            bool isCompleted = false;
            
            timeoutTimer.Tick += (s, args) =>
            {
                if (!isCompleted)
                {
                    timeoutTimer.Stop();
                    isCompleted = true;
                    lblUpdateStatus.Text = "⏱️ Таймаут - обновлений нет";
                    lblUpdateStatus.ForeColor = Color.Gray;
                    btnCheckUpdates.Enabled = true;
                }
            };
            
            timeoutTimer.Start();
            
            await Task.Run(async () =>
            {
                await Task.Delay(3000); // Имитация проверки
                
                if (!isCompleted)
                {
                    timeoutTimer.Stop();
                    isCompleted = true;
                    
                    // Текущая версия v1.1 является самой новой
                    bool updateAvailable = false;
                    
                    this.Invoke(() =>
                    {
                        if (updateAvailable)
                        {
                            lblUpdateStatus.Text = "🎉 Доступно обновление v1.2!";
                            lblUpdateStatus.ForeColor = Color.LightGreen;
                            
                            // Предложение автоустановки
                            var result = MessageBox.Show(
                                "Найдено обновление v1.2!\n\n" +
                                "🎨 Что нового:\n" +
                                "• Программа Paint для рисования\n" +
                                "• Оптимизированная производительность\n" +
                                "• Улучшенный интерфейс\n\n" +
                                "Хотите установить автоматически?\n" +
                                "Приложение перезапустится с новой версией.",
                                "Автообновление TM OS",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );
                            
                            if (result == DialogResult.Yes)
                            {
                                InstallUpdateAutomatically();
                            }
                        }
                        else
                        {
                            lblUpdateStatus.Text = "✅ У вас последняя версия v1.1";
                            lblUpdateStatus.ForeColor = Color.LightGreen;
                        }
                        btnCheckUpdates.Enabled = true;
                    });
                }
            });
        }
        catch
        {
            lblUpdateStatus.Text = "❌ Ошибка проверки";
            lblUpdateStatus.ForeColor = Color.Red;
            btnCheckUpdates.Enabled = true;
        }
    }
    
    private void btnSelectVersion_Click(object sender, EventArgs e)
    {
        try
        {
            // Показываем информацию о текущей версии
            MessageBox.Show(
                "Текущая версия: v1.1\n\n" +
                "📥 Для обновления:\n" +
                "1. Нажмите 'Проверить обновления'\n" +
                "2. Скачайте новую версию с GitHub\n" +
                "3. Замените старые файлы новыми\n\n" +
                "🔗 Репозиторий: github.com/USERNAME/TM-OS",
                "Информация о версии",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private async void InstallUpdateAutomatically()
    {
        try
        {
            lblUpdateStatus.Text = "📥 Скачивание обновления...";
            lblUpdateStatus.ForeColor = Color.Yellow;
            btnCheckUpdates.Enabled = false;
            
            // Создаем папку для загрузки
            string downloadPath = Path.Combine(Path.GetTempPath(), "TM_OS_Update");
            Directory.CreateDirectory(downloadPath);
            
            // Имитируем скачивание обновления
            await Task.Run(async () =>
            {
                for (int i = 0; i <= 100; i += 10)
                {
                    await Task.Delay(200);
                    this.Invoke(() =>
                    {
                        lblUpdateStatus.Text = $"📥 Скачивание... {i}%";
                    });
                }
            });
            
            lblUpdateStatus.Text = "🔄 Подготовка к установке...";
            await Task.Delay(1000);
            
            // Создаем батник для автообновления
            string currentExe = Application.ExecutablePath;
            string currentDir = Path.GetDirectoryName(currentExe) ?? "";
            string updateBat = Path.Combine(downloadPath, "update.bat");
            
            string batContent = $@"@echo off
title TM OS Auto-Update
color 0A
echo.
echo        ████████╗███╗   ███╗     ██████╗ ███████╗
echo        ╚══██╔══╝████╗ ████║    ██╔═══██╗██╔════╝
echo           ██║   ██╔████╔██║    ██║   ██║███████╗
echo           ██║   ██║╚██╔╝██║    ██║   ██║╚════██║
echo           ██║   ██║ ╚═╝ ██║    ╚██████╔╝███████║
echo           ╚═╝   ╚═╝     ╚═╝     ╚═════╝ ╚══════╝
echo.
echo                   Автообновление v1.2
echo         ═══════════════════════════════════════════
echo.
timeout /t 2 /nobreak > nul
echo 🔄 Создание резервной копии...
if exist ""{Path.Combine(currentDir, "TM_OS_backup.exe")}"" del ""{Path.Combine(currentDir, "TM_OS_backup.exe")}""
copy ""{currentExe}"" ""{Path.Combine(currentDir, "TM_OS_backup.exe")}"" > nul
echo ✅ Резервная копия создана
echo.
echo 📦 Установка обновлений...
timeout /t 2 /nobreak > nul
echo    ▓▓▓▓▓▓▓▓▓▓ 100%%
echo ✅ Обновление v1.2 установлено!
echo.
echo 🎮 Новые возможности:
echo    • 🎨 Новая программа Paint для рисования
echo    • ⚡ Оптимизированная производительность
echo    • 🎯 Улучшенный интерфейс кнопок
echo.
echo 🚀 Запуск TM OS v1.2...
timeout /t 2 /nobreak > nul
start """" ""{currentExe}""
exit";

            File.WriteAllText(updateBat, batContent);
            
            lblUpdateStatus.Text = "✅ Установка завершена! Перезапуск...";
            lblUpdateStatus.ForeColor = Color.LightGreen;
            
            await Task.Delay(1000);
            
            // Запускаем батник и закрываем приложение
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = updateBat,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Normal
            };
            
            Process.Start(psi);
            Application.Exit();
        }
        catch (Exception ex)
        {
            lblUpdateStatus.Text = "❌ Ошибка установки";
            lblUpdateStatus.ForeColor = Color.Red;
            MessageBox.Show($"Ошибка автообновления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnCheckUpdates.Enabled = true;
        }
    }
}