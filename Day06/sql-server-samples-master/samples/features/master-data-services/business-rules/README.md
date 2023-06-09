# Master Data Services Business Rule API Sample
This is a C# code sample to show how to use MDS APIs to create, edit, validate, exclude, and delete business rules. The scenario in this sample is that the system creates a business rule (when "Code equals ABC", "Name must be equal to Test") and edits the business rule (change the condition to �Code starts with Test�
The next step creates a member that causes a business rule validation error (add a member with Code = �Test12� and Name = �AA�), processes validation, and gets the validation issue information. To complete the example, the sample excludes and deletes the business rule.
For every action that changes the business rule status (creates, edits, excludes, and deletes), the business rule must be published to finalize the change.

Please set the MDS URL (plus /Service/Service.svc) to mdsURL in Program.cs.

```C#
string mdsURL = @"http://localhost/MDS/Service/Service.svc";
```

Program.cs uses Reference.cs (the service reference class file) that was generated by using Visual Studio to access MDS Web service API. You may need to regenerate Reference.cs in case when MDS Web service API is changed.

To generate Reference.cs using Visual Studio:

You need to expose the WSDL. Exposing the WSDL is only necessary at the time when you want to generate proxy classes using a client development tool such as Visual Studio. After a proxy has been generated, the WSDL does not need to be exposed going forward for client programs to call the API.

To enable an http/https Get on the WSDL:

1. Open the MDS web.config file in a text editor (<Program Files>\Microsoft SQL Server\Master Data Services\WebApplication\web.config).
2. Search for the tag serviceMetadata and set httpGetEnabled to true (or httpsGetEnabled if using SSL).


To also enable service exception details for additional debugging (not necessary for standard, trapped errors):
1. Search for the tag �serviceDebug� and set includeExceptionDetailInFaults to true.

After that you need to add a Service Reference to http://ServerName/MdsSiteName/service/service.svc and set the namespace to the service to "MDSTestService" in the following steps using Visual Studio.

1. Click "Add Service Reference".
2. In Address, enter the URL to the MDS service which will be �http://ServerName/MdsSiteName/service/service.svc�.
3. Specify the namespace to the service as "MDSTestService" in the Namespace box.
4. Click the Advanced button to configure advanced settings.
5. Check Always generate message contracts.
6. Set the Collection type drop-down to System.Collections.ObjectModel.Collection.
7. Click OK to return to the Add Service Reference dialog.
8. Click OK.

Reference.cs will be generated in BusinessRules\Service References\MDSTestService folder. You can replace BusinessRules\Reference.cs with the newly generated one.
