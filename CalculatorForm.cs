namespace MyApp;

public partial class CalculatorForm : Form
{
    private string currentInput = "";
    private string operation = "";
    private double firstNumber = 0;
    private bool isNewOperation = true;

    public CalculatorForm()
    {
        InitializeComponent();
        this.Text = "Калькулятор";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
        
        // Устанавливаем сохраненный курсор для формы и всех элементов
        ApplySavedCursor();
    }

    private void ApplySavedCursor()
    {
        try
        {
            string cursorType = MyApp.Properties.Settings.Default.CursorType;
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
                    selectedCursor = LoadCustomCursorFromPath(MyApp.Properties.Settings.Default.CustomCursor1Path);
                    break;
                case "Custom2":
                    selectedCursor = LoadCustomCursorFromPath(MyApp.Properties.Settings.Default.CustomCursor2Path);
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

    private void NumberButton_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string number = btn.Text;

        if (isNewOperation)
        {
            txtDisplay.Text = "";
            isNewOperation = false;
        }

        if (txtDisplay.Text == "0")
            txtDisplay.Text = number;
        else
            txtDisplay.Text += number;
    }

    private void OperationButton_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string newOperation = btn.Text;

        if (!isNewOperation)
        {
            firstNumber = double.Parse(txtDisplay.Text);
            operation = newOperation;
            isNewOperation = true;
        }
    }

    private void EqualsButton_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(operation) && !isNewOperation)
        {
            double secondNumber = double.Parse(txtDisplay.Text);
            double result = 0;

            // Пасхалка для 2+2
            if (firstNumber == 2 && secondNumber == 2 && operation == "+")
            {
                txtDisplay.Text = "Ну не знаю, может 5 или 6";
                operation = "";
                isNewOperation = true;
                return;
            }

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                    {
                        MessageBox.Show("Деление на ноль невозможно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            }

            txtDisplay.Text = result.ToString();
            operation = "";
            isNewOperation = true;
        }
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        txtDisplay.Text = "0";
        currentInput = "";
        operation = "";
        firstNumber = 0;
        isNewOperation = true;
    }

    private void DecimalButton_Click(object sender, EventArgs e)
    {
        if (isNewOperation)
        {
            txtDisplay.Text = "0";
            isNewOperation = false;
        }

        if (!txtDisplay.Text.Contains("."))
            txtDisplay.Text += ".";
    }
}