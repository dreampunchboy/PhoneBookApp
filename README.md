# PhoneBookApp

This is an implementation of a phone book app using .NET Core WEB API with seperate services injected into the running service.
The frontend is a nifty console application running in a simple state machine and within that multiple screens to view and maintain the phone book entries.

To run:
 - Open the PhoneBookApp.API.sln solution file in Visual Studio and run the project
 
 
 Troubleshooting
1. If the console app can't find the API 
Update the APIRUL in app.json in PhoneBookApp.App project to point to the correct path