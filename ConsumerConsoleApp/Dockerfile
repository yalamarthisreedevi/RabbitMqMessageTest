#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-runtime-nanoserver-1803 AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ConsumerConsoleApp/ConsumerConsoleApp.csproj ConsumerConsoleApp/
RUN dotnet restore ConsumerConsoleApp/ConsumerConsoleApp.csproj
COPY . .
WORKDIR /src/ConsumerConsoleApp
RUN dotnet build ConsumerConsoleApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ConsumerConsoleApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ConsumerConsoleApp.dll"]
