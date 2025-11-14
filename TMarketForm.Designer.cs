namespace MyApp
{
    partial class TMarketForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewApps;
        private Button btnAddToDesktop;
        private Label lblTitle;
        private Label lblAppInfo;
        private Label lblStatus;
        private Panel panelInfo;
        private ComboBox comboBoxCategory;
        private TextBox textBoxSearch;
        private Label lblCategoryFilter;
        private Label lblSearch;

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
            this.listViewApps = new ListView();
            this.btnAddToDesktop = new Button();
            this.lblTitle = new Label();
            this.lblAppInfo = new Label();
            this.lblStatus = new Label();
            this.panelInfo = new Panel();
            this.comboBoxCategory = new ComboBox();
            this.textBoxSearch = new TextBox();
            this.lblCategoryFilter = new Label();
            this.lblSearch = new Label();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            
            // TMarketForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 700);
            this.Text = "TMarket - Магазин приложений TM OS";
            this.BackColor = Color.FromArgb(25, 25, 35);
            this.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = SystemIcons.Application;
            
            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Size = new Size(1000, 70);
            this.lblTitle.Location = new Point(0, 10);
            this.lblTitle.Text = "🛒 TMarket - Магазин приложений";
            this.lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(120, 180, 255);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            // lblCategoryFilter
            this.lblCategoryFilter.Location = new Point(20, 90);
            this.lblCategoryFilter.Size = new Size(100, 25);
            this.lblCategoryFilter.Text = "📂 Категория:";
            this.lblCategoryFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCategoryFilter.ForeColor = Color.LightGray;
            this.lblCategoryFilter.TextAlign = ContentAlignment.MiddleLeft;
            
            // comboBoxCategory
            this.comboBoxCategory.Location = new Point(130, 90);
            this.comboBoxCategory.Size = new Size(150, 28);
            this.comboBoxCategory.BackColor = Color.FromArgb(45, 45, 55);
            this.comboBoxCategory.ForeColor = Color.White;
            this.comboBoxCategory.Font = new Font("Segoe UI", 10F);
            this.comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCategory.Items.AddRange(new object[] { "Все категории", "Утилиты", "Творчество", "Музыка" });
            this.comboBoxCategory.SelectedIndex = 0;
            this.comboBoxCategory.SelectedIndexChanged += new EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            
            // lblSearch
            this.lblSearch.Location = new Point(300, 90);
            this.lblSearch.Size = new Size(80, 25);
            this.lblSearch.Text = "🔍 Поиск:";
            this.lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSearch.ForeColor = Color.LightGray;
            this.lblSearch.TextAlign = ContentAlignment.MiddleLeft;
            
            // textBoxSearch
            this.textBoxSearch.Location = new Point(380, 90);
            this.textBoxSearch.Size = new Size(200, 28);
            this.textBoxSearch.BackColor = Color.FromArgb(45, 45, 55);
            this.textBoxSearch.ForeColor = Color.White;
            this.textBoxSearch.Font = new Font("Segoe UI", 10F);
            this.textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            this.textBoxSearch.TextChanged += new EventHandler(this.textBoxSearch_TextChanged);
            
            // listViewApps
            this.listViewApps.Location = new Point(20, 130);
            this.listViewApps.Size = new Size(650, 450);
            this.listViewApps.BackColor = Color.FromArgb(35, 35, 45);
            this.listViewApps.ForeColor = Color.White;
            this.listViewApps.BorderStyle = BorderStyle.FixedSingle;
            this.listViewApps.MultiSelect = false;
            this.listViewApps.HideSelection = false;
            this.listViewApps.SelectedIndexChanged += new EventHandler(this.listViewApps_SelectedIndexChanged);
            this.listViewApps.DoubleClick += new EventHandler(this.listViewApps_DoubleClick);
            
            // panelInfo
            this.panelInfo.Location = new Point(690, 130);
            this.panelInfo.Size = new Size(290, 450);
            this.panelInfo.BackColor = Color.FromArgb(30, 30, 40);
            this.panelInfo.BorderStyle = BorderStyle.FixedSingle;
            
            // lblAppInfo
            this.lblAppInfo.Location = new Point(10, 10);
            this.lblAppInfo.Size = new Size(270, 350);
            this.lblAppInfo.Text = "Выберите приложение для просмотра информации";
            this.lblAppInfo.Font = new Font("Segoe UI", 11F);
            this.lblAppInfo.ForeColor = Color.LightGray;
            this.lblAppInfo.TextAlign = ContentAlignment.TopLeft;
            
            // btnAddToDesktop
            this.btnAddToDesktop.Location = new Point(10, 370);
            this.btnAddToDesktop.Size = new Size(270, 60);
            this.btnAddToDesktop.Text = "⬇️ Загрузить на рабочий стол";
            this.btnAddToDesktop.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnAddToDesktop.BackColor = Color.FromArgb(120, 180, 255);
            this.btnAddToDesktop.ForeColor = Color.White;
            this.btnAddToDesktop.FlatStyle = FlatStyle.Flat;
            this.btnAddToDesktop.FlatAppearance.BorderSize = 0;
            this.btnAddToDesktop.Enabled = false;
            this.btnAddToDesktop.Click += new EventHandler(this.btnAddToDesktop_Click);
            
            // lblStatus
            this.lblStatus.Location = new Point(20, 600);
            this.lblStatus.Size = new Size(960, 50);
            this.lblStatus.Text = "💡 Выберите приложение и нажмите 'Загрузить на рабочий стол'";
            this.lblStatus.Font = new Font("Segoe UI", 12F);
            this.lblStatus.ForeColor = Color.FromArgb(120, 180, 255);
            this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            
            // Добавляем элементы управления
            this.panelInfo.Controls.Add(this.lblAppInfo);
            this.panelInfo.Controls.Add(this.btnAddToDesktop);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCategoryFilter);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.listViewApps);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.lblStatus);
            
            this.panelInfo.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}