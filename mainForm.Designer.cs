﻿namespace ScientistManagementSystem_C_
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиФайлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatistics = new System.Windows.Forms.ComboBox();
            this.btnTestPolymorphism = new System.Windows.Forms.Button();
            this.btnShowStatistics = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arsenal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem1,
            this.проПрограмуToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1181, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // файлToolStripMenuItem1
            // 
            this.файлToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.відкритиФайлToolStripMenuItem1,
            this.зберегтиToolStripMenuItem1,
            this.вихідToolStripMenuItem1});
            this.файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            this.файлToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.файлToolStripMenuItem1.Size = new System.Drawing.Size(71, 32);
            this.файлToolStripMenuItem1.Text = "Файл";
            // 
            // відкритиФайлToolStripMenuItem1
            // 
            this.відкритиФайлToolStripMenuItem1.Name = "відкритиФайлToolStripMenuItem1";
            this.відкритиФайлToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.відкритиФайлToolStripMenuItem1.Size = new System.Drawing.Size(283, 32);
            this.відкритиФайлToolStripMenuItem1.Text = "Відкрити файл";
            this.відкритиФайлToolStripMenuItem1.Click += new System.EventHandler(this.відкритиФайлToolStripMenuItem1_Click);
            // 
            // зберегтиToolStripMenuItem1
            // 
            this.зберегтиToolStripMenuItem1.Name = "зберегтиToolStripMenuItem1";
            this.зберегтиToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.зберегтиToolStripMenuItem1.Size = new System.Drawing.Size(283, 32);
            this.зберегтиToolStripMenuItem1.Text = "Зберегти";
            this.зберегтиToolStripMenuItem1.Click += new System.EventHandler(this.зберегтиToolStripMenuItem1_Click);
            // 
            // вихідToolStripMenuItem1
            // 
            this.вихідToolStripMenuItem1.Name = "вихідToolStripMenuItem1";
            this.вихідToolStripMenuItem1.Size = new System.Drawing.Size(283, 32);
            this.вихідToolStripMenuItem1.Text = "Вихід";
            this.вихідToolStripMenuItem1.Click += new System.EventHandler(this.вихідToolStripMenuItem1_Click);
            // 
            // проПрограмуToolStripMenuItem1
            // 
            this.проПрограмуToolStripMenuItem1.Name = "проПрограмуToolStripMenuItem1";
            this.проПрограмуToolStripMenuItem1.Size = new System.Drawing.Size(142, 32);
            this.проПрограмуToolStripMenuItem1.Text = "Про програму";
            this.проПрограмуToolStripMenuItem1.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem1_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Arsenal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(71, 32);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // відкритиФайлToolStripMenuItem
            // 
            this.відкритиФайлToolStripMenuItem.Name = "відкритиФайлToolStripMenuItem";
            this.відкритиФайлToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.відкритиФайлToolStripMenuItem.Size = new System.Drawing.Size(283, 32);
            this.відкритиФайлToolStripMenuItem.Text = "Відкрити файл";
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(283, 32);
            this.зберегтиToolStripMenuItem.Text = "Зберегти";
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(283, 32);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Font = new System.Drawing.Font("Arsenal", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(142, 32);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.проПрограмуToolStripMenuItem_Click_1);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 208);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1157, 533);
            this.dataGridView.TabIndex = 1;
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Font = new System.Drawing.Font("Arsenal", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddStaff.Location = new System.Drawing.Point(12, 101);
            this.btnAddStaff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(363, 43);
            this.btnAddStaff.TabIndex = 2;
            this.btnAddStaff.Text = "Додати працівника";
            this.btnAddStaff.UseVisualStyleBackColor = true;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arsenal", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(741, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Виведення статистики";
            // 
            // cmbStatistics
            // 
            this.cmbStatistics.Font = new System.Drawing.Font("Arsenal", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStatistics.FormattingEnabled = true;
            this.cmbStatistics.Location = new System.Drawing.Point(744, 101);
            this.cmbStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbStatistics.Name = "cmbStatistics";
            this.cmbStatistics.Size = new System.Drawing.Size(415, 40);
            this.cmbStatistics.TabIndex = 4;
            this.cmbStatistics.Text = "Оберіть варіант";
            // 
            // btnTestPolymorphism
            // 
            this.btnTestPolymorphism.Location = new System.Drawing.Point(12, 162);
            this.btnTestPolymorphism.Name = "btnTestPolymorphism";
            this.btnTestPolymorphism.Size = new System.Drawing.Size(363, 41);
            this.btnTestPolymorphism.TabIndex = 6;
            this.btnTestPolymorphism.Text = "Test Polymorphism";
            this.btnTestPolymorphism.UseVisualStyleBackColor = true;
            this.btnTestPolymorphism.Click += new System.EventHandler(this.btnTestPolymorphism_Click);
            // 
            // btnShowStatistics
            // 
            this.btnShowStatistics.Location = new System.Drawing.Point(744, 162);
            this.btnShowStatistics.Name = "btnShowStatistics";
            this.btnShowStatistics.Size = new System.Drawing.Size(415, 41);
            this.btnShowStatistics.TabIndex = 7;
            this.btnShowStatistics.Text = "btnShowStatistics";
            this.btnShowStatistics.UseVisualStyleBackColor = true;
            this.btnShowStatistics.Click += new System.EventHandler(this.btnShowStatistics_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 753);
            this.Controls.Add(this.btnShowStatistics);
            this.Controls.Add(this.btnTestPolymorphism);
            this.Controls.Add(this.cmbStatistics);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddStaff);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Головна сторінка";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatistics;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem відкритиФайлToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem1;
        private System.Windows.Forms.Button btnTestPolymorphism;
        private System.Windows.Forms.Button btnShowStatistics;
    }
}

