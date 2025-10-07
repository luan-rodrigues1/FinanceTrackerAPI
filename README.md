## Tecnologias

- ASP.NET Core 8
- C#
- Entity Framework Core
- SQLite
- Swagger (OpenAPI)
---
## Pré-requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQLite (opcional, apenas se quiser inspecionar o banco)

## Configuração do projeto

### Clone o repositório

```bash
git clone https://github.com/SEU_USUARIO/FinanceTrackerAPI.git
cd FinanceTrackerAPI
```
---

### Instale as dependências
```bash
dotnet restore
```
### Configuração do banco
O projeto utiliza SQLite.
O arquivo do banco será criado automaticamente na pasta Data/ quando você rodar as migrations.
```bash
"ConnectionStrings": {
    "DefaultConnection": "Data Source=Data/FinanceTracker.db"
}
```
---

### Rodando as migrations
Atualizando o banco com as migrations existentes
#### 1. Pelo **Package Manager Console**
Comando:

```bash
Update-Database
````
ou 
#### 2. Pelo terminal (dotnet CLI)
Comando:
```bash
dotnet ef database update
```
---

### Rodando a API
```bash
dotnet run
```
Atenção: A API ficará disponível em https://localhost:7016 (ou http://localhost:5265) conforme configuração do launchSettings.json. 
Swagger disponível em https://localhost:7016/swagger

---

## Endpoints principais

| Método | Endpoint                  | Descrição                                   |
|--------|---------------------------|---------------------------------------------|
| GET    | `/api/transaction`        | Listar todos os lançamentos (com query params opcionais) |
| GET    | `/api/transaction/{id}`   | Obter um lançamento específico              |
| POST   | `/api/transaction`        | Criar um lançamento                         |
| PUT    | `/api/transaction/{id}`   | Atualizar um lançamento                     |
| DELETE | `/api/transaction/{id}`   | Excluir um lançamento                       |

---

## Observações

Os enums são serializados como string no JSON.

Campos obrigatórios nos DTOs são validados automaticamente.

CORS habilitado para permitir chamadas de frontends externos (desenvolvimento).

