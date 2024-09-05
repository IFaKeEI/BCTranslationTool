using System.Windows.Forms;

namespace TranslationTool
{
    partial class TranslationToolForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslationToolForm));
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            uploadToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            source = new ColumnHeader();
            target = new ColumnHeader();
            translationUnitList = new DataGridView();
            bindingSource = new BindingSource(components);
            sourceFilter = new TextBox();
            noteFilterLabel = new Label();
            noteFilter = new TextBox();
            targetFilter = new TextBox();
            sourceFilterLabel = new Label();
            targetFilterLabel = new Label();
            nonTranslatedCheckBox = new CheckBox();
            developerNoteCheckBox = new CheckBox();
            targetLanguageTextBox = new TextBox();
            targetLanguageLabel = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)translationUnitList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "xlf";
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "xlf files (*.xlf)|*.xlf";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1057, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uploadToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 19);
            fileToolStripMenuItem.Text = "File";
            // 
            // uploadToolStripMenuItem
            // 
            uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            uploadToolStripMenuItem.Size = new Size(114, 22);
            uploadToolStripMenuItem.Text = "Upload";
            uploadToolStripMenuItem.Click += UploadToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // source
            // 
            source.Text = "Source";
            // 
            // target
            // 
            target.Text = "Target";
            // 
            // translationUnitList
            // 
            translationUnitList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            translationUnitList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            translationUnitList.Location = new Point(14, 109);
            translationUnitList.Margin = new Padding(4, 3, 4, 3);
            translationUnitList.Name = "translationUnitList";
            translationUnitList.RowTemplate.Height = 25;
            translationUnitList.Size = new Size(1036, 621);
            translationUnitList.TabIndex = 2;
            // 
            // sourceFilter
            // 
            sourceFilter.Location = new Point(378, 80);
            sourceFilter.Margin = new Padding(4, 3, 4, 3);
            sourceFilter.Name = "sourceFilter";
            sourceFilter.Size = new Size(144, 23);
            sourceFilter.TabIndex = 5;
            sourceFilter.TextChanged += TxtFilter_TextChanged;
            // 
            // noteFilterLabel
            // 
            noteFilterLabel.AutoSize = true;
            noteFilterLabel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            noteFilterLabel.Location = new Point(52, 61);
            noteFilterLabel.Margin = new Padding(4, 0, 4, 0);
            noteFilterLabel.Name = "noteFilterLabel";
            noteFilterLabel.Size = new Size(81, 16);
            noteFilterLabel.TabIndex = 4;
            noteFilterLabel.Text = "Note Filter";
            // 
            // noteFilter
            // 
            noteFilter.Location = new Point(52, 80);
            noteFilter.Margin = new Padding(4, 3, 4, 3);
            noteFilter.Name = "noteFilter";
            noteFilter.Size = new Size(144, 23);
            noteFilter.TabIndex = 3;
            noteFilter.TextChanged += NoteFilter_TextChanged;
            // 
            // targetFilter
            // 
            targetFilter.Location = new Point(700, 80);
            targetFilter.Margin = new Padding(4, 3, 4, 3);
            targetFilter.Name = "targetFilter";
            targetFilter.Size = new Size(144, 23);
            targetFilter.TabIndex = 6;
            targetFilter.TextChanged += TargetFilter_TextChanged;
            // 
            // sourceFilterLabel
            // 
            sourceFilterLabel.AutoSize = true;
            sourceFilterLabel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            sourceFilterLabel.Location = new Point(378, 61);
            sourceFilterLabel.Margin = new Padding(4, 0, 4, 0);
            sourceFilterLabel.Name = "sourceFilterLabel";
            sourceFilterLabel.Size = new Size(98, 16);
            sourceFilterLabel.TabIndex = 7;
            sourceFilterLabel.Text = "Source Filter";
            // 
            // targetFilterLabel
            // 
            targetFilterLabel.AutoSize = true;
            targetFilterLabel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            targetFilterLabel.Location = new Point(700, 61);
            targetFilterLabel.Margin = new Padding(4, 0, 4, 0);
            targetFilterLabel.Name = "targetFilterLabel";
            targetFilterLabel.Size = new Size(92, 16);
            targetFilterLabel.TabIndex = 8;
            targetFilterLabel.Text = "Target Filter";
            // 
            // nonTranslatedCheckBox
            // 
            nonTranslatedCheckBox.AutoSize = true;
            nonTranslatedCheckBox.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            nonTranslatedCheckBox.Location = new Point(850, 54);
            nonTranslatedCheckBox.Margin = new Padding(4, 3, 4, 3);
            nonTranslatedCheckBox.Name = "nonTranslatedCheckBox";
            nonTranslatedCheckBox.Size = new Size(157, 20);
            nonTranslatedCheckBox.TabIndex = 10;
            nonTranslatedCheckBox.Text = "Show untranslated";
            nonTranslatedCheckBox.UseVisualStyleBackColor = true;
            nonTranslatedCheckBox.CheckedChanged += NonTranslatedCheckBox_CheckedChanged;
            // 
            // developerNoteCheckBox
            // 
            developerNoteCheckBox.AutoSize = true;
            developerNoteCheckBox.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            developerNoteCheckBox.Location = new Point(850, 80);
            developerNoteCheckBox.Margin = new Padding(4, 3, 4, 3);
            developerNoteCheckBox.Name = "developerNoteCheckBox";
            developerNoteCheckBox.Size = new Size(187, 20);
            developerNoteCheckBox.TabIndex = 11;
            developerNoteCheckBox.Text = "Show Developer Notes";
            developerNoteCheckBox.UseVisualStyleBackColor = true;
            developerNoteCheckBox.CheckedChanged += DeveloperNoteCheckBox_CheckedChanged;
            // 
            // targetLanguageTextBox
            // 
            targetLanguageTextBox.Location = new Point(973, 29);
            targetLanguageTextBox.Margin = new Padding(4, 3, 4, 3);
            targetLanguageTextBox.Name = "targetLanguageTextBox";
            targetLanguageTextBox.Size = new Size(67, 23);
            targetLanguageTextBox.TabIndex = 9;
            // 
            // targetLanguageLabel
            // 
            targetLanguageLabel.AutoSize = true;
            targetLanguageLabel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            targetLanguageLabel.Location = new Point(850, 29);
            targetLanguageLabel.Margin = new Padding(4, 0, 4, 0);
            targetLanguageLabel.Name = "targetLanguageLabel";
            targetLanguageLabel.Size = new Size(124, 16);
            targetLanguageLabel.TabIndex = 12;
            targetLanguageLabel.Text = "Target Langauge";
            // 
            // TranslationToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 739);
            Controls.Add(targetLanguageLabel);
            Controls.Add(targetLanguageTextBox);
            Controls.Add(developerNoteCheckBox);
            Controls.Add(nonTranslatedCheckBox);
            Controls.Add(targetFilterLabel);
            Controls.Add(sourceFilterLabel);
            Controls.Add(targetFilter);
            Controls.Add(noteFilter);
            Controls.Add(noteFilterLabel);
            Controls.Add(sourceFilter);
            Controls.Add(translationUnitList);
            Controls.Add(menuStrip1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "TranslationToolForm";
            Text = "Translation Tool";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)translationUnitList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem uploadToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ColumnHeader source;
        private ColumnHeader target;
        private DataGridView translationUnitList;
        private BindingSource bindingSource;
        private TextBox sourceFilter;
        private Label noteFilterLabel;
        private TextBox noteFilter;
        private TextBox targetFilter;
        private Label sourceFilterLabel;
        private Label targetFilterLabel;
        private CheckBox nonTranslatedCheckBox;
        private CheckBox developerNoteCheckBox;
        private TextBox targetLanguageTextBox;
        private Label targetLanguageLabel;
    }
}