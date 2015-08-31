# DAL-BaseLibrary
Class library written in C# with public methods to execute stored procedures and queries in SQL Server, and send mails in an easier way. 

## Requirements
- .Net Framework 3.5 or later
- This library takes values from the web.config/app.config AppSettings section, this are the keys required:
  - **ConnStr:** Default connection string to use by the DAL methods, you can specify another *connection string* in the method's overloads
  - **SmptHost:** The value assigned to `SmtpClient.Host` property to send a mail
  - **SystemName:** It will be the value to use in the *From* field in mail methods if you don't specify one
  - **YourDomain:** The mail methods will take this value for all the mail addresses by default, except in one method's overloaded which takes a `string` in the *To* field, as well as the *From* field, which default value are the appSettings `SystemName + YourDomain`
  - **SystemAdminsMail:** If you call the `Mail.sendError(string body)` method, the mail is going to be send to the addresses declared here

  ### Example of the .config file
  ```XML
  <?xml version="1.0"?>
  <configuration>
    <appSettings>
      <add key="ConnStr"          value="Server=etc..."/>
      <add key="SystemName"       value="My web app"/>
      <add key="YourDomain"       value="@yourDomain.com"/>
      <add key="SmptHost"         value="your.host.name.com"/> 
      <add key="SystemAdminsMail" value="sysAdmin@yourDomain.com"/> 
    </appSettings>
  </configuration>
  ```
  
## Methods Availables
### DAL methods
All the methods are statics, so you do not need to create an instance of the DAL class, there are 6 main methods:
- **DAL.getDataTable & DAL.getDataTableFromQuery:** 
  These two methods Return a `DataTable`, so you can just return the value of one `SELECT`, the `DAL.getDataTable` will take the name of a *Stored Procedure* and the `DAL.getDataTableFromQuery` the *raw query*

  ```C#
  DAL.getDataTable          (string storedProcedure, Dictionary<string, object> parameters, string connStr)
  DAL.getDataTableFromQuery (string query,           Dictionary<string, object> parameters, string connStr)
  ```
- **DAL.getDataSet & DAL.getDataSetFromQuery:** 
  These two methods Return a `DataSet`, so you can return the value of one or more `SELECT` statements, the `DAL.getDataSet` will take the name of a *Stored Procedure* and the `DAL.getDataSetFromQuery` the *raw query*

  ```C#
  DAL.getDataSet          (string storedProcedure, Dictionary<string, object> parameters, string connStr)
  DAL.getDataSetFromQuery (string query,           Dictionary<string, object> parameters, string connStr)
  ```
- **DAL.executeNonQuery & DAL.executeNonQueryFromQuery:** 
  These two methods Return a `bool`, if one or more rows where affected a `true` value is returned, otherway a  `false` value is returned, the `DAL.executeNonQuery` will take the name of a *Stored Procedure* and the `DAL.executeNonQueryFromQuery` the *raw query*

  ```C#
  DAL.executeNonQuery          (string storedProcedure, Dictionary<string, object> parameters, string connStr)
  DAL.executeNonQueryFromQuery (string query,           Dictionary<string, object> parameters, string connStr)
  ```
  #### Overloads
  
  Each one of the 6 methods above has 3 overloads:
  - `DAL.getDataTable (string storedProcedure)`: Just need to pass the name of the Store procedure (or the raw query if you are going to call the `DAL.getDataTableFromQuery`), this oveload is going to execute the statement *with no parameters* and using the default *connection string*:

    ```C#
    DAL.getDataTable("myProcedureName");
    ```
  - `DAL.getDataTable (string storedProcedure, Dictionary<string, object> parameters)`: The `Dictionary<string, object>` should't has the `@` character at the begining of the parameter's name, also there is no need to declare the variable `type`:

    ```C#
    DAL.getDataTable("myProcedureName", 
                    new Dictionary<string, object> { 
                          { "ID", 2 },                      // int
                          { "City", "Ags" },                // string
                          { "RecordDate", DateTime.Now() }, // DateTime
    });
    ```
  - `DAL.getDataTable (string storedProcedure, string connStr)`: It is going to execute the statement *with no parameters* and using the *connection string* specified in the parameter *connStr*:

    ```C#
    DAL.getDataTable("myProcedureName", "Server=etc...");
    ```
  - `DAL.getDataTable (string storedProcedure, Dictionary<string, object> parameters, string connStr)`: It is going to execute the statement *with parameters (`Dictionary<string, object> parameters`)* and using the *connection string* specified in the parameter *connStr*::

    ```C#
    DAL.getDataTable("myProcedureName", 
                    new Dictionary<string, object> { 
                          { "ID", 2 },                      // int
                          { "City", "Ags" },                // string
                          { "RecordDate", DateTime.Now() }, // DateTime
                    },
                    "Server=etc...");
    ```

### Mail methods
The function takes 4 parameters, this method is overloaded so can take 3 or 4 parameters and type in one of them can be different :
```C#
Mail.send(
string to,      
// It's required and  can be a string with the addresses separated by comma
// (They must be well formed: "abc@yourDomain.com,def@yourDomain.com")
// This parameter also can be a string[] or a List<string>, but they must contain just the username (["abc","ghi"])
// Because they are going to be concatenated with your appSetting "YourDomain"
string subject, 
// It's required, and it is always going to be a string
string body, 
// It's required, and it is always is going to be a string
string from);
// It's optional, when no specified the defauolt value are the appSettings concatenated "SystemName" + "yourDomain"
```

