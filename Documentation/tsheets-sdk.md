# TSheets C# .NET SDK Documentation

This documentation is intended to be a quick start reference, and covers basic usage and common practices.  It should be read in conjunction with the TSheets [API documentation](https://tsheetsteam.github.io/api_docs/), where you'll find comprehensive information on all endpoints, operations, and data types supported by the TSheets API.

## Getting Started
1. [Sign up for a free TSheets trial](https://www.tsheets.com/#a:apidocs)
2. [Obtain an OAuth access token](https://tsheetsteam.github.io/api_docs/#obtaining-an-api-access-token)
3. Try the SDK example code, or read on.


## The DataService object
`DataService` is the top-level service class for interacting with all TSheets API operations.  Begin by instantiating this class.

For **development** purposes, it's simplest to construct the data service with a static OAuth token string (obtained in _Getting Started_, step 2 above):

```cs
var apiClient = new DataService("<YOUR_AUTH_TOKEN>", logger);
```

For **production** applications, however, you'll need to use the OAuth2 flow (described [here](https://tsheetsteam.github.io/api_docs/#oauth2-0)).  In this case you'll need to supply your own implementation of the `IOAuth2` interface, for example:

```cs
/// <summary>
/// An example custom auth provider (for you to fully implement).
/// Retrieves an encrypted token from a database (by customer
/// ID lookup), and returns the decrypted string.
/// </summary>
internal class MyAuthProvider : IOAuth2
{
    private readonly int customerId;
    private readonly IDBClient dbClient;

    internal MyAuthProvider(int customerId)
        :this(customerId, new DBClient())
    {
    }

    internal MyAuthProvider(int customerId, DBClient dbClient)
    {
        this.customerId = customerId;
        this.dbClient = dbClient;
    }

    public string GetAccessToken()
    {
        string tokenEnc = this.dbClient.GetEncryptedToken(this.customerId);
        return Decrypt(tokenEnc);
    }
}
```

The data service object is then instantiated, as follows:
```cs
var authProvider = new MyAuthProvider(customerId: 100);

var apiClient = new DataService(
    new DataServiceContext(authProvider),
    logger);

```

See the example code for additional ways the `DataService` class can be configured upon instantiation.


## Logging
The SDK uses the common logging framework provided by .NET Core's [Microsoft.Extensions.Logging](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging?view=aspnetcore-2.2) namespace to support [ease of use](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2) with a variety of built-in and third-party logging providers (NLog, Serilog, etc.). To use, pass an `ILogger` instance to the `DataService` constructor, for example:
```cs
var apiClient = new DataService("<YOUR_AUTH_TOKEN>", logger);
```
There are 6 logging levels, in increasing order of verbosity: _Critical, Error, Warning, Information, Debug, and Trace_.

Note that both the _Debug_ and _Trace_ levels are extremely verbose and should only be used temporarily, for troubleshooting purposes.  By default, we recommend you configure the logger to use the _Information_ level for standard production logging.


## Endpoints & Operations
The SDK provides both synchronous and asynchronous methods for all API operations, as well as overloads for optionally controlling aspects of request behavior, and for creating or updating either a single entity, or multiple entities (batch mode), in a single call.


### "Get" Operations
To retrieve entities, pass the appropriate filter object to the corresponding _Get_ method.  Note that each endpoint has a different set of required filter properties.  In many cases all properties are _optional_, or even the filter object itself (e.g. `GetJobcodes()` and `GetCurrentUser()`).  Consult the _Retrieve_ section of the relevant endpoint in the [API documentation](https://tsheetsteam.github.io/api_docs) for specifics.

**Examples**:

```cs
// Retrieve all users that have been modified within the past week
// and have a last name that begins with the letter 'S'.

var userFilter = new UserFilter
{
    LastName = "S*",
    ModifiedSince = DateTimeOffset.Now.AddDays(-7)
};

(IList<User> users, ResultsMeta resultsMeta) = apiClient.GetUsers(userFilter);

```

```cs
// Retrieve 3 jobcodes, by id.        
var jobcodeFilter = new JobcodeFilter
{
    Ids = new[] { 137, 175, 199 }
};

(IList<Jobcode> jobcodes, ResultsMeta resultsMeta) = apiClient.GetJobcodes(jobcodeFilter);
```

```cs
// Retrieve the current user, asynchronously.
(User user, ResultsMeta resultsMeta) = await apiClient.GetCurrentUserAsync().ConfigureAwait(false);

// Retrieve all users, with a cancellation token.
// If not yet complete, cancel after 200ms.
var tokenSource = new CancellationTokenSource();
tokenSource.CancelAfter(200);
(IList<User> users, ResultsMeta resultsMeta) = await apiClient.GetUsersAsync(tokenSource.Token).ConfigureAwait(false);
```

#### Auto-Paging Behavior
Enabled by default, the SDK includes "auto-paging" behavior that simplifies the retrieval of entities that exceed the maximum count of 50 items per page.

```cs
// Retrieves all users, regardless of the number of page requests required.
(IList<User> allUsers, _) = apiClient.GetUsers();
```

This behavior can be disabled so that you can take direct control over paged requests.  The following code is functionally equivalent to the example above:
```cs
var allUsers = new List<User>();
var requestOptions = new RequestOptions { AutoPaging = false };

ResultsMeta resultsMeta = null;
do
{
    IList<User> users;
    (users, resultsMeta) = apiClient.GetUsers(requestOptions);

    allUsers.AddRange(users);

    requestOptions.Page++;
}
while (resultsMeta.More);
```

### "Create" Operations
Pass an `IEnumerable` batch of entities to the corresponding _Create_ method.  Note that each entity type has a different set of required properties.  Consult the _Create_ section of the relevant endpoint in the [API documentation](https://tsheetsteam.github.io/api_docs) for specifics. Also, each entity type includes a constructor with the minimum set of parameters needed to satisfy the method.  Use object initializer syntax to set additional properties, for example:

```cs
var users = new List<User>
{
    new User("bobsmith", "Bob", "Smith"),
    new User("raviagarwal", "Ravi", "Agarwal")
    {
        EmployeeNumber = 14
    }
};

apiClient.CreateUsers(users);
```

#### Multistatus Exceptions
On a _Create_ or _Update_ operation, it's possible that some of the entities will succeed, and others fail.  For this reason, the following pattern is recommended:

```cs
try
{
    var users = new List<User>
    {
        new User("bobsmith", "Bob", "Smith"),
        new User("raviagarwal", "Ravi", "Agarwal")
        {
            EmployeeNumber = 14
        }
    };

    apiClient.CreateUsers(users);
}
catch (MultiStatusException<User> e)
{
    foreach (ErrorItem<User> error in e.FailureResults)
    {
        // Take corrective action here.
        // The error object contains exception details and an index number
        // to identify which item in the input list failed.
    }
}
```

#### Auto-Batching Behavior
The TSheets API allows a maximum of 50 items per batch on a _create_ or _update_ operation.  Enabled by default, the SDK includes "auto-batching" behavior to hide this limitation, by automatically splitting the batch into multiple request calls.  Results, as well as any multi-status exceptions, are automatically consolidated. To disable this behavior, simply limit your batch sizes to a maximum of 50 items.


### "Update" Operations
For an _Update_ operation, the `id` property of the entities in the batch must be set.  Otherwise, the operation is similar to a _Create_.  Consult the _Update_ section of the relevant endpoint in the [API documentation](https://tsheetsteam.github.io/api_docs) for specifics.

### "Delete" Operations
For a _Delete_ operation, pass an `IEnumerable` of ids or entities to delete.

**Examples**:
```cs
apiClient.DeleteTimesheets(timesheets);
```

```cs
apiClient.DeleteTimesheets(new[]{ 122357, 122359, 122365 });
```

Note that most endpoints don't support deletes.  Some of them instead allow for "soft deletes" by updating the entities' `Active` property to _false_.

## Accessing Supplemental Data
`SupplementalData` is returned in the `ResultsMeta` object of the tuple response, for most endpoint operations.  It contains additional data pertinent to the given API operation (see [here](https://tsheetsteam.github.io/api_docs/#handling-supplemental-timesheet-data) for more).  Generic methods are provided to retrieve the supplemental data.

**Examples**:

_Display the name of the group to which the current user belongs._
```cs
(User user, ResultsMeta resultsMeta) = apiClient.GetCurrentUser();
Group group = resultsMeta.SupplementalData.GetById<Group>(user.GroupId.Value);
Console.WriteLine($"User '{user.Name}' belongs to the '{group.Name}' group.");
```

_Display the names of all jobcodes assigned to the current user_
```cs
(User user, ResultsMeta resultsMeta) = apiClient.GetCurrentUser();
IReadOnlyList<Jobcode> jobcodes = resultsMeta.SupplementalData.GetAll<Jobcode>();
Console.WriteLine($"User '{user.Name}' is assigned the following jobcodes: " +
    string.Join(',', jobcodes.Select(j => j.Name)));
```

**Caution**:

Because supplemental data can significantly increase response payload size, you should disable its inclusion when possible.  For example:
```cs
// Note both the request option setting, as well as the discard (underscore) in the tuple response.
(IList<Timesheet> timesheets, _) = apiClient.GetTimesheets(
    new TimesheetFilter { ModifiedBefore = DateTimeOffset.Now.AddDays(-7) },
    new RequestOptions { IncludeSupplementalData = false });
```

## Retry Behavior
The SDK includes support for automatic transient error retries.  By default, all method calls which result in _HTTP 503 Service Unavailable_ will be retried up to 3 times, with an exponential backoff between attempts (retries at 1 second, then 4 seconds, then 9 seconds).  The types of exceptions retried, as well as the number of retries and the timespan between each is fully configurable.

**Example**:
```cs
// Example retries up to 5 times when the API service is unavailable (HTTP 503).
// The formula is R^e*m, where "R" is the retry number, "e" is the exponential back-off value, and "m" is
// a multiplier to linearly compress/expand time between the retries (first 3 params below, respectively).
// So for this example: R^2*1.5 => retries after 1.5, 6, 13.5, 24, & 37.5 seconds.

var retrySettings = new RetrySettings(5, 2.0f, 1.5f, typeof(ServiceUnavailableException));
return new DataService(authToken, retrySettings, logger);
```

## Known Issues

**"Method Not Found" Error**
If you encounter an error similar to the following, try adding a NuGet package dependency to System.ValueTuple.  While this shouldn't happen in C# 7.0 (.NET Framework >=4.7), both the error has been reported, and the workaround confirmed.
```cs
Method not found: 'System.ValueTuple`2<System.Collections.Generic.IList`1<Intuit.TSheets.Model.Timesheet>,Intuit.TSheets.Api.ResultsMeta> Intuit.TSheets.Api.DataService.GetTimesheets(Intuit.TSheets.Model.Filters.TimesheetFilter, Intuit.TSheets.Api.RequestOptions
```

## More
Is there anything in the SDK you'd like to see better documented?  Please open an issue in this GitHub repo.
