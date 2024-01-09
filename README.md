# TaskMaster API - Gerenciamento de Projetos e Tarefas (.NET 6)

Esta API oferece uma série de endpoints para interação com projetos e itens de tarefas. Utilize as instruções abaixo para começar a explorar as funcionalidades.

## Funcionalidades

### Projetos

#### Listar Todos os Projetos

- **Endpoint:** `GET /Project`
- **Descrição:** Retorna uma lista de todos os projetos cadastrados.

#### Detalhes de um Projeto Específico

- **Endpoint:** `GET /Project/{id}`
- **Parâmetros de Path:** `{id}` - O identificador único do projeto.
- **Descrição:** Obtém detalhes de um projeto específico com base no ID fornecido.

#### Adicionar Novo Projeto

- **Endpoint:** `POST /Project`
- **Corpo da Requisição:** Deve conter os dados do projeto a ser adicionado, seguindo o formato definido no esquema.

#### Atualizar Projeto Existente

- **Endpoint:** `PUT /Project/{id}`
- **Parâmetros de Path:** `{id}` - O identificador único do projeto a ser atualizado.
- **Corpo da Requisição:** Deve conter os dados atualizados do projeto.

#### Excluir Projeto

- **Endpoint:** `DELETE /Project/{id}`
- **Parâmetros de Path:** `{id}` - O identificador único do projeto a ser excluído.
- **Descrição:** Remove um projeto específico com base no ID fornecido.

### Tarefas (ToDo)

#### Listar Todas as Tarefas

- **Endpoint:** `GET /ToDo`
- **Descrição:** Retorna uma lista de todas as tarefas cadastradas.

#### Detalhes de uma Tarefa Específica

- **Endpoint:** `GET /ToDo/{id}`
- **Parâmetros de Path:** `{id}` - O identificador único da tarefa.
- **Descrição:** Obtém detalhes de uma tarefa específica com base no ID fornecido.

#### Adicionar Nova Tarefa

- **Endpoint:** `POST /ToDo`
- **Corpo da Requisição:** Deve conter os dados da tarefa a ser adicionada, seguindo o formato definido no esquema.

#### Atualizar Tarefa Existente

- **Endpoint:** `PUT /ToDo/{id}`
- **Parâmetros de Path:** `{id}` - O identificador único da tarefa a ser atualizada.
- **Corpo da Requisição:** Deve conter os dados atualizados da tarefa.

#### Excluir Tarefa

- **Endpoint:** `DELETE /ToDo/{id}`
- **Parâmetros de Path:** `{id}` - O identificador único da tarefa a ser excluída.
- **Descrição:** Remove uma tarefa específica com base no ID fornecido.

## Como Instalar e Executar

1. Clone este repositório: `git clone https://github.com/seu-usuario/taskmaster-api.git`
2. Navegue até o diretório do projeto: `cd taskmaster-api`
3. Aplique as migrações: `dotnet ef database update`
4. Inicie o servidor: `dotnet run`
