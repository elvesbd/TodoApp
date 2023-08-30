# TodoAPI

![GitHub repo size](https://img.shields.io/github/repo-size/elvesbd/TodoApp?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/elvesbd/TodoApp?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/elvesbd/TodoApp?style=for-the-badge)
![GitHub issues](https://img.shields.io/github/issues-raw/elvesbd/TodoApp?style=for-the-badge)
![GitHub pull requests](https://img.shields.io/github/issues-pr/elvesbd/TodoApp?style=for-the-badge)

<img src="https://i.imgur.com/ccqPFbN.png" alt="Imagem Da Documentação da API">

# Documentação da API TodoApp

Bem-vindo à documentação da API TodoApp! Esta API permite gerenciar itens de tarefa (Todo) para diferentes usuários. Abaixo, você encontrará informações sobre os endpoints disponíveis e como interagir com eles.

## Endpoints

### Obter Todos os Todos de um Usuário

Recupere uma lista de todos os Todos para um usuário específico.

- **Endpoint:** `GET /v1/todos/user/{user}`
- **Parâmetros:**
  - `{user}`: O nome de usuário do usuário cujos Todos você deseja recuperar.
- **Resposta:** Um array JSON contendo uma lista de itens de Todo para o usuário especificado.

### Obter Todos Completos de um Usuário

Recupere uma lista de todos os Todos completos para um usuário específico.

- **Endpoint:** `GET /v1/todos/done/{user}`
- **Parâmetros:**
  - `{user}`: O nome de usuário do usuário cujos Todos completos você deseja recuperar.
- **Resposta:** Um array JSON contendo uma lista de itens de Todo completos para o usuário especificado.

### Obter Todos Incompletos de um Usuário

Recupere uma lista de todos os Todos incompletos para um usuário específico.

- **Endpoint:** `GET /v1/todos/undone/{user}`
- **Parâmetros:**
  - `{user}`: O nome de usuário do usuário cujos Todos incompletos você deseja recuperar.
- **Resposta:** Um array JSON contendo uma lista de itens de Todo incompletos para o usuário especificado.

### Obter Todos Completos para Hoje

Recupere uma lista de Todos completos para um usuário que estão programados para hoje.

- **Endpoint:** `GET /v1/todos/done/today/{user}`
- **Parâmetros:**
  - `{user}`: O nome de usuário do usuário cujos Todos completos para hoje você deseja recuperar.
- **Resposta:** Um array JSON contendo uma lista de itens de Todo completos programados para hoje para o usuário especificado.

### Obter Todos Incompletos para Hoje

Recupere uma lista de Todos incompletos para um usuário que estão programados para hoje.

- **Endpoint:** `GET /v1/todos/undone/today/{user}`
- **Parâmetros:**
  - `{user}`: O nome de usuário do usuário cujos Todos incompletos para hoje você deseja recuperar.
- **Resposta:** Um array JSON contendo uma lista de itens de Todo incompletos programados para hoje para o usuário especificado.

### Criar um Novo Todo

Crie um novo item de Todo.

- **Endpoint:** `POST /v1/todos`
- **Corpo da Requisição:** Forneça um objeto JSON representando o `CreateTodoCommand`.
- **Resposta:** Um objeto JSON contendo o resultado da operação de criação.

### Atualizar um Todo

Atualize um item de Todo existente.

- **Endpoint:** `PUT /v1/todos`
- **Corpo da Requisição:** Forneça um objeto JSON representando o `UpdateTodoCommand`.
- **Resposta:** Um objeto JSON contendo o resultado da operação de atualização.

### Marcar um Todo como Concluído

Marque um item de Todo como concluído.

- **Endpoint:** `PUT /v1/todos/mark-as-done`
- **Corpo da Requisição:** Forneça um objeto JSON representando o `MarkTodoAsDoneCommand`.
- **Resposta:** Um objeto JSON contendo o resultado da operação de marcação como concluído.

### Marcar um Todo como Não Concluído

Marque um item de Todo como não concluído.

- **Endpoint:** `PUT /v1/todos/mark-as-undone`
- **Corpo da Requisição:** Forneça um objeto JSON representando o `MarkTodoAsUndoneCommand`.
- **Resposta:** Um objeto JSON contendo o resultado da operação de marcação como não concluído.

## Uso

Para interagir com a API TodoApp, você pode usar ferramentas como `curl` ou qualquer biblioteca de cliente HTTP na sua linguagem de programação preferida.

Observe que esta documentação fornece uma visão geral dos endpoints disponíveis. Certifique-se de consultar o código do controlador e suas classes associadas para obter informações detalhadas sobre as estruturas de solicitação e resposta.

## 🤝 Colaborador

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://github.com/elvesbd.png" width="100px;" alt="Foto do Elves Brito no GitHub"/><br>
        <sub>
          <b>Elves Brito</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

## 📝 Licença

Esse projeto está sob licença. Veja o arquivo [LICENÇA](LICENSE.md) para mais detalhes.

[⬆ Voltar ao topo](#TodoAPI)<br>
