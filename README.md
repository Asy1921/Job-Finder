dotnet new sln -n "Job_Finder_sln"
Dotnet dev-certs https --trust
dotnet new classlib -o "Models"
dotnet new classlib -o "BAL"
dotnet new classlib -o "DAL"
cd ./DAL
dotnet add package Microsoft.entityframeworkcore.sqlserver
dotnet add package Microsoft.entityframeworkcore.Design
dotnet add package Microsoft.entityframeworkcore.Tools
cd ..
dotnet new react -o "Job_Finder"
dotnet sln Job_Finder_sln.sln add ./BAL/BAL.csproj
dotnet sln Job_Finder_sln.sln add ./DAL/DAL.csproj
dotnet sln Job_Finder_sln.sln add ./Job_Finder/Job_Finder.csproj
dotnet sln Job_Finder_sln.sln add ./Models/Models.csproj
dotnet add ./BAL/BAL.csproj reference ./DAL/DAL.csproj
dotnet add ./BAL/BAL.csproj reference ./Models/Models.csproj
dotnet add ./Job_Finder/Job_Finder.csproj reference ./BAL/BAL.csproj
dotnet add ./Job_Finder/Job_Finder.csproj reference ./Models/Models.csproj
