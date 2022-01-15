# Pierre's Treats And Flavors Portal
A website that allows visitors to view lists of flavors and associated treats. Registered users are able to create flavors and treats.

#### By Jeff Terrell

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/solar.png)

## Technologies Used
* C#
* .Net5
* ASP.Net Core MVC
* ASP.Net Identity
* Entity Framework Core
* Razor View Engine
* MySql and MySql Workbench
* LINQ
* HTML
* CSS
* Bootstrap

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/solar.png)

## Description

A web application that allows a registered user to create flavors and treats. This information is saved so that a user can access and view all of the associated data based on the specific profile being accessed (ex: flavors used in a specific treat or treats that use a specific flavor). A registered user has the ability to edit, delete, and add associations for both object types. Visitors to the website only have read access and cannot create, update, or delete information.

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/solar.png)


## Setup/Installation Requirements
* If needed, download and install .NET 5 here: https://dotnet.microsoft.com/en-us/download/dotnet/5.0
* From a terminal, navigate to a directory of your choosing and use the "Git clone" command to copy the repository from this address (https://github.com/JeffTerrell/PierreTreats.Solution).
Navigate to the sub directory "PierreTreats" of the cloned main directory on your local machine.
* From the same directory "PierreTreats", enter the following commands individually:
  - _dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0_ 
  - _dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2_
  - _dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0_
  - _dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0_
  - _dotnet tool install --global dotnet-ef --version 3.0.0_	
* From the same directory "PierreTreats", create a new file called .appsettings.json.		
* Open this file with a code editor and add the following:

  ```
  {
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[data_base_name];uid=root;pwd=[password];"
    }
  }
  ```
* Delete the [] surrounding data_base_name and pwd and include correct database name and password.

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/solar.png)


## Database Setup/Installation Requirements 
After completing the Setup/Installation requirements follow these steps to create the database schema in MySQL Workbench:
* From a terminal in the sub directory "PierreTreats", enter the following command to build the database:
  - _dotnet ef database update
* Open MySQL Workbench and start/create a local instance with localhost:3306.  
* To view the imported database, click the "Schemas" tab from the Navigator Menu, right click in the pane and select "Refresh All".


![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/solar.png)


## Run the Application 
  * From a terminal, navigate to the sub directory "PierreTreats".
  * Enter the following command, "dotnet restore" to create necessary folders and files.
  * Next enter the following command, "dotnet run". This will launch the application in your terminal. Enter "Ctrl c" to exit the application at any point.
  * To access the application, load a web browser and in the URL bar insert the specific URL(s) listed in your terminal (ex: Now listening on: http://localhost:5000).
  * Note: to have create, update, and delete rights, you must register an account and login with these credentials.

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/solar.png)

## Known Bugs
* Can add duplicate treats to flavors
* Can add duplicate flavors to treats

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/solar.png)


## License

[MIT](https://opensource.org/licenses/MIT)

Please contact Jeff Terrell via email with any issues, questions, or ideas.
<br>
[![GitHub Badge](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/JeffTerrell)
[![LinkedIn Badge](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/jeffaterrell)
<br>
<br>
Copyright (c) 2021 Jeff Terrell