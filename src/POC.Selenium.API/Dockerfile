FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
# Install Chrome
RUN apt-get update && apt-get install -y \
	apt-transport-https \
	ca-certificates \
	curl \
	gnupg \
	hicolor-icon-theme \
	libcanberra-gtk* \
	libgl1-mesa-dri \
	libgl1-mesa-glx \
	libpango1.0-0 \
	libpulse0 \
	libv4l-0 \
	fonts-symbola \
	--no-install-recommends \
	&& curl -sSL https://dl.google.com/linux/linux_signing_key.pub | apt-key add - \
	&& echo "deb [arch=amd64] https://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google.list \
	&& apt-get update && apt-get install -y \
	google-chrome-stable \
	--no-install-recommends \
	&& apt-get purge --auto-remove -y curl \
	&& rm -rf /var/lib/apt/lists/*
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/POC.Selenium.API/POC.Selenium.API.csproj", "src/POC.Selenium.API/"]
COPY ["src/POC.Selenium.Job/POC.Selenium.Job.csproj", "src/POC.Selenium.Job/"]
RUN dotnet restore "src/POC.Selenium.API/POC.Selenium.API.csproj"
COPY . .
WORKDIR "/src/src/POC.Selenium.API"
RUN dotnet build "POC.Selenium.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.Selenium.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Selenium.API.dll"]