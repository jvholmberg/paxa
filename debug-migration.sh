now=$(date +%F_%H-%M-%S)
dotnet ef migrations add $now --project Paxa.Data --verbose
