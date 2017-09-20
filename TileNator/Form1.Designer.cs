namespace TileNator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbLogo150px = new System.Windows.Forms.PictureBox();
            this.pbLogo70px = new System.Windows.Forms.PictureBox();
            this.tbMenuItemExe = new System.Windows.Forms.TextBox();
            this.tbMenuItemArgs = new System.Windows.Forms.TextBox();
            this.lblMenuItemExe = new System.Windows.Forms.Label();
            this.lblMenuItemArgs = new System.Windows.Forms.Label();
            this.lblMenuItemName = new System.Windows.Forms.Label();
            this.tbMenuItemName = new System.Windows.Forms.TextBox();
            this.btnRemMenuItem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbMenuItem = new System.Windows.Forms.GroupBox();
            this.btnPin = new System.Windows.Forms.Button();
            this.btnSelectMenuItemExe = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMenuItems = new System.Windows.Forms.Label();
            this.lvMenuItems = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo150px)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo70px)).BeginInit();
            this.gbMenuItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo150px
            // 
            this.pbLogo150px.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbLogo150px.Location = new System.Drawing.Point(42, 308);
            this.pbLogo150px.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLogo150px.Name = "pbLogo150px";
            this.pbLogo150px.Size = new System.Drawing.Size(150, 150);
            this.pbLogo150px.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo150px.TabIndex = 0;
            this.pbLogo150px.TabStop = false;
            this.pbLogo150px.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // pbLogo70px
            // 
            this.pbLogo70px.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbLogo70px.Location = new System.Drawing.Point(246, 388);
            this.pbLogo70px.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLogo70px.Name = "pbLogo70px";
            this.pbLogo70px.Size = new System.Drawing.Size(70, 69);
            this.pbLogo70px.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo70px.TabIndex = 1;
            this.pbLogo70px.TabStop = false;
            this.pbLogo70px.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // tbMenuItemExe
            // 
            this.tbMenuItemExe.Location = new System.Drawing.Point(184, 133);
            this.tbMenuItemExe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMenuItemExe.Name = "tbMenuItemExe";
            this.tbMenuItemExe.Size = new System.Drawing.Size(398, 31);
            this.tbMenuItemExe.TabIndex = 2;
            // 
            // tbMenuItemArgs
            // 
            this.tbMenuItemArgs.Location = new System.Drawing.Point(182, 200);
            this.tbMenuItemArgs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMenuItemArgs.Name = "tbMenuItemArgs";
            this.tbMenuItemArgs.Size = new System.Drawing.Size(400, 31);
            this.tbMenuItemArgs.TabIndex = 4;
            // 
            // lblMenuItemExe
            // 
            this.lblMenuItemExe.AutoSize = true;
            this.lblMenuItemExe.Location = new System.Drawing.Point(36, 133);
            this.lblMenuItemExe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuItemExe.Name = "lblMenuItemExe";
            this.lblMenuItemExe.Size = new System.Drawing.Size(119, 25);
            this.lblMenuItemExe.TabIndex = 4;
            this.lblMenuItemExe.Text = "Executable";
            // 
            // lblMenuItemArgs
            // 
            this.lblMenuItemArgs.AutoSize = true;
            this.lblMenuItemArgs.Location = new System.Drawing.Point(36, 200);
            this.lblMenuItemArgs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuItemArgs.Name = "lblMenuItemArgs";
            this.lblMenuItemArgs.Size = new System.Drawing.Size(115, 25);
            this.lblMenuItemArgs.TabIndex = 5;
            this.lblMenuItemArgs.Text = "Arguments";
            // 
            // lblMenuItemName
            // 
            this.lblMenuItemName.AutoSize = true;
            this.lblMenuItemName.Location = new System.Drawing.Point(36, 65);
            this.lblMenuItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuItemName.Name = "lblMenuItemName";
            this.lblMenuItemName.Size = new System.Drawing.Size(114, 25);
            this.lblMenuItemName.TabIndex = 7;
            this.lblMenuItemName.Text = "Item Name";
            // 
            // tbMenuItemName
            // 
            this.tbMenuItemName.Location = new System.Drawing.Point(184, 65);
            this.tbMenuItemName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMenuItemName.Name = "tbMenuItemName";
            this.tbMenuItemName.Size = new System.Drawing.Size(398, 31);
            this.tbMenuItemName.TabIndex = 1;
            // 
            // btnRemMenuItem
            // 
            this.btnRemMenuItem.Enabled = false;
            this.btnRemMenuItem.Location = new System.Drawing.Point(1210, 62);
            this.btnRemMenuItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemMenuItem.Name = "btnRemMenuItem";
            this.btnRemMenuItem.Size = new System.Drawing.Size(44, 42);
            this.btnRemMenuItem.TabIndex = 8;
            this.btnRemMenuItem.Text = "-";
            this.btnRemMenuItem.UseVisualStyleBackColor = true;
            this.btnRemMenuItem.Click += new System.EventHandler(this.btnRemMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 512);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 12;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(340, 494);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(130, 42);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Add";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // gbMenuItem
            // 
            this.gbMenuItem.Controls.Add(this.btnPin);
            this.gbMenuItem.Controls.Add(this.btnSelectMenuItemExe);
            this.gbMenuItem.Controls.Add(this.label6);
            this.gbMenuItem.Controls.Add(this.label5);
            this.gbMenuItem.Controls.Add(this.pbLogo150px);
            this.gbMenuItem.Controls.Add(this.pbLogo70px);
            this.gbMenuItem.Controls.Add(this.btnApply);
            this.gbMenuItem.Controls.Add(this.tbMenuItemExe);
            this.gbMenuItem.Controls.Add(this.label4);
            this.gbMenuItem.Controls.Add(this.tbMenuItemArgs);
            this.gbMenuItem.Controls.Add(this.lblMenuItemExe);
            this.gbMenuItem.Controls.Add(this.lblMenuItemArgs);
            this.gbMenuItem.Controls.Add(this.tbMenuItemName);
            this.gbMenuItem.Controls.Add(this.lblMenuItemName);
            this.gbMenuItem.Location = new System.Drawing.Point(24, 23);
            this.gbMenuItem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbMenuItem.Name = "gbMenuItem";
            this.gbMenuItem.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbMenuItem.Size = new System.Drawing.Size(682, 587);
            this.gbMenuItem.TabIndex = 15;
            this.gbMenuItem.TabStop = false;
            this.gbMenuItem.Text = "Current Item";
            // 
            // btnPin
            // 
            this.btnPin.Enabled = false;
            this.btnPin.Location = new System.Drawing.Point(524, 494);
            this.btnPin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPin.Name = "btnPin";
            this.btnPin.Size = new System.Drawing.Size(130, 42);
            this.btnPin.TabIndex = 6;
            this.btnPin.Text = "Pin/Unpin";
            this.btnPin.UseVisualStyleBackColor = true;
            this.btnPin.Click += new System.EventHandler(this.btnPin_Click);
            // 
            // btnSelectMenuItemExe
            // 
            this.btnSelectMenuItemExe.Location = new System.Drawing.Point(594, 133);
            this.btnSelectMenuItemExe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectMenuItemExe.Name = "btnSelectMenuItemExe";
            this.btnSelectMenuItemExe.Size = new System.Drawing.Size(60, 42);
            this.btnSelectMenuItemExe.TabIndex = 3;
            this.btnSelectMenuItemExe.Text = "...";
            this.btnSelectMenuItemExe.UseVisualStyleBackColor = true;
            this.btnSelectMenuItemExe.Click += new System.EventHandler(this.btnSelectMenuItemExe_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 360);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "70px";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 279);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "150px";
            // 
            // lblMenuItems
            // 
            this.lblMenuItems.AutoSize = true;
            this.lblMenuItems.Location = new System.Drawing.Point(798, 23);
            this.lblMenuItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMenuItems.Name = "lblMenuItems";
            this.lblMenuItems.Size = new System.Drawing.Size(173, 25);
            this.lblMenuItems.TabIndex = 18;
            this.lblMenuItems.Text = "Start menu Items";
            // 
            // lvMenuItems
            // 
            this.lvMenuItems.Location = new System.Drawing.Point(804, 62);
            this.lvMenuItems.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvMenuItems.Name = "lvMenuItems";
            this.lvMenuItems.Size = new System.Drawing.Size(392, 416);
            this.lvMenuItems.TabIndex = 7;
            this.lvMenuItems.UseCompatibleStateImageBehavior = false;
            this.lvMenuItems.View = System.Windows.Forms.View.List;
            this.lvMenuItems.SelectedIndexChanged += new System.EventHandler(this.lvMenuItems_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 677);
            this.Controls.Add(this.lvMenuItems);
            this.Controls.Add(this.lblMenuItems);
            this.Controls.Add(this.gbMenuItem);
            this.Controls.Add(this.btnRemMenuItem);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo150px)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo70px)).EndInit();
            this.gbMenuItem.ResumeLayout(false);
            this.gbMenuItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo150px;
        private System.Windows.Forms.PictureBox pbLogo70px;
        private System.Windows.Forms.TextBox tbMenuItemExe;
        private System.Windows.Forms.TextBox tbMenuItemArgs;
        private System.Windows.Forms.Label lblMenuItemExe;
        private System.Windows.Forms.Label lblMenuItemArgs;
        private System.Windows.Forms.Label lblMenuItemName;
        private System.Windows.Forms.TextBox tbMenuItemName;
        private System.Windows.Forms.Button btnRemMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox gbMenuItem;
        private System.Windows.Forms.Button btnSelectMenuItemExe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMenuItems;
        private System.Windows.Forms.ListView lvMenuItems;
        private System.Windows.Forms.Button btnPin;
    }
}

