# docker build --no-cache --progress=plain -t my-image .
ARG registryUrl

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder

WORKDIR /
COPY ./ /code

WORKDIR /code/build
RUN dotnet run
