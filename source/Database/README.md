#Volta versão para 0
dotnet ef database update 0
dotnet ef migrations remove

#Cria uma nova versão de migração 
dotnet ef migrations add [Nome]

#Altera o banco de dados
dotnet ef database update

