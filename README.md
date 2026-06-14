# Biblioteca.API

API REST desenvolvida em ASP.NET Core para gerenciamento de uma biblioteca.

Projeto criado com o objetivo de praticar conceitos fundamentais de desenvolvimento back-end com C#, orientação a objetos, HTTP e APIs REST.

## Funcionalidades

### Books

* Criar livros
* Listar livros
* Alterar livros
* Remover livros

### Authors

* Criar autores
* Listar autores
* Alterar autores
* Remover autores

### Customers

* Criar clientes
* Listar clientes
* Alterar clientes
* Remover clientes

## Tecnologias utilizadas

* C#
* ASP.NET Core
* Swagger
* Git
* GitHub

## Conceitos praticados

* Orientação a Objetos
* Encapsulamento
* Construtores privados
* Métodos de fábrica (`Create`)
* Regras de negócio nas entidades
* Controllers
* Rotas HTTP
* GET
* POST
* PUT
* DELETE
* Coleções (`List<T>`)
* Controle de Ids
* Versionamento com Git

## Estrutura do projeto

```
Biblioteca.API
│
├── Controllers
│   ├── BooksController.cs
│   ├── AuthorController.cs
│   └── CustomerController.cs
│
├── Entities
│   ├── Book.cs
│   ├── Author.cs
│   └── Customer.cs
│
└── Program.cs
```

## Endpoints

### Books

| Método | Endpoint   |
| ------ | ---------- |
| GET    | /api/Books |
| POST   | /api/Books |
| PUT    | /api/Books |
| DELETE | /api/Books |

### Authors

| Método | Endpoint    |
| ------ | ----------- |
| GET    | /api/Author |
| POST   | /api/Author |
| PUT    | /api/Author |
| DELETE | /api/Author |

### Customers

| Método | Endpoint      |
| ------ | ------------- |
| GET    | /api/Customer |
| POST   | /api/Customer |
| PUT    | /api/Customer |
| DELETE | /api/Customer |

## Próximos passos

* Entity Framework Core
* SQL Server
* DbContext
* Migrations
* Relacionamentos entre entidades
* DTOs
* Persistência em banco de dados

## Objetivo

Este projeto faz parte da minha jornada de aprendizado em desenvolvimento back-end com .NET e tem como objetivo consolidar fundamentos de C#, orientação a objetos e construção de APIs REST.
