﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IService2")]
    public interface IService2 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/tomarInformacion", ReplyAction="http://tempuri.org/IService2/tomarInformacionResponse")]
        void tomarInformacion(string nombre, string apellido, string sexo, string email, string dir, string ciudad, string reque);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/tomarInformacion", ReplyAction="http://tempuri.org/IService2/tomarInformacionResponse")]
        System.Threading.Tasks.Task tomarInformacionAsync(string nombre, string apellido, string sexo, string email, string dir, string ciudad, string reque);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService2Channel : WebApplication1.ServiceReference2.IService2, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service2Client : System.ServiceModel.ClientBase<WebApplication1.ServiceReference2.IService2>, WebApplication1.ServiceReference2.IService2 {
        
        public Service2Client() {
        }
        
        public Service2Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service2Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service2Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service2Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void tomarInformacion(string nombre, string apellido, string sexo, string email, string dir, string ciudad, string reque)
        {
            base.Channel.tomarInformacion(nombre,apellido,sexo,email,dir,ciudad,reque);
        }
        
        public System.Threading.Tasks.Task tomarInformacionAsync(string nombre, string apellido, string sexo, string email, string dir, string ciudad, string reque) {
            return base.Channel.tomarInformacionAsync(nombre, apellido, sexo, email, dir, ciudad, reque);
        }
    }
}