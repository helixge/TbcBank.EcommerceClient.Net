# TBC Bank Ecommerce Card Payments Gateway Client (.NET Library)

[![Version](https://helix.ge/helix-tbcbank-ecommerceclient-nuget.svg?1-2-0)](https://www.nuget.org/packages/Helix.TbcBank.EcommerceClient)

[Helix.TbcBank.EcommerceClient](https://www.nuget.org/packages/Helix.TbcBank.EcommerceClient) is a .NET client library for using TBC Bank e-commerce visa and master card payments gateway .


## How To Use
### Define options
You can specify either file path or file data content to the options.

Using certificate file
```csharp
var clientOptions = new TbcBankEcommerceClientOptions()
{
    CertPath = "/path/to/file.p12",
    CertPassword = "",
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


### Create client
```csharp
var client = new TbcBankEcommerceClient(clientOptions);
```

## Methods
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
  
* **CloseBusinessDay**    
  ...    
  
* **ExecuteCreditTransaction**    
  This feature should be enabled by TBC.    
  ...    
  
