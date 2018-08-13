using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VmRepository.Interface
{
    public interface IVmRepository
    {
        IEnumerable<VirtualMachine> GetVirtualMachines();

        VirtualMachine GetVirtualMachine();
        
        void AddVirtualMachine(VirtualMachine virtualMachine);
        
        void UpdateVirtualMachines(IEnumerable<VirtualMachine> virtualMachineList);
        
        void UpdateVirtualMachine(VirtualMachine virtualMachine);
        
        void DeleteVirtualMachine(VirtualMachine virtualMachine);

    }
}
