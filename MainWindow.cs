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
                radioButton.FlatAppearance.BorderSize = listAll.FlatAppearance.BorderSize;
                radioButton.FlatAppearance.CheckedBackColor = listAll.FlatAppearance.CheckedBackColor;
                radioButton.FlatAppearance.MouseOverBackColor = listAll.FlatAppearance.MouseOverBackColor;
                radioButton.FlatAppearance.MouseDownBackColor = listAll.FlatAppearance.MouseDownBackColor;
                radioButton.Appearance = listAll.Appearance;
                radioButton.FlatStyle = listAll.FlatStyle;
                radioButton.Font = listAll.Font;
                radioButton.Margin = listAll.Margin;
                radioButton.Height = listAll.Height;
                radioButton.Width = 268;
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
                if (!TaskList.Exists(value, user.UserId))
                {
                    user.CreateTaskList(value, DateTime.Now);
                    RadioButton radioButton = new RadioButton();
                    radioButton.FlatAppearance.BorderSize = listAll.FlatAppearance.BorderSize;
                    radioButton.FlatAppearance.CheckedBackColor = listAll.FlatAppearance.CheckedBackColor;
                    radioButton.FlatAppearance.MouseOverBackColor = listAll.FlatAppearance.MouseOverBackColor;
                    radioButton.FlatAppearance.MouseDownBackColor = listAll.FlatAppearance.MouseDownBackColor;
                    radioButton.Appearance = Appearance.Button;
                    radioButton.FlatStyle = listAll.FlatStyle;
                    radioButton.Font = listAll.Font;
                    radioButton.Margin = listAll.Margin;
                    radioButton.Height = listAll.Height;
                    radioButton.Width = 268;
                    radioButton.Text = value;
                    radioButton.CheckedChanged += new System.EventHandler(changeCurrentList_Event);
                    listsPanel.Controls.Add(radioButton);
                }
                else
                {
                    MessageBox.Show("List already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changeCurrentList_Event(object sender, EventArgs e)
        {
            selectedListLabel.Text = ((RadioButton)sender).Text;
            // Clear displayed tasks
            tasksPanel.Controls.Clear();

            // Add new set of tasks
            List<Task> tasks = user.GetTasksFromList(TaskListDAO.GetId(selectedListLabel.Text, user.UserId));
            tasks.ForEach(task =>
            {
                CheckBox checkBox = CreateTaskButton();
                checkBox.Text = task.Name;
                checkBox.Tag = task.Id;
                checkBox.Checked = task.CompletionDate != null;
                checkBox.CheckedChanged += new EventHandler(TaskCheckbox_CheckedChanged);
                tasksPanel.Controls.Add(checkBox);
            });
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

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            string value = "";
            if (InputBox("Create new task", "Enter task name:", ref value) == DialogResult.OK && !value.Equals(""))
            {
                user.CreateTask(value, TaskListDAO.GetId(selectedListLabel.Text, user.UserId));
                CheckBox checkBox = CreateTaskButton();
                checkBox.Text = value;
                checkBox.Tag = TaskDAO.GetLastInsertedId();
                checkBox.Checked = false;
                checkBox.CheckedChanged += new EventHandler(TaskCheckbox_CheckedChanged);
                tasksPanel.Controls.Add(checkBox);
            }
        }

        public void TaskCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked)
            {
                // Checkbox was checked
                user.MarkTaskAsCompleted(int.Parse(checkbox.Tag.ToString()));
            }
            else
            {
                // Checkbox was unchecked
                user.MarkTaskAsUnfinished(int.Parse(checkbox.Tag.ToString()));
            }
        }

        private CheckBox CreateTaskButton()
        {
            CheckBox checkBox = new CheckBox();
            checkBox.FlatAppearance.BorderSize = 0;
            //checkBox.FlatAppearance.CheckedBackColor = listAll.FlatAppearance.CheckedBackColor;
            //checkBox.FlatAppearance.MouseOverBackColor = listAll.FlatAppearance.MouseOverBackColor;
            //checkBox.FlatAppearance.MouseDownBackColor = listAll.FlatAppearance.MouseDownBackColor;
            checkBox.Appearance = Appearance.Normal;
            checkBox.ForeColor = Color.White;
            checkBox.BackColor = Color.FromArgb(42, 42, 42);
            checkBox.FlatStyle = FlatStyle.Flat;
            checkBox.Font = new Font("Helvetica", 14, FontStyle.Regular);
            checkBox.Margin = new Padding(3, 3, 3, 3);
            checkBox.Padding = new Padding(10, 0, 0, 0);
            checkBox.Height = 38;
            checkBox.Width = 758;
            checkBox.Text = "";
            // radioButton.CheckedChanged += new System.EventHandler(changeCurrentList_Event);
            return checkBox;
        }

        private void taskButton_MouseEnter(object sender, EventArgs e)
        {
            ((CheckBox)sender).BackColor = Color.FromArgb(55,55,55);
        }
        private void taskButton_MouseLeave(object sender, EventArgs e)
        {
            ((CheckBox)sender).BackColor = Color.Empty;
        }
    }
}
