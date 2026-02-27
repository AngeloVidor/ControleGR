# ControleGR

Aplicação full stack para controle de **pessoas**, **categorias** e **transações financeiras** (receitas e despesas), com consolidação de totais por pessoa e por categoria.

## Estrutura do projeto

```text
ControleGR/
├── src/
│   ├── webapi/ControleGR.API/            # API ASP.NET Core + Entity Framework Core
│   └── frontend/ControleGR.Frontend/     # Front-end React + TypeScript + Vite
└── ControleGR.sln
```

## Tecnologias

### Back-end
- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

### Front-end
- React
- TypeScript
- Vite
- Axios
- React Router

## Funcionalidades

- Cadastro e listagem de pessoas
- Edição e remoção de pessoas
- Cadastro e listagem de categorias
- Cadastro e listagem de transações
- Consolidação de totais por pessoa
- Consolidação de totais por categoria

## Pré-requisitos

Instale na sua máquina:

- [.NET SDK 8+](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- SQL Server (local ou remoto)

## Configuração

### 1) API (back-end)

Entre na pasta da API:

```bash
cd src/webapi/ControleGR.API
```

Ajuste a string de conexão em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "SUA_STRING_DE_CONEXAO"
}
```

Aplique as migrations:

```bash
dotnet ef database update
```

Execute a API:

```bash
dotnet run
```

A API sobe por padrão em `http://localhost:5185`

Swagger:

- `http://localhost:5185/swagger/index.html`

### 2) Front-end

Entre na pasta do front-end:

```bash
cd src/frontend/ControleGR.Frontend
```

Instale dependências:

```bash
npm install
```

Inicie em modo desenvolvimento:

```bash
npm run dev
```

O front-end roda por padrão em:

- `http://localhost:5173`

> O front-end já está configurado para consumir a API em `http://localhost:5185/api`.

## Rotas principais do front-end

- `/` → Home
- `/pessoas` → Gestão de pessoas
- `/categorias` → Gestão de categorias
- `/transacoes` → Gestão de transações e totais

## Endpoints principais da API

### Pessoas
- `POST /api/pessoas`
- `GET /api/pessoas/pessoas`
- `PUT /api/pessoas/{id}`
- `DELETE /api/pessoas/{id}`

### Categorias
- `POST /api/categoria`
- `GET /api/categoria/categorias`

### Transações
- `POST /api/transacao`
- `GET /api/transacao/transacoes`
- `GET /api/transacao/totais-por-pessoa`
- `GET /api/transacao/totais-por-categoria`

## Observações

- A política de CORS da API está liberada para `http://localhost:5173`.
- Se você alterar portas, ajuste também o `baseURL` em `src/frontend/ControleGR.Frontend/src/api.ts`.
