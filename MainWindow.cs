using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Todo
{
    
    public partial class MainWindow : Form
    {
        User user;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(User user)
        {
            this.user = user;
            InitializeComponent();
            addListsToForm(user.TaskLists);
        }

        private void addListsToForm(List<TaskList> taskLists)
        {
            taskLists.ForEach(taskList =>
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Font = listAll.Font;
                radioButton.Margin = listAll.Margin;
                radioButton.Height = listAll.Height;
                radioButton.Width = 500;
                radioButton.Text = taskList.Name;
                radioButton.CheckedChanged += new System.EventHandler(changeCurrentList_Event);
                listsPanel.Controls.Add(radioButton);
            });
        }

        private void listAll_CheckedChanged(object sender, EventArgs e)
        {
            selectedListLabel.Text = listAll.Text;
        }

        private void newListButton_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox("Create new list", "Enter list name:", ref value) == DialogResult.OK && !value.Equals(""))
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Font = listAll.Font;
                radioButton.Margin = listAll.Margin;
                radioButton.Height = listAll.Height;
                radioButton.Width = 500;
                radioButton.Text = value;
                radioButton.CheckedChanged += new System.EventHandler(changeCurrentList_Event);
                listsPanel.Controls.Add(radioButton);
            }
        }

        private void changeCurrentList_Event(object sender, EventArgs e) {
            selectedListLabel.Text = ((RadioButton)sender).Text;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 700, 20);
            buttonOk.SetBounds(228, 160, 160, 60);
            buttonCancel.SetBounds(400, 160, 160, 60);

            label.AutoSize = true;
            form.ClientSize = new Size(796, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }
    }
}
