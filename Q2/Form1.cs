using Q2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new PRN211_Spr22Context())
            {
                comboBox1.DataSource = context.Rooms.Select(x => new
                {
                    x.Title
                })
                    .ToList();
                comboBox1.DisplayMember = "Title";
                comboBox2.DataSource = context.Services.Select(x => new
                {
                    x.FeeType
                })
                    .Distinct()
                    .ToList();
                comboBox2.DisplayMember = "FeeType";
                List<Service> list = new List<Service>();
                context.Rooms.ToList();
                dataGridView1.DataSource = context.Services.Select(x => new
                {
                    x.RoomTitle,
                    x.RoomTitleNavigation.Floor,
                    x.RoomTitleNavigation.Square,
                    x.Month,
                    x.Year,
                    x.FeeType,
                    x.Amount,
                    x.PaymentDate,
                    x.Employee
                })
                    .ToList();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new PRN211_Spr22Context())
            {
                context.Rooms.ToList();
                dataGridView1.DataSource = context.Services
                    .Where(x => x.FeeType.Equals(comboBox2.Text) && x.RoomTitle.Equals(comboBox1.Text))
                    .Select(x => new
                    {
                        x.RoomTitle,
                        x.RoomTitleNavigation.Floor,
                        x.RoomTitleNavigation.Square,
                        x.Month,
                        x.Year,
                        x.FeeType,
                        x.Amount,
                        x.PaymentDate,
                        x.Employee
                    })
                    .ToList();
            }
        }
    }
}
