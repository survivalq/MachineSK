using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MachineSK
{
    public partial class Form1 : Form
    {
        bool IS_LEATHER = false;
        decimal ITEM_COLOR = 16711680;
        Point lastPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void gen_button_Click(object sender, EventArgs e)
        {
            string eventType = "Passive";
            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            {
                if (indexChecked == 0)
                {
                    eventType = "Passive";
                }
                else if (indexChecked == 1)
                {
                    eventType = "OnDamage"; 
                }
            }
            outputSkript_textbox.Text = Utils.customArmor.skriptCommand(eventType, armor_customName.Text, skript_textbox.Lines).Replace("'", "\"").Replace("´", "'");
            outputSkriptGive_textbox.Text = Utils.customArmor.giveCommand(comboBox1.Text, armor_customName.Text, itemLore_textbox.Lines, armor_customNBT.Text, IS_LEATHER, ITEM_COLOR).Replace("'", "\"").Replace("´", "'");
        }

        private void generate_button_2_Click(object sender, EventArgs e)
        {
            string eventType = "Passive";
            foreach (int indexChecked in checkedListBox2.CheckedIndices)
            {
                if (indexChecked == 0)
                {
                    eventType = "Passive";
                }
                else if (indexChecked == 1)
                {
                    eventType = "OnDamage";
                }
            }
            outputSkript_textbox_2.Text = Utils.customItem.skriptCommand(eventType, itemType_textbox.Text, item_customName.Text, itemLore_textbox_2.Lines, skript_textbox_2.Lines).Replace("'", "\"").Replace("´", "'");
            outputSkriptGive_textbox_2.Text = Utils.customItem.giveCommand(itemType_textbox.Text, item_customName.Text, itemLore_textbox_2.Lines, item_customNBT.Text).Replace("'", "\"").Replace("´", "'");
        }

        private void color_button_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                color_button.BackColor = colorPicker.Color;
                string COLOR_IN_HEX = string.Format("{0:X2}{1:X2}{2:X2}", colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B);
                ITEM_COLOR = Convert.ToInt32(COLOR_IN_HEX, 16);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "leather")
            {
                color_button.Visible = true;
                IS_LEATHER = true;
            }
            else
            {
                color_button.Visible = false;
                IS_LEATHER = false;
            }
        }

        // Buttons mayhem
        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/SkriptLang");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.spigotmc.org/resources/skbee-skript-addon.75839/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://sk.rayfall.net/");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Sharpjaws/SharpSK/releases");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/jugMszmPRf");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/survivalq/MachineSK");
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Moving the UserInterface

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        // Custom tabControl system
        private void tabPage_armor_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabPage_item_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void tabPage_toolbox_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}
