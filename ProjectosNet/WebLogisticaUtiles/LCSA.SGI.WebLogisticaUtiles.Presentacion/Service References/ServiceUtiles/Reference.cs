﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.586
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.ServiceUtiles {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceUtiles.IUtiles")]
    public interface IUtiles {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUtiles/ListarArticulosUtiles", ReplyAction="http://tempuri.org/IUtiles/ListarArticulosUtilesResponse")]
        System.Data.DataTable ListarArticulosUtiles(string SQL);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUtilesChannel : LCSA.SGI.WebLogisticaUtiles.Presentacion.ServiceUtiles.IUtiles, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UtilesClient : System.ServiceModel.ClientBase<LCSA.SGI.WebLogisticaUtiles.Presentacion.ServiceUtiles.IUtiles>, LCSA.SGI.WebLogisticaUtiles.Presentacion.ServiceUtiles.IUtiles {
        
        public UtilesClient() {
        }
        
        public UtilesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UtilesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UtilesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UtilesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable ListarArticulosUtiles(string SQL) {
            return base.Channel.ListarArticulosUtiles(SQL);
        }
    }
}