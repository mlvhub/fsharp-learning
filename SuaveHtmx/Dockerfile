FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

RUN apk update
RUN apk upgrade --no-cache
RUN apk add clang build-base zlib-static binutils musl-dev

COPY . /app
WORKDIR /app
RUN dotnet publish -r linux-musl-x64 -c Release -o /app/out SuaveHtmx.fsproj
RUN ls -la /app/out

FROM scratch
COPY --from=build /app/out /app
ENTRYPOINT ["/app/SuaveHtmx"]
