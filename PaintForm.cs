using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MyApp;

public partial class PaintForm : Form
{
    private bool isDrawing = false;
    private Point lastPoint;
    private Bitmap? canvas;
    private Graphics? canvasGraphics;
    private Color currentColor = Color.Black;
    private int brushSize = 3;
    private string currentTool = "brush";
    
    // Оптимизация: переиспользуемые объекты
    private Pen? currentPen;
    private SolidBrush? currentBrush;
    
    public PaintForm()
    {
        InitializeComponent();
        
        // Оптимизация: включаем двойную буферизацию
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint | 
                     ControlStyles.DoubleBuffer | 
                     ControlStyles.ResizeRedraw, true);
        
        InitializeCanvas();
        ApplySavedCursor();
        InitializeDrawingTools();
    }
    
    private void InitializeDrawingTools()
    {
        currentPen = new Pen(currentColor, brushSize);
        currentPen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
        currentBrush = new SolidBrush(currentColor);
    }
    
    private void UpdateDrawingTools()
    {
        // Оптимизация: обновляем существующие объекты вместо создания новых
        if (currentPen != null)
        {
            currentPen.Color = currentColor;
            currentPen.Width = brushSize;
        }
        
        if (currentBrush != null)
        {
            currentBrush.Color = currentColor;
        }
    }
    
    private void InitializeCanvas()
    {
        // Создаем canvas большего размера для лучшего качества
        int canvasWidth = 1200;
        int canvasHeight = 800;
        
        canvas = new Bitmap(canvasWidth, canvasHeight, PixelFormat.Format32bppArgb);
        canvasGraphics = Graphics.FromImage(canvas);
        canvasGraphics.Clear(Color.White);
        
        // Улучшенные настройки для рисования
        canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        canvasGraphics.CompositingQuality = CompositingQuality.HighQuality;
        canvasGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        canvasGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        
        pictureBoxCanvas.Image = canvas;
        pictureBoxCanvas.SizeMode = PictureBoxSizeMode.Zoom;
    }
    
    private void ApplySavedCursor()
    {
        try
        {
            string cursorType = MyApp.Properties.Settings.Default.CursorType;
            
            switch (cursorType)
            {
                case "Tony":
                    this.Cursor = Form1.CreateTonyMaskCursorStatic();
                    break;
                case "Richard":
                    this.Cursor = Form1.CreateRichardMaskCursorStatic();
                    break;
                case "Custom1":
                    var cursor1Path = MyApp.Properties.Settings.Default.CustomCursor1Path;
                    if (!string.IsNullOrEmpty(cursor1Path) && File.Exists(cursor1Path))
                    {
                        this.Cursor = LoadCustomCursorFromPath(cursor1Path);
                    }
                    break;
                case "Custom2":
                    var cursor2Path = MyApp.Properties.Settings.Default.CustomCursor2Path;
                    if (!string.IsNullOrEmpty(cursor2Path) && File.Exists(cursor2Path))
                    {
                        this.Cursor = LoadCustomCursorFromPath(cursor2Path);
                    }
                    break;
                default:
                    this.Cursor = Cursors.Default;
                    break;
            }
            
            SetCursorForAllControls(this, this.Cursor);
        }
        catch
        {
            this.Cursor = Cursors.Default;
        }
    }
    
    private Cursor? LoadCustomCursorFromPath(string imagePath)
    {
        return Form1.CreateCursorFromImageStatic(imagePath);
    }
    
    private void SetCursorForAllControls(Control parent, Cursor cursor)
    {
        foreach (Control control in parent.Controls)
        {
            control.Cursor = cursor;
            SetCursorForAllControls(control, cursor);
        }
    }
    
    private void pictureBoxCanvas_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && canvas != null)
        {
            isDrawing = true;
            // Преобразуем координаты из PictureBox в canvas
            lastPoint = ConvertToCanvasCoordinates(e.Location);
        }
    }
    
    private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDrawing && canvasGraphics != null && canvas != null)
        {
            // Преобразуем координаты из PictureBox в canvas
            Point currentPoint = ConvertToCanvasCoordinates(e.Location);
            
            switch (currentTool)
            {
                case "brush":
                    if (currentPen != null && currentBrush != null)
                    {
                        canvasGraphics.DrawLine(currentPen, lastPoint, currentPoint);
                        // Также рисуем круг для более плавного рисования
                        canvasGraphics.FillEllipse(currentBrush, currentPoint.X - brushSize/2, currentPoint.Y - brushSize/2, brushSize, brushSize);
                    }
                    break;
                case "eraser":
                    using (SolidBrush eraserBrush = new SolidBrush(Color.White))
                    {
                        int eraserSize = brushSize * 2;
                        canvasGraphics.FillEllipse(eraserBrush, currentPoint.X - eraserSize/2, currentPoint.Y - eraserSize/2, eraserSize, eraserSize);
                    }
                    break;
            }
            
            lastPoint = currentPoint;
            pictureBoxCanvas.Invalidate();
        }
    }
    
    private Point ConvertToCanvasCoordinates(Point pictureBoxPoint)
    {
        if (canvas == null) return pictureBoxPoint;
        
        // Получаем размеры PictureBox и canvas
        float scaleX = (float)canvas.Width / pictureBoxCanvas.Width;
        float scaleY = (float)canvas.Height / pictureBoxCanvas.Height;
        
        // Преобразуем координаты
        int canvasX = (int)(pictureBoxPoint.X * scaleX);
        int canvasY = (int)(pictureBoxPoint.Y * scaleY);
        
        // Ограничиваем координаты размерами canvas
        canvasX = Math.Max(0, Math.Min(canvas.Width - 1, canvasX));
        canvasY = Math.Max(0, Math.Min(canvas.Height - 1, canvasY));
        
        return new Point(canvasX, canvasY);
    }
    
    private void pictureBoxCanvas_MouseUp(object sender, MouseEventArgs e)
    {
        isDrawing = false;
    }
    
    private void btnColorBlack_Click(object sender, EventArgs e)
    {
        currentColor = Color.Black;
        UpdateDrawingTools();
        UpdateColorButtons();
    }
    
    private void btnColorRed_Click(object sender, EventArgs e)
    {
        currentColor = Color.Red;
        UpdateDrawingTools();
        UpdateColorButtons();
    }
    
    private void btnColorBlue_Click(object sender, EventArgs e)
    {
        currentColor = Color.Blue;
        UpdateDrawingTools();
        UpdateColorButtons();
    }
    
    private void btnColorGreen_Click(object sender, EventArgs e)
    {
        currentColor = Color.Green;
        UpdateDrawingTools();
        UpdateColorButtons();
    }
    
    private void btnColorYellow_Click(object sender, EventArgs e)
    {
        currentColor = Color.Yellow;
        UpdateColorButtons();
    }
    
    private void btnColorPurple_Click(object sender, EventArgs e)
    {
        currentColor = Color.Purple;
        UpdateColorButtons();
    }
    
    private void btnCustomColor_Click(object sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
                UpdateColorButtons();
            }
        }
    }
    
    private void UpdateColorButtons()
    {
        lblCurrentColor.BackColor = currentColor;
        lblCurrentColor.Text = $"Цвет: {currentColor.Name}";
    }
    
    private void btnBrush_Click(object sender, EventArgs e)
    {
        currentTool = "brush";
        UpdateToolButtons();
    }
    
    private void btnEraser_Click(object sender, EventArgs e)
    {
        currentTool = "eraser";
        UpdateToolButtons();
    }
    
    private void UpdateToolButtons()
    {
        btnBrush.BackColor = currentTool == "brush" ? Color.LightBlue : Color.FromArgb(60, 60, 70);
        btnEraser.BackColor = currentTool == "eraser" ? Color.LightBlue : Color.FromArgb(60, 60, 70);
    }
    
    private void trackBarBrushSize_Scroll(object sender, EventArgs e)
    {
        brushSize = trackBarBrushSize.Value;
        lblBrushSize.Text = $"Размер: {brushSize}px";
        UpdateDrawingTools(); // Обновляем инструменты при изменении размера
    }
    
    private void btnClear_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Очистить холст?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            canvasGraphics?.Clear(Color.White);
            pictureBoxCanvas.Invalidate();
        }
    }
    
    private void btnSave_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog saveDialog = new SaveFileDialog())
        {
            saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            saveDialog.DefaultExt = "png";
            
            if (saveDialog.ShowDialog() == DialogResult.OK && canvas != null)
            {
                canvas.Save(saveDialog.FileName);
                MessageBox.Show("Рисунок сохранен!", "Paint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    
    private void btnLoad_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openDialog = new OpenFileDialog())
        {
            openDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var loadedImage = new Bitmap(openDialog.FileName))
                    {
                        canvas = new Bitmap(800, 600);
                        canvasGraphics?.Dispose();
                        canvasGraphics = Graphics.FromImage(canvas);
                        canvasGraphics.Clear(Color.White);
                        canvasGraphics.DrawImage(loadedImage, 0, 0, 800, 600);
                        pictureBoxCanvas.Image = canvas;
                        pictureBoxCanvas.Invalidate();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка загрузки изображения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // Оптимизация: освобождаем все ресурсы
        currentPen?.Dispose();
        currentBrush?.Dispose();
        canvasGraphics?.Dispose();
        canvas?.Dispose();
        base.OnFormClosed(e);
    }
}