using Q11.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Room title not empty");
            } else
            {
                RoomDAO roomDAO = new RoomDAO();
                roomDAO.AddRoom(textBox1.Text, Convert.ToInt32(comboBox1.Text), Convert.ToInt32(numericUpDown1.Value), textBox2.Text, textBox3.Text);
                MessageBox.Show("Add room successfully");
            }
        }
    }
}
