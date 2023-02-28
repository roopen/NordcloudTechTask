# NordcloudTechTask

Calculates network speed based on distance to the nearest network station. It is a C# Console application running on .NET 7.0. Solution consists of 3 projects Console, Domain and Tests. Console handles displaying information to the user. Domain handles logic and contains nothing but static classes and functions and data models. Test project contains unit tests.

If you want to make a major changes, such as turning the application into a REST API or a Web UI, you should delete the console project and create a new project from a more fitting template available in Visual Studio for instance. The domain project handles the underlying logic, how to display information should be done in it's own project.

## HOW TO RUN

### IN EDITOR

### Requirements
.NET 7.0 runtime (https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Pick either .NET Runtime 7 or SDK 7 and install the appropriate version for your operating system.

### Opening with an IDE
Open NordcloudTechTask.sln with Visual Studio or Visual Code and select NordcloudTechTask.Console as your startup project and run.

### IN COMMAND LINE
Download the ready-made .exe from version control and run that. If you want to build binaries yourself you have to do so by opening the project with an IDE.
