# PhoneBookApp

This is an implementation of a phone book app using .NET Core WEB API with seperate services injected into the running service.
The frontend is a nifty console application running in a simple state machine and within that multiple screens to view and maintain the phone book entries.

To run:
 - Open the PhoneBookApp.API.sln solution file in Visual Studio
 - Set the solution as the Startup Project (right click on PhoneBookApp at the top and and select "Set startup projects")
 - Set multiple projects to start: PhoneBookApp.API and PhoneBookApp.App
 - Build and run the project (NUGET packages will be restored and both the APP and API will be run.)
 
 ![Setting project startup](https://i.imgur.com/pSLnIAP.png)
 
 Tech Used:
  - asp.net WEB API (Core)
  - C# Console App (Core)
  - Mongodb
 
Troubleshooting
1. If the console app can't find the API 
Update the APIURL in app.json in PhoneBookApp.App project to point to the correct path
