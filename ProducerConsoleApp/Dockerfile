#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-runtime-nanoserver-1803 AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ProducerConsoleApp/ProducerConsoleApp.csproj ProducerConsoleApp/
RUN dotnet restore ProducerConsoleApp/ProducerConsoleApp.csproj
COPY . .
WORKDIR /src/ProducerConsoleApp
RUN dotnet build ProducerConsoleApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ProducerConsoleApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProducerConsoleApp.dll"]
