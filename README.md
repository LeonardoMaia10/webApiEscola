# Projeto escola.

## Aprendizado
No desenvolvimento dessa WebApi eu aprendi a calcular em datas com a funçao DateDiff, aprimorei o meu conhecimento em C# e utilizei técnicas de código limpo baseadas no livro Clean Code escrito por Robert Cecil Martin.

## Indice

- [Descrição](#-descrição)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Diagrama de classe](#-Diagrama-de-classe)
- [Como Baixar o projeto](#-como-baixar-o-projeto)

---

## 😃 Descrição 

Web api desenvolvida para tratar o tema escola e para armazenar turmas e alunos em um banco de dados contendo os seguintes atributos: 
```
    Turma:
    Id, tituloDaTurma, qtdDeAlunos, idadeMedia.

    Aluno:
    Id, nome, matricula, dataDeNascimento, idade (calculada à partir da data atual - data de nascimento), turma.
```

o principal desafio foi de definir a idade a partir da data de nascimento informada pelo usuario para isso utilizei a funçao DateDiff que Retorna um valor que especifica o número de intervalos de tempo entre dois valores Date. assim no meu Get de idade utilizei o seguinte código

```
$ return DateAndTime.DateDiff(DateInterval.Year, dataDeNascimento, DateTime.Now);
```
onde coloquei que o intervalo de datas será medido em anos, e calculei entre a data de nascimento até a data atual.

Para consumir a WebApi utilizamos o Swagger, Segue link de auxilio para configuraçao do Swagger.
- https://medium.com/@renato.groffe/asp-net-core-swagger-documentando-apis-com-o-package-swashbuckle-aspnetcore-5eef480ba1c0

<img src="https://user-images.githubusercontent.com/56007944/91593336-58783480-e936-11ea-8af3-8ba60e004b41.PNG">


---

## 🚀 Tecnologias utilizadas

Essa Api foi desenvolvida a partir dessas técnologias.

- C#
- ASP.NET Core 3
- EF Core 3

---

## 📖 Diagrama de classe

<img src="https://user-images.githubusercontent.com/56007944/91089026-57d75980-e629-11ea-88a7-8427c5958577.PNG">
<<<<<<< HEAD

--
=======
---
>>>>>>> 966cf265374d2ade3ba908e5235c6ad96a2b31f3

## 📚 Como baixar o projeto

```bash

# Clonar o repositório
$ git clone https://github.com/LeonardoMaia10/webApiEscola

# entrar no diretório
$ cd webApiEscola

# iniciar o projeto
$ dotnet run
```
---

😎 Desenvolvido por Leonardo Maia
