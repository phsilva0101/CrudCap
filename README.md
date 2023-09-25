# CrudCap

## Overview

Este projeto é uma API REST CRUD construída com .NET 7 C# usando Entity Framework e SQL Server como banco de dados. Esta API foi desenvolvida para gerenciar propriedades em um sistema imobiliário, permitindo criar, ler, atualizar e deletar propriedades.

## Instalação e Configuração

. Realizar a clonagem em sua maquina
```
git clone git@github.com:phsilva0101/CrudCap.git
```
. Mude para o Diretório do Projeto:
  ```
  cd crudCap
  ```
. Restaure as Dependências:
    ```
    dotnet restore
    ```

. Configure o Banco de Dados SQL Server:
  * ir no appSettings e inserir sua string de conexão para SQL Server
  * Execute as migrações para criar a base de dados:
  * ```
    dotnet ef database update
    ```
  * ou via Package Manager Console do próprio Visual Studio:
      ```
      Update-Database
      ```
  . Execute o Projeto:
    ```
    dotnet run
    ```

## Documentação da API:

A documentação detalhada dos endpoints da API está disponível no Swagger UI, que pode ser acessado ao executar o projeto e navegar para https://localhost:7094/swagger/index.html

## Licença:
Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## Contato
 [Linkedin](https://www.linkedin.com/in/paulo-araujo-01/)

    
    


