using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.IO;
using System.Collections;
using Microsoft.PowerShell;
using VmRepository.Azure;
using VmRepository.Interface;

namespace UIProject
{
    public partial class Form1 : Form
    {

        IVmRepository repository = new AzureRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                repository.ConnectToCloudService();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            MessageBox.Show("Successfully connected to Azure Acount");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.ToString();
            
            try
            {
                repository.AddVirtualMachine(new VirtualMachine(name));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            MessageBox.Show("Successfully created Azure Virtual Machine");
        }
    }
}
