using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace FarmFrenzy2TR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProcessMemoryReaderWriter pmrw = new ProcessMemoryReaderWriter(Process.GetProcessesByName("engine")[0].Id);

        public int getBaseAddress(int PID) {
            int baseAdress = 0;
            baseAdress = (int)Process.GetProcessById(PID).MainModule.BaseAddress;
            return baseAdress;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            int GAMEBASEADDRESS = getBaseAddress(Process.GetProcessesByName("engine")[0].Id);
            int basePTR = GAMEBASEADDRESS + 0x00380720;
            int MoneyAdress = pmrw.MultiLevelPointerReader(basePTR, new int[] { 0x648 });
            int moneyValue = Convert.ToInt32(textBox1.Text);
            pmrw.WriteInteger(MoneyAdress, moneyValue);
            MessageBox.Show("Money Hacked" , "Trainer" ,  MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int GAMEBASEADDRESS = getBaseAddress(Process.GetProcessesByName("engine")[0].Id);
            int basePTR = GAMEBASEADDRESS + 0x0005BCFC;
            int starsAdress = pmrw.MultiLevelPointerReader(basePTR, new int[] { 0x28D8 });
            int starsValue = Convert.ToInt32(textBox2.Text);
            pmrw.WriteInteger(starsAdress, starsValue);
            MessageBox.Show("Stars Hacked", "Trainer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int GAMEBASEADDRESS = getBaseAddress(Process.GetProcessesByName("engine")[0].Id);
            int basePTR = GAMEBASEADDRESS + 0x00380720;
            int timeAdress = pmrw.MultiLevelPointerReader(basePTR, new int[] { 0x298 });
            float timeFreeze = 0.2f;
            pmrw.WriteFloat(timeAdress, timeFreeze);

            
            MessageBox.Show("Time reset sucess", "Trainer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coded By OmarElKhaitb", "ABOUT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
