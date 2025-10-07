FinanceTrackerAPI

API para gerenciar lançamentos financeiros (CRUD) desenvolvida em ASP.NET Core 8 com Entity Framework Core e SQLite.

Tecnologias

ASP.NET Core 8

C#

Entity Framework Core

SQLite

Swagger (OpenAPI)

Pré-requisitos

.NET SDK 8

Visual Studio 2022 / VS Code

SQLite (opcional, apenas se quiser inspecionar o banco)

Configuração do projeto

Clone o repositório

git clone https://github.com/SEU_USUARIO/FinanceTrackerAPI.git
cd FinanceTrackerAPI


Instale as dependências

dotnet restore


Configuração do banco

O projeto utiliza SQLite.

O arquivo do banco será criado automaticamente na pasta Data/ quando você rodar as migrations.

Connection string no appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Data Source=Data/FinanceTracker.db"
}

Rodando migrations

Para criar o banco e as tabelas, execute:

dotnet ef migrations add InitialCreate
dotnet ef database update


Se já houver migrations, apenas rode dotnet ef database update.

Rodando a API
dotnet run


A API ficará disponível em http://localhost:8080 (ou https://localhost:8080) conforme configuração do launchSettings.json.

Swagger disponível em http://localhost:8080/swagger.

Endpoints principais
Método	Endpoint	Descrição
GET	/api/transaction	Listar todos os lançamentos (com query params opcionais)
GET	/api/transaction/{id}	Obter um lançamento específico
POST	/api/transaction	Criar um lançamento
PUT	/api/transaction/{id}	Atualizar um lançamento
DELETE	/api/transaction/{id}	Excluir um lançamento
Observações

Os enums são serializados como string no JSON.

Campos obrigatórios nos DTOs são validados automaticamente.

CORS habilitado para permitir chamadas de frontends externos (desenvolvimento).