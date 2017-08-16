# PeopleApi

Very simple dot net core crud webapi Person microservice using the Steeltoe MySQL connector and Swagger on Cloud foundry

# On Cloudfoundry (Pivotal web services)
```
$ git clone https://github.com/DaxterM/PeopleApi.git
$ cd PeopleApi
$ dotnet restore
$ dotnet publish -c release
Create MySQL Service
$ cf create-service cleardb spark  PeopleApiDB
$ cf push PeopleApi -p bin/Release/netcoreapp1.1/publish/
$ cf bind-service PeopleApi PeopleApiDB
$ cf restart PeopleApi

```
# Local
```
TBC
```
