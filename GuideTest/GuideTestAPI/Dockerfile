FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet publish -c Debug -o out

FROM mcr.microsoft.com/dotnet/core/sdk:2.1
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

COPY --from=build-env /app/out .
COPY --from=build-env /app/db ./db
ENTRYPOINT [ "dotnet", "GuideTest.dll" ]