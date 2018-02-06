namespace Keylogger
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_nomPC = new System.Windows.Forms.ComboBox();
            this.listBox_requeteResult = new System.Windows.Forms.ListBox();
            this.button_requete = new System.Windows.Forms.Button();
            this.pictureBox_screenshot = new System.Windows.Forms.PictureBox();
            this.button_resetTable = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_ipPC = new System.Windows.Forms.Label();
            this.checkBox_screen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_screenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_nomPC
            // 
            this.comboBox_nomPC.FormattingEnabled = true;
            this.comboBox_nomPC.Location = new System.Drawing.Point(135, 29);
            this.comboBox_nomPC.Name = "comboBox_nomPC";
            this.comboBox_nomPC.Size = new System.Drawing.Size(159, 21);
            this.comboBox_nomPC.TabIndex = 0;
            // 
            // listBox_requeteResult
            // 
            this.listBox_requeteResult.FormattingEnabled = true;
            this.listBox_requeteResult.HorizontalScrollbar = true;
            this.listBox_requeteResult.Location = new System.Drawing.Point(12, 71);
            this.listBox_requeteResult.Name = "listBox_requeteResult";
            this.listBox_requeteResult.Size = new System.Drawing.Size(830, 173);
            this.listBox_requeteResult.TabIndex = 1;
            this.listBox_requeteResult.SelectedValueChanged += new System.EventHandler(this.listBox_requeteResult_SelectedValueChanged);
            // 
            // button_requete
            // 
            this.button_requete.Location = new System.Drawing.Point(12, 12);
            this.button_requete.Name = "button_requete";
            this.button_requete.Size = new System.Drawing.Size(95, 23);
            this.button_requete.TabIndex = 2;
            this.button_requete.Text = "Requete";
            this.button_requete.UseVisualStyleBackColor = true;
            this.button_requete.Click += new System.EventHandler(this.button_requete_Click);
            // 
            // pictureBox_screenshot
            // 
            this.pictureBox_screenshot.Location = new System.Drawing.Point(12, 250);
            this.pictureBox_screenshot.Name = "pictureBox_screenshot";
            this.pictureBox_screenshot.Size = new System.Drawing.Size(830, 264);
            this.pictureBox_screenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_screenshot.TabIndex = 3;
            this.pictureBox_screenshot.TabStop = false;
            this.pictureBox_screenshot.Click += new System.EventHandler(this.pictureBox_screenshot_Click);
            // 
            // button_resetTable
            // 
            this.button_resetTable.Location = new System.Drawing.Point(327, 27);
            this.button_resetTable.Name = "button_resetTable";
            this.button_resetTable.Size = new System.Drawing.Size(95, 23);
            this.button_resetTable.TabIndex = 4;
            this.button_resetTable.Text = "Reset Table";
            this.button_resetTable.UseVisualStyleBackColor = true;
            this.button_resetTable.Click += new System.EventHandler(this.button_resetTable_Click);
            // 
            // label_ipPC
            // 
            this.label_ipPC.AutoSize = true;
            this.label_ipPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_ipPC.Location = new System.Drawing.Point(460, 30);
            this.label_ipPC.Name = "label_ipPC";
            this.label_ipPC.Size = new System.Drawing.Size(37, 17);
            this.label_ipPC.TabIndex = 5;
            this.label_ipPC.Text = "ipPC";
            // 
            // checkBox_screen
            // 
            this.checkBox_screen.AutoSize = true;
            this.checkBox_screen.Location = new System.Drawing.Point(19, 40);
            this.checkBox_screen.Name = "checkBox_screen";
            this.checkBox_screen.Size = new System.Drawing.Size(80, 17);
            this.checkBox_screen.TabIndex = 6;
            this.checkBox_screen.Text = "Screenshot";
            this.checkBox_screen.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 526);
            this.Controls.Add(this.checkBox_screen);
            this.Controls.Add(this.label_ipPC);
            this.Controls.Add(this.button_resetTable);
            this.Controls.Add(this.pictureBox_screenshot);
            this.Controls.Add(this.button_requete);
            this.Controls.Add(this.listBox_requeteResult);
            this.Controls.Add(this.comboBox_nomPC);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_screenshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_nomPC;
        private System.Windows.Forms.ListBox listBox_requeteResult;
        private System.Windows.Forms.Button button_requete;
        private System.Windows.Forms.PictureBox pictureBox_screenshot;
        private System.Windows.Forms.Button button_resetTable;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_ipPC;
        private System.Windows.Forms.CheckBox checkBox_screen;
    }
}

