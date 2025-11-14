namespace MyApp;

partial class CalculatorForm
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
        this.txtDisplay = new System.Windows.Forms.TextBox();
        this.btn7 = new System.Windows.Forms.Button();
        this.btn8 = new System.Windows.Forms.Button();
        this.btn9 = new System.Windows.Forms.Button();
        this.btnDivide = new System.Windows.Forms.Button();
        this.btn4 = new System.Windows.Forms.Button();
        this.btn5 = new System.Windows.Forms.Button();
        this.btn6 = new System.Windows.Forms.Button();
        this.btnMultiply = new System.Windows.Forms.Button();
        this.btn1 = new System.Windows.Forms.Button();
        this.btn2 = new System.Windows.Forms.Button();
        this.btn3 = new System.Windows.Forms.Button();
        this.btnSubtract = new System.Windows.Forms.Button();
        this.btn0 = new System.Windows.Forms.Button();
        this.btnDecimal = new System.Windows.Forms.Button();
        this.btnEquals = new System.Windows.Forms.Button();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();
        this.SuspendLayout();
        
        // txtDisplay
        this.txtDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
        this.txtDisplay.Location = new System.Drawing.Point(20, 20);
        this.txtDisplay.Name = "txtDisplay";
        this.txtDisplay.ReadOnly = true;
        this.txtDisplay.Size = new System.Drawing.Size(240, 29);
        this.txtDisplay.TabIndex = 0;
        this.txtDisplay.Text = "0";
        this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        
        // btnClear
        this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnClear.Location = new System.Drawing.Point(20, 60);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(240, 40);
        this.btnClear.TabIndex = 1;
        this.btnClear.Text = "C";
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += new System.EventHandler(this.ClearButton_Click);
        
        // btn7
        this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn7.Location = new System.Drawing.Point(20, 110);
        this.btn7.Name = "btn7";
        this.btn7.Size = new System.Drawing.Size(50, 50);
        this.btn7.TabIndex = 2;
        this.btn7.Text = "7";
        this.btn7.UseVisualStyleBackColor = true;
        this.btn7.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btn8
        this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn8.Location = new System.Drawing.Point(80, 110);
        this.btn8.Name = "btn8";
        this.btn8.Size = new System.Drawing.Size(50, 50);
        this.btn8.TabIndex = 3;
        this.btn8.Text = "8";
        this.btn8.UseVisualStyleBackColor = true;
        this.btn8.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btn9
        this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn9.Location = new System.Drawing.Point(140, 110);
        this.btn9.Name = "btn9";
        this.btn9.Size = new System.Drawing.Size(50, 50);
        this.btn9.TabIndex = 4;
        this.btn9.Text = "9";
        this.btn9.UseVisualStyleBackColor = true;
        this.btn9.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btnDivide
        this.btnDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnDivide.Location = new System.Drawing.Point(200, 110);
        this.btnDivide.Name = "btnDivide";
        this.btnDivide.Size = new System.Drawing.Size(50, 50);
        this.btnDivide.TabIndex = 5;
        this.btnDivide.Text = "/";
        this.btnDivide.UseVisualStyleBackColor = true;
        this.btnDivide.Click += new System.EventHandler(this.OperationButton_Click);
        
        // btn4
        this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn4.Location = new System.Drawing.Point(20, 170);
        this.btn4.Name = "btn4";
        this.btn4.Size = new System.Drawing.Size(50, 50);
        this.btn4.TabIndex = 6;
        this.btn4.Text = "4";
        this.btn4.UseVisualStyleBackColor = true;
        this.btn4.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btn5
        this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn5.Location = new System.Drawing.Point(80, 170);
        this.btn5.Name = "btn5";
        this.btn5.Size = new System.Drawing.Size(50, 50);
        this.btn5.TabIndex = 7;
        this.btn5.Text = "5";
        this.btn5.UseVisualStyleBackColor = true;
        this.btn5.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btn6
        this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn6.Location = new System.Drawing.Point(140, 170);
        this.btn6.Name = "btn6";
        this.btn6.Size = new System.Drawing.Size(50, 50);
        this.btn6.TabIndex = 8;
        this.btn6.Text = "6";
        this.btn6.UseVisualStyleBackColor = true;
        this.btn6.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btnMultiply
        this.btnMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnMultiply.Location = new System.Drawing.Point(200, 170);
        this.btnMultiply.Name = "btnMultiply";
        this.btnMultiply.Size = new System.Drawing.Size(50, 50);
        this.btnMultiply.TabIndex = 9;
        this.btnMultiply.Text = "*";
        this.btnMultiply.UseVisualStyleBackColor = true;
        this.btnMultiply.Click += new System.EventHandler(this.OperationButton_Click);
        
        // btn1
        this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn1.Location = new System.Drawing.Point(20, 230);
        this.btn1.Name = "btn1";
        this.btn1.Size = new System.Drawing.Size(50, 50);
        this.btn1.TabIndex = 10;
        this.btn1.Text = "1";
        this.btn1.UseVisualStyleBackColor = true;
        this.btn1.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btn2
        this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn2.Location = new System.Drawing.Point(80, 230);
        this.btn2.Name = "btn2";
        this.btn2.Size = new System.Drawing.Size(50, 50);
        this.btn2.TabIndex = 11;
        this.btn2.Text = "2";
        this.btn2.UseVisualStyleBackColor = true;
        this.btn2.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btn3
        this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn3.Location = new System.Drawing.Point(140, 230);
        this.btn3.Name = "btn3";
        this.btn3.Size = new System.Drawing.Size(50, 50);
        this.btn3.TabIndex = 12;
        this.btn3.Text = "3";
        this.btn3.UseVisualStyleBackColor = true;
        this.btn3.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btnSubtract
        this.btnSubtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnSubtract.Location = new System.Drawing.Point(200, 230);
        this.btnSubtract.Name = "btnSubtract";
        this.btnSubtract.Size = new System.Drawing.Size(50, 50);
        this.btnSubtract.TabIndex = 13;
        this.btnSubtract.Text = "-";
        this.btnSubtract.UseVisualStyleBackColor = true;
        this.btnSubtract.Click += new System.EventHandler(this.OperationButton_Click);
        
        // btn0
        this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btn0.Location = new System.Drawing.Point(20, 290);
        this.btn0.Name = "btn0";
        this.btn0.Size = new System.Drawing.Size(50, 50);
        this.btn0.TabIndex = 14;
        this.btn0.Text = "0";
        this.btn0.UseVisualStyleBackColor = true;
        this.btn0.Click += new System.EventHandler(this.NumberButton_Click);
        
        // btnDecimal
        this.btnDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnDecimal.Location = new System.Drawing.Point(80, 290);
        this.btnDecimal.Name = "btnDecimal";
        this.btnDecimal.Size = new System.Drawing.Size(50, 50);
        this.btnDecimal.TabIndex = 15;
        this.btnDecimal.Text = ".";
        this.btnDecimal.UseVisualStyleBackColor = true;
        this.btnDecimal.Click += new System.EventHandler(this.DecimalButton_Click);
        
        // btnEquals
        this.btnEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnEquals.Location = new System.Drawing.Point(140, 290);
        this.btnEquals.Name = "btnEquals";
        this.btnEquals.Size = new System.Drawing.Size(50, 50);
        this.btnEquals.TabIndex = 16;
        this.btnEquals.Text = "=";
        this.btnEquals.UseVisualStyleBackColor = true;
        this.btnEquals.Click += new System.EventHandler(this.EqualsButton_Click);
        
        // btnAdd
        this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.btnAdd.Location = new System.Drawing.Point(200, 290);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(50, 50);
        this.btnAdd.TabIndex = 17;
        this.btnAdd.Text = "+";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.OperationButton_Click);
        
        // CalculatorForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 361);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnEquals);
        this.Controls.Add(this.btnDecimal);
        this.Controls.Add(this.btn0);
        this.Controls.Add(this.btnSubtract);
        this.Controls.Add(this.btn3);
        this.Controls.Add(this.btn2);
        this.Controls.Add(this.btn1);
        this.Controls.Add(this.btnMultiply);
        this.Controls.Add(this.btn6);
        this.Controls.Add(this.btn5);
        this.Controls.Add(this.btn4);
        this.Controls.Add(this.btnDivide);
        this.Controls.Add(this.btn9);
        this.Controls.Add(this.btn8);
        this.Controls.Add(this.btn7);
        this.Controls.Add(this.btnClear);
        this.Controls.Add(this.txtDisplay);
        this.Name = "CalculatorForm";
        this.Text = "Калькулятор";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtDisplay;
    private System.Windows.Forms.Button btn7;
    private System.Windows.Forms.Button btn8;
    private System.Windows.Forms.Button btn9;
    private System.Windows.Forms.Button btnDivide;
    private System.Windows.Forms.Button btn4;
    private System.Windows.Forms.Button btn5;
    private System.Windows.Forms.Button btn6;
    private System.Windows.Forms.Button btnMultiply;
    private System.Windows.Forms.Button btn1;
    private System.Windows.Forms.Button btn2;
    private System.Windows.Forms.Button btn3;
    private System.Windows.Forms.Button btnSubtract;
    private System.Windows.Forms.Button btn0;
    private System.Windows.Forms.Button btnDecimal;
    private System.Windows.Forms.Button btnEquals;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnClear;
}