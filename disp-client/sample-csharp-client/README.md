# Import

- Download the project on your local environment using git
- Open the .csproj using Visual Studio
- At this point the project will not build as it is required to generate the client classes from the WSDL
- In the solution explorer, open "Service References", NotificationPoller should appear
- Right click on NotificationPoller and choose "Update Service Reference"
- This should start the process of going to the WSDL externally and generate the client classes
- Rebuild the project by clicking Build, Rebuild DispClientApplication

# Running

To run the application, please make sure that first you would have obtained the username and password set from DA-Desk. Once you have all the requirments, you can run the application as follows:

- Enter the username and the password under the respective text boxes on the left hand side of the application
- Click Login button
- A token should appear if login was successfull
- On the right hand side, enter the assigned principal ID
- Click Poll
- If any notifications were available, the screen should display these notifications, otherwise an empty XML will be displayed

  ## Note
  
  Please note that this application requires setting up of users on DA-Desk side. Please contact DA-Desk before starting.
