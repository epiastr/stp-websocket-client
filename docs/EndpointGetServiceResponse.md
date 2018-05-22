# IO.Swagger.Model.EndpointGetServiceResponse
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ResultCode** | **string** | 0 for successful requests. For unsuccessful requests, this value contains the error code. | 
**ResultDescription** | **string** | Returns OK if successful or error description otherwise. | 
**ResultType** | **string** | SUCCESS for successful requests BUSINESSERROR if a business is blocked by the rule. SECURITYERROR if it is attached to security or authorization control, SYSTEMERROR if there is a system error. | 
**TransactionId** | **string** | SUCCESS for successful requests BUSINESSERROR if a business is blocked by the rule. SECURITYERROR if it is attached to security or authorization control, SYSTEMERROR if there is a system error. | [optional] 
**Body** | [**EndpointResponse**](EndpointResponse.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

