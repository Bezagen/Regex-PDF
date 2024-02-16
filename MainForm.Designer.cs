
namespace PDFReader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openPdfFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.saveExcelFile = new System.Windows.Forms.SaveFileDialog();
            this.MenuPanel = new System.Windows.Forms.MenuStrip();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDataGridItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToExcelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowParametersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugBox = new PDFReader.CustomUserControls.NoScrollRichTextBox();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openPdfFile
            // 
            this.openPdfFile.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vesion: PreRelease 1.0";
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.MenuPanel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem});
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuPanel.Size = new System.Drawing.Size(800, 27);
            this.MenuPanel.TabIndex = 6;
            this.MenuPanel.Text = "menuStrip1";
            // 
            // MenuItem
            // 
            this.MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectFileItem,
            this.ShowDataGridItem,
            this.ExportToExcelItem,
            this.toolStripSeparator1,
            this.ShowParametersItem});
            this.MenuItem.ForeColor = System.Drawing.Color.White;
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.Size = new System.Drawing.Size(57, 23);
            this.MenuItem.Text = "Меню";
            // 
            // SelectFileItem
            // 
            this.SelectFileItem.BackColor = System.Drawing.SystemColors.Control;
            this.SelectFileItem.ForeColor = System.Drawing.Color.White;
            this.SelectFileItem.Name = "SelectFileItem";
            this.SelectFileItem.Size = new System.Drawing.Size(240, 24);
            this.SelectFileItem.Text = "Выбрать файл";
            this.SelectFileItem.Click += new System.EventHandler(this.SelectFileItem_Click);
            // 
            // ShowDataGridItem
            // 
            this.ShowDataGridItem.ForeColor = System.Drawing.Color.White;
            this.ShowDataGridItem.Name = "ShowDataGridItem";
            this.ShowDataGridItem.Size = new System.Drawing.Size(240, 24);
            this.ShowDataGridItem.Text = "Посмотреть таблицу";
            this.ShowDataGridItem.Click += new System.EventHandler(this.ShowDataGridItem_Click);
            // 
            // ExportToExcelItem
            // 
            this.ExportToExcelItem.ForeColor = System.Drawing.Color.White;
            this.ExportToExcelItem.Name = "ExportToExcelItem";
            this.ExportToExcelItem.Size = new System.Drawing.Size(240, 24);
            this.ExportToExcelItem.Text = "Экспорт в Excel";
            this.ExportToExcelItem.Click += new System.EventHandler(this.ExportToExcelItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // ShowParametersItem
            // 
            this.ShowParametersItem.ForeColor = System.Drawing.Color.White;
            this.ShowParametersItem.Name = "ShowParametersItem";
            this.ShowParametersItem.Size = new System.Drawing.Size(240, 24);
            this.ShowParametersItem.Text = "Настройки";
            this.ShowParametersItem.Click += new System.EventHandler(this.ShowParametersItem_Click);
            // 
            // debugBox
            // 
            this.debugBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.debugBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.debugBox.ForeColor = System.Drawing.SystemColors.Info;
            this.debugBox.Location = new System.Drawing.Point(12, 38);
            this.debugBox.Name = "debugBox";
            this.debugBox.ReadOnly = true;
            this.debugBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.debugBox.Size = new System.Drawing.Size(777, 387);
            this.debugBox.TabIndex = 0;
            this.debugBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.debugBox);
            this.Controls.Add(this.MenuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoRe";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUserControls.NoScrollRichTextBox debugBox;
        private System.Windows.Forms.OpenFileDialog openPdfFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveExcelFile;
        private System.Windows.Forms.MenuStrip MenuPanel;
        private System.Windows.Forms.ToolStripMenuItem MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectFileItem;
        private System.Windows.Forms.ToolStripMenuItem ShowDataGridItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToExcelItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ShowParametersItem;
    }
}

