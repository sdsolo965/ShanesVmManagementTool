
 param(
[string]$Name,
[PSCredential]$cred)

New-AzureRmVM `
 -ResourceGroupName 'testResourceGroup' `
  -Name $Name `
   -Location 'East US' `
    -VirtualNetworkName 'myVnet' `
     -SubnetName 'mySubnet' `
      -SecurityGroupName 'myNetworkSecurityGroup' `
       -PublicIpAddressName 'myPublicIpAddress' `
        -OpenPorts 80,3389 `
         -Credential $cred

        