using System.Windows.Forms;
using TranslationTool;

namespace TranslationTool
{
    public partial class TranslationToolForm : Form
    {
        private static List<TranslationUnit>? translationUnits;
        private string? originalName;
        private string? targetLangauge;
        public TranslationToolForm()
        {
            InitializeComponent();
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

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = this.sourceFilter.Text;

            var filteredList = translationUnits?.Where(tu => tu.Source != null && tu.Source.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();

            this.bindingSource.DataSource = filteredList;
            this.translationUnitList.DataSource = bindingSource;
        }

        private void NoteFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = this.noteFilter.Text;

            var filteredList = translationUnits?.Where(tu => tu.XliffGeneratorNote != null && tu.XliffGeneratorNote.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();

            this.bindingSource.DataSource = filteredList;
            this.translationUnitList.DataSource = bindingSource;
        }

        private void TargetFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = this.targetFilter.Text;

            var filteredList = translationUnits?.Where(tu => tu.Target != null && tu.Target.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();

            this.bindingSource.DataSource = filteredList;
            this.translationUnitList.DataSource = bindingSource;
        }

        private void NonTranslatedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.nonTranslatedCheckBox.Checked)
            {
                var filteredUnits = translationUnits?.Where(tu => string.IsNullOrEmpty(tu.Target) || tu.Target.Contains("[NAB")).ToList();
                bindingSource.DataSource = filteredUnits;
            }
            else
            {
                bindingSource.DataSource = translationUnits;
            }
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
    }
}