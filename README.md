# TestWindowsFormApplication
This project provides a Windows form application, developed in .NET 6, that contains an input and an output field. Users can provide textual input in the input field, which gets written to a local database on clicking the `Submit` button. The output field displays the data written to the local database by the local Web application.

## Installation
The prerequisites for running this application are:  
1. Download and install [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&passive=false&cid=2030).
2. Install `.NET desktop development` workload of Visual Studio 2022 in the default location.

## Build and run using Visual Studio 2022
1. Open the `WinFormsTestApp1.sln` file given in the repository to view the source code for Windows form application.
2. Configure the `ApplicationInstanceName` and `DatabasePath` keys in the `App.config` file as per user's requirement. Add the path without the database file name. For example, the value of `DatabasePath` key can be `"C:\\Projects\\Netzsch\\Database"`. 
`ApplicationInstanceName`: indicates the name / title for the form application. This is also used while writing input data to database. Multiple instances of this application can be launched with different instance names for each one of them.
`DatabasePath`: indicates the path to the local SQLite database. By default, it creates a new database `Testdatabase.db` in the `DatabasePath` folder.
3. `Program.cs` is the entry point for this application.
4. `Form1.Designer.cs` provides the layout and callback methods used by form elements.
5. `Form1.cs` provides the main functionality of this form application.
6. This solution is dependent on the NuGet packages: `System.Data.SQLite.Core 1.0.117` and `StyleCop.Analyzers 1.1.118`. Ensure that the package dependencies are resolved when clicking on `Build Solution` or `(Ctrl + Shift + B)`.
7. Launch the application by clicking on `Start without Debugging` or `(Ctrl + F5)`.
8. The Windows form application page should be visible upon a successful build as shown below.

## (or) Directly run using the release
1. Download the release package of this application.
2. Unzip the release package and configure the `ApplicationInstanceName` and `DatabasePath` keys in the `WinFormsTestApp1.dll.config` file as per user's requirement. Add the path without the database file name. For example, the value of `DatabasePath` key can be `"C:\\Projects\\Netzsch\\Database"`.
2.1. `ApplicationInstanceName`: indicates the name / title for the form application. This is also used while writing input data to database. Multiple instances of this application can be launched by duplicating the entire release folder and providing different instance names for each one of them.
2.2. `DatabasePath`: indicates the path to the local SQLite database. By default, it creates a new database `Testdatabase.db` in the `DatabasePath` folder.
3. The application can be launched by opening `WinFormsTestApp1.exe` in the unzipped folder.

<img src="images/TestWindowsFormApplication.png" width="100%" alt="Windows Form Application">

## Application functionality
1. When starting the application for the first time, a table called `DataTable` is created, if it is not already present in the provided database.
2. User can enter textual input in the text box provided.
3. The input text and `ApplicationInstanceName` are persisted in the `TextData` and `Sender` columns, respectively of the `DataTable`, upon clicking the `Submit` button.
4. The application keeps polling the `DataTable` to read the `TextData` sent from the local Web Application and display it in the output text box. 
5. Polling is done at regular intervals of one second in a non-blocking fashion using a Thread.

## Contributors
For further assistance or support in maintaining the application, you may please contact Pooja Prasanna Nanjunda (poojananjunda1996@gmail.com). Any bugs or errors in the application can be notified to the contributor by raising issue requests.
