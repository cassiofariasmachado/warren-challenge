# Desafio Warren

A solução para o problema apresentado é composta de um backend e um frontend. O backend é uma API Rest desenvolvida com [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core) e o frontend é uma [SPA](https://en.wikipedia.org/wiki/Single-page_application) desenvolvida com [React](https://pt-br.reactjs.org/).

## Preview

![image](https://user-images.githubusercontent.com/16840260/104967055-33599080-59c1-11eb-9324-4fe9e96b8e15.png)

## Warren Banking API 
![Warren Banking API](https://github.com/cassiofariasmachado/warren-challenge/workflows/Warren%20Banking%20API/badge.svg) ![Warren Banking APP/API (Docker Compose)](https://github.com/cassiofariasmachado/warren-challenge/workflows/Warren%20Banking%20APP/API%20(Docker%20Compose)/badge.svg) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=warren-banking-api&metric=alert_status)](https://sonarcloud.io/dashboard?id=warren-banking-api)

### Arquitetura

A arquitetura da API, bebe da fonte do [DDD](https://en.wikipedia.org/wiki/Domain-driven_design), absorvendo alguns conceitos e _building blocks_ para construir um domínio rico (claro essa API é um exemplo, e na prática isso só é possível com a integração entre a equipe de desenvolvimento - devs, POs, analistas, testers, designers e demais membros da equipe - e os _domain experts_).

Estrutura da solution:

- **Warren.Core.Api:** interface Rest da API, onde estão controllers, models e etc;
- **Warren.Core.Core:** domínio da aplicação, onde estão as regras de négocio;
- **Warren.Core.Infra:** onde fica a integração com banco de dados, migrations, comunicação com outros sistemas e etc;

### Tecnologias

Foram utilizadas as seguintes tecnologias/bibliotecas:

- ASP.NET Core (5.0)
- EF Core (5.0)
- MySQL
- Docker e Docker Compose

### Setup

Para executar o projeto execute os seguintes passos:

- [Instalação do .NET Core (5.0)](https://dotnet.microsoft.com/download)
- Instalação de uma IDE ou editor de texto compatível (recomendo o [VS Code](https://code.visualstudio.com/))
- Build/execução da aplicação
    - Utilizando _command line_

        ``` bash
        cd api/
        dotnet build # builda a solution
        dotnet test # executa os testes unitários
        
        cd src/Warren.Banking.Api
        dotnet run # executa o projeto da API
        ```

    - Utilizando o VS Code
        - Abrir projeto com o Code
        - Executar API no modo debug através do F5

## Warren Banking APP 
![Warren Banking APP](https://github.com/cassiofariasmachado/warren-challenge/workflows/Warren%20Banking%20APP/badge.svg) ![Warren Banking APP/API (Docker Compose)](https://github.com/cassiofariasmachado/warren-challenge/workflows/Warren%20Banking%20APP/API%20(Docker%20Compose)/badge.svg) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=warren-banking-app&metric=alert_status)](https://sonarcloud.io/dashboard?id=warren-banking-app)

### Arquitetura

A arquitetura do APP é simples. Trata-se de uma SPA desenvolvida utilizando React e React Router.

A estrutura de pastas está organizada da seguintes forma:

- **api/:** comunicação com backend;
- **components/:** componentes genéricos da aplicação;
- **config/:** abstração para acessar configurações do APP;
- **screens/:** páginas do APP;
- **theme/:** configurações de tema do APP;
- **types/:** tipos utilizadas por todo APP (ex.: requests e responses da API, e etc);
- **utils/:** funções úteis;


### Tecnologias

Foram utilizadas as seguintes tecnologias/bibliotecas:

- TypeScript (4.0.3)
- React (17.0.1)
- React Router
- Axios
- Styled Components
- MaterialUI
- Jest
- Docker e Docker Compose


### Setup

Para executar o projeto execute os seguintes passos:

- [Instalação do Node (LTS 12.19.0)](https://nodejs.org/en/)
- Instalação de uma IDE ou editor de texto compatível (recomendo o [VS Code](https://code.visualstudio.com/))
- Build/execução da aplicação:

    ``` bash
    cd app/
    yarn install # instalação dos pacotes
    yarn test # executa os testes unitários
    yarn start # executa o APP com hot reload, na porta 3000
    ```

## Docker/Compose

### Setup

Para executar toda a solução (API + APP + MySQL) utilizando Docker e Docker Compose, basta:

- [Instalação do Docker](https://docs.docker.com/get-docker/)
- [Instalação do Docker Compose](https://docs.docker.com/compose/install/)
- Execução dos seguintes comandos:
    ``` bash
    docker-compose build
    ASPNETCORE_ENVIRONMENT=Staging docker-compose up -d
    ```

    Após execução dos comandos acima, o frontend estará disponível através da porta 3000 e o backend através da 5000.