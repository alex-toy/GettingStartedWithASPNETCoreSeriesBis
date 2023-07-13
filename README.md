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