# ProsperiDevLab
Desafio para ingressão na vaga de Back-end Developer .NET da Prosperi.

## 🛠️ Pré-requisitos técnicos
- .NET Core 3.1
- MS SQL Server 13.0.40001
- Node.js 14.17.0
- Angular 12.0.3

## 🚀 Execução da aplicação local
### .NET Core API
Configure a variável de ambiente `ConnectionStrings__DefaultConnection` para definir um banco de dados que não seja o LocalDB do MS SQL Server (Express ou não), em seguida, navegue até o diretório `ProsperiDevLab/` e execute um dos comandos abaixo para criar o banco e suas tabelas:
```bash
#Package-Manager
Update-Database

#Dotnet CLI
dotnet ef database update
```
Para restaurar as dependências do projeto .NET e executar a API, utilize os comandos que se seguem:
```bash
dotnet restore
dotnet run
```
A aplicação encontra-se disponível em [http://localhost:5000](http://localhost:5000) ou [https://localhost:5001](https://localhost:5001), enquanto que a documentação pode ser consultada em
**[TODO](http://localhost:5000)**.

### Angular UI
Para restaurar as dependências e executar a aplicação Angular, navegue até o diretório `ProsperiDevLab/ClientApp/` e utilize os comandos que se seguem:
```bash
npm install
npm start
```

A aplicação Angular encontra-se disponível em [http://localhost:4200/](http://localhost:4200/)

## 📰 Documentação
- TODO: Definição de requisitos.
- TODO: Diagrama de classes.