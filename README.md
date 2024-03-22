<h1>  Hackathon - SOAT1 - Grupo 13 - Microserviço de produção </h1>

![GitHub](https://img.shields.io/github/license/dropbox/dropbox-sdk-java)

# Resumo do projeto

Este projeto é desenvolvido em C# com .NET 6, seguindo os princípios da arquitetura hexagonal. Seu objetivo principal é a geração de relatórios solicitado pelos colaboradores e seu envio por email.

Para garantir a segurança das informações de acesso ao banco de dados PostgreSQL, o projeto faz uso do Secret Manager. Isso permite que as credenciais do banco de dados sejam armazenadas de forma segura e acessadas apenas por autorizações apropriadas. Essa abordagem fortalece a segurança dos dados sensíveis.


Sinta-se à vontade para entrar em contato conosco se tiver alguma dúvida ou sugestão. Agradecemos pelo interesse em nosso projeto!


> :construction: Projeto em construção :construction:

License: [MIT](License.txt)

# Sonar Cloud
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=coverage)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=bugs)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio) [![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=SOAT1-GRP13_Hackathon-Relatorio&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=SOAT1-GRP13_Hackathon-Relatorio)

Para maiores detalhes através do link: https://sonarcloud.io/summary/overall?id=SOAT1-GRP13_Hackathon-Relatorio.

# Clean Architecture

Devido à natureza específica do framework .Net, adotamos uma nomeclatura diferente para nossa estrutura que segue os princípios da Clean Architecture (Arquitetura Limpa).

Na nossa arquitetura, a camada de Controller corresponde à Camada de API da Clean Architecture. Esta camada é responsável por lidar com as requisições externas e coordenar o fluxo de dados.

A camada de queries foi concebida como a camada de Gateways na Clean Architecture. Aqui, centralizamos a lógica relacionada à recuperação de dados, permitindo uma separação clara entre a fonte de dados e a lógica de negócios.

Para a implementação das operações de comando, optamos por utilizar a camada de command handlers, que equivale à camada de controller na Clean Architecture. Nesta camada, tratamos as ações e comandos vindos da camada de API, garantindo a execução das operações necessárias.

O projeto de Domain abriga as nossas entidades de negócio e objetos de valor (Value Objects). Esta camada é o coração do nosso sistema, encapsulando as regras de negócio essenciais.

No contexto da persistência de dados, a camada de Infraestrutura (Infra) foi designada como a camada de DB (Banco de Dados) na Clean Architecture. Aqui, lidamos com aspectos de armazenamento e recuperação de dados, mantendo a separação entre as preocupações de banco de dados e as regras de negócio.

Esta arquitetura foi adotada para promover a manutenibilidade, escalabilidade e testabilidade do nosso projeto, permitindo uma clara separação de responsabilidades em cada camada. Estamos comprometidos em seguir os princípios da Clean Architecture para alcançar um sistema robusto e bem estruturado.

# Bando de Dados

Para o armazenamento de dados do nosso projeto, optamos pelo PostgreSQL, um sistema de gerenciamento de banco de dados objeto-relacional avançado. A decisão foi baseada principalmente na familiaridade da nossa equipe com essa tecnologia, além das seguintes características do PostgreSQL que consideramos fundamentais para o sucesso do nosso sistema:

**Robustez e Confiabilidade**

O PostgreSQL é conhecido por sua alta confiabilidade, integridade de dados e conformidade com padrões, o que é essencial para o gerenciamento eficaz dos dados de ponto eletrônico em nossa aplicação.

**Escalabilidade e Performance**

Suporta grandes volumes de dados e um número significativo de transações simultâneas, essencial para atender às demandas de uma grande corporação.

**Recursos Avançados**

Oferece recursos avançados como transações complexas, consultas avançadas, tipos de dados extensíveis e suporte a extensões, permitindo uma maior flexibilidade no desenvolvimento.

**Comunidade Ativa e Suporte**

Possui uma comunidade ativa e diversas fontes de suporte, garantindo acesso a recursos e atualizações que podem ajudar a otimizar e aprimorar continuamente nossa solução.

A escolha do PostgreSQL reflete nosso compromisso com a entrega de uma solução robusta e confiável, que possa atender às exigentes necessidades de registro de ponto e gestão de dados de nossa grande corporação.

# ⌨️ Testando a API

**Importante**
Você pode baixar o projeto e executá-lo em seu ambiente local com o Visual Studio. Embora o projeto esteja hospedado em nossa infraestrutura na AWS, também o apresentamos aos professores em um vídeo demonstrando seu funcionamento.

Isso permite que você experimente a funcionalidade da API em seu próprio ambiente e explore seu comportamento. Se tiver alguma dúvida ou precisar de assistência, sinta-se à vontade para entrar em contato conosco.

Você pode testar esta API de duas maneiras: usando o Postman ou o Swagger, que está configurado no projeto.

Acessando o Swagger:

Para acessar o Swagger do projeto localmente, utilize o seguinte link:
- http://localhost:5272/swagger/index.html

Se quiser instalar toda a infraestrutura do projeto, você pode fazer seguindo os passos do projeto central:
- https://github.com/SOAT1-GRP13/Hackathon

Autenticação:
As chamadas requerem autenticação. Para obter um token Bearer, você pode através do seguinte projeto: 
- https://github.com/SOAT1-GRP13/Hackathon-Auth.

# 🛠️ Abrir e rodar o projeto utilizando o docker

Para o correto funcionamento precisa do docker instalado.

Com o docker instalado, acesse a pasta raiz do projeto e execute o comando abaixo: 

```shell
docker-compose up
```

# 📒 Documentação da API

No projeto foi instalado o REDOC e pode ser acessado através do link abaixo:

- http://localhost:5272/api-docs/index.html

# ✔️ Tecnologias utilizadas

- ``.Net 6``
- ``Postgres``
- ``Secrets Manager``
- ``RabbitMQ``


# Autores

| [<img src="https://avatars.githubusercontent.com/u/28829303?s=400&v=4" width=115><br><sub>Christian Melo</sub>](https://github.com/christiandmelo) |  [<img src="https://avatars.githubusercontent.com/u/89987201?v=4" width=115><br><sub>Luiz Soh</sub>](https://github.com/luiz-soh) |  [<img src="https://avatars.githubusercontent.com/u/21027037?v=4" width=115><br><sub>Wagner Neves</sub>](https://github.com/nevesw) |  [<img src="https://avatars.githubusercontent.com/u/34692183?v=4" width=115><br><sub>Mateus Bernardi Marcato</sub>](https://github.com/xXMateus97Xx) |
| :---: | :---: | :---: | :---: |
