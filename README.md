# TBC Bank Ecommerce Card Payments Gateway Client (.NET Library)

[![Version](https://helix.ge/helix-tbcbank-ecommerceclient-nuget.svg?1-0-0)](https://www.nuget.org/packages/Helix.TbcBank.EcommerceClient)

TbcBank.EcommerceClient is a .NET client library for using TBC Bank e-commerce visa and master card payments gateway .


## Define options
```csharp
var clientOptions = new TbcBankEcommerceClientOptions()
{
    CertPath = "",
    CertPassword = "",
    Environment = TbcEnvironment.Production
};
```
* **CertPath** (string)    
  Full physical path to p12 certificate provided by TBC    
  
* **CertPassword** (string)    
  Password for the certificate provided by TBC    
  
* **Environment** (string)    
  Environment you want to connect to. The possible values are:
  * **Environment.Production**     
    (most common)
  * **Environment.Test**    
    (if provided by TBC)


## Create client
```csharp
var client = new TbcBankEcommerceClient(clientOptions);
```

## Use the API
* **RegisterTransactionAsync**    
  Register transaction for single use. Once transaction id is retreieved, call GetClientRedirectUrl() method and navigate the user to the corresponding URL.    
  
* **RegisterTransactionAndGetReoccuringPaymentIdAsync**    
  Register transaction and save information for future transactions. This feature should be enabled by TBC. Once transaction id is retreieved, call GetClientRedirectUrl() method and navigate the user to the corresponding URL.    
  
* **GetClientRedirectUrl**    
  Once the transation is registered and the corresponding ID is retrieved from TBC, call this method to retrieve URL where the user should be redirected to in order to enter card details and complete the transaction    
  
* **ExecuteReoccurringTransactionAsync**    
  If you have already succesfully completed the transaction using RegisterTransactionAndGetReoccuringPaymentIdAsync method, you can execute additional transactions without the user intervension using this method.    
  
* **RegisterPreAuthorizationAsync**    
  ...    
  
* **ExecutePreAuthorizationAsync**    
  ...    
  
* **CheckTransactionResultAsync**    
  ...    
  
* **ReverseTransactionAsync**    
  ...    
  
* **RefundTransactionAsync**    
  ...    
  
* **ExecuteCreditTransaction**    
  ...    
  
