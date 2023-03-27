## Docker Support
#### To run the application in docker, run from solution directory

###### Detached mode
```bash
docker-compose up --build -d
```
###### Foreground mode
```bash
docker-compose up --build
```
###### To stop the application
```bash
docker-compose down
```

## Migration
#### To add migration, run from solution directory
```bash
dotnet ef migrations add Initial --project src/TodoCQRS.Infrastructure --startup-project src/TodoCQRS.API
```

#### To remove migrations, run from solution directory
```bash
dotnet ef migrations remove --project src/TodoCQRS.Infrastructure --startup-project src/TodoCQRS.API
```

#### To update database, run from solution directory
```bash
dotnet ef database update --startup-project src/TodoCQRS.API
```

#### To run the tests
```bash
dotnet test
```