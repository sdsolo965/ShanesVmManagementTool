using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VmRepository.Interface;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace VmRepository.Azure
{
    public class AzureRepository : IVmRepository
    {
        Runspace runspace = RunspaceFactory.CreateRunspace();
        private string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public AzureRepository()
        {
            runspace.Open();
        }

        public void AddVirtualMachine(VirtualMachine virtualMachine)
        {
            string scriptLocation = Path.Combine(executableLocation, "CreateAzureVMv1.ps1");

            Pipeline pipeline = runspace.CreatePipeline();
            Command getCred = new Command("Get-Credential");
            pipeline.Commands.Add(getCred);
            Collection<PSObject> credential = pipeline.Invoke();
            Command scriptCommand = new Command(scriptLocation);
            pipeline.Commands.Add(scriptCommand);
            scriptCommand.Parameters.Add("Name", virtualMachine.Name);
            scriptCommand.Parameters.Add("Credential", credential[0]);
            pipeline.Invoke();
        }

        public void ConnectToCloudService()
        {
            string scriptLocation = Path.Combine(executableLocation, "ConnectAzureAccount.ps1");

            /*
            This is what causes an exception to be throw due to AzureRm.Profile not being properly loaded.

            Command connectAzureRmAccount = new Command("Connect-AzureRmAccount");
            pipeline.Commands.Add(connectAzureRmAccount);

            pipeline.Invoke();
            */

            //Temp work around that worked lastnight, but doesn't seem to want to allow me to set execution policy anymore.
            Pipeline pipeline = runspace.CreatePipeline();
            Command setExecutionPolicy = new Command("Set-ExecutionPolicy");
            setExecutionPolicy.Parameters.Add("Scope", "CurrentUser");
            setExecutionPolicy.Parameters.Add("ExecutionPolicy", "Unrestricted");
            pipeline.Commands.Add(setExecutionPolicy);
            pipeline.Commands.AddScript(scriptLocation);
            pipeline.Invoke();

            

        }

        public void DeleteVirtualMachine(VirtualMachine virtualMachine)
        {
            throw new NotImplementedException();
        }

        public VirtualMachine GetVirtualMachine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VirtualMachine> GetVirtualMachines()
        {
            throw new NotImplementedException();
        }

        public void UpdateVirtualMachine(VirtualMachine virtualMachine)
        {
            throw new NotImplementedException();
        }

        public void UpdateVirtualMachines(IEnumerable<VirtualMachine> virtualMachineList)
        {
            throw new NotImplementedException();
        }
    }
}
