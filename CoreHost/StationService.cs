﻿[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IStationService")]
public interface IStationService
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/CheckIn", ReplyAction = "http://tempuri.org/IStationService/CheckInResponse")]
    void CheckIn(DronePost.DataModel.Drone drone);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/CheckIn", ReplyAction = "http://tempuri.org/IStationService/CheckInResponse")]
    System.Threading.Tasks.Task CheckInAsync(DronePost.DataModel.Drone drone);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/CheckOut", ReplyAction = "http://tempuri.org/IStationService/CheckOutResponse")]
    void CheckOut(DronePost.DataModel.Drone drone);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/CheckOut", ReplyAction = "http://tempuri.org/IStationService/CheckOutResponse")]
    System.Threading.Tasks.Task CheckOutAsync(DronePost.DataModel.Drone drone);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/GivePackageToRecipient", ReplyAction = "http://tempuri.org/IStationService/GivePackageToRecipientResponse")]
    void GivePackageToRecipient(DronePost.DataModel.Customer customer, DronePost.DataModel.Package package);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/GivePackageToRecipient", ReplyAction = "http://tempuri.org/IStationService/GivePackageToRecipientResponse")]
    System.Threading.Tasks.Task GivePackageToRecipientAsync(DronePost.DataModel.Customer customer, DronePost.DataModel.Package package);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/GetPackageFromCustomer", ReplyAction = "http://tempuri.org/IStationService/GetPackageFromCustomerResponse")]
    bool GetPackageFromCustomer(DronePost.SupportClasses.GeneratedPackage package);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/GetPackageFromCustomer", ReplyAction = "http://tempuri.org/IStationService/GetPackageFromCustomerResponse")]
    System.Threading.Tasks.Task<bool> GetPackageFromCustomerAsync(DronePost.SupportClasses.GeneratedPackage package);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/SetTask", ReplyAction = "http://tempuri.org/IStationService/SetTaskResponse")]
    void SetTask(DronePost.SupportClasses.StationTask stationTask);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/SetTask", ReplyAction = "http://tempuri.org/IStationService/SetTaskResponse")]
    System.Threading.Tasks.Task SetTaskAsync(DronePost.SupportClasses.StationTask stationTask);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/AddTask", ReplyAction = "http://tempuri.org/IStationService/AddTaskResponse")]
    void AddTask(DronePost.SupportClasses.StationTask stationTask);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/AddTask", ReplyAction = "http://tempuri.org/IStationService/AddTaskResponse")]
    System.Threading.Tasks.Task AddTaskAsync(DronePost.SupportClasses.StationTask stationTask);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/DoNextTask", ReplyAction = "http://tempuri.org/IStationService/DoNextTaskResponse")]
    void DoNextTask(bool force);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/DoNextTask", ReplyAction = "http://tempuri.org/IStationService/DoNextTaskResponse")]
    System.Threading.Tasks.Task DoNextTaskAsync(bool force);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/RequestChargeSlot", ReplyAction = "http://tempuri.org/IStationService/RequestChargeSlotResponse")]
    int RequestChargeSlot();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStationService/RequestChargeSlot", ReplyAction = "http://tempuri.org/IStationService/RequestChargeSlotResponse")]
    System.Threading.Tasks.Task<int> RequestChargeSlotAsync();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IStationServiceChannel : IStationService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class StationServiceClient : System.ServiceModel.ClientBase<IStationService>, IStationService
{

    public StationServiceClient()
    {
    }

    public StationServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public StationServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public StationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public StationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
    {
    }

    public void CheckIn(DronePost.DataModel.Drone drone)
    {
        base.Channel.CheckIn(drone);
    }

    public System.Threading.Tasks.Task CheckInAsync(DronePost.DataModel.Drone drone)
    {
        return base.Channel.CheckInAsync(drone);
    }

    public void CheckOut(DronePost.DataModel.Drone drone)
    {
        base.Channel.CheckOut(drone);
    }

    public System.Threading.Tasks.Task CheckOutAsync(DronePost.DataModel.Drone drone)
    {
        return base.Channel.CheckOutAsync(drone);
    }

    public void GivePackageToRecipient(DronePost.DataModel.Customer customer, DronePost.DataModel.Package package)
    {
        base.Channel.GivePackageToRecipient(customer, package);
    }

    public System.Threading.Tasks.Task GivePackageToRecipientAsync(DronePost.DataModel.Customer customer, DronePost.DataModel.Package package)
    {
        return base.Channel.GivePackageToRecipientAsync(customer, package);
    }

    public bool GetPackageFromCustomer(DronePost.SupportClasses.GeneratedPackage package)
    {
        return base.Channel.GetPackageFromCustomer(package);
    }

    public System.Threading.Tasks.Task<bool> GetPackageFromCustomerAsync(DronePost.SupportClasses.GeneratedPackage package)
    {
        return base.Channel.GetPackageFromCustomerAsync(package);
    }

    public void SetTask(DronePost.SupportClasses.StationTask stationTask)
    {
        base.Channel.SetTask(stationTask);
    }

    public System.Threading.Tasks.Task SetTaskAsync(DronePost.SupportClasses.StationTask stationTask)
    {
        return base.Channel.SetTaskAsync(stationTask);
    }

    public void AddTask(DronePost.SupportClasses.StationTask stationTask)
    {
        base.Channel.AddTask(stationTask);
    }

    public System.Threading.Tasks.Task AddTaskAsync(DronePost.SupportClasses.StationTask stationTask)
    {
        return base.Channel.AddTaskAsync(stationTask);
    }

    public void DoNextTask(bool force)
    {
        base.Channel.DoNextTask(force);
    }

    public System.Threading.Tasks.Task DoNextTaskAsync(bool force)
    {
        return base.Channel.DoNextTaskAsync(force);
    }

    public int RequestChargeSlot()
    {
        return base.Channel.RequestChargeSlot();
    }

    public System.Threading.Tasks.Task<int> RequestChargeSlotAsync()
    {
        return base.Channel.RequestChargeSlotAsync();
    }
}
