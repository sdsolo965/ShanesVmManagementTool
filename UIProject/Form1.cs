using System;
using System.Collections.Generic;
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

namespace UIProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            try
            {


                Pipeline pipeline = runspace.CreatePipeline();
                Command connectAzureRmAccount = new Command("Connect-AzureRmAccount");

                pipeline.Commands.Add(connectAzureRmAccount);
                pipeline.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                runspace.Close();
            }

            MessageBox.Show("Successfully connected to Azure Acount");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.ToString();

            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            
            try
            {
                Pipeline pipeline = runspace.CreatePipeline();
                Command scriptCommand = new Command(@".\Users\shanesolomon\Documents\StorageLearning\Scripts\CreateAzureVMv1.ps1");
                pipeline.Commands.Add(scriptCommand);
                scriptCommand.Parameters.Add("Name", name);
                pipeline.Invoke();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                runspace.Close();
            }

            MessageBox.Show("Successfully created Azure Virtual Machine");
        }
    }
}
