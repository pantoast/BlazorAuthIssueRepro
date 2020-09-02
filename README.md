# BlazorAuthIssueRepro
 Barebones Blazor Webasembly solution meant to reproduce web API authorization issues.

 Related to issue: https://github.com/dotnet/aspnetcore/issues/25313

This project uses IdentityServer4 role based authentication. 

To use: 
1. Register and confirm a new user. 
2. Navigate to the "Counter" page and click the "Add to Role2" button. 
3. Reload the page to refresh the client. 
4. Navigate to the "Fetch Data" page. You should see the default weather forecast data included in the Blazor Webassembly project template. The difference here is that the API call to get the forecast data now verifies the user is in Role2 (see step 2) and it attempts to fetch user data using the ControllerBase.User property. 

I left this project deployed to IIS for a few days until eventually when I logged in and navigated to the "Fetch Data" tab it no longer worked. Project logs to C:\ by default in a log file called "BlazorAuthIssueRepro_All.log". 
