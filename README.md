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


access app at http://random-route-here/swagger
```
# Local
```
$ docker run -p 3306:3306 --rm -it  -e MYSQL_DATABASE=test -e MYSQL_USER=test -e MYSQL_ALLOW_EMPTY_PASSWORD=Yes  mysql:5.7.13 --console
$ git clone https://github.com/DaxterM/PeopleApi.git
$ cd PeopleApi
$ dotnet restore
$ dotnet run

access app at http://localhost:5000/swagger
```
