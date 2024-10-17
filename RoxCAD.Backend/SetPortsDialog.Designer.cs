namespace RoxCAD.Backend
{
    partial class SetPortsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPortsDialog));
            servicePortLabel = new Label();
            servicePortInput = new TextBox();
            label1 = new Label();
            buttonUpdate = new Button();
            SuspendLayout();
            // 
            // servicePortLabel
            // 
            servicePortLabel.AutoSize = true;
            servicePortLabel.FlatStyle = FlatStyle.Flat;
            servicePortLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            servicePortLabel.ForeColor = SystemColors.ActiveCaption;
            servicePortLabel.Location = new Point(3, 7);
            servicePortLabel.Margin = new Padding(4, 0, 4, 0);
            servicePortLabel.Name = "servicePortLabel";
            servicePortLabel.Size = new Size(102, 21);
            servicePortLabel.TabIndex = 0;
            servicePortLabel.Text = "Service Port";
            servicePortLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // servicePortInput
            // 
            servicePortInput.BackColor = SystemColors.WindowFrame;
            servicePortInput.Cursor = Cursors.IBeam;
            servicePortInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            servicePortInput.Location = new Point(244, 4);
            servicePortInput.Name = "servicePortInput";
            servicePortInput.Size = new Size(119, 29);
            servicePortInput.TabIndex = 1;
            servicePortInput.KeyPress += portInput_KeyPress;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(123, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 2;
            label1.Text = "http://localhost:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = SystemColors.MenuHighlight;
            buttonUpdate.DialogResult = DialogResult.OK;
            buttonUpdate.FlatStyle = FlatStyle.System;
            buttonUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonUpdate.ForeColor = SystemColors.ActiveCaption;
            buttonUpdate.Location = new Point(244, 39);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(119, 31);
            buttonUpdate.TabIndex = 9;
            buttonUpdate.Text = "Ok";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // SetPortsDialog
            // 
            AcceptButton = buttonUpdate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(366, 75);
            Controls.Add(buttonUpdate);
            Controls.Add(label1);
            Controls.Add(servicePortInput);
            Controls.Add(servicePortLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetPortsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update RoxCAD Service Port";
            Load += SetPortsDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label servicePortLabel;
        private TextBox servicePortInput;
        private Label label1;
        private Button buttonUpdate;
    }
}