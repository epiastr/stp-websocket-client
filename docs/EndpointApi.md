# IO.Swagger.Api.EndpointApi

All URIs are relative to *https://stp-dev.epias.com.tr/stp-broadcaster-orchestrator/rest*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Endpointget**](EndpointApi.md#endpointget) | **POST** /endpoint/get | Realtime Notification Service Configuration


<a name="endpointget"></a>
# **Endpointget**
> EndpointGetServiceResponse Endpointget (EndpointGetRequest body = null)

Realtime Notification Service Configuration

Returns connection parameters and url of notification endpoint.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class EndpointgetExample
    {
        public void main()
        {
            var apiInstance = new EndpointApi();
            var body = new EndpointGetRequest(); // EndpointGetRequest |  (optional) 

            try
            {
                // Realtime Notification Service Configuration
                EndpointGetServiceResponse result = apiInstance.Endpointget(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EndpointApi.Endpointget: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**EndpointGetRequest**](EndpointGetRequest.md)|  | [optional] 

### Return type

[**EndpointGetServiceResponse**](EndpointGetServiceResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

