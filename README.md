<h1>
    Projeto escola.
</h1>

# Indice

- [Sobre](#-sobre)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Como Baixar o projeto](#-como-baixar-o-projeto)

---

## 😃 descrição 

<p>  Web api desenvolvida para tratar o tema escola e para armazenar turmas contendo os atributos: Nome,Matricula, DataDeNasicmento e idade e alunos contendo os atributos tituloDaTurma, qtdDeAlunos e idade Media. em um banco de dados em memória, o principal desafio foi de definir a idade a partir da data de nascimento informada pelo usuario para isso utilizei a funçao DateDiff que Retorna um valor que especifica o número de intervalos de tempo entre dois valores Date. assim no meu Get de idade utilizei o seguinte código 
    ``` $return DateAndTime.DateDiff(DateInterval.Year, dataDeNascimento, DateTime.Now);
    ```
    onde coloquei que o intervalo de datas sem em anos, e calculei entre a data de nascimento até a data atual.
</p>

---

## 🚀 Tecnologias utilizadas

Essa Api foi desenvolvida a partir dessas técnologias.

- C#
- ASP.NET Core 3
- EF Core 3
- Insomnia

---

## 📖 Diagrama de classe

<img src="https://user-images.githubusercontent.com/56007944/91089026-57d75980-e629-11ea-88a7-8427c5958577.PNG">
---

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
