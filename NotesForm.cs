using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;

namespace MyApp
{
    public partial class NotesForm : Form
    {
        private const string NotesFolder = "Notes";
        private const string NotesFile = "notes.json";
        private List<Note> notes = new List<Note>();
        private Note? currentNote = null;
        private bool isModified = false;

        public NotesForm()
        {
            InitializeComponent();
            InitializeNotesApp();
        }

        private void InitializeNotesApp()
        {
            // Настройки формы
            this.Text = "📝 Заметки - TM OS";
            this.Size = new Size(900, 600);
            this.MinimumSize = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Загружаем заметки
            LoadNotes();
            RefreshNotesList();

            // Применяем стили
            ApplyModernStyles();

            // Устанавливаем обработчики событий
            SetupEventHandlers();

            // Если есть заметки, выбираем первую
            if (notes.Count > 0)
            {
                SelectNote(notes[0]);
            }
            else
            {
                NewNote();
            }
        }

        private void ApplyModernStyles()
        {
            // Стиль для кнопок
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    StyleButton(btn);
                }
                else if (control is TextBox txt)
                {
                    StyleTextBox(txt);
                }
                else if (control is ListBox list)
                {
                    StyleListBox(list);
                }
            }
        }

        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;

            // Разные стили для разных кнопок
            if (btn.Name.Contains("Delete"))
            {
                btn.BackColor = Color.FromArgb(231, 76, 60);
                btn.ForeColor = Color.White;
            }
            else if (btn.Name.Contains("New") || btn.Name.Contains("Save"))
            {
                btn.BackColor = Color.FromArgb(52, 152, 219);
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.FromArgb(149, 165, 166);
                btn.ForeColor = Color.White;
            }
        }

        private void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.None;
            txt.Font = new Font("Segoe UI", 10F);
            txt.BackColor = Color.White;
        }

        private void StyleListBox(ListBox list)
        {
            list.BorderStyle = BorderStyle.None;
            list.Font = new Font("Segoe UI", 10F);
            list.BackColor = Color.White;
        }

        private void SetupEventHandlers()
        {
            // Обработчик изменения текста
            txtNoteContent.TextChanged += (s, e) => {
                isModified = true;
                UpdateTitle();
            };

            txtNoteTitle.TextChanged += (s, e) => {
                isModified = true;
                if (currentNote != null)
                {
                    currentNote.Title = txtNoteTitle.Text;
                    RefreshNotesList();
                }
                UpdateTitle();
            };

            // Автосохранение каждые 5 секунд
            System.Windows.Forms.Timer autoSaveTimer = new System.Windows.Forms.Timer();
            autoSaveTimer.Interval = 5000; // 5 секунд
            autoSaveTimer.Tick += (s, e) => {
                if (isModified && currentNote != null)
                {
                    SaveCurrentNote();
                }
            };
            autoSaveTimer.Start();

            // Обработчик закрытия формы
            this.FormClosing += (s, e) => {
                if (isModified && currentNote != null)
                {
                    SaveCurrentNote();
                }
                SaveNotes();
            };
        }

        private void UpdateTitle()
        {
            string title = "📝 Заметки - TM OS";
            if (currentNote != null)
            {
                title += $" - {currentNote.Title}";
                if (isModified)
                {
                    title += " *";
                }
            }
            this.Text = title;
        }

        private void NewNote()
        {
            if (isModified && currentNote != null)
            {
                SaveCurrentNote();
            }

            var note = new Note
            {
                Id = Guid.NewGuid().ToString(),
                Title = $"Новая заметка {notes.Count + 1}",
                Content = "",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            notes.Insert(0, note);
            RefreshNotesList();
            SelectNote(note);
            txtNoteTitle.Focus();
            txtNoteTitle.SelectAll();
        }

        private void DeleteNote()
        {
            if (currentNote == null) return;

            var result = MessageBox.Show(
                $"Удалить заметку \"{currentNote.Title}\"?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                notes.Remove(currentNote);
                RefreshNotesList();

                if (notes.Count > 0)
                {
                    SelectNote(notes[0]);
                }
                else
                {
                    NewNote();
                }

                SaveNotes();
            }
        }

        private void SaveCurrentNote()
        {
            if (currentNote != null)
            {
                currentNote.Content = txtNoteContent.Text;
                currentNote.ModifiedDate = DateTime.Now;
                isModified = false;
                UpdateTitle();
                RefreshNotesList();
            }
        }

        private void SelectNote(Note note)
        {
            if (isModified && currentNote != null)
            {
                SaveCurrentNote();
            }

            currentNote = note;
            txtNoteTitle.Text = note.Title;
            txtNoteContent.Text = note.Content;
            isModified = false;
            UpdateTitle();

            // Выделяем в списке
            lstNotes.SelectedItem = note;
        }

        private void RefreshNotesList()
        {
            var selectedNote = currentNote;
            lstNotes.DataSource = null;
            lstNotes.DataSource = notes.OrderByDescending(n => n.ModifiedDate).ToList();
            lstNotes.DisplayMember = "DisplayText";
            
            if (selectedNote != null)
            {
                lstNotes.SelectedItem = selectedNote;
            }
        }

        private void LoadNotes()
        {
            try
            {
                string notesPath = Path.Combine(Application.StartupPath, NotesFolder);
                string filePath = Path.Combine(notesPath, NotesFile);

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    var loadedNotes = JsonSerializer.Deserialize<List<Note>>(json);
                    if (loadedNotes != null)
                    {
                        notes = loadedNotes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заметок: {ex.Message}");
            }
        }

        private void SaveNotes()
        {
            try
            {
                string notesPath = Path.Combine(Application.StartupPath, NotesFolder);
                if (!Directory.Exists(notesPath))
                {
                    Directory.CreateDirectory(notesPath);
                }

                string filePath = Path.Combine(notesPath, NotesFile);
                string json = JsonSerializer.Serialize(notes, new JsonSerializerOptions 
                { 
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
                
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении заметок: {ex.Message}");
            }
        }

        // Обработчики событий кнопок
        private void btnNewNote_Click(object sender, EventArgs e)
        {
            NewNote();
        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            DeleteNote();
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            SaveCurrentNote();
            SaveNotes();
            MessageBox.Show("Заметка сохранена!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is Note note)
            {
                SelectNote(note);
            }
        }

        // Переопределяем Paint для красивого фона
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(245, 245, 245),
                Color.FromArgb(235, 235, 235),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }

    // Класс для хранения заметки
    public class Note
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string DisplayText => $"{Title} ({ModifiedDate:dd.MM.yyyy HH:mm})";
    }
}