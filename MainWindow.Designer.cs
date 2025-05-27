namespace Todo
{
    partial class MainWindow
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
            this.sidePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.listsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.listAll = new System.Windows.Forms.RadioButton();
            this.newListButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.listDetailsPanel = new System.Windows.Forms.Panel();
            this.selectedListLabel = new System.Windows.Forms.Label();
            this.tasksPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.sidePanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.listsPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.listDetailsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.sidePanel.Controls.Add(this.titlePanel);
            this.sidePanel.Controls.Add(this.listsPanel);
            this.sidePanel.Controls.Add(this.newListButton);
            this.sidePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidePanel.ForeColor = System.Drawing.Color.White;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(273, 682);
            this.sidePanel.TabIndex = 2;
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Location = new System.Drawing.Point(5, 5);
            this.titlePanel.Margin = new System.Windows.Forms.Padding(5);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(264, 58);
            this.titlePanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.AutoSize = true;
            this.titleLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.titleLabel.Font = new System.Drawing.Font("Helvetica", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(3, 7);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(192, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "ToDo App";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listsPanel
            // 
            this.listsPanel.Controls.Add(this.listAll);
            this.listsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.listsPanel.Location = new System.Drawing.Point(5, 73);
            this.listsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.listsPanel.Name = "listsPanel";
            this.listsPanel.Size = new System.Drawing.Size(264, 543);
            this.listsPanel.TabIndex = 1;
            // 
            // listAll
            // 
            this.listAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.listAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.listAll.Checked = true;
            this.listAll.FlatAppearance.BorderSize = 0;
            this.listAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.listAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.listAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.listAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listAll.Font = new System.Drawing.Font("Helvetica", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAll.Location = new System.Drawing.Point(0, 0);
            this.listAll.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.listAll.Name = "listAll";
            this.listAll.Size = new System.Drawing.Size(268, 38);
            this.listAll.TabIndex = 1;
            this.listAll.TabStop = true;
            this.listAll.Text = "All";
            this.listAll.UseVisualStyleBackColor = false;
            this.listAll.CheckedChanged += new System.EventHandler(this.listAll_CheckedChanged);
            // 
            // newListButton
            // 
            this.newListButton.BackColor = System.Drawing.Color.Transparent;
            this.newListButton.FlatAppearance.BorderSize = 0;
            this.newListButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.newListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newListButton.Font = new System.Drawing.Font("Helvetica", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newListButton.Location = new System.Drawing.Point(5, 626);
            this.newListButton.Margin = new System.Windows.Forms.Padding(5);
            this.newListButton.Name = "newListButton";
            this.newListButton.Size = new System.Drawing.Size(264, 41);
            this.newListButton.TabIndex = 2;
            this.newListButton.Text = "New list";
            this.newListButton.UseVisualStyleBackColor = false;
            this.newListButton.Click += new System.EventHandler(this.newListButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.listDetailsPanel);
            this.mainPanel.Controls.Add(this.tasksPanel);
            this.mainPanel.Controls.Add(this.addTaskButton);
            this.mainPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainPanel.Location = new System.Drawing.Point(277, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(787, 682);
            this.mainPanel.TabIndex = 3;
            // 
            // listDetailsPanel
            // 
            this.listDetailsPanel.Controls.Add(this.selectedListLabel);
            this.listDetailsPanel.Location = new System.Drawing.Point(5, 5);
            this.listDetailsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.listDetailsPanel.Name = "listDetailsPanel";
            this.listDetailsPanel.Size = new System.Drawing.Size(759, 58);
            this.listDetailsPanel.TabIndex = 1;
            // 
            // selectedListLabel
            // 
            this.selectedListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedListLabel.AutoSize = true;
            this.selectedListLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectedListLabel.Font = new System.Drawing.Font("Helvetica", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedListLabel.ForeColor = System.Drawing.Color.White;
            this.selectedListLabel.Location = new System.Drawing.Point(3, 7);
            this.selectedListLabel.Name = "selectedListLabel";
            this.selectedListLabel.Size = new System.Drawing.Size(0, 45);
            this.selectedListLabel.TabIndex = 0;
            this.selectedListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tasksPanel
            // 
            this.tasksPanel.Location = new System.Drawing.Point(3, 71);
            this.tasksPanel.Name = "tasksPanel";
            this.tasksPanel.Size = new System.Drawing.Size(761, 547);
            this.tasksPanel.TabIndex = 2;
            // 
            // addTaskButton
            // 
            this.addTaskButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.addTaskButton.FlatAppearance.BorderSize = 0;
            this.addTaskButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.addTaskButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.addTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTaskButton.Font = new System.Drawing.Font("Helvetica", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTaskButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.addTaskButton.Location = new System.Drawing.Point(5, 626);
            this.addTaskButton.Margin = new System.Windows.Forms.Padding(5);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.addTaskButton.Size = new System.Drawing.Size(759, 41);
            this.addTaskButton.TabIndex = 3;
            this.addTaskButton.Text = "Add a task";
            this.addTaskButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addTaskButton.UseVisualStyleBackColor = false;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "ToDo App";
            this.sidePanel.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.listsPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.listDetailsPanel.ResumeLayout(false);
            this.listDetailsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel sidePanel;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.Panel listDetailsPanel;
        private System.Windows.Forms.Label selectedListLabel;
        private System.Windows.Forms.FlowLayoutPanel listsPanel;
        private System.Windows.Forms.RadioButton listAll;
        private System.Windows.Forms.Button newListButton;
        private System.Windows.Forms.FlowLayoutPanel tasksPanel;
        private System.Windows.Forms.Button addTaskButton;
    }
}

