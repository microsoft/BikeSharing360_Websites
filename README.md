#BikeSharing360-An Amazing Website

During our Connect(); event this year we presented 15 demos in Scott Guthrie’s and Scott Hanselman’s keynotes. If you missed the keynotes, you can watch the recording in [Channel 9](https://channel9.msdn.com/Events/Connect/2016/Keynotes-Scott-Guthrie-and-Scott-Hanselman).

This year, we built the technology stack for a fictional company named BikeSharing360, which allows users to rent bikes from one location to another.

BikeSharing360 is a fictitious example of a smart bike sharing system with 10,000 bikes distributed in 650 stations located throughout New York City and Seattle. Their vision is to provide a modern and personalized experience to riders and to run their business with intelligence.

In this demo scenario, we built several apps for both the enterprise and the consumer (bike riders). You can find all other BikeSharing360 repos in the following locations:

*[Mobile Apps](https://github.com/Microsoft/BikeSharing360_MobileApps)
*[Backend Services](https://github.com/Microsoft/BikeSharing360_BackendServices)
*[Websites](https://github.com/Microsoft/BikeSharing360_Websites)
*[Single Container Apps](https://github.com/Microsoft/BikeSharing360_SingleContainer)
*[Multi Container Apps](https://github.com/Microsoft/BikeSharing360_MultiContainer)
*[Cognitive Services Kiosk App](https://github.com/Microsoft/BikeSharing360_CognitiveServicesKioskApp)
*[Azure Bot App](https://github.com/Microsoft/BikeSharing360_BotApps)

Websites
========
This repo contains the BikeSharing360 web sites.

BikeSharing360 Public Web Site (MVC5)
-------------------------------------

The solution `BikeSharing.Web.sln` located in folder `/PublicWeb/` contains the BikeSharing360 Public Web Site. This is a **MVC5 project, developed using VS2015**.

Project can be opened using VS2015 Update 3 or VS2017RC.

This web uses gulp tasks to manage assets and scripts. Output of gulp tasks is in the `Content` folder, and outputs of tasks gulps **are not part of the csproj file**. This is because if output files are part of the csproj, VS wants to include them in source control, what makes no sense for generated files.

The csproj file was modified manually to include a MSBuild Task to allow publish the output of gulp, even thought this output is not part of the project. Look at the csproj at line 710 and below for these changes.

BikeSharing360 Public Web Site (NetCore)
---------------------------------------

The solution `Public_Web_Site_Core.sln` located in folder `/PublicWebSite_NetCore/` contains the BikeSharing360 Public Web Site. This is the **NetCore version using csproj (no project.json)**.

Project must be opened using VS2017RC (No VS2015 support).

Code has been updated to use some of the new MVC Core features , like _Tag Helpers_.

BikeSharing360 Private Web Site (Netcore 1.1)
---------------------------------------------

This repo contains also a demo private web site that uses the microservices to display some lists about the BikeSharing360  users' operations. The folder `/PrivateWebSite/` contains all files for the private web.

This project **is a netcore 1.1 website** and must be opened with **VS2017 RC** (no support for VS2015). Contains some of the new features of the netcore 1.1 as AppServices logs integration and View Components as Tag Helpers among others.

This website needs a database. The _appsettings.json_ has a connection string against a (local)\mssqllocaldb database named _bikesharing-private-web_. You can use the file _/PrivateWebSite/sql/SampleDb.sql to fill the database with schema and sample data (Note that you have to manually create the database.)

Also, you need to edit the `appsettings.json` file and update:

* **The connection string** (Only if your database is located in any other SQL Server or has another name)
* **The APIs endpoints** The private web site uses three microservices (rides, profiles and APIs). You need to provide the server on which these microservices run. Remember that those microservices are in the [BikeSharing360 Backend Repository](https://github.com/Microsoft/BikeSharing360_BackendServices).

Once database is created you can login with any user with the password "Bikes360".

NetCore Tools VS2017 Demo
-------------------------

The folder `VS2017-NetCoreTools-Demo` contains a version of the BikeSharing360 Public Web Site shown by Beth Massi in the "Visual Studio 2017 Launch Event" Keynote.

Is a version of the Public Web Site that uses a database (created using Entity Framework code-first) that has a list of cities where BikeSharing360 operates. It is developed using netcore 1.1

In this folder there are three subfolders:

1. **NETCoreDemo_reset**: Contains a project.json based version of the website (Visual Studio 2015 tooling).
2. **NETCoreDemo_start**: Contains the same project but migrated to a VS2017 csproj format.
3. **NETCoreDemo_end**: Contains the version after all updates done by Beth in the Keynote.

## How to sign up for Microsoft Azure

You need an Azure account to work with this demo code. You can:

- Open an Azure account for free [Azure subscription](https://azure.com). You get credits that can be used to try out paid Azure services. Even after the credits are used up, you can keep the account and use free Azure services and features, such as the Web Apps feature in Azure App Service.
- [Activate Visual Studio subscriber benefits](https://www.visualstudio.com/products/visual-studio-dev-essentials-vs). Your Visual Studio subscription gives you credits every month that you can use for paid Azure services.
- Not a Visual Studio subscriber? Get a $25 monthly Azure credit by joining [Visual Studio Dev Essentials](https://www.visualstudio.com/products/visual-studio-dev-essentials-vs).

## Blogs posts

Here's links to blog posts related to this project:

- Xamarin Blog: [Microsoft Connect(); 2016 Recap](https://blog.xamarin.com/microsoft-connect-2016-recap/)
- The Visual Studio Blog: [Announcing the new Visual Studio for Mac](https://blogs.msdn.microsoft.com/visualstudio/2016/11/16/visual-studio-for-mac/)
- The Visual Studio Blog: [Introducing Visual Studio Mobile Center (Preview)](https://blogs.msdn.microsoft.com/visualstudio/2016/11/16/visual-studio-mobile-center/)
- The Visual Studio Blog: [Visual Studio 2017 Release Candidate](https://blogs.msdn.microsoft.com/visualstudio/2016/11/16/visual-studio-2017-rc/)

## Clean and Rebuild
If you see build issues when pulling updates from the repo, try cleaning and rebuilding the solution.

## Copyright and license
* Code and documentation copyright 2016 Microsoft Corp. Code released under the [MIT license](https://opensource.org/licenses/MIT).

## Code of Conduct 
This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
