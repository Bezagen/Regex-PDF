
namespace PDFReader
{
    partial class ParametersForm
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
            this.CharsBeforeWord = new System.Windows.Forms.TextBox();
            this.CharacterBeforeWord = new System.Windows.Forms.Label();
            this.CharactersAfterWord = new System.Windows.Forms.Label();
            this.CharsAfterWord = new System.Windows.Forms.TextBox();
            this.AplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CharsBeforeWord
            // 
            this.CharsBeforeWord.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CharsBeforeWord.Location = new System.Drawing.Point(138, 6);
            this.CharsBeforeWord.Name = "CharsBeforeWord";
            this.CharsBeforeWord.Size = new System.Drawing.Size(70, 30);
            this.CharsBeforeWord.TabIndex = 0;
            this.CharsBeforeWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CharsBeforeWord_KeyPress);
            // 
            // CharacterBeforeWord
            // 
            this.CharacterBeforeWord.AutoSize = true;
            this.CharacterBeforeWord.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CharacterBeforeWord.ForeColor = System.Drawing.Color.White;
            this.CharacterBeforeWord.Location = new System.Drawing.Point(12, 9);
            this.CharacterBeforeWord.Name = "CharacterBeforeWord";
            this.CharacterBeforeWord.Size = new System.Drawing.Size(120, 22);
            this.CharacterBeforeWord.TabIndex = 1;
            this.CharacterBeforeWord.Text = "Символов до";
            // 
            // CharactersAfterWord
            // 
            this.CharactersAfterWord.AutoSize = true;
            this.CharactersAfterWord.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CharactersAfterWord.ForeColor = System.Drawing.Color.White;
            this.CharactersAfterWord.Location = new System.Drawing.Point(12, 39);
            this.CharactersAfterWord.Name = "CharactersAfterWord";
            this.CharactersAfterWord.Size = new System.Drawing.Size(90, 44);
            this.CharactersAfterWord.TabIndex = 2;
            this.CharactersAfterWord.Text = "Символов\r\nпосле\r\n";
            // 
            // CharsAfterWord
            // 
            this.CharsAfterWord.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CharsAfterWord.Location = new System.Drawing.Point(138, 53);
            this.CharsAfterWord.Name = "CharsAfterWord";
            this.CharsAfterWord.Size = new System.Drawing.Size(70, 30);
            this.CharsAfterWord.TabIndex = 3;
            this.CharsAfterWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CharsAfterWord_KeyPress);
            // 
            // AplyButton
            // 
            this.AplyButton.BackColor = System.Drawing.Color.White;
            this.AplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AplyButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AplyButton.Location = new System.Drawing.Point(12, 337);
            this.AplyButton.Name = "AplyButton";
            this.AplyButton.Size = new System.Drawing.Size(120, 29);
            this.AplyButton.TabIndex = 4;
            this.AplyButton.Text = "Применить";
            this.AplyButton.UseVisualStyleBackColor = false;
            this.AplyButton.Click += new System.EventHandler(this.AplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.White;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelButton.Location = new System.Drawing.Point(155, 337);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 29);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Закрыть";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(287, 378);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AplyButton);
            this.Controls.Add(this.CharsAfterWord);
            this.Controls.Add(this.CharactersAfterWord);
            this.Controls.Add(this.CharacterBeforeWord);
            this.Controls.Add(this.CharsBeforeWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ParametersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CharsBeforeWord;
        private System.Windows.Forms.Label CharacterBeforeWord;
        private System.Windows.Forms.Label CharactersAfterWord;
        private System.Windows.Forms.TextBox CharsAfterWord;
        private System.Windows.Forms.Button AplyButton;
        private System.Windows.Forms.Button CancelButton;
    }
}