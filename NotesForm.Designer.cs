namespace MyApp
{
    partial class NotesForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox lstNotes;
        private TextBox txtNoteTitle;
        private TextBox txtNoteContent;
        private Button btnNewNote;
        private Button btnDeleteNote;
        private Button btnSaveNote;
        private Label lblNotesList;
        private Label lblNoteTitle;
        private Label lblNoteContent;
        private Panel pnlSidebar;
        private Panel pnlMain;

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
            this.lstNotes = new ListBox();
            this.txtNoteTitle = new TextBox();
            this.txtNoteContent = new TextBox();
            this.btnNewNote = new Button();
            this.btnDeleteNote = new Button();
            this.btnSaveNote = new Button();
            this.lblNotesList = new Label();
            this.lblNoteTitle = new Label();
            this.lblNoteContent = new Label();
            this.pnlSidebar = new Panel();
            this.pnlMain = new Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.pnlSidebar.Controls.Add(this.lblNotesList);
            this.pnlSidebar.Controls.Add(this.lstNotes);
            this.pnlSidebar.Controls.Add(this.btnNewNote);
            this.pnlSidebar.Controls.Add(this.btnDeleteNote);
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 600);
            this.pnlSidebar.TabIndex = 0;
            
            // 
            // lblNotesList
            // 
            this.lblNotesList.BackColor = System.Drawing.Color.Transparent;
            this.lblNotesList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNotesList.ForeColor = System.Drawing.Color.White;
            this.lblNotesList.Location = new System.Drawing.Point(10, 10);
            this.lblNotesList.Name = "lblNotesList";
            this.lblNotesList.Size = new System.Drawing.Size(230, 30);
            this.lblNotesList.TabIndex = 0;
            this.lblNotesList.Text = "📝 Список заметок";
            this.lblNotesList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // 
            // lstNotes
            // 
            this.lstNotes.BackColor = System.Drawing.Color.White;
            this.lstNotes.BorderStyle = BorderStyle.None;
            this.lstNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstNotes.Location = new System.Drawing.Point(10, 50);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(230, 450);
            this.lstNotes.TabIndex = 1;
            this.lstNotes.SelectedIndexChanged += new System.EventHandler(this.lstNotes_SelectedIndexChanged);
            
            // 
            // btnNewNote
            // 
            this.btnNewNote.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnNewNote.FlatAppearance.BorderSize = 0;
            this.btnNewNote.FlatStyle = FlatStyle.Flat;
            this.btnNewNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNewNote.ForeColor = System.Drawing.Color.White;
            this.btnNewNote.Location = new System.Drawing.Point(10, 515);
            this.btnNewNote.Name = "btnNewNote";
            this.btnNewNote.Size = new System.Drawing.Size(110, 35);
            this.btnNewNote.TabIndex = 2;
            this.btnNewNote.Text = "➕ Новая";
            this.btnNewNote.UseVisualStyleBackColor = false;
            this.btnNewNote.Click += new System.EventHandler(this.btnNewNote_Click);
            
            // 
            // btnDeleteNote
            // 
            this.btnDeleteNote.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDeleteNote.FlatAppearance.BorderSize = 0;
            this.btnDeleteNote.FlatStyle = FlatStyle.Flat;
            this.btnDeleteNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteNote.ForeColor = System.Drawing.Color.White;
            this.btnDeleteNote.Location = new System.Drawing.Point(130, 515);
            this.btnDeleteNote.Name = "btnDeleteNote";
            this.btnDeleteNote.Size = new System.Drawing.Size(110, 35);
            this.btnDeleteNote.TabIndex = 3;
            this.btnDeleteNote.Text = "🗑️ Удалить";
            this.btnDeleteNote.UseVisualStyleBackColor = false;
            this.btnDeleteNote.Click += new System.EventHandler(this.btnDeleteNote_Click);
            
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblNoteTitle);
            this.pnlMain.Controls.Add(this.txtNoteTitle);
            this.pnlMain.Controls.Add(this.lblNoteContent);
            this.pnlMain.Controls.Add(this.txtNoteContent);
            this.pnlMain.Controls.Add(this.btnSaveNote);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(250, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(650, 600);
            this.pnlMain.TabIndex = 1;
            
            // 
            // lblNoteTitle
            // 
            this.lblNoteTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoteTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblNoteTitle.Location = new System.Drawing.Point(20, 10);
            this.lblNoteTitle.Name = "lblNoteTitle";
            this.lblNoteTitle.Size = new System.Drawing.Size(610, 30);
            this.lblNoteTitle.TabIndex = 0;
            this.lblNoteTitle.Text = "📋 Заголовок заметки";
            this.lblNoteTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // 
            // txtNoteTitle
            // 
            this.txtNoteTitle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.txtNoteTitle.BorderStyle = BorderStyle.None;
            this.txtNoteTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtNoteTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.txtNoteTitle.Location = new System.Drawing.Point(20, 50);
            this.txtNoteTitle.Name = "txtNoteTitle";
            this.txtNoteTitle.Size = new System.Drawing.Size(610, 25);
            this.txtNoteTitle.TabIndex = 1;
            
            // 
            // lblNoteContent
            // 
            this.lblNoteContent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoteContent.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblNoteContent.Location = new System.Drawing.Point(20, 90);
            this.lblNoteContent.Name = "lblNoteContent";
            this.lblNoteContent.Size = new System.Drawing.Size(610, 30);
            this.lblNoteContent.TabIndex = 2;
            this.lblNoteContent.Text = "📝 Содержание заметки";
            this.lblNoteContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            // 
            // txtNoteContent
            // 
            this.txtNoteContent.BackColor = System.Drawing.Color.White;
            this.txtNoteContent.BorderStyle = BorderStyle.None;
            this.txtNoteContent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNoteContent.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.txtNoteContent.Location = new System.Drawing.Point(20, 130);
            this.txtNoteContent.Multiline = true;
            this.txtNoteContent.Name = "txtNoteContent";
            this.txtNoteContent.ScrollBars = ScrollBars.Vertical;
            this.txtNoteContent.Size = new System.Drawing.Size(610, 410);
            this.txtNoteContent.TabIndex = 3;
            
            // 
            // btnSaveNote
            // 
            this.btnSaveNote.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnSaveNote.FlatAppearance.BorderSize = 0;
            this.btnSaveNote.FlatStyle = FlatStyle.Flat;
            this.btnSaveNote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveNote.ForeColor = System.Drawing.Color.White;
            this.btnSaveNote.Location = new System.Drawing.Point(520, 550);
            this.btnSaveNote.Name = "btnSaveNote";
            this.btnSaveNote.Size = new System.Drawing.Size(110, 40);
            this.btnSaveNote.TabIndex = 4;
            this.btnSaveNote.Text = "💾 Сохранить";
            this.btnSaveNote.UseVisualStyleBackColor = false;
            this.btnSaveNote.Click += new System.EventHandler(this.btnSaveNote_Click);
            
            // 
            // NotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "NotesForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "📝 Заметки - TM OS";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}