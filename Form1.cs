using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using MyApp.Properties;

namespace MyApp;

public partial class Form1 : Form
{
    private List<DesktopIcon> desktopIcons = new List<DesktopIcon>();
    private DesktopIcon? draggedIcon = null;
    private DesktopIcon? hoveredIcon = null;
    private Point dragOffset;
    private System.Windows.Forms.Timer animationTimer;
    
    public Form1()
    {
        InitializeComponent();
        
        // Включаем двойную буферизацию для плавной отрисовки
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint | 
                     ControlStyles.DoubleBuffer | 
                     ControlStyles.ResizeRedraw, true);
        this.UpdateStyles();
        
        // Настройка таймера анимации
        animationTimer = new System.Windows.Forms.Timer();
        animationTimer.Interval = 50; // 20 FPS для плавной анимации
        animationTimer.Tick += AnimationTimer_Tick;
        animationTimer.Start();
        
        // Центрируем заголовок "TM OS" при загрузке и изменении размера
        this.Load += Form1_Load;
        this.Resize += Form1_Resize;
        this.Paint += Form1_Paint;
        this.FormClosing += Form1_FormClosing;
        
        // Обработка событий мыши для иконок рабочего стола
        this.MouseDown += Form1_MouseDown;
        this.MouseMove += Form1_MouseMove;
        this.MouseUp += Form1_MouseUp;
    }
    
    private void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        // Обновляем анимации только если есть выделенные иконки
        bool hasSelectedIcon = desktopIcons.Any(icon => icon.IsSelected);
        if (hasSelectedIcon)
        {
            // Перерисовываем только области с выделенными иконками для оптимизации
            foreach (var icon in desktopIcons.Where(i => i.IsSelected))
            {
                Rectangle invalidateRect = new Rectangle(
                    icon.Position.X - 5, icon.Position.Y - 5,
                    icon.Size.Width + 10, icon.Size.Height + 10
                );
                this.Invalidate(invalidateRect);
            }
        }
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Останавливаем таймер анимации
        animationTimer?.Stop();
        animationTimer?.Dispose();
        
        // Сохраняем состояние окна при закрытии
        Properties.Settings.Default.WindowMaximized = (this.WindowState == FormWindowState.Maximized);
        Properties.Settings.Default.Save();
    }

    private void Form1_Paint(object? sender, PaintEventArgs e)
    {
        // Рисуем "TM OS" поверх всего содержимого
        using (Font titleFont = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold))
        {
            string titleText = "TM OS";
            SizeF textSize = e.Graphics.MeasureString(titleText, titleFont);
            
            // Вычисляем позицию для центрирования
            float x = (this.ClientSize.Width - textSize.Width) / 2;
            float y = 30;
            
            // Рисуем тень для лучшей видимости
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(180, 0, 0, 0)))
            {
                e.Graphics.DrawString(titleText, titleFont, shadowBrush, x + 2, y + 2);
            }
            
            // Рисуем основной текст
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                e.Graphics.DrawString(titleText, titleFont, textBrush, x, y);
            }
        }
        
        // Рисуем иконки рабочего стола
        DrawDesktopIcons(e.Graphics);
    }
    
    private void DrawDesktopIcons(Graphics g)
    {
        // Включаем высококачественную отрисовку
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        g.CompositingQuality = CompositingQuality.HighQuality;
        
        foreach (var icon in desktopIcons)
        {
            DrawHighQualityIcon(g, icon);
        }
    }
    
    private void DrawHighQualityIcon(Graphics g, DesktopIcon icon)
    {
        Rectangle iconRect = new Rectangle(icon.Position, icon.Size);
        
        // Тень под иконкой для глубины
        Rectangle shadowRect = new Rectangle(iconRect.X + 3, iconRect.Y + 3, iconRect.Width, iconRect.Height);
        using (var shadowBrush = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
        {
            g.FillRoundedRectangle(shadowBrush, shadowRect, 12);
        }
        
        // Фон иконки с градиентом
        Color baseColor = GetIconBaseColor(icon.AppInfo.Category);
        Color lightColor = ControlPaint.Light(baseColor);
        Color darkColor = ControlPaint.Dark(baseColor);
        
        // Улучшаем цвета для выделенных или наведенных иконок
        if (icon.IsSelected)
        {
            lightColor = ControlPaint.LightLight(baseColor);
            darkColor = baseColor;
        }
        else if (icon == hoveredIcon)
        {
            lightColor = ControlPaint.Light(lightColor);
            darkColor = ControlPaint.Light(darkColor);
        }
        
        using (var gradientBrush = new LinearGradientBrush(
            iconRect,
            lightColor,
            darkColor,
            LinearGradientMode.Vertical))
        {
            g.FillRoundedRectangle(gradientBrush, iconRect, 12);
        }
        
        // Рамка иконки
        Color borderColor = icon.IsSelected ? Color.FromArgb(200, 255, 255, 255) : 
                           icon == hoveredIcon ? Color.FromArgb(150, 255, 255, 255) : 
                           Color.FromArgb(100, 255, 255, 255);
        float borderWidth = icon.IsSelected ? 2.5f : icon == hoveredIcon ? 2.0f : 1.5f;
        
        using (var borderPen = new Pen(borderColor, borderWidth))
        {
            g.DrawRoundedRectangle(borderPen, iconRect, 12);
        }
        
        // Эмодзи иконка с улучшенным позиционированием
        float emojiSize = icon.IsSelected ? 30f : icon == hoveredIcon ? 29f : 28f;
        using (Font emojiFont = new Font("Segoe UI Emoji", emojiSize, FontStyle.Bold))
        {
            SizeF textSize = g.MeasureString(icon.AppInfo.Icon, emojiFont);
            PointF emojiPos = new PointF(
                icon.Position.X + (icon.Size.Width - textSize.Width) / 2,
                icon.Position.Y + 8
            );
            
            // Тень для эмодзи
            using (var emojiShadow = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
            {
                g.DrawString(icon.AppInfo.Icon, emojiFont, emojiShadow, emojiPos.X + 1, emojiPos.Y + 1);
            }
            
            // Основной эмодзи
            g.DrawString(icon.AppInfo.Icon, emojiFont, Brushes.White, emojiPos);
        }
        
        // Название приложения с улучшенной типографикой
        using (Font nameFont = new Font("Segoe UI", 8.5f, FontStyle.Bold))
        {
            string displayName = icon.AppInfo.Name;
            if (displayName.Length > 10)
            {
                displayName = displayName.Substring(0, 9) + "...";
            }
            
            SizeF nameSize = g.MeasureString(displayName, nameFont);
            PointF namePos = new PointF(
                icon.Position.X + (icon.Size.Width - nameSize.Width) / 2,
                icon.Position.Y + icon.Size.Height - 22
            );
            
            // Тень для текста
            using (var textShadow = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
            {
                g.DrawString(displayName, nameFont, textShadow, namePos.X + 1, namePos.Y + 1);
            }
            
            // Основной текст
            g.DrawString(displayName, nameFont, Brushes.White, namePos);
        }
        
        // Дополнительные эффекты для выделенных иконок
        if (icon.IsSelected)
        {
            DrawSelectionEffects(g, iconRect);
        }
        else if (icon == hoveredIcon)
        {
            DrawHoverEffects(g, iconRect);
        }
    }
    
    private void DrawHoverEffects(Graphics g, Rectangle iconRect)
    {
        // Мягкое свечение при наведении
        using (var hoverBrush = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
        {
            Rectangle hoverRect = new Rectangle(
                iconRect.X - 1, iconRect.Y - 1, 
                iconRect.Width + 2, iconRect.Height + 2
            );
            g.FillRoundedRectangle(hoverBrush, hoverRect, 13);
        }
    }
    
    private Color GetIconBaseColor(string category)
    {
        return category.ToLower() switch
        {
            "система" => Color.FromArgb(70, 130, 180),      // Стальной синий
            "утилиты" => Color.FromArgb(95, 158, 160),       // Кадетский синий
            "творчество" => Color.FromArgb(218, 112, 214),   // Орхидея
            "музыка" => Color.FromArgb(138, 43, 226),        // Сине-фиолетовый
            _ => Color.FromArgb(100, 149, 237)               // Васильковый синий (по умолчанию)
        };
    }
    
    private void DrawSelectionEffects(Graphics g, Rectangle iconRect)
    {
        // Мерцающий эффект для выделенной иконки
        int alpha = (int)(Math.Sin(Environment.TickCount * 0.01) * 30 + 50);
        using (var glowBrush = new SolidBrush(Color.FromArgb(alpha, 255, 255, 255)))
        {
            Rectangle glowRect = new Rectangle(
                iconRect.X - 2, iconRect.Y - 2, 
                iconRect.Width + 4, iconRect.Height + 4
            );
            g.FillRoundedRectangle(glowBrush, glowRect, 14);
        }
    }
    
    private void Form1_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            // Находим иконку под курсором
            DesktopIcon? clickedIcon = GetIconAtPosition(e.Location);
            
            if (clickedIcon != null)
            {
                // Снимаем выделение с других иконок
                foreach (var icon in desktopIcons)
                {
                    icon.IsSelected = false;
                }
                
                // Выделяем нажатую иконку
                clickedIcon.IsSelected = true;
                draggedIcon = clickedIcon;
                dragOffset = new Point(e.X - clickedIcon.Position.X, e.Y - clickedIcon.Position.Y);
                
                this.Invalidate();
            }
            else
            {
                // Клик по пустому месту - снимаем выделение
                foreach (var icon in desktopIcons)
                {
                    icon.IsSelected = false;
                }
                this.Invalidate();
            }
        }
    }
    
    private void Form1_MouseMove(object? sender, MouseEventArgs e)
    {
        // Обновляем hover эффект
        DesktopIcon? newHoveredIcon = GetIconAtPosition(e.Location);
        if (newHoveredIcon != hoveredIcon)
        {
            hoveredIcon = newHoveredIcon;
            this.Invalidate(); // Перерисовываем для обновления hover эффекта
        }
        
        if (draggedIcon != null && e.Button == MouseButtons.Left)
        {
            // Перетаскиваем иконку
            draggedIcon.Position = new Point(e.X - dragOffset.X, e.Y - dragOffset.Y);
            this.Invalidate();
        }
    }
    
    private void Form1_MouseUp(object? sender, MouseEventArgs e)
    {
        // Если иконка была перемещена минимально, запускаем приложение
        if (draggedIcon != null)
        {
            Point currentPos = e.Location;
            Point startPos = new Point(draggedIcon.Position.X + dragOffset.X, draggedIcon.Position.Y + dragOffset.Y);
            
            // Если курсор почти не двигался (меньше 10 пикселей), это клик для запуска
            double distance = Math.Sqrt(Math.Pow(currentPos.X - startPos.X, 2) + Math.Pow(currentPos.Y - startPos.Y, 2));
            if (distance < 10)
            {
                LaunchApplication(draggedIcon.AppInfo);
            }
        }
        
        draggedIcon = null;
    }
    
    private DesktopIcon? GetIconAtPosition(Point position)
    {
        foreach (var icon in desktopIcons)
        {
            Rectangle iconRect = new Rectangle(icon.Position, icon.Size);
            if (iconRect.Contains(position))
            {
                return icon;
            }
        }
        return null;
    }
    
    private void LaunchApplication(AppInfo appInfo)
    {
        try
        {
            if (appInfo.FormType != null)
            {
                Form? appForm = Activator.CreateInstance(appInfo.FormType) as Form;
                if (appForm != null)
                {
                    appForm.Show();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка запуска приложения {appInfo.Name}: {ex.Message}", 
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        // Скрываем оригинальный Label, теперь текст рисуется в Paint
        lblTitle.Visible = false;
        
        // Загружаем сохраненные настройки
        LoadSavedSettings();
        
        // НЕ добавляем базовые иконки на рабочий стол - оставляем чистый рабочий стол
        
        // Автоматическая проверка обновлений при запуске
        CheckForUpdatesOnStartup();
    }
    
    private void AddDefaultDesktopIcons()
    {
        // Добавляем Настройки
        AddAppToDesktop(new AppInfo 
        { 
            Name = "Настройки", 
            Description = "Персонализация TM OS", 
            Icon = "⚙️",
            FormType = typeof(SettingsForm),
            Category = "Система"
        });
        
        // Добавляем Обновления
        AddAppToDesktop(new AppInfo 
        { 
            Name = "Обновления", 
            Description = "Центр обновлений TM OS", 
            Icon = "🔄",
            FormType = typeof(UpdateForm),
            Category = "Система"
        });
    }

    private void LoadSavedSettings()
    {
        try
        {
            // Восстанавливаем состояние окна
            if (Properties.Settings.Default.WindowMaximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            // Загружаем сохраненный курсор
            LoadSavedCursor();

            // Загружаем сохраненный тип обоев
            string wallpaperType = Properties.Settings.Default.WallpaperType;
            
            switch (wallpaperType)
            {
                case "GradientBlue":
                    SetGradientBackground(Color.FromArgb(25, 25, 35), Color.FromArgb(45, 45, 65));
                    break;
                case "GradientPurple":
                    SetGradientBackground(Color.FromArgb(35, 25, 45), Color.FromArgb(65, 45, 85));
                    break;
                case "GradientGreen":
                    SetGradientBackground(Color.FromArgb(25, 35, 25), Color.FromArgb(45, 65, 45));
                    break;
                case "GradientRed":
                    SetGradientBackground(Color.FromArgb(35, 25, 25), Color.FromArgb(65, 45, 45));
                    break;
                case "SolidBlack":
                    SetSolidBackground(Color.Black);
                    break;
                case "SolidGray":
                    SetSolidBackground(Color.FromArgb(50, 50, 50));
                    break;
                case "Custom":
                    LoadCustomWallpaper();
                    break;
                default:
                    // По умолчанию загружаем градиентный синий фон
                    LoadWallpaper();
                    break;
            }
        }
        catch (Exception ex)
        {
            // Если возникла ошибка, загружаем дефолтные обои
            LoadWallpaper();
            MessageBox.Show($"Ошибка при загрузке настроек: {ex.Message}", "TM OS", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void LoadCustomWallpaper()
    {
        string customPath = Properties.Settings.Default.CustomWallpaperPath;
        if (!string.IsNullOrEmpty(customPath) && File.Exists(customPath))
        {
            try
            {
                using (Image img = Image.FromFile(customPath))
                {
                    this.BackgroundImage = new Bitmap(img);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackColor = Color.Black;
                }
            }
            catch
            {
                // Если файл поврежден или недоступен, загружаем дефолтный фон
                LoadWallpaper();
            }
        }
        else
        {
            // Если файл не найден, загружаем дефолтный фон
            LoadWallpaper();
        }
    }

    private void LoadSavedCursor()
    {
        try
        {
            string cursorType = Properties.Settings.Default.CursorType;
            Cursor selectedCursor;
            
            switch (cursorType)
            {
                case "Richard":
                    selectedCursor = CreateRichardMaskCursorStatic();
                    break;
                case "Tony":
                    selectedCursor = CreateTonyMaskCursorStatic();
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
            
            SetCursorForAllControls(this, selectedCursor);
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
                    return CreateCursorFromImageStatic(cursorPath);
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

    public static Cursor CreateCursorFromImageStatic(string imagePath)
    {
        try
        {
            using (Image originalImage = Image.FromFile(imagePath))
            {
                // Создаем курсор размером 32x32 с полноцветным изображением
                Bitmap cursorBitmap = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                
                using (Graphics g = Graphics.FromImage(cursorBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    
                    // Очищаем фон (прозрачный)
                    g.Clear(Color.Transparent);
                    
                    // Рисуем изображение с масштабированием
                    g.DrawImage(originalImage, new Rectangle(0, 0, 32, 32));
                }
                
                // Создаем курсор простым способом
                IntPtr hIcon = cursorBitmap.GetHicon();
                return new Cursor(hIcon);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading cursor image: {ex.Message}");
            return Cursors.Default;
        }
    }

    private void LoadWallpaper()
    {
        try
        {
            // Попробуем загрузить обои из папки Resources
            string wallpaperPath = Path.Combine(Application.StartupPath, "Resources", "wallpaper.jpg");
            
            if (File.Exists(wallpaperPath))
            {
                this.BackgroundImage = Image.FromFile(wallpaperPath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                // Если файл не найден, создаем простой градиент
                CreateGradientBackground();
            }
        }
        catch
        {
            // Если что-то пошло не так, создаем градиент
            CreateGradientBackground();
        }
    }

    private void CreateGradientBackground()
    {
        // Создаем простой градиентный фон
        Bitmap gradient = new Bitmap(800, 600);
        using (Graphics g = Graphics.FromImage(gradient))
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, 800, 600),
                Color.FromArgb(25, 25, 35),    // Темный сине-серый
                Color.FromArgb(45, 45, 65),    // Чуть светлее
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, 0, 0, 800, 600);
            }
        }
        this.BackgroundImage = gradient;
        this.BackgroundImageLayout = ImageLayout.Stretch;
    }

    private void Form1_Resize(object? sender, EventArgs e)
    {
        // Перерисовываем форму при изменении размера
        this.Invalidate();
    }

    private void CenterTitle()
    {
        // Центрируем заголовок "TM OS" по ширине формы
        lblTitle.Location = new Point(
            (this.ClientSize.Width - lblTitle.Width) / 2,
            30
        );
    }

    private Cursor CreateTonyMaskCursor()
    {
        return CreateTonyMaskCursorStatic();
    }

    public static Cursor CreateTonyMaskCursorStatic()
    {
        try
        {
            // Создаем больший bitmap для курсора (48x48 пикселей)
            Bitmap cursorBitmap = new Bitmap(48, 48);
            Graphics g = Graphics.FromImage(cursorBitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // Очищаем фон (прозрачный)
            g.Clear(Color.Transparent);
            
            // Основа маски (яркий оранжевый как у Тони)
            Brush tigerBrush = new SolidBrush(Color.FromArgb(255, 140, 0)); // Более насыщенный оранжевый
            
            // Основная форма головы (овальная)
            g.FillEllipse(tigerBrush, 8, 8, 32, 28);
            
            // Морда (светлее)
            Brush muzzleBrush = new SolidBrush(Color.FromArgb(255, 180, 50));
            g.FillEllipse(muzzleBrush, 14, 20, 20, 16);
            
            // Полоски тигра (широкие черные полосы как у Тони)
            Pen thickBlackPen = new Pen(Color.Black, 3);
            
            // Вертикальные полоски по всей голове
            g.DrawLine(thickBlackPen, 12, 10, 12, 32); // Левая
            g.DrawLine(thickBlackPen, 18, 8, 18, 34);  // Левая центральная
            g.DrawLine(thickBlackPen, 24, 8, 24, 34);  // Правая центральная  
            g.DrawLine(thickBlackPen, 30, 8, 30, 34);  // Правая
            g.DrawLine(thickBlackPen, 36, 10, 36, 32); // Крайняя правая
            
            // Горизонтальные полоски на лбу
            g.DrawLine(thickBlackPen, 10, 14, 38, 14);
            g.DrawLine(thickBlackPen, 12, 18, 36, 18);
            
            // Уши (большие треугольные как у тигра)
            Point[] leftEar = { new Point(8, 10), new Point(4, 2), new Point(12, 6) };
            Point[] rightEar = { new Point(36, 6), new Point(44, 2), new Point(40, 10) };
            g.FillPolygon(tigerBrush, leftEar);
            g.FillPolygon(tigerBrush, rightEar);
            
            // Внутренняя часть ушей (розовая)
            Point[] leftEarInner = { new Point(8, 9), new Point(6, 5), new Point(10, 7) };
            Point[] rightEarInner = { new Point(38, 7), new Point(42, 5), new Point(40, 9) };
            g.FillPolygon(Brushes.Pink, leftEarInner);
            g.FillPolygon(Brushes.Pink, rightEarInner);
            
            // Контур ушей
            g.DrawPolygon(new Pen(Color.Black, 2), leftEar);
            g.DrawPolygon(new Pen(Color.Black, 2), rightEar);
            
            // Глаза (большие красные как в Hotline Miami)
            Brush eyeBrush = new SolidBrush(Color.FromArgb(200, 0, 0)); // Темно-красный
            g.FillEllipse(eyeBrush, 14, 16, 6, 6);  // Левый глаз
            g.FillEllipse(eyeBrush, 28, 16, 6, 6);  // Правый глаз
            
            // Зрачки (черные точки)
            g.FillEllipse(Brushes.Black, 16, 18, 2, 2); // Левый зрачок
            g.FillEllipse(Brushes.Black, 30, 18, 2, 2); // Правый зрачок
            
            // Блики в глазах (белые точки)
            g.FillEllipse(Brushes.White, 17, 17, 1, 1); // Левый блик
            g.FillEllipse(Brushes.White, 31, 17, 1, 1); // Правый блик
            
            // Контур глаз
            g.DrawEllipse(new Pen(Color.Black, 1), 14, 16, 6, 6);
            g.DrawEllipse(new Pen(Color.Black, 1), 28, 16, 6, 6);
            
            // Нос (черный треугольник, больше)
            Point[] nosePoints = { 
                new Point(24, 24), 
                new Point(20, 30), 
                new Point(28, 30) 
            };
            g.FillPolygon(Brushes.Black, nosePoints);
            
            // Рот (усы и пасть тигра)
            Pen mouthPen = new Pen(Color.Black, 2);
            g.DrawLine(mouthPen, 20, 32, 28, 32); // Рот
            g.DrawLine(mouthPen, 24, 30, 24, 34); // Центральная линия
            
            // Усы
            g.DrawLine(new Pen(Color.Black, 1), 10, 26, 16, 28); // Левые усы
            g.DrawLine(new Pen(Color.Black, 1), 10, 30, 16, 30);
            g.DrawLine(new Pen(Color.Black, 1), 32, 28, 38, 26); // Правые усы  
            g.DrawLine(new Pen(Color.Black, 1), 32, 30, 38, 30);
            
            // Общий контур маски
            g.DrawEllipse(new Pen(Color.Black, 2), 8, 8, 32, 28);
            
            // Тени для объема
            Brush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));
            g.FillEllipse(shadowBrush, 10, 30, 28, 6);
            
            g.Dispose();
            tigerBrush.Dispose();
            muzzleBrush.Dispose();
            thickBlackPen.Dispose();
            eyeBrush.Dispose();
            mouthPen.Dispose();
            shadowBrush.Dispose();
            
            // Создаем курсор с кастомной hot spot точкой на кончике левого уха
            // Левое ухо находится в точке (4, 2) - это кончик левого уха
            return CreateCursorWithHotSpot(cursorBitmap, 4, 2);
        }
        catch
        {
            // Если что-то пошло не так, используем системный курсор
            return Cursors.Hand;
        }
    }

    public static void SetCursorForAllControls(Control parent, Cursor cursor)
    {
        parent.Cursor = cursor;
        foreach (Control control in parent.Controls)
        {
            SetCursorForAllControls(control, cursor);
        }
    }

    public static Cursor CreateRichardMaskCursorStatic()
    {
        try
        {
            // Создаем детализированный курсор маски петуха Ричарда (48x48 пикселей)
            Bitmap cursorBitmap = new Bitmap(48, 48);
            Graphics g = Graphics.FromImage(cursorBitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // Прозрачный фон
            g.Clear(Color.Transparent);
            
            // Основная голова петуха (белая с красными акцентами)
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            g.FillEllipse(whiteBrush, 10, 15, 28, 25);
            
            // Красный гребень петуха (детализированный)
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Point[] combPoints = {
                new Point(15, 8), new Point(18, 4), new Point(21, 8),
                new Point(24, 3), new Point(27, 8), new Point(30, 5),
                new Point(33, 8), new Point(35, 15), new Point(10, 15)
            };
            g.FillPolygon(redBrush, combPoints);
            
            // Контур гребня
            g.DrawPolygon(new Pen(Color.DarkRed, 1), combPoints);
            
            // Клюв (желто-оранжевый, детализированный)
            LinearGradientBrush beakBrush = new LinearGradientBrush(
                new Rectangle(5, 25, 12, 8),
                Color.Orange,
                Color.Gold,
                45f);
            Point[] beakPoints = {
                new Point(5, 28), new Point(17, 25), new Point(17, 31), new Point(5, 28)
            };
            g.FillPolygon(beakBrush, beakPoints);
            g.DrawPolygon(new Pen(Color.DarkOrange, 1), beakPoints);
            
            // Глаза (черные с белыми бликами)
            SolidBrush eyeBrush = new SolidBrush(Color.Black);
            g.FillEllipse(eyeBrush, 18, 20, 4, 4);
            g.FillEllipse(eyeBrush, 26, 20, 4, 4);
            
            // Блики в глазах
            SolidBrush highlightBrush = new SolidBrush(Color.White);
            g.FillEllipse(highlightBrush, 19, 21, 1, 1);
            g.FillEllipse(highlightBrush, 27, 21, 1, 1);
            
            // Красные серьги (детализированные)
            g.FillEllipse(redBrush, 8, 30, 6, 8);
            g.FillEllipse(redBrush, 34, 30, 6, 8);
            g.DrawEllipse(new Pen(Color.DarkRed, 1), 8, 30, 6, 8);
            g.DrawEllipse(new Pen(Color.DarkRed, 1), 34, 30, 6, 8);
            
            // Шея и плечи (белые с текстурой)
            g.FillEllipse(whiteBrush, 15, 35, 18, 12);
            
            // Детали перьев (тонкие линии)
            Pen featherPen = new Pen(Color.LightGray, 1);
            g.DrawLine(featherPen, 12, 18, 20, 22);
            g.DrawLine(featherPen, 28, 22, 36, 18);
            g.DrawLine(featherPen, 15, 25, 23, 30);
            g.DrawLine(featherPen, 25, 30, 33, 25);
            
            // Общий контур головы
            g.DrawEllipse(new Pen(Color.Black, 2), 10, 15, 28, 25);
            
            // Тени для объема
            Brush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));
            g.FillEllipse(shadowBrush, 12, 37, 24, 8);
            
            // Освобождаем ресурсы
            g.Dispose();
            whiteBrush.Dispose();
            redBrush.Dispose();
            beakBrush.Dispose();
            eyeBrush.Dispose();
            highlightBrush.Dispose();
            featherPen.Dispose();
            shadowBrush.Dispose();
            
            // Создаем курсор с hot spot на кончике гребня
            return CreateCursorWithHotSpot(cursorBitmap, 24, 3);
        }
        catch
        {
            // Если что-то пошло не так, используем системный курсор
            return Cursors.Hand;
        }
    }

    public static Cursor CreateCursorWithHotSpot(Bitmap bitmap, int hotSpotX, int hotSpotY)
    {
        try
        {
            // Простой и надежный способ - преобразуем в иконку
            IntPtr hIcon = bitmap.GetHicon();
            return new Cursor(hIcon);
        }
        catch
        {
            return Cursors.Default;
        }
    }
    
    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnRestart_Click(object sender, EventArgs e)
    {
        // Перезапуск приложения
        Application.Restart();
        Environment.Exit(0);
    }

    private void btnCalculator_Click(object sender, EventArgs e)
    {
        try
        {
            // Открываем наш собственный калькулятор
            CalculatorForm calculator = new CalculatorForm();
            calculator.ShowDialog(); // Открываем как модальное окно
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не удалось открыть калькулятор: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        try
        {
            // Открываем окно настроек
            SettingsForm settings = new SettingsForm(this);
            settings.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не удалось открыть настройки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    
        private void btnPaint_Click(object sender, EventArgs e)
        {
            try
            {
                // Открываем Paint
                PaintForm paintForm = new PaintForm();
                paintForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии Paint: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnAmbient_Click(object sender, EventArgs e)
        {
            try
            {
                // Открываем Ambient Manager
                AmbientForm ambientForm = new AmbientForm();
                ambientForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия Ambient Manager: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    public void SetGradientBackground(Color color1, Color color2)
    {
        // Создаем градиентный фон с заданными цветами
        Bitmap gradient = new Bitmap(800, 600);
        using (Graphics g = Graphics.FromImage(gradient))
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, 800, 600),
                color1, color2,
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, 0, 0, 800, 600);
            }
        }
        this.BackgroundImage?.Dispose(); // Освобождаем предыдущее изображение
        this.BackgroundImage = gradient;
        this.BackgroundImageLayout = ImageLayout.Stretch;
        this.Invalidate(); // Перерисовываем для отображения текста поверх
        
        // Сохраняем настройки
        SaveGradientSettings(color1, color2);
    }

    private void SaveGradientSettings(Color color1, Color color2)
    {
        // Определяем тип градиента по цветам
        string wallpaperType = "GradientBlue"; // По умолчанию
        
        if (color1 == Color.FromArgb(25, 25, 35) && color2 == Color.FromArgb(45, 45, 65))
            wallpaperType = "GradientBlue";
        else if (color1 == Color.FromArgb(35, 25, 45) && color2 == Color.FromArgb(65, 45, 85))
            wallpaperType = "GradientPurple";
        else if (color1 == Color.FromArgb(25, 35, 25) && color2 == Color.FromArgb(45, 65, 45))
            wallpaperType = "GradientGreen";
        else if (color1 == Color.FromArgb(35, 25, 25) && color2 == Color.FromArgb(65, 45, 45))
            wallpaperType = "GradientRed";
            
        Properties.Settings.Default.WallpaperType = wallpaperType;
        Properties.Settings.Default.GradientColor1 = color1;
        Properties.Settings.Default.GradientColor2 = color2;
        Properties.Settings.Default.Save();
    }

    public void SetSolidBackground(Color color)
    {
        // Создаем сплошной фон
        Bitmap solid = new Bitmap(800, 600);
        using (Graphics g = Graphics.FromImage(solid))
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, 0, 0, 800, 600);
            }
        }
        this.BackgroundImage?.Dispose(); // Освобождаем предыдущее изображение
        this.BackgroundImage = solid;
        this.BackgroundImageLayout = ImageLayout.Stretch;
        this.Invalidate(); // Перерисовываем для отображения текста поверх
        
        // Сохраняем настройки
        string wallpaperType = color == Color.Black ? "SolidBlack" : "SolidGray";
        Properties.Settings.Default.WallpaperType = wallpaperType;
        Properties.Settings.Default.SolidColor = color;
        Properties.Settings.Default.Save();
    }

    private async void CheckForUpdatesOnStartup()
    {
        try
        {
            // Временно отключаем автопроверку до реализации настроек
            return;
        }
        catch
        {
            // Тихо игнорируем ошибки автопроверки
        }
    }
    
    private async Task CheckForUpdatesQuietly()
    {
        try
        {
            // Проверяем обновления с таймаутом 10 секунд для фоновой проверки
            var timeoutTask = Task.Delay(10000);
            var checkTask = CheckForUpdatesInBackground();
            
            var completedTask = await Task.WhenAny(timeoutTask, checkTask);
            
            if (completedTask != timeoutTask)
            {
                bool updateAvailable = await checkTask;
                
                if (updateAvailable)
                {
                    if (MessageBox.Show("🎉 Доступно обновление TM OS!\n\nХотите обновиться сейчас?", 
                        "Обновление TM OS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        btnUpdate_Click(this, EventArgs.Empty);
                    }
                }
            }
            // Если таймаут - тихо игнорируем
        }
        catch
        {
            // Тихо игнорируем ошибки
        }
    }
    
    private async Task<bool> CheckForUpdatesInBackground()
    {
        try
        {
            await Task.Delay(3000); // Имитация проверки
            
            // Случайно определяем есть ли обновление (20% вероятность)
            Random rand = new Random();
            return rand.Next(0, 5) == 1;
        }
        catch
        {
            return false;
        }
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog(this);
            
            // Запускаем проверку обновлений
            await updateForm.CheckForUpdates();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при проверке обновлений: {ex.Message}", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    
    // Метод для добавления приложений на рабочий стол
    public void AddAppToDesktop(AppInfo appInfo)
    {
        // Находим свободное место на рабочем столе
        Point position = FindFreeDesktopPosition();
        
        DesktopIcon icon = new DesktopIcon
        {
            AppInfo = appInfo,
            Position = position,
            Size = new Size(80, 100)
        };
        
        desktopIcons.Add(icon);
        this.Invalidate(); // Перерисовываем форму
    }
    
    private Point FindFreeDesktopPosition()
    {
        int startX = 50;
        int startY = 120; // После заголовка "TM OS"
        int iconWidth = 80;
        int iconHeight = 100;
        int spacing = 20;
        
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 10; col++)
            {
                Point candidate = new Point(
                    startX + col * (iconWidth + spacing),
                    startY + row * (iconHeight + spacing)
                );
                
                // Проверяем, не занято ли это место
                bool occupied = false;
                foreach (var icon in desktopIcons)
                {
                    if (Math.Abs(icon.Position.X - candidate.X) < iconWidth && 
                        Math.Abs(icon.Position.Y - candidate.Y) < iconHeight)
                    {
                        occupied = true;
                        break;
                    }
                }
                
                if (!occupied)
                {
                    return candidate;
                }
            }
        }
        
        return new Point(startX, startY); // Fallback
    }
    
    private void btnTMarket_Click(object sender, EventArgs e)
    {
        TMarketForm tMarketForm = new TMarketForm();
        tMarketForm.Owner = this;
        tMarketForm.ShowDialog();
    }
}

public class DesktopIcon
{
    public AppInfo AppInfo { get; set; } = new AppInfo();
    public Point Position { get; set; }
    public Size Size { get; set; }
    public bool IsSelected { get; set; } = false;
}
