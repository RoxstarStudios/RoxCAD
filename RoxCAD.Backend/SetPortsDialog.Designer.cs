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
            backendApiPortLabel = new Label();
            backendApiPortInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            backendWSPortInput = new TextBox();
            label3 = new Label();
            label4 = new Label();
            frontendWebPortInput = new TextBox();
            label5 = new Label();
            buttonUpdate = new Button();
            SuspendLayout();
            // 
            // backendApiPortLabel
            // 
            backendApiPortLabel.AutoSize = true;
            backendApiPortLabel.FlatStyle = FlatStyle.Flat;
            backendApiPortLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backendApiPortLabel.ForeColor = SystemColors.ActiveCaption;
            backendApiPortLabel.Location = new Point(3, 7);
            backendApiPortLabel.Margin = new Padding(4, 0, 4, 0);
            backendApiPortLabel.Name = "backendApiPortLabel";
            backendApiPortLabel.Size = new Size(105, 21);
            backendApiPortLabel.TabIndex = 0;
            backendApiPortLabel.Text = "Backend API";
            backendApiPortLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backendApiPortInput
            // 
            backendApiPortInput.BackColor = SystemColors.WindowFrame;
            backendApiPortInput.Cursor = Cursors.IBeam;
            backendApiPortInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backendApiPortInput.Location = new Point(244, 4);
            backendApiPortInput.Name = "backendApiPortInput";
            backendApiPortInput.Size = new Size(119, 29);
            backendApiPortInput.TabIndex = 1;
            backendApiPortInput.KeyPress += portInput_KeyPress;
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
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(123, 47);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(118, 21);
            label2.TabIndex = 5;
            label2.Text = "http://localhost:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backendWSPortInput
            // 
            backendWSPortInput.BackColor = SystemColors.WindowFrame;
            backendWSPortInput.Cursor = Cursors.IBeam;
            backendWSPortInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backendWSPortInput.Location = new Point(244, 44);
            backendWSPortInput.Name = "backendWSPortInput";
            backendWSPortInput.Size = new Size(119, 29);
            backendWSPortInput.TabIndex = 4;
            backendWSPortInput.KeyPress += portInput_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(3, 47);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 21);
            label3.TabIndex = 3;
            label3.Text = "Backend WS";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(123, 88);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(118, 21);
            label4.TabIndex = 8;
            label4.Text = "http://localhost:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frontendWebPortInput
            // 
            frontendWebPortInput.BackColor = SystemColors.WindowFrame;
            frontendWebPortInput.Cursor = Cursors.IBeam;
            frontendWebPortInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            frontendWebPortInput.Location = new Point(244, 85);
            frontendWebPortInput.Name = "frontendWebPortInput";
            frontendWebPortInput.Size = new Size(119, 29);
            frontendWebPortInput.TabIndex = 7;
            frontendWebPortInput.KeyPress += portInput_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(3, 88);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(118, 21);
            label5.TabIndex = 6;
            label5.Text = "Frontend Web";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = SystemColors.MenuHighlight;
            buttonUpdate.DialogResult = DialogResult.OK;
            buttonUpdate.FlatStyle = FlatStyle.System;
            buttonUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonUpdate.ForeColor = SystemColors.ActiveCaption;
            buttonUpdate.Location = new Point(244, 120);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(119, 31);
            buttonUpdate.TabIndex = 9;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // SetPortsDialog
            // 
            AcceptButton = buttonUpdate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(366, 156);
            Controls.Add(buttonUpdate);
            Controls.Add(label4);
            Controls.Add(frontendWebPortInput);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(backendWSPortInput);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(backendApiPortInput);
            Controls.Add(backendApiPortLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetPortsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set RoxCAD Ports";
            Load += SetPortsDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backendApiPortLabel;
        private TextBox backendApiPortInput;
        private Label label1;
        private Label label2;
        private TextBox backendWSPortInput;
        private Label label3;
        private Label label4;
        private TextBox frontendWebPortInput;
        private Label label5;
        private Button buttonUpdate;
    }
}