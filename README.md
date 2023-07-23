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


## Secret Manager in ASP.NET Core

Most applications that we build these days rely on secrets to perform certain operations. These secrets could include API keys, database credentials, third-party service credentials, etc. In ASP.NET projects application secrets are often stored within configuration files such as web.config or appsettings.json. However one of the first recommendations of secure coding practices is to Never store passwords or other sensitive data as part of the source code. So how do you solve this problem of not having sensitive information in your configuration file, but still have a seamless local development experience when developing ASP NET Applications.

- right clic on the project and select *Manage User Sercrets*
<img src="/pictures/user_secret.png" title="user secret"  width="400">

- put the secrets inside that file

- you can also use the following command
```
dotnet user-secrets init
dotnet user-secrets set "secrets:key" "9c9d2ab2daa4497bb3f175429231907"
dotnet user-secrets remove "secrets:key"
```

- the app still works, but the secret is nowhere to be found in the repo
<img src="/pictures/user_secret2.png" title="user secret"  width="900">


## Jwt Authentication in ASP.NET Core

When building applications we often want to control access to it. The process of securing your application is commonly referred to as authentication and authorization. In this project, we will learn how to protect your ASP NET Core Web API using JWT Bearer Token. We will be using Azure Active Directory as our identity provider and see how to integrate with it from our application and how everything works together.

- create an *App Registration*
<img src="/pictures/app_registration.png" title="app registration"  width="900">

- Install packages
```
Microsoft.Identity.Web
```

- configure the *AzureAd* section. Grab the client and tenant id in the portal
<img src="/pictures/app_registration2.png" title="app registration"  width="900">

- at this point, the API is successfully protected against unauthenticated calls
<img src="/pictures/app_registration3.png" title="app registration"  width="900">

- Send the sign-in request
```
https://login.microsoftonline.com/{tenant}/oauth2/v2.0/authorize?
client_id=XXXXXXXXXXXX
&response_type=token
&scope=openid
&response_mode=fragment
&state=12345
&nonce=678910
```

## Azure Functions

Azure Functions is a serverless compute service that lets you run event-triggered code without having to explicitly provision or manage infrastructure. In this project, we will see how to set up a build deploy pipeline for your Azure Functions. We will set up a build pipeline which creates a build artifact that can be used in the Release pipeline. We will set up multiple environments (Dev and Test) and see how to progress the function through the different stages. The Azure Function uses an environment value, which we will set up using Azure Variable groups and pass it as Application settings to Azure infrastructure.

- create an *HTTP Triggered Function*
<img src="/pictures/az_function.png" title="azure function"  width="900"> 

- call the function and get the environment
<img src="/pictures/az_function2.png" title="azure function"  width="900"> 

### Create Azure Pipeline

<img src="/pictures/pipeline.png" title="azure pipeline"  width="900"> 

- choose *starter pipeline*
<img src="/pictures/pipeline2.png" title="azure pipeline"  width="900"> 

In order to set up the *build pipeline* we need three steps :
1. build the project
2. archive the output
3. publish the artifacts so that we can later use them in the release pipeline

Let's build the *build pipeline* using the assistant :

- in the assistant, use *.NET Core*
<img src="/pictures/build_pipeline.png" title="build pipeline"  width="900"> 

- add *build* task
<img src="/pictures/build_pipeline2.png" title="build pipeline"  width="900"> 

- add *archive* task
<img src="/pictures/build_pipeline3.png" title="build pipeline"  width="900">
<img src="/pictures/build_pipeline4.png" title="build pipeline"  width="900">

- add *publish artifact* task
<img src="/pictures/build_pipeline5.png" title="build pipeline"  width="900">
<img src="/pictures/build_pipeline6.png" title="build pipeline"  width="900">