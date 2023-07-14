# Fusion Cache Proof of concept
## Goal
Our goal is to demonstrate  how the library [FusionCache](https://github.com/ZiggyCreatures/FusionCache) works and showcase its main API & functionalities ( 2nd level cache, Backplane, Dependency injection)
## Getting start
1. Start up **RabbitMQ** in **Docker**, using the command **docker compose up** or launching the file **compose-up.ps1**
3. Execute both projects **FusionCacheApi** and **FusionCacheWorker**..
4. Execute some HTTP requests to **FusionCacheApi** (you can use the file **fusion-cache.http** with Visual Studio)
5. Watch the console output of **FusionCacheWorker**
