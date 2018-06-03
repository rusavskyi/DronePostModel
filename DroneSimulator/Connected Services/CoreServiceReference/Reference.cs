﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DroneSimulator.CoreServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CoreServiceReference.ICoreService")]
    public interface ICoreService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/AssignCore", ReplyAction="http://tempuri.org/ICoreService/AssignCoreResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.SupportClasses.GeneratedPackage))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Package))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Station))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.PackageSize))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Transfer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Drone))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.DroneModel))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Customer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Person))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.City))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Company))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Package[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(DronePost.DataModel.Drone[]))]
        void AssignCore(object core);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/AssignCore", ReplyAction="http://tempuri.org/ICoreService/AssignCoreResponse")]
        System.Threading.Tasks.Task AssignCoreAsync(object core);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterPackage", ReplyAction="http://tempuri.org/ICoreService/RegisterPackageResponse")]
        DronePost.DataModel.Package RegisterPackage(DronePost.SupportClasses.GeneratedPackage package);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterPackage", ReplyAction="http://tempuri.org/ICoreService/RegisterPackageResponse")]
        System.Threading.Tasks.Task<DronePost.DataModel.Package> RegisterPackageAsync(DronePost.SupportClasses.GeneratedPackage package);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterTransfer", ReplyAction="http://tempuri.org/ICoreService/RegisterTransferResponse")]
        int RegisterTransfer(DronePost.DataModel.Transfer transfer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterTransfer", ReplyAction="http://tempuri.org/ICoreService/RegisterTransferResponse")]
        System.Threading.Tasks.Task<int> RegisterTransferAsync(DronePost.DataModel.Transfer transfer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterDrone", ReplyAction="http://tempuri.org/ICoreService/RegisterDroneResponse")]
        int RegisterDrone(DronePost.DataModel.Drone drone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterDrone", ReplyAction="http://tempuri.org/ICoreService/RegisterDroneResponse")]
        System.Threading.Tasks.Task<int> RegisterDroneAsync(DronePost.DataModel.Drone drone);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterStation", ReplyAction="http://tempuri.org/ICoreService/RegisterStationResponse")]
        int RegisterStation(DronePost.DataModel.Station station);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterStation", ReplyAction="http://tempuri.org/ICoreService/RegisterStationResponse")]
        System.Threading.Tasks.Task<int> RegisterStationAsync(DronePost.DataModel.Station station);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterCustomer", ReplyAction="http://tempuri.org/ICoreService/RegisterCustomerResponse")]
        int RegisterCustomer(DronePost.DataModel.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RegisterCustomer", ReplyAction="http://tempuri.org/ICoreService/RegisterCustomerResponse")]
        System.Threading.Tasks.Task<int> RegisterCustomerAsync(DronePost.DataModel.Customer customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RequestDroneForPackage", ReplyAction="http://tempuri.org/ICoreService/RequestDroneForPackageResponse")]
        void RequestDroneForPackage(DronePost.DataModel.Package package);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RequestDroneForPackage", ReplyAction="http://tempuri.org/ICoreService/RequestDroneForPackageResponse")]
        System.Threading.Tasks.Task RequestDroneForPackageAsync(DronePost.DataModel.Package package);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RequestDroneForPackages", ReplyAction="http://tempuri.org/ICoreService/RequestDroneForPackagesResponse")]
        void RequestDroneForPackages(DronePost.DataModel.Package[] packages);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RequestDroneForPackages", ReplyAction="http://tempuri.org/ICoreService/RequestDroneForPackagesResponse")]
        System.Threading.Tasks.Task RequestDroneForPackagesAsync(DronePost.DataModel.Package[] packages);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RequestChargeForDrone", ReplyAction="http://tempuri.org/ICoreService/RequestChargeForDroneResponse")]
        int RequestChargeForDrone(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/RequestChargeForDrone", ReplyAction="http://tempuri.org/ICoreService/RequestChargeForDroneResponse")]
        System.Threading.Tasks.Task<int> RequestChargeForDroneAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/GetDrones", ReplyAction="http://tempuri.org/ICoreService/GetDronesResponse")]
        DronePost.DataModel.Drone[] GetDrones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/GetDrones", ReplyAction="http://tempuri.org/ICoreService/GetDronesResponse")]
        System.Threading.Tasks.Task<DronePost.DataModel.Drone[]> GetDronesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICoreServiceChannel : DroneSimulator.CoreServiceReference.ICoreService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CoreServiceClient : System.ServiceModel.ClientBase<DroneSimulator.CoreServiceReference.ICoreService>, DroneSimulator.CoreServiceReference.ICoreService {
        
        public CoreServiceClient() {
        }
        
        public CoreServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CoreServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoreServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoreServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AssignCore(object core) {
            base.Channel.AssignCore(core);
        }
        
        public System.Threading.Tasks.Task AssignCoreAsync(object core) {
            return base.Channel.AssignCoreAsync(core);
        }
        
        public DronePost.DataModel.Package RegisterPackage(DronePost.SupportClasses.GeneratedPackage package) {
            return base.Channel.RegisterPackage(package);
        }
        
        public System.Threading.Tasks.Task<DronePost.DataModel.Package> RegisterPackageAsync(DronePost.SupportClasses.GeneratedPackage package) {
            return base.Channel.RegisterPackageAsync(package);
        }
        
        public int RegisterTransfer(DronePost.DataModel.Transfer transfer) {
            return base.Channel.RegisterTransfer(transfer);
        }
        
        public System.Threading.Tasks.Task<int> RegisterTransferAsync(DronePost.DataModel.Transfer transfer) {
            return base.Channel.RegisterTransferAsync(transfer);
        }
        
        public int RegisterDrone(DronePost.DataModel.Drone drone) {
            return base.Channel.RegisterDrone(drone);
        }
        
        public System.Threading.Tasks.Task<int> RegisterDroneAsync(DronePost.DataModel.Drone drone) {
            return base.Channel.RegisterDroneAsync(drone);
        }
        
        public int RegisterStation(DronePost.DataModel.Station station) {
            return base.Channel.RegisterStation(station);
        }
        
        public System.Threading.Tasks.Task<int> RegisterStationAsync(DronePost.DataModel.Station station) {
            return base.Channel.RegisterStationAsync(station);
        }
        
        public int RegisterCustomer(DronePost.DataModel.Customer customer) {
            return base.Channel.RegisterCustomer(customer);
        }
        
        public System.Threading.Tasks.Task<int> RegisterCustomerAsync(DronePost.DataModel.Customer customer) {
            return base.Channel.RegisterCustomerAsync(customer);
        }
        
        public void RequestDroneForPackage(DronePost.DataModel.Package package) {
            base.Channel.RequestDroneForPackage(package);
        }
        
        public System.Threading.Tasks.Task RequestDroneForPackageAsync(DronePost.DataModel.Package package) {
            return base.Channel.RequestDroneForPackageAsync(package);
        }
        
        public void RequestDroneForPackages(DronePost.DataModel.Package[] packages) {
            base.Channel.RequestDroneForPackages(packages);
        }
        
        public System.Threading.Tasks.Task RequestDroneForPackagesAsync(DronePost.DataModel.Package[] packages) {
            return base.Channel.RequestDroneForPackagesAsync(packages);
        }
        
        public int RequestChargeForDrone(int id) {
            return base.Channel.RequestChargeForDrone(id);
        }
        
        public System.Threading.Tasks.Task<int> RequestChargeForDroneAsync(int id) {
            return base.Channel.RequestChargeForDroneAsync(id);
        }
        
        public DronePost.DataModel.Drone[] GetDrones() {
            return base.Channel.GetDrones();
        }
        
        public System.Threading.Tasks.Task<DronePost.DataModel.Drone[]> GetDronesAsync() {
            return base.Channel.GetDronesAsync();
        }
    }
}
