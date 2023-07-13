# Getting Started With ASP.NET Core Series


## Controller Action return types in ASP.NET

ASP NET Core offers different return types for the Web API Controllers. Each of these return types has its own use cases. The 3 main return types are
    1. Specific Type
    2. *IActionResult*
    3. Generic *ActionResult*

In this project, we will dive into each of these return types and when it's most appropriate to use each return type.

### Install packages
```
Microsoft.AspNetCore.Mvc.Newtonsoft
```


## Background tasks in ASP.NET

Background tasks are those that run in the background without interfering with the primary process. In ASP NET Core, background tasks are implemented as Hosted Services. This allows us to perform tasks outside of the main web thread, determine changes to data in a database, and also long-running tasks to process messages from the queue, etc. In this project, we will learn how to create and run a task in the background in ASP.NET Core applications. We will learn how to use the *BackgroundService* class, how to register it to work with the ASP NET Application. We will also see how the *IHostedService* interface works along with the BackgroundService and also the different Dependency Injection models it supports.


## Cross-Origin Requests (CORS) in ASP.NET Core

Browser security prevents a web page from making requests to a different domain than the one that served the web page. This restriction is called the same-origin policy. The same-origin policy prevents a malicious site from reading sensitive data from another site. 

Sometimes, you might want to allow other sites to make cross-origin requests to your application. This is usually when you have an API hosted independently and your different web applications talking to the API. In such scenarios,  we need to enable CORS support on the API, so that the web application can call it.

In this project, we will learn about CORS, how it works, how to enable it in ASP NET API, how to simulate a CORS error in ASP NET Single Page Application and then add the appropriate configuration to ease the browser policies using CORS. 

CORS is not a security feature, It is a W3C standard to relax same-origin policy. However if configured incorrectly CORS can cause potential issues to your application. Make sure to be explicit about the origins that can interact with the API that you are building.

- start the react application from a differnet port
```
$env:PORT=4000; npm start
```


## Startup class in ASP.NET Core

The Startup class in ASP NET Core configures services and the app's request pipeline. It uses various conventions to setup up the application and the corresponding services. In this project, we will take a deep dive into the whole Startup process and understand the different conventions and how it fits into the whole ASP NET Application cycle.