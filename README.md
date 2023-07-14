# Getting start
1. Start up **RabbitMQ in docker**, using the command ***'docker compose up'** or launching the file **'compose-up.ps1'**
2. Edit the ConnectionStrings:SqlServer in appsettings.json of projects **DeviceOperationPoc.Api** and **DeviceOperationPoc.Worker**.
3. Execute both projects **DeviceOperationPoc.Api** and **DeviceOperationPoc.Worker**.. The databases will be created each time.
4. Execute a request opening the file **device-operation.http** with Visual Studio
5. Execute multiple request launching the file **massiveCreate.ps1**
