# CrudCap

## Overview

Api Rest criada utilizando .NET 7, com a utilização do ORM Entity framework para a parte da persistência dos dados. 
Essa API foi criada pensada em por em prática os conceitos e boas práticas do .net e de criação de API's, simulando um sistema de imobiliaria, de cadastro simples de residências, edição, inativação e consulta dos imoveis.

## Clone

* Realizar a clonagem em sua maquina
```
git clone git@github.com:phsilva0101/CrudCap.git
```

* Após ter o projeto clonado localmente, ir no appSettings e inserir sua string de conexão para SQL Server
* Com a conexão de string devidamente inserida, será necessário rodar a criação das entidades em banco via migration, portando no Package Manager do Visual studio, rode o comando:
  ```
  Update-Database
  ```
  * Confirmando a criação das entidades em banco, o projeto está pronto para ser executado 
