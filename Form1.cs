using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tavlama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            BAF_WebService.BAF_WebService objService = new BAF_WebService.BAF_WebService();

            dt = objService.GetAnnealingEstimatedProcessEnding().Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            byte equipmentID = 0;
            BAF_WebService.BAF_WebService objService = new BAF_WebService.BAF_WebService();

            equipmentID = byte.Parse(comboBox1.Text.Split(' ')[0].ToString());

            dt=objService.GetAnnealingEquipments(equipmentID).Tables[0];

            dataGridView2.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            BAF_WebService.BAF_WebService objService = new BAF_WebService.BAF_WebService();

            dt = objService.GetAnnealingStateRecords().Tables[0];
            dataGridView3.DataSource = dt;
        }
    }
}
