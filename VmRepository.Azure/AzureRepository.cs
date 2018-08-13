using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VmRepository.Interface;

namespace VmRepository.Azure
{
    public class AzureRepository : IVmRepository
    {
        public void AddVirtualMachine(VirtualMachine virtualMachine)
        {
            throw new NotImplementedException();
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
