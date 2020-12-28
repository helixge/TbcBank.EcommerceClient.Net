# TBC Bank Ecommerce Card Payments Gateway Client (.NET Library)

[![Version](https://helix.ge/helix-tbcbank-ecommerceclient-nuget.svg?3-0-0)](https://www.nuget.org/packages/Helix.TbcBank.EcommerceClient)

[Helix.TbcBank.EcommerceClient](https://www.nuget.org/packages/Helix.TbcBank.EcommerceClient) is a .NET client library for using TBC Bank e-commerce visa and master card payments gateway .

> :warning: ⚠️ **Version 2 has introduced breaking chnages.** See [RELEASE NOTES](https://github.com/helixge/TbcBank.EcommerceClient.Net/blob/master/RELEASE-NOTES.txt) for more details

## How To Use
### Define options
You can specify either file path or file data content to the options.

Using certificate file
```csharp
var clientOptions = new TbcBankEcommerceClientOptions()
{
    CertPath = "/path/to/file.pfx",
    CertPassword = "password",
    Environment = TbcEnvironment.Production
};
```

Using certificate file data
```csharp
var byte[] certData = LoadCertDataContentAsByteArray();

var clientOptions = new TbcBankEcommerceClientOptions()
{
    CertData = certData,
    CertPassword = "",
    Environment = TbcEnvironment.Production
};
```
* **CertPath** (string)    
  Full physical path to p12 certificate provided by TBC    
  You can only assign either CertPath or CertData. Both cannot be assigned.    
  
* **CertData** (byte[])    
  Byte array data of the p12 certificate content provided by TBC    
  You can only assign either CertPath or CertData. Both cannot be assigned.    

* **CertPassword** (string)    
  Password for the certificate provided by TBC    
  
* **Environment** (string)    
  Environment you want to connect to. The possible values are:
  * **Environment.Production**     
    (most common)
  * **Environment.Test**    
    (if provided by TBC)

* **MerchantId** (string)    
  Merchant identifier. The field is optional with there is only one merchant registered. Fhe field is required when more than one merchant options are registered. You can specify any unique value to this parameter, but it is recommended to set it to the same identifier as given by the bank. It is a numeric identifier and you can find this identified in the email subject or the certificate file name sent to you by the bank.

* **Currencies** (CurrencyCode[])    
  List of currencies available for the merchant. The field is optional with there is only one merchant registered. Fhe field is required when more than one merchant options are registered.



### Create client
```csharp
var client = new TbcBankEcommerceClient(clientOptions);
```

## Payment and Transaction Related Methods
* **RegisterTransactionAsync**    
  Register payment transaction with the specified amount for single use. Once transaction id is retreieved, call ```GetClientRedirectUrl()``` method and navigate the user to the corresponding URL.    
  
* **RegisterTransactionAndGetReoccuringPaymentIdAsync**    
  Register payment transaction with specified amount and save information for future transactions. This feature should be enabled by TBC. Once transaction id is retreieved, call ```GetClientRedirectUrl()``` method and navigate the user to the corresponding URL.    

* **RegisterTransactionAndGetReoccuringPaymentIdWithoutChargeAsync**    
  Register a request to save card information for future transactions without charging the card. This feature should be enabled by TBC. Once transaction id is retreieved, call ```GetClientRedirectUrl()``` method and navigate the user to the corresponding URL.    

* **GetClientRedirectUrl**    
  Once the transation is registered and the corresponding ID is retrieved from TBC, call this method to retrieve URL where the user should be redirected to in order to enter card details and complete the transaction    
  
* **ExecuteReoccurringTransactionAsync**    
  If you have already succesfully completed the transaction using ```RegisterTransactionAndGetReoccuringPaymentIdAsync``` method, you can execute additional transactions without the user intervension using this method.    
  
* **RegisterPreAuthorizationAsync**    
  Use this method if you want to tempoarily block the amount on the card while processing offline or asynchronous operation. ```ExecutePreAuthorizationAsync()``` method must be called to complete the transaction.
  
* **ExecutePreAuthorizationAsync**    
  If you have previously pre-authorized the transaction using ```RegisterPreAuthorizationAsync()``` method, you must complete the transaction by calling this method.
  
* **CheckTransactionResultAsync**    
  Check the result of transaction using a transaction id that you have previously acquired by calling any of the operations that returns transaction id. 
  
* **ReverseTransactionAsync**    
  Reversal can be used for transactions that are still in an open bussiness day. The process shold return the funds to the client immediately. The operation can revese the full amount or only a part of it. It requires ```amount``` input parameter.
  
* **RefundTransactionAsync**    
  Refund should be used for transactions that are no longer in an open busness day. The process might take up to 3 bank days to be completed and return the funds to the client. The operation can revese the full amount or only a part of it. It requires ```amount``` input parameter.
  
* **CloseBusinessDayAsync**    
  Closes the bussiness day for a merchant    
  
* **ExecuteCreditTransactionAsync**    
  This feature should be enabled by TBC.    
  ...    
  





## Using Multiple Merchant Accounts
You might need to use multiple merchant accounts and define different currencies for each of them. In this case you need to define multiple ```TbcBankEcommerceClientOptions``` and pass them to ```TbcBankEcommerceClient``` class constructor.

When multiple ```TbcBankEcommerceClientOptions``` are defined it is required to set ```MerchantId``` and ```Currencies``` property values to all merchant options.

When each merchant has separate currencies defined in the options, no additional processing is required, the appropriate merchant will automatically be selected based on the transaction currency.

In case some of the  merchants share the same currency or if you are calling one of the following methods:
* ```CloseBussinessDayAsync```
* ```CheckTransactionResultAsync```
* ```ReverseTransactionAsync```
* ```RefundTransactionAsync```
* ```GetClientRedirectUrl```
* ```ExecuteCreditTransactionAsync```

then it is required to explicitly call ```SelectMerchant``` before any other method to set the merchant manually. Otherwise wrong merchant might be selected automatically.

### Using ```SelectMerchant``` Method
There are two options for manually selecting a merchant
* **SelectMerchant** (string merchantId)    
  The method tries to find the options with the specified `merchantId` value. Throws ```TbcBankEcommerceClientConfigurationException``` if not found.

* **SelectMerchant** (Func<TbcBankEcommerceClientOptions, bool> predicate)    
  The method tries to find the options with the specified predicate. List of all options will be passed to the predicate function and the first item receiving return ```true``` will be selected. Throws ```TbcBankEcommerceClientConfigurationException``` if no items has been selected;


## Integrating with ASP.NET Core
In order to seamlessly integrate the client with ASP.NET Core dependency injection pipeline, use the following steps:

1. Add an array entry in your appSettings.json file and specify one or more merchant options. For this example we eill call the entry ```Tbc```:
```
{
   //...other options
   "Tbc": [
    {
      "MerchantId": "0000001",
      "CertPath": "/linux/path/to/cert-file.pfx",
      "CertPassword": "password",
      "Environment": "Production",
      "Currencies": [ "GEL", "EUR" ]
    },
    {
      "MerchantId": "0000002",
      "CertPath": "C:\\Windows\\Path\\To\\cert-file.pfx",
      "CertPassword": "password",
      "Environment": "Production",
      "Currencies": [ "USD" ]
    }
  ]
   //...other options
}
```

2. call the following extension method in ```ConfigureServices``` method of ```Startup.cs``` file and specify the condifuration parameter name containing the options array:
````
services.AddTbcBankEcommerce(
  Configuration.GetTbcBankEcommerceOptions("Tbc")
);
````

3. Inject ```TbcBankEcommerceClient```:
````
public class HomeController : Controller
{
    private readonly TbcBankEcommerceClient _tbcBankEcommerceClient;

    public HomeController(
        TbcBankEcommerceClient tbcBankEcommerceClient
        )
    {
        _tbcBankEcommerceClient = tbcBankEcommerceClient;
    }

    //...other methods
}
````