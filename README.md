# mexican-lottery-dotnet-api
## Requirements
- You need to have already installed NodeJs and SQL Server with User and Password login configurated.

## Steps to configurate the project
- Create the "appsettings.json" file in the project's root, you'll see an example called appsettings - Copy.json'.
- You will notice an object called "ConnectionStrings" with a field inside "DefaultConnection", this stores the connection string to database.
- Now replace the {YourServerName}, {YourUserDB} and {YourPasswordDB} in the connection string inside appsettings file with your credentials.
- Next open the "LotteryDB.sql" file located in the project's root and execute the script in SQL Server.
- Finally start the application.

## How to use the API?
- Install Postman.
- You can import the "Lottery.postman_collection.json" to your Postman desktop application.
- "GetAllCards" is to obtain all the available cards from Mexican Lottery, there are about 54 cards ready to use in database!
- "GetAllTables" is to obtain all the tables randomly generated with the API.
- "GenerateTables" is to generate new random tables, the endpoint receives the number of tables to generate as a parameter on the endpoint, for example `localhost:8000/api/lottery/generateTables/5` will generate five different tables. 