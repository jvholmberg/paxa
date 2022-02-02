echo Enter name of migration.
read migrationName
dotnet ef migrations add $migrationName --project Paxa.Data
