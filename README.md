# Moesif .NET Web API SelfHost Example

[Moesif](https://www.moesif.com) is an API analytics platform. [Moesif.Middleware](https://github.com/Moesif/moesif-dotnet)
is a middleware that makes integration with Moesif easy for .NET applications.

This is an example of NET Framework 4.6.2 application with Moesif integrated as a [self hosted executable](https://docs.microsoft.com/en-us/aspnet/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api) which is less common.
If you're looking for a .NET app running on IIS (more common), view the [.NET Framework example](https://github.com/Moesif/moesif-netframework-example).

## Key files

Moesif Middleware's [github readme](https://github.com/Moesif/moesif-dotnet) already documented
the steps to setup Moesif Middleware. But here is the key file where the Moesif integration is added:

- `Program.cs` contains the main C# application.
- `Settings/MoesifOptions.cs` has the Moesif middleware related settings.

## How to run this example.

1. Restore Nuget packages using Visual Studio or via command line.

2. Be sure to edit the `Settings/MoesifOptions.cs` to add your Moesif Application Id.

Your Moesif Application Id can be found in the [_Moesif Portal_](https://www.moesif.com/).
After signing up for a Moesif account, your Moesif Application Id will be displayed during the onboarding steps. 

You can always find your Moesif Application Id at any time by logging 
into the [_Moesif Portal_](https://www.moesif.com/), click on the top right menu,
and then clicking _Installation_.

  ```csharp
  Dictionary<string, object> moesifOptions = new Dictionary<string, object>
        {
            {"ApplicationId", 'Your Application ID Found in Settings on Moesif'},
            {"LogBody", true},
            ...
        }
  ```

3. See `ProductController.cs` for some sample ASP.NET Web API routes that you can test such as the below GET:

```
GET http://localhost:9000/api/product/123
```

You can also try a POST request:

```
POST http://localhost:9000/api/product
{
    "Id": 1234,
    "Name": "Chair",
    "Category": "Furniture",
    "Price": 0.0
}
```

The sample API calls should be logged to Moesif. 
