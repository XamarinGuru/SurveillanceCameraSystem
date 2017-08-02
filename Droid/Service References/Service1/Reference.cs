// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace goheja.Service1 {
    
}


[System.ServiceModel.ServiceContractAttribute(Namespace="goheja.Service1", ConfigurationName="TempConvertSoap")]
public interface TempConvertSoap {
    
    [System.ServiceModel.OperationContractAttribute(Action="*", ReplyAction="http://www.w3schools.com/webservices/FahrenheitToCelsius")]
    string FahrenheitToCelsius(string Fahrenheit);
    
    [System.ServiceModel.OperationContractAttribute(Action="*", ReplyAction="http://www.w3schools.com/webservices/FahrenheitToCelsius", AsyncPattern=true)]
    System.IAsyncResult BeginFahrenheitToCelsius(string Fahrenheit, System.AsyncCallback asyncCallback, object userState);
    
    string EndFahrenheitToCelsius(System.IAsyncResult result);
    
    [System.ServiceModel.OperationContractAttribute(Action="*", ReplyAction="http://www.w3schools.com/webservices/CelsiusToFahrenheit")]
    string CelsiusToFahrenheit(string Celsius);
    
    [System.ServiceModel.OperationContractAttribute(Action="*", ReplyAction="http://www.w3schools.com/webservices/CelsiusToFahrenheit", AsyncPattern=true)]
    System.IAsyncResult BeginCelsiusToFahrenheit(string Celsius, System.AsyncCallback asyncCallback, object userState);
    
    string EndCelsiusToFahrenheit(System.IAsyncResult result);
}

public interface TempConvertSoapChannel : TempConvertSoap, System.ServiceModel.IClientChannel {
}

public class TempConvertSoapClient : System.ServiceModel.ClientBase<TempConvertSoap>, TempConvertSoap {
    
    public TempConvertSoapClient() {
    }
    
    public TempConvertSoapClient(string endpointConfigurationName) : 
            base(endpointConfigurationName) {
    }
    
    public TempConvertSoapClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress) {
    }
    
    public TempConvertSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress) {
    }
    
    public TempConvertSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress endpoint) : 
            base(binding, endpoint) {
    }
    
    public string FahrenheitToCelsius(string Fahrenheit) {
        return base.Channel.FahrenheitToCelsius(Fahrenheit);
    }
    
    public System.IAsyncResult BeginFahrenheitToCelsius(string Fahrenheit, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginFahrenheitToCelsius(Fahrenheit, asyncCallback, userState);
    }
    
    public string EndFahrenheitToCelsius(System.IAsyncResult result) {
        return base.Channel.EndFahrenheitToCelsius(result);
    }
    
    public string CelsiusToFahrenheit(string Celsius) {
        return base.Channel.CelsiusToFahrenheit(Celsius);
    }
    
    public System.IAsyncResult BeginCelsiusToFahrenheit(string Celsius, System.AsyncCallback asyncCallback, object userState) {
        return base.Channel.BeginCelsiusToFahrenheit(Celsius, asyncCallback, userState);
    }
    
    public string EndCelsiusToFahrenheit(System.IAsyncResult result) {
        return base.Channel.EndCelsiusToFahrenheit(result);
    }
}