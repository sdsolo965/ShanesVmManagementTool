namespace VmRepository.Interface
{
    public class VirtualMachine
    {
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string VirtualNetworkName { get; set; }
        public string SubnetName { get; set; }
        public string SecurityGroupName { get; set; }
        public string PublicIpAddressName { get; set; }
        public int[] OpenPorts { get; set; }

        public VirtualMachine(string name)
        {
            Name = name;
        }
    }
}