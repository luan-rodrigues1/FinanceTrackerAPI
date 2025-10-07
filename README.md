FinanceTrackerAPI

API para gerenciar lan�amentos financeiros (CRUD) desenvolvida em ASP.NET Core 8 com Entity Framework Core e SQLite.

Tecnologias

ASP.NET Core 8

C#

Entity Framework Core

SQLite

Swagger (OpenAPI)

Pr�-requisitos

.NET SDK 8

Visual Studio 2022 / VS Code

SQLite (opcional, apenas se quiser inspecionar o banco)

Configura��o do projeto

Clone o reposit�rio

git clone https://github.com/SEU_USUARIO/FinanceTrackerAPI.git
cd FinanceTrackerAPI


Instale as depend�ncias

dotnet restore


Configura��o do banco

O projeto utiliza SQLite.

O arquivo do banco ser� criado automaticamente na pasta Data/ quando voc� rodar as migrations.

Connection string no appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Data Source=Data/FinanceTracker.db"
}

Rodando migrations

Para criar o banco e as tabelas, execute:

dotnet ef migrations add InitialCreate
dotnet ef database update


Se j� houver migrations, apenas rode dotnet ef database update.

Rodando a API
dotnet run


A API ficar� dispon�vel em http://localhost:8080 (ou https://localhost:8080) conforme configura��o do launchSettings.json.

Swagger dispon�vel em http://localhost:8080/swagger.

Endpoints principais
M�todo	Endpoint	Descri��o
GET	/api/transaction	Listar todos os lan�amentos (com query params opcionais)
GET	/api/transaction/{id}	Obter um lan�amento espec�fico
POST	/api/transaction	Criar um lan�amento
PUT	/api/transaction/{id}	Atualizar um lan�amento
DELETE	/api/transaction/{id}	Excluir um lan�amento
Observa��es

Os enums s�o serializados como string no JSON.

Campos obrigat�rios nos DTOs s�o validados automaticamente.

CORS habilitado para permitir chamadas de frontends externos (desenvolvimento).