using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace MyApp
{
    public partial class TMarketForm : Form
    {
        private List<AppInfo> availableApps = new List<AppInfo>();
        private List<AppInfo> filteredApps = new List<AppInfo>();
        
        public TMarketForm()
        {
            InitializeComponent();
            
            // Включаем двойную буферизацию для плавности
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                         ControlStyles.UserPaint | 
                         ControlStyles.DoubleBuffer, true);
            
            LoadAvailableApps();
            filteredApps = new List<AppInfo>(availableApps);
            SetupMarketApps();
        }
        
        private void LoadAvailableApps()
        {
            // Список доступных приложений в TMarket (убрали Настройки и Обновления)
            availableApps.Add(new AppInfo 
            { 
                Name = "Калькулятор", 
                Description = "Мощный калькулятор с пасхалками", 
                Icon = "🧮",
                FormType = typeof(CalculatorForm),
                Category = "Утилиты"
            });
            
            availableApps.Add(new AppInfo 
            { 
                Name = "Paint", 
                Description = "Редактор для рисования", 
                Icon = "🎨",
                FormType = typeof(PaintForm),
                Category = "Творчество"
            });
            
            availableApps.Add(new AppInfo 
            { 
                Name = "Ambient Manager", 
                Description = "Музыкальный плеер для релакса", 
                Icon = "🎵",
                FormType = typeof(AmbientForm),
                Category = "Музыка"
            });
        }
        
        private void SetupMarketApps()
        {
            listViewApps.View = View.LargeIcon;
            listViewApps.LargeImageList = new ImageList();
            listViewApps.LargeImageList.ImageSize = new Size(72, 72);
            
            UpdateAppsList();
        }
        
        private void UpdateAppsList()
        {
            listViewApps.Items.Clear();
            
            if (listViewApps.LargeImageList != null)
            {
                listViewApps.LargeImageList.Images.Clear();
            }
            
            foreach (var app in filteredApps)
            {
                // Создаем улучшенную иконку для приложения
                Bitmap icon = CreateEnhancedAppIcon(app.Icon, app.Name, app.Category);
                listViewApps.LargeImageList?.Images.Add(app.Name, icon);
                
                // Добавляем элемент в список
                ListViewItem item = new ListViewItem(app.Name);
                item.ImageKey = app.Name;
                item.Tag = app;
                item.ToolTipText = $"{app.Description}\nКатегория: {app.Category}";
                
                listViewApps.Items.Add(item);
            }
        }
        
        private Bitmap CreateEnhancedAppIcon(string emoji, string appName, string category)
        {
            Bitmap icon = new Bitmap(72, 72);
            using (Graphics g = Graphics.FromImage(icon))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                
                // Получаем цвет категории
                Color categoryColor = GetCategoryColor(category);
                Color lightColor = ControlPaint.Light(categoryColor);
                Color darkColor = ControlPaint.Dark(categoryColor);
                
                // Фон иконки с градиентом
                using (var brush = new LinearGradientBrush(
                    new Rectangle(0, 0, 72, 72),
                    lightColor,
                    darkColor,
                    LinearGradientMode.Vertical))
                {
                    g.FillRoundedRectangle(brush, new Rectangle(2, 2, 68, 68), 16);
                }
                
                // Рамка
                using (var pen = new Pen(Color.FromArgb(150, 255, 255, 255), 1.5f))
                {
                    g.DrawRoundedRectangle(pen, new Rectangle(2, 2, 68, 68), 16);
                }
                
                // Эмодзи
                using (Font emojiFont = new Font("Segoe UI Emoji", 28, FontStyle.Bold))
                {
                    SizeF emojiSize = g.MeasureString(emoji, emojiFont);
                    PointF emojiPos = new PointF(
                        (72 - emojiSize.Width) / 2,
                        (72 - emojiSize.Height) / 2 - 5
                    );
                    
                    // Тень
                    using (var shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                    {
                        g.DrawString(emoji, emojiFont, shadowBrush, emojiPos.X + 1, emojiPos.Y + 1);
                    }
                    
                    g.DrawString(emoji, emojiFont, Brushes.White, emojiPos);
                }
            }
            return icon;
        }
        
        private Color GetCategoryColor(string category)
        {
            return category.ToLower() switch
            {
                "система" => Color.FromArgb(70, 130, 180),
                "утилиты" => Color.FromArgb(95, 158, 160),
                "творчество" => Color.FromArgb(218, 112, 214),
                "музыка" => Color.FromArgb(138, 43, 226),
                _ => Color.FromArgb(100, 149, 237)
            };
        }
        
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterApps();
        }
        
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            FilterApps();
        }
        
        private void FilterApps()
        {
            string selectedCategory = comboBoxCategory.SelectedItem?.ToString() ?? "Все категории";
            string searchText = textBoxSearch.Text.ToLower();
            
            filteredApps = availableApps.Where(app =>
            {
                // Фильтр по категории
                bool categoryMatch = selectedCategory == "Все категории" || app.Category == selectedCategory;
                
                // Фильтр по поиску
                bool searchMatch = string.IsNullOrEmpty(searchText) ||
                                 app.Name.ToLower().Contains(searchText) ||
                                 app.Description.ToLower().Contains(searchText);
                
                return categoryMatch && searchMatch;
            }).ToList();
            
            UpdateAppsList();
            
            // Обновляем статус
            int totalApps = availableApps.Count;
            int filteredCount = filteredApps.Count;
            lblStatus.Text = $"📱 Показано {filteredCount} из {totalApps} приложений";
            lblStatus.ForeColor = Color.FromArgb(120, 180, 255);
        }
        
        private void btnAddToDesktop_Click(object sender, EventArgs e)
        {
            if (listViewApps.SelectedItems.Count > 0 && listViewApps.SelectedItems[0].Tag != null)
            {
                AppInfo? selectedApp = listViewApps.SelectedItems[0].Tag as AppInfo;
                
                if (selectedApp != null && this.Owner is Form1 mainForm)
                {
                    // Добавляем приложение на рабочий стол как иконку
                    mainForm.AddAppToDesktop(selectedApp);
                    
                    lblStatus.Text = $"⬇️ {selectedApp.Name} загружен на рабочий стол!";
                    lblStatus.ForeColor = Color.LightGreen;
                }
            }
            else
            {
                lblStatus.Text = "⚠️ Выберите приложение для загрузки";
                lblStatus.ForeColor = Color.Orange;
            }
        }
        
        private void listViewApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewApps.SelectedItems.Count > 0 && listViewApps.SelectedItems[0].Tag != null)
            {
                AppInfo? selectedApp = listViewApps.SelectedItems[0].Tag as AppInfo;
                if (selectedApp != null)
                {
                    lblAppInfo.Text = $"📱 {selectedApp.Name}\n\n📝 {selectedApp.Description}\n\n📂 Категория: {selectedApp.Category}";
                    btnAddToDesktop.Enabled = true;
                }
            }
            else
            {
                lblAppInfo.Text = "Выберите приложение для просмотра информации";
                btnAddToDesktop.Enabled = false;
            }
        }
        
        private void listViewApps_DoubleClick(object sender, EventArgs e)
        {
            btnAddToDesktop_Click(sender, e);
        }
    }
    
    public class AppInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Icon { get; set; } = "";
        public Type? FormType { get; set; }
        public string Category { get; set; } = "";
    }
}

// Расширение для рисования скругленных прямоугольников
public static class GraphicsExtensions
{
    public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle rect, int radius)
    {
        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
        {
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            graphics.FillPath(brush, path);
        }
    }
    
    public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rect, int radius)
    {
        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
        {
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            graphics.DrawPath(pen, path);
        }
    }
}