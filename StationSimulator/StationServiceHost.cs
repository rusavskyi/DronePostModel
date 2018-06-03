using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using DronePost.Interfaces;

namespace StationSimulator
{
    public class MyServiceHostFactory : ServiceHostFactory
    {
        private readonly IStation dep;

        public MyServiceHostFactory()
        {
            //this.dep = new MyClass();
        }

        protected override ServiceHost CreateServiceHost(Type serviceType,
            Uri[] baseAddresses)
        {
            return new StationServiceHost(this.dep, serviceType, baseAddresses);
        }
    }

    public class StationServiceHost : ServiceHost
    {
        public StationServiceHost(IStation dep, Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            if (dep == null)
            {
                throw new ArgumentNullException("dep");
            }

            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new MyInstanceProvider(dep));
            }
        }
    }

    public class MyInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly IStation dep;

        public MyInstanceProvider(IStation dep)
        {
            if (dep == null)
            {
                throw new ArgumentNullException("dep");
            }

            this.dep = dep;
        }

        #region IInstanceProvider Members

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return new StationService.StationService(this.dep);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        #endregion

        #region IContractBehavior Members

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        #endregion
    }
}
