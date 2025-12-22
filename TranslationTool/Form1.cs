using System.Windows.Forms;
using TranslationTool;

namespace TranslationTool
{
    public partial class TranslationToolForm : Form
    {
        private static List<TranslationUnit>? translationUnits;
        private string? originalName;
        private string? targetLangauge;
        private Size formOriginalSize;
        private Rectangle recDataGrid;
        private Rectangle recNoteFilter;
        private Rectangle recNoteFilterLabel;
        private Rectangle recSourceFilter;
        private Rectangle recSourceFilterLabel;
        private Rectangle recTargetFilter;
        private Rectangle recTargetFilterLabel;
        private Rectangle recTargetLanguage;
        private Rectangle recTargetLanguageLabel;
        private Rectangle recShowUntranslated;
        private Rectangle recShowDeveloperNotes;
        private Rectangle recShowChangedRowCheckBox;



        public TranslationToolForm()
        {
            InitializeComponent();
            this.Resize += TranslationToolForm_Resize;
            formOriginalSize = this.Size;
            recDataGrid = new Rectangle(translationUnitList.Location, translationUnitList.Size);
            recNoteFilter = new Rectangle(noteFilter.Location, noteFilter.Size);
            recNoteFilterLabel = new Rectangle(noteFilterLabel.Location, noteFilterLabel.Size);
            recSourceFilter = new Rectangle(sourceFilter.Location, sourceFilter.Size);
            recSourceFilterLabel = new Rectangle(sourceFilterLabel.Location, sourceFilterLabel.Size);
            recTargetFilter = new Rectangle(targetFilter.Location, targetFilter.Size);
            recTargetFilterLabel = new Rectangle(targetFilterLabel.Location, targetFilterLabel.Size);
            recTargetLanguage = new Rectangle(targetLanguageTextBox.Location, targetLanguageTextBox.Size);
            recTargetLanguageLabel = new Rectangle(targetLanguageLabel.Location, targetLanguageLabel.Size);
            recShowUntranslated = new Rectangle(nonTranslatedCheckBox.Location, nonTranslatedCheckBox.Size);
            recShowDeveloperNotes = new Rectangle(developerNoteCheckBox.Location, developerNoteCheckBox.Size);
            recShowChangedRowCheckBox = new Rectangle(showChangedRowCheckBox.Location, showChangedRowCheckBox.Size);
        }

        private void TranslationToolForm_Resize(object? sender, EventArgs e)
        {
            Resize_Control(translationUnitList, recDataGrid);
            Resize_Control(noteFilter, recNoteFilter);
            Resize_Control(noteFilterLabel, recNoteFilterLabel);
            Resize_Control(sourceFilter, recSourceFilter);
            Resize_Control(sourceFilterLabel, recSourceFilterLabel);
            Resize_Control(targetFilter, recTargetFilter);
            Resize_Control(targetFilterLabel, recTargetFilterLabel);
            Resize_Control(targetLanguageTextBox, recTargetLanguage);
            Resize_Control(targetLanguageLabel, recTargetLanguageLabel);
            Resize_Control(nonTranslatedCheckBox, recShowUntranslated);
            Resize_Control(developerNoteCheckBox, recShowDeveloperNotes);
            Resize_Control(showChangedRowCheckBox, recShowChangedRowCheckBox);
        }

        private void Resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }

        private void UploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var parser = new TranslationParser();
                translationUnits = parser.ParseXlfFile(openFileDialog1.FileName, out originalName, out targetLangauge);
                this.bindingSource.DataSource = translationUnits;
                this.translationUnitList.DataSource = this.bindingSource;
                this.translationUnitList.Columns["Id"].Visible = false;
                this.translationUnitList.Columns["AlObjectTarget"].Visible = false;
                this.translationUnitList.Columns["NabToolNote"].Visible = false;
                this.translationUnitList.Columns["DeveloperNote"].Visible = false;
                this.translationUnitList.Columns["IsChanged"].Visible = false;
                this.targetLanguageTextBox.Text = targetLangauge;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var writer = new TranslationWriter();

                foreach (DataGridViewRow row in this.translationUnitList.Rows)
                {
                    if (row.DataBoundItem is TranslationUnit translationUnit)
                    {
                        var targetValue = row.Cells["Target"].Value?.ToString();
                        if (targetValue != null)
                        {
                            translationUnit.Target = targetValue;
                        }
                    }
                }
                if (translationUnits != null)
                {
                    writer.WriteXlfFile(this.saveFileDialog1.FileName, translationUnits, this.targetLanguageTextBox.Text, originalName ?? "");
                }
            }
        }

        private void SourceFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void NoteFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void TargetFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void NonTranslatedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ShowChangedRowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string sourceFilterText = this.sourceFilter.Text;
            string noteFilterText = this.noteFilter.Text;
            string targetFilterText = this.targetFilter.Text;
            bool filterUntranslated = this.nonTranslatedCheckBox.Checked;
            bool showChangedOnly = this.showChangedRowCheckBox.Checked;

            var filteredList = translationUnits?.Where(tu =>
                // Source filter
                (string.IsNullOrEmpty(sourceFilterText) ||
                    (tu.Source != null &&
                     tu.Source.Contains(sourceFilterText, StringComparison.OrdinalIgnoreCase))) &&

                // Target filter
                (string.IsNullOrEmpty(targetFilterText) ||
                    (tu.Target != null &&
                     tu.Target.Contains(targetFilterText, StringComparison.OrdinalIgnoreCase))) &&

                // Note filter
                (string.IsNullOrEmpty(noteFilterText) ||
                    (tu.XliffGeneratorNote != null &&
                     tu.XliffGeneratorNote.Contains(noteFilterText, StringComparison.OrdinalIgnoreCase))) &&

                // Untranslated checkbox
                (!filterUntranslated ||
                    string.IsNullOrEmpty(tu.Target) ||
                    tu.Target.Contains("[NAB")) &&

                // Changed-only checkbox
                (!showChangedOnly || (tu.IsChanged ?? false))
            ).ToList();

            bindingSource.DataSource = filteredList;
        }

        private void DeveloperNoteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.developerNoteCheckBox.Checked)
            {
                if (translationUnitList.Columns["DeveloperNote"] != null)
                {
                    this.translationUnitList.Columns["DeveloperNote"].Visible = true;
                }
            }
            else
            {
                if (translationUnitList.Columns["DeveloperNote"] != null)
                {
                    this.translationUnitList.Columns["DeveloperNote"].Visible = false;
                }
            }
        }

        private void RemoveNABToolTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to remove NAB tool texts?", "Confirm Action", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            var unwantedPrefixes = new HashSet<string>
            {
                "[NAB: SUGGESTION]",
                "[NAB: NOT TRANSLATED]",
                "[NAB: REVIEW]"
            };

            if (translationUnits is not null)
            {
                foreach (var tu in translationUnits)
                {
                    if (tu.Target != null)
                    {
                        foreach (var prefix in unwantedPrefixes)
                        {
                            if (tu.Target.StartsWith(prefix))
                            {
                                tu.Target = tu.Target.Substring(prefix.Length).TrimStart();
                                tu.IsChanged = true;
                                break;
                            }
                        }
                    }
                }
            }

            ApplyFilters(); // Reapply filters to refresh the view
        }

        private void MoveNoteToTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to move Notes into translation Targets? This will only move Notes to untranslated Targets.", "Confirm Action", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            if (translationUnits is not null)
            {
                foreach (var tu in translationUnits)
                {
                    if (tu.DeveloperNote != null)
                    {
                        if (tu.Target == null)
                        {
                            tu.Target = tu.DeveloperNote;
                            tu.IsChanged = true;
                        }
                    }
                }
            }

            ApplyFilters(); // Reapply filters to refresh the view
        }

        private void TranslationUnitList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                translationUnitList.Rows[e.RowIndex].Cells[translationUnitList.Columns["IsChanged"].Index].Value = true;
            }
        }
    }
}