# Fiap Monitoramento Ambiental API

## Descrição

Fiap Monitoramento Ambiental API é uma aplicação com foco de registrar eventos ambientais e monitorar a qualidade do ar 

## Uso

### Desastres Ambientais
- GET /api/v1/DesastresNaturais: Retorna os detalhes de toso os desastre natural registrados.
- GET /api/v1/DesastresNaturais/{id}: Retorna os detalhes de um unico registro.
- POST /api/v1/DesastresNaturais: Cria um novo desastre natural.
- PUT /api/v1/DesastresNaturais/{id}: Atualiza um desastre natural existente.
- DELETE /api/v1/DesastresNaturais/{id}: Deleta um desastre natural.

### Qualidade do ar
- GET api/v1/MonitoraQualidadeAr: Retorna os detalhes de todos os registros feitos.
- GET api/v1/MonitoraQualidadeAr/{id}: Retorna os detalhes de um unico registro de qualidade do ar.
- POST api/v1/MonitoraQualidadeAr: Cria um novo registro.
- PUT api/v1/MonitoraQualidadeAr/{id}: Atualiza um registro existente.
- DELETE api/v1/MonitoraQualidadeAr/{id}: Deleta um registro de qualidade do ar.

### Irrigação
- GET /api/v1/Irrigacao: Retorna os detalhes de todos os registros feitos.
- GET /api/v1/Irrigacao/{id}: Retorna os detalhes de um unico registro de irrigação.
- POST /api/v1/Irrigacao: Cria um novo registro de irrigação.
- PUT /api/v1/Irrigacao/{id}: Atualiza um registro existente.
- DELETE /api/v1/Irrigacao/{id}: Deleta um registro.

### Usuarios
- GET /api/v1/User: Retorna os detalhes de todos os usuários.
- GET /api/v1/User{id}: Retorna os detalhes de um unico usuário.
- POST /api/v1/User: Cria um novo usuário.
- PUT /api/v1/User/{id}: Atualiza um usuário existente.
- DELETE /api/v1/User{id}: Deleta um usuário.

### Login
- POST /api/v1/Auth/login: Loga na aplicação para usar os enpoints.

> Por padrão apenas o endpoint de cadas de usuário está disponivel para usar sem uma autenticação. A aplicação possui uma hierarquia simples: ***Admin, Gerente, Usuario***, sendo que Usuários apenas tem operação básica na APi. Ou seja, apenas podem usar os métodos ***GET*** do HTTP.
> Para testar a API sem frustrações o campo Role do usuário deverá ser um dos três mencionados anteriormente.

#### JSON para criação de usuário:

{
  "userName": "Admin",
  "role": "Admin",
  "passwordHash": "admin"
}

### Pré-requisitos

- .NET 8.0 SDK
- ORACLE Database
- Ferramentas de build como Visual Studio ou Visual Studio Code

Essa é uma API desenvolvida com propósitos educacionais.
