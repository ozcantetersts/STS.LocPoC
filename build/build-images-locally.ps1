param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../"
### Apps Folders
$mvcAppFolder = Join-Path $slnFolder "apps/web/src/STS.LocPoC.Web"
$authserverFolder = Join-Path $slnFolder "apps/auth-server/src/STS.LocPoC.AuthServer"
$publicWebFolder = Join-Path $slnFolder "apps/public-web/src/STS.LocPoC.PublicWeb"

### Microservice Folders
$identityServiceFolder = Join-Path $slnFolder "services/identity/src/STS.LocPoC.IdentityService.HttpApi.Host"
$administrationServiceFolder = Join-Path $slnFolder "services/administration/src/STS.LocPoC.AdministrationService.HttpApi.Host"
$saasServiceFolder = Join-Path $slnFolder "services/saas/src/STS.LocPoC.SaasService.HttpApi.Host"
$productServiceFolder = Join-Path $slnFolder "services/product/src/STS.LocPoC.ProductService.HttpApi.Host"

### Gateway Folders
$webGatewayFolder = Join-Path $slnFolder "gateways/web/src/STS.LocPoC.WebGateway"
$webPublicGatewayFolder = Join-Path $slnFolder "gateways/web-public/src/STS.LocPoC.PublicWebGateway"

### DB Migrator Folder
$dbmigratorFolder = Join-Path $slnFolder "shared/STS.LocPoC.DbMigrator"

Write-Host "*** BUILDING DB MIGRATOR ***" -ForegroundColor Green
Set-Location $dbmigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-db-migrator:$version .

Write-Host "===== BUILDING MICROSERVICES =====" -ForegroundColor Yellow 
### IDENTITY-SERVICE
Write-Host "*** BUILDING IDENTITY-SERVICE ***" -ForegroundColor Green
Set-Location $identityServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-service-identity:$version .

### ADMINISTRATION-SERVICE
Write-Host "*** BUILDING ADMINISTRATION-SERVICE ***" -ForegroundColor Green
Set-Location $administrationServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-service-administration:$version .

### SAAS-SERVICE
Write-Host "*** BUILDING SAAS-SERVICE ***" -ForegroundColor Green
Set-Location $saasServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-service-saas:$version .

### PRODUCT-SERVICE
Write-Host "*** BUILDING PRODUCT-SERVICE ***" -ForegroundColor Green
Set-Location $productServiceFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-service-product:$version .
Write-Host "===== COMPLETED BUILDING MICROSERVICES =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING GATEWAYS =====" -ForegroundColor Yellow 
### WEB-GATEWAY
Write-Host "*** BUILDING WEB-GATEWAY ***" -ForegroundColor Green
Set-Location $webGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-gateway-web:$version .

### PUBLICWEB-GATEWAY
Write-Host "*** BUILDING WEB-PUBLIC-GATEWAY ***" -ForegroundColor Green
Set-Location $webPublicGatewayFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-gateway-web-public:$version .
Write-Host "===== COMPLETED BUILDING GATEWAYS =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### AUTH-SERVER
Write-Host "*** BUILDING AUTH-SERVER ***" -ForegroundColor Green
Set-Location $authserverFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-app-authserver:$version .

### PUBLIC-WEB
Write-Host "*** BUILDING WEB-PUBLIC ***" -ForegroundColor Green
Set-Location $publicWebFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t sts/locpoc-app-public-web:$version .
### MVC WEB App
if (Test-Path -Path $mvcAppFolder) {
    Write-Host "*** BUILDING MVC WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $mvcAppFolder
    dotnet publish -c Release
    docker build -f Dockerfile.local -t sts/locpoc-app-web:$version .
}
Write-Host "===== COMPLETED BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder