Websites & container demos
==========================

This repo contains the BikeSharing360 web site and Docker Demos showcased in Connect() 2016.

BikeSharing360 Public Web Site (MVC5)
-------------------------------------

The solution _BikeSharing.Web.sln_ located in folder _/PublicWeb/_ contains the BikeSharing360 Public Web Site. This is a **MVC5 project, developed using VS2015**.

Project can be opened using VS2015 Update 3 or VS2017RC.

This web uses gulp tasks to manage assets and scripts. Output of gulp tasks is in the _Content_ folder, and outputs of tasks gulps **are not part of the csproj file**. This is because if output files are part of the csproj, VS wants to include them in source control, what makes no sense for generated files.

The csproj file was modified manually to include a MSBuild Task to allow publish the output of gulp, even thought this output is not part of the project. Look at the csproj at line 710 and below for these changes.

BikeSharing360 Public Web Site (NetCore)
---------------------------------------

The solution _Public_Web_Site_Core.sln_ located in folder _/PublicWebSite_NetCore/_ contains the BikeSharing360 Public Web Site. This is the **NetCore version using csproj (no project.json)**.

Project must be opened using VS2017RC (No VS2015 support).

Code has been updated to use some of the new MVC Core features , like _Tag Helpers_.

BikeSharing360 Private Web Site (Netcore 1.1)
---------------------------------------------

This repo contains also a demo private web site that uses the microservices to display some lists about the BikeSharing360  users' operations. The folder _/PrivateWebSite/ contains all files for the private web.

This project **is a netcore 1.1 website** and must be opened with **VS2017 RC** (no support for VS2015). Contains some of the new features of the netcore 1.1 as AppServices logs integration and View Components as Tag Helpers among others.

This website needs a database. The _appsettings.json_ has a connection string against a (local)\mssqllocaldb database named _bikesharing-private-web_. You can use the file _/PrivateWebSite/sql/SampleDb.sql to fill the database with schema and sample data (Note that you have to manually create the database.)

Also, you need to edit the _appsettings.json_ file and update:

* **The connection string** (Only if your database is located in any other SQL Server or has another name)
* **The APIs endpoints** The private web site uses three microservices (rides, profiles and APIs). You need to provide the server on which these microservices run. Remember that those microservices are in the [BikeSharing360 Backend Repository](https://github.com/Microsoft/BikeSharing360_BackendServices).

Once database is created you can login with any user with the password "Bikes360".

Keynote's MultiContainer Demo
-----------------------------

The solution _BikeSharing360.sln_ contains the MultiContainer Demo shown by Donovan Brown. It is a multicontainer solution that contains various netcore projects.

You can run the solution under Docker using the "Dcker: Debug Solution" in VS2107. All projects in the solution will run under Docker, and debug still works as usual.




