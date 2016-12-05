Websites & container demos
==========================

This repo contains the BikeSharing360 web site and Docker Demos showcased in Connect() 2016.

BikeSharing360 Public Web Site (MVC5)
-------------------------------------

The solution _BikeSharing.Web.sln_ located in folder _/PublicWeb/_ contains the BikeSharing360 Public Web Site. This is a **MVC5 project, developed using VS2015**.

Project can be opened using VS2015 Update 3 or VS2017RC.

This web uses gulp tasks to manage assets and scripts. Output of gulp tasks is in the _Content_ folder, and outputs of tasks gulps **are not part of the csproj file**. This is because if output files are part of the csproj, VS wants to include them in source control, what makes no sense for generated files.

The csproj file was modified manually to include a MSBuild Task to allow publish the output of gulp, even thought this output is not part of the project. Look at the csproj at line 710 and below for these changes.

Keynote's MultiContainer Demo
-----------------------------

The solution _BikeSharing360.sln_ contains the MultiContainer Demo shown by Donovan Brown. It is a multicontainer solution that contains various netcore projects.

You can run the solution under Docker using the "Dcker: Debug Solution" in VS2107. All projects in the solution will run under Docker, and debug still works as usual.




