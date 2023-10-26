<br>
<p align="center">
  <u><big>|| <b>MessageBoard Api</b> ||</big></u>
</p>
<p align="center">
    <!-- Project Avatar/Logo -->
    <!-- <br>
    <a href="">
        <img src="">
    </a> -->
    <p align="center">
      ___________________________
    </p>
    <!-- GitHub Link -->
    <p align="center">
        <a href="https://github.com/jfpalchak">
            <strong>Joey Palchak</strong>
        </a>
         | 
        <a href="https://github.com/rbarcode">
            <strong>Richard Barbour</strong>
        </a>
         | 
        <a href="https://github.com/onurkaymak">
            <strong>Onur Kaymak</strong>
        </a>
    </p>
    <!-- Project Shields -->
    <p align="center">
        <a href="https://github.com/jfpalchak/MessageBoardAPI/graphs/contributors">
            <img src="https://img.shields.io/github/contributors/jfpalchak/MessageBoardAPI.svg?style=plastic">
        </a>
        &nbsp;
        <a href="https://github.com/jfpalchak/MessageBoardAPI/stargazers">
            <img src="https://img.shields.io/github/stars/jfpalchak/MessageBoardAPI.svg?color=yellow&style=plastic">
        </a>
        &nbsp;
        <a href="https://github.com/jfpalchak/MessageBoardAPI/issues">
            <img src="https://img.shields.io/github/issues/jfpalchak/MessageBoardAPI?style=plastic">
        </a>
        &nbsp;
        <a href="https://github.com/jfpalchak/MessageBoardAPI/blob/main/LICENSE.txt">
            <img src="https://img.shields.io/github/license/jfpalchak/MessageBoardAPI?color=orange&style=plastic">
        </a>
        <!-- &nbsp;
        <a href="">
            <img src="https://img.shields.io/badge/">
        </a> -->
    </p>    
</p>

<p align="center">
  <small>Initiated October 25th, 2023.</small>
</p>

<!-- Project Links -->
<p align="center">
    <a href="https://github.com/jfpalchak/MessageBoardAPI.git"><big>Project Docs</big></a> ·
    <a href="https://github.com/jfpalchak/MessageBoardAPI/issues"><big>Report Bug</big></a> ·
    <a href="https://github.com/jfpalchak/MessageBoardAPI/issues"><big>Request Feature</big></a>
</p>

------------------------------
### <u>Table of Contents</u>
* <a href="#🌐-about-the-project">About the Project</a>
    * <a href="#📖-description">Description</a>
    * <a href="#🦠-known-bugs">Known Bugs</a>
    * <a href="#🛠-built-with">Built With</a>
    <!-- * <a href="#🔍-preview">Preview</a> -->
* <a href="#🏁-getting-started">Getting Started</a>
    * <a href="#📋-prerequisites">Prerequisites</a>
    * <a href="#⚙️-setup-and-use">Setup and Use</a>
* <a href="#🛰️-api-documentation">API Documentation</a>
* <a href="#🤝-contributors">Auxiliary</a>
    * <a href="#🤝-contributors">Contributors</a>
    * <a href="#✉️-contact-and-support">Contact</a>
    * <a href="#⚖️-license">License</a>
    * <a href="#🌟-acknowledgements">Acknowledgements</a>
    
------------------------------

## 🌐 About the Project

### 📖 Description
An API that functions as a message board utilizing RESTful principles and Json web tokens (JWT) for authentication to keep the API Read-Only except for authenticated users. The user is able to see the in-use version of the API when using Postman.

### 🦠 Known Bugs

* If any bugs are discovered, please contact the author(s).
<!-- * This is not a real API, which is the greatest shame of all. -->

### 🛠 Built With
* [Visual Studio Code](https://code.visualstudio.com/)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [MySQL 8.0.34](https://dev.mysql.com/)
* [Entity Framework Core 6.0.0](https://docs.microsoft.com/en-us/ef/core/)
* [Entity Framework Core CLI Tools 6.0.0](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
* [Postman](https://www.postman.com/)
<!-- * [Swagger - NSwag 13.3.0](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio) -->

<!-- ### 🔍 Preview -->

------------------------------

## 🏁 Getting Started

### 📋 Prerequisites

#### Install .NET Core
* On macOS Mojave or later
  * [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download the .NET Core SDK from Microsoft Corp for macOS.
* On Windows 10 x64 or later
  * [Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp for Windows.

#### Install dotnet script
 Enter the command ``dotnet tool install -g dotnet-script`` in Terminal for macOS or PowerShell for Windows.

#### Install dotnet-ef
For Entity Framework Core, we'll use a tool called dotnet-ef to reference the project's migrations and update our database accordingly. To install this tool globally, run the following command in your terminal:

```
$ dotnet tool install --global dotnet-ef --version 6.0.0
```

Optionally, you can run the following command to verify that EF Core CLI tools are correctly installed:

```
$ dotnet ef
```

#### Install MySQL Workbench
This project assumes you have MySQL Server and MySQL Workbench installed on your system. If you do not have these tools installed, follow along with the installation steps for the the necessary tools introduced in the series of lessons found here on [LearnHowToProgram](https://full-time.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).

[Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/).

#### Install Postman
(Optional) [Download and install Postman](https://www.postman.com/downloads/).

#### Code Editor

  To view or edit the code, you will need a code editor or text editor. A popular open-source choice for a code editor is VisualStudio Code.

  1) Code Editor Download:
     * [VisualStudio Code](https://code.visualstudio.com/)
  2) Click the download most applicable to your OS and system.
  3) Wait for download to complete, then install -- Windows will run the setup exe and macOS will drag and drop into applications.
  4) Optionally, create a [GitHub Account](https://github.com)

### ⚙️ Setup and Use

  #### Cloning

  1) Navigate to the [MessageBoard Api repository here](https://github.com/jfpalchak/MessageBoardAPI.git).
  2) Click 'Clone or download' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
  3) Open up your system Terminal or GitBash, navigate to your desktop with the command: `cd Desktop`, or whichever location suits you best.
  4) Clone the repository to your desktop: `$ git clone https://github.com/jfpalchak/MessageBoardAPI.git`
  5) Run the command `cd MessageBoardAPI/MessageBoardApi` to enter into the project directory.
  6) View or Edit:
      * Code Editor - Run the command `code .` to open the project in VisualStudio Code for review and editing.
      * Text Editor - Open by double clicking on any of the files to open in a text editor.

  #### Download

  1) Navigate to the [MessageBoard Api repository here](https://github.com/jfpalchak/MessageBoardAPI.git).
  2) Click 'Clone or download' to reveal the HTTPS url ending with .git and the 'Download ZIP' option.
  3) Click 'Download ZIP' and extract.
  4) Open by double clicking on any of the files to open in a text editor.

  #### AppSettings

  1) Create a new file in the MessageBoardApi project directory named `appsettings.json`
  2) Add in the following code snippet to the new `appsettings.json` file:
  
  ```
{
    "Logging": {
        "LogLevel": {
        "Default": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=message_board;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    },
    "JWT": {
        "ValidAudience": "example-audience",
        "ValidIssuer": "example-issuer",
        "Secret": "[YOUR-SECRET-HERE]"
  }
}
  ```
  3) Change the server, port, and user id as necessary. Replace `[YOUR-USERNAME-HERE]` and `[YOUR-PASSWORD-HERE]` with your personal MySQL username and password (set at installation of MySQL).
  4) To properly implement JSON Web Tokens for API authorization, replace `[YOUR-SECRET-HERE]` with your own personalized string.
     1) NOTE: The `Secret` is a special string that will be used to encode our JWTs, to make them unique to our application. Depending on what type of algorithm being used, the Secret string will need to be a certain length. **In this case, it needs to be at least 16 characters long**. 
   
  #### Database
  1) Navigate to MessageBoardAPI/MessageBoardApi directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/MessageBoardAPI/MessageBoardApi`).
  2) Run the command `dotnet ef database update` to generate the database through Entity Framework Core.
  3) (Optional) To update the database with any changes to the code, run the command `dotnet ef migrations add <MigrationsName>` which will use Entity Framework Core's code-first principle to generate a database update. 4) After, run the previous command `dotnet ef database update` to update the database.

  #### Launch the API
  1) Navigate to MessageBoardAPI/MessageBoardApi directory using the MacOS Terminal or Windows Powershell (e.g. `cd Desktop/MessageBoardAPI/MessageBoardApi`).
  2) Run the command `dotnet watch run` to have access to the API in Postman or browser.

------------------------------

## 🛰️ API Documentation
Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.

### Using Swagger Documentation 
To explore the MessageBoard API with NSwag, launch the project using `dotnet run` with the Terminal or Powershell, and input the following URL into your browser: `http://localhost:5000/swagger`

### Using the JSON Web Token
In order to be authorized to use the POST, PUT, DELETE functionality of the API, please authenticate yourself through Postman.

#### Registration
Again, we'll be using Postman for this example. Let's setup a `POST` request to the `accounts/register` endpoint. Select the 'Body' tab, choose the 'raw' radio button, and select 'JSON' from the dropdown selection.

In the Body of the Post request, use the following format:
```
{
    "email": "email@test.com",
    "userName": "testUser",
    "password": "Password123!"
}
```

#### Example Query
```
https://localhost:5000/api/accounts/register
```

#### Sample JSON Response
```
{
    "status": "success",
    "message": "User has been successfully created."
}
```

<a href="https://ibb.co/h78d8zH"><img src="https://i.ibb.co/dWKpKY6/Register.png" alt="Register" border="0" /></a>
  
Note that the password must contain at least six characters, one non-alphanumeric character, at least one digit lowercase letter, at least one uppercase letter and at least two unique characters. An invalid password will generate the following response from the API:  

<a href="https://ibb.co/y00H6yS"><img src="https://i.ibb.co/VVVfgSm/Password-Req.png" alt="Password-Req" border="0" /></a>     

#### SignIn
Now that we've registered an account with our API, we'll need to authenticate our account and generate a JSON Web Token. We'll be using Postman again for this example. 

Let's setup another `POST` request to the `accounts/signin` endpoint. Select the 'Body' tab, choose the 'raw' radio button, and select 'JSON' from the dropdown selection.

In the Body of the Post request, use the following format:
```
{
    "email": "email@test.com",
    "password": "Password123!"
}
```
#### Example Query
```
https://localhost:5000/api/accounts/signin
```

#### Sample JSON Response
```
{
    "status": "success",
    "message": "email@test.com signed in.",
    "token": "xxxx.xxxx.xxxx"
}
```
<a href="https://ibb.co/4tP1HRT"><img src="https://i.ibb.co/JjCK9cc/SignIn.png" alt="SignIn" border="0" /></a>

#### Using the JSON Web Token
Now let's copy that token from the response, and add it as an authorization header to our next request. Copy the token from the body, and click on the Authorization tab in Postman. On the 'Type', make sure that is set to 'Bearer Token', and then paste in the token in the field on the right.

Until the Token expires, you should now have access to all endpoints requiring user authorization!

<!-- ### Note on CORS
CORS is a W3C standard that allows a server to relax the same-origin policy. It is not a security feature, CORS relaxes security. It allows a server to explicitly allow some cross-origin requests while rejecting others. An API is not safer by allowing CORS.
For more information or to see how CORS functions, see the [Microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2#how-cors). -->

### Note on Pagination
For some endpoints, the MessageBoard API returns a default of 10 results per page at a time, which is also the maximum number of results possible.

To modify this, use the query parameters `pageSize` and `pageNumber` to alter the response results displayed. The `pageSize` parameter will specify how many results will be displayed, and the `pageNumber` parameter will specify which element in the response the limit should start counting.

#### Example Query
```
https://localhost:5000/api/groups/1/messages?pageNumber=1&pageSize=2
```

To use the defaults, _do not include_ `pageNumber` and `pageSize`, or, set them equal to zero.

### Notes on Adding Search Parameters
When adding more than one search parameter to an endpoint query, be sure to include an `&` between parameters, as shown above in the example query for pagination.


..........................................................................................

### API Endpoints
Base URL: `https://localhost:5000`

#### HTTP Request Structure
```
GET /api/{component}
POST /api/{component}
GET /api/{component}/{id}
PUT /api/{component}/{id}
DELETE /api/{component}/{id}
```

#### Example Query
```
https://localhost:5000/api/boards/3
```

#### Sample JSON Response
```
{
    "groupId": 3,
    "name": "Costumes",
    "messages": [
        {
            "messageId": 2,
            "text": "What did ya'll get for candy? I got rocks.",
            "date": "2023-03-21T06:30:00",
            "userId": "abc"
        }
    ]
}
```

..........................................................................................

### Messages
Access information on messages posted by MessageBoard users.

#### HTTP Request
```
GET /api/messages
POST /api/messages
GET /api/messages/{id}
PUT /api/messages/{id}
DELETE /api/messages/{id}
```

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| groupId | int | none | false | Return matches by group.
| dateFrom | string | none | false | Return any message on or after the specified date. |
| dateTo | string | none | false | Return any message on or before the specified date. |

#### Example Query
```
https://localhost:5001/api/messages?groupId=1&dateTo=08/2023
```

#### Sample JSON Response
```
[
    {
        "messageId": 1,
        "text": "This new Spider-Man game looks awesome!",
        "date": "2022-12-08T08:15:00",
        "groupId": 1,
        "userId": "def"
    }
]
```
<a href="https://ibb.co/X2cRm3g"><img src="https://i.ibb.co/GxzSgtL/Get-With-Token.png" alt="Get-With-Token" border="0" /></a>

..........................................................................................

### Groups
Access information about messages board groups, in which messages are posted.

### Notes
The GET endpoint for `groups/{id}/messages` includes pagination by default. Users may override pagination defaults by including new search parameters.

#### HTTP Request
```
GET /api/groups
GET /api/groups/{id}
GET /api/groups/{id}/messages
GET /api/groups/{id}/messages/{messageId}
POST /api/groups/{id}/messages
DELETE /api/groups/{id}
```

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| pageNumber | int | 1 | false | Specifies which element in the response the pageSize limit should start counting from. |
| pageSize | int | 10 | false | Returns the specified number of elements per response; default is 10 elements. |

#### Example Query
```
https://localhost:5000/api/groups/1/messages??pageNumber=1&pageSize=2
```

#### Sample JSON Response
```
{
    "pageNumber": 1,
    "pageSize": 2,
    "firstPage": "https://localhost:5001/api/groups/1/messages?pageNumber=1&pageSize=2",
    "lastPage": "https://localhost:5001/api/groups/1/messages?pageNumber=2&pageSize=2",
    "totalPages": 2,
    "totalRecords": 3,
    "nextPage": "https://localhost:5001/api/groups/1/messages?pageNumber=2&pageSize=2",
    "previousPage": null,
    "data": [
        {
            "messageId": 1,
            "text": "This new Spider-Man game looks awesome!",
            "date": "2022-12-08T08:15:00",
            "groupId": 1,
            "userId": "def"
        },
        {
            "messageId": 4,
            "text": "Testing a post with tokens.",
            "date": "2023-10-25T14:16:54.29078",
            "groupId": 1,
            "userId": "abc"
        }
    ],
    "succeeded": true,
    "errors": null,
    "message": null
}
```

------------------------------

### 🤝 Contributors

| Author | GitHub | Email |
|--------|:------:|:-----:|
| [Joey Palchak](https://www.linkedin.com/in/joey-palchak/) | [jfpalchak](https://github.com/jfpalchak)| [joey.palchak@gmail.com](mailto:joey.palchak@gmail.com) |
| [Onur Kaymak](https://www.linkedin.com/in/onurkaymak/) | [onurkaymak](https://github.com/onurkaymak) |  [onurkaymak34@gmail.com](mailto:email@gmail.com) 
| [Richard Barbour](https://www.linkedin.com/in/richardbarbour2/) | [barcode](https://github.com/rbarcode) |  [richyb07@gmail.com](mailto:email@gmail.com) 

------------------------------

### ✉️ Contact and Support

If you have any feedback or concerns, please contact one of the contributors.

<p>
    <a href="https://github.com/jfpalchak/MessageBoardAPI/issues">Report Bug</a> ·
    <a href="https://github.com/jfpalchak/MessageBoardAPI/issues">Request Feature</a>
</p>

------------------------------

### ⚖️ License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT). Copyright (C) 2023 Joey Palchak, Onur Kaymak and Richard Barbour. All Rights Reserved.

```
MIT License

Copyright (c) 2023 Joey Palchak, Onur Kaymak and Richard Barbour.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```

------------------------------

### 🌟 Acknowledgments

#### [Epicodus](https://www.epicodus.com/)
>"A school for tech careers... to help people learn the skills they need to get great jobs."

#### [The Internet](https://webfoundation.org/)
> "...the first thing that humanity has built that humanity doesn't understand..."
> - Eric Schmidt, Google (Alphabet Inc.)

------------------------------

<center><a href="#">Return to Top</a></center>

