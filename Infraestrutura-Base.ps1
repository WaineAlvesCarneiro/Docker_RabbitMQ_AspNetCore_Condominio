# Fase‑1: Infraestrutura base
$ErrorActionPreference = "Stop"

# Carregar variáveis do .env
Get-Content .env | ForEach-Object {
    if ($_ -match "^(.*?)=(.*)$") {
        $name  = $matches[1].Trim()
        $value = $matches[2].Trim()
        [System.Environment]::SetEnvironmentVariable($name, $value)
    }
}

# Variáveis do ambiente
$networkName     = $env:DOCKER_NETWORK
$sqlContainer    = $env:SQL_CONTAINER
$rabbitContainer = $env:RABBIT_CONTAINER
#$devopsContainer = $env:DEVOPS_CONTAINER
$sqlPassword     = $env:SQL_SA_PASSWORD
$sqlUser         = $env:SQL_SA_USER

Write-Host "🚀 Iniciando o provisionamento da Infraestrutura Base..." -ForegroundColor Cyan
# Testa se o contexto docker-desktop existe
try {
    $contexts = kubectl config get-contexts 2>$null
} catch {
    $contexts = ""
}

# 1. CRIAR REDE DOCKER
$networkExists = docker network ls --format '{{.Name}}' | Where-Object { $_ -eq $networkName }
if (-not $networkExists) {
    Write-Host "🌐 Criando a rede Docker '$networkName'..." -ForegroundColor Yellow
    docker network create $networkName | Out-Null
    Write-Host "✅ Rede Docker '$networkName' criada." -ForegroundColor Green
} else {
    Write-Host "✅ Rede Docker '$networkName' já existe." -ForegroundColor Gray
}

# 3. SUBIR SQL SERVER 2022
$sqlExists = docker ps -a --format '{{.Names}}' | Where-Object { $_ -eq $sqlContainer }
if (-not $sqlExists) {
    Write-Host "🐘 Subindo container do SQL Server 2022..." -ForegroundColor Yellow
    docker run -d `
        --name $sqlContainer `
        --network $networkName `
        --restart unless-stopped `
        -e 'ACCEPT_EULA=Y' `
        -e "MSSQL_SA_PASSWORD=$sqlPassword" `
        --mount source=$env:SQL_VOLUME,target=/var/opt/mssql `
        -p 1433:1433 `
        mcr.microsoft.com/mssql/server:2022-latest | Out-Null
} else {
    Write-Host "✅ Container '$sqlContainer' já existe. Garantindo que está rodando..." -ForegroundColor Gray
    docker start $sqlContainer | Out-Null
}

# 4. SUBIR RABBITMQ
$rabbitExists = docker ps -a --format '{{.Names}}' | Where-Object { $_ -eq $rabbitContainer }
if (-not $rabbitExists) {
    Write-Host "🐇 Subindo container do RabbitMQ..." -ForegroundColor Yellow
    docker run -d `
      --name $rabbitContainer `
      --network $networkName `
      --restart unless-stopped `
      --mount source=$env:RABBIT_VOLUME,target=/var/lib/rabbitmq `
      -p 5672:5672 `
      -p 15672:15672 `
      rabbitmq:3-management | Out-Null
} else {
    Write-Host "✅ Container '$rabbitContainer' já existe. Garantindo que está rodando..." -ForegroundColor Gray
    docker start $rabbitContainer | Out-Null
}

Write-Host "`n✅ Concluído com sucesso! Infraestrutura base pronta." -ForegroundColor Green