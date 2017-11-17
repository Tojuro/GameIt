namespace GameItViewerUI
{
    partial class ViewDefinitionPicker
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
            this.lstViewDefinitions = new System.Windows.Forms.ListBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.txtSelectedValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstViewDefinitions
            // 
            this.lstViewDefinitions.FormattingEnabled = true;
            this.lstViewDefinitions.ItemHeight = 16;
            this.lstViewDefinitions.Location = new System.Drawing.Point(12, 12);
            this.lstViewDefinitions.Name = "lstViewDefinitions";
            this.lstViewDefinitions.Size = new System.Drawing.Size(265, 228);
            this.lstViewDefinitions.TabIndex = 0;
            this.lstViewDefinitions.SelectedIndexChanged += new System.EventHandler(this.lstViewDefinitions_SelectedIndexChanged);
            this.lstViewDefinitions.DoubleClick += new System.EventHandler(this.lstViewDefinitions_DoubleClick);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(283, 180);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "E&xit";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(283, 219);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 2;
            this.cmdSelect.Text = "&Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // txtSelectedValue
            // 
            this.txtSelectedValue.Location = new System.Drawing.Point(283, 12);
            this.txtSelectedValue.Name = "txtSelectedValue";
            this.txtSelectedValue.Size = new System.Drawing.Size(75, 22);
            this.txtSelectedValue.TabIndex = 3;
            this.txtSelectedValue.Visible = false;
            // 
            // ViewDefinitionPicker
            // 
            this.AcceptButton = this.cmdSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(370, 253);
            this.ControlBox = false;
            this.Controls.Add(this.txtSelectedValue);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lstViewDefinitions);
            this.MaximizeBox = false;
            this.Name = "ViewDefinitionPicker";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GameIt - Choose View";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstViewDefinitions;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.TextBox txtSelectedValue;
    }
}

