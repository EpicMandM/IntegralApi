# Integral API

This is a .NET class library that provides a simple API for computing integrals of mathematical equations. The library uses the Newton API to perform the computations.

## Getting Started

To use this library in your .NET project, you will need to add a reference to the `IntegralApi` project and include the following using statement in your code:

```csharp
using IntegralApi.Model;
using Newtonsoft.Json;
using System.Web;
```
Once you have done this, you can call the Get method in the Integral class to compute the integral of an equation. The method takes a single parameter, which is a string representing the equation to integrate.

# Usage
To compute the integral of an equation, simply call the Get method in the Integral class with the equation as a parameter. The method returns an IntegralModel object that contains the results of the computation, including the value of the integral and the URL of the API request.

```csharp
IntegralModel result = await Integral.Get("sin(x)");

Console.WriteLine($"Integral of sin(x) = {result.Result}");
Console.WriteLine($"API request: {result.Operation}");
```

The `IntegralModel` object also includes several other properties that provide additional information about the computation, such as the status code of the API response and any error messages that were returned.

## Configuration
The library uses the `Newtonsoft.Json` package to deserialize the API response into an `IntegralModel` object. You will need to include this package in your project in order to use the library.
