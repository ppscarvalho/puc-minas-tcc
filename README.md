### Arquitetura de Sistemas Distribuidos - PUC-MINAS

#### Trabalhode Conclusão de Curso

##### Disciplina: PROJETO INTEGRADO - ARQUITETURA DE SOFTWARE DISTRIBUÍDO (2022)

##### Orientador: Prof. Pedro Alves

##### Início do desenvolvimento da API: 06/05/2023 15h00

#### Tecnologias usadas no desenvolvimento da API

-&nbsp;ASP.NET Core 7.0
<br/>-&nbsp;Entity Framework Core 7.0
<br/>-&nbsp;MassTransit
<br/>-&nbsp;AutoMapper
<br/>-&nbsp;ASP.NET Core MVC
<br/>-&nbsp;xUnit
<br/>-&nbsp;Mock
<br/>-&nbsp;AutoFixture
<br/>-&nbsp;Fluent Assertions
<br/>-&nbsp;Ocelot
<br/>-&nbsp;Duente Identyti Server

##### Arquitetura do Projeto - Sistema de Gestão de Loja

<br/>Core
<br/>&nbsp; -SGL.Cliente.Core.Application
<br/>&nbsp; -SGL.Cliente.Core.Domain
<br/>&nbsp; -SGL.Fornecedor.Core.Application
<br/>&nbsp; -SGL.Fornecedor.Core.Domain
<br/>&nbsp; -SGL.Produto.Core.Application
<br/>&nbsp; -SGL.Produto.Core.Domain
<br/>&nbsp; -SGL.ContasPagar.Core.Application
<br/>&nbsp; -SGL.ContasPagar.Core.Domain
<br/>&nbsp; -SGL.ContasReceber.Core.Application
<br/>&nbsp; -SGL.ContasReceber.Core.Domain
<br/>&nbsp; -SGL.LancamentoVendas.Core.Application
<br/>&nbsp; -SGL.LancamentoVendas.Core.Domain
<br/>
<br/>Infrastructure
<br/>&nbsp; -SGL.Cliente.Infrastructure
<br/>&nbsp; -SGL.Fornecedor.Infrastructure
<br/>&nbsp; -SGL.Produto.Infrastructure
<br/>&nbsp; -SGL.ContasPagar.Infrastructure
<br/>&nbsp; -SGL.ContasReceber.Infrastructure
<br/>&nbsp; -SGL.LancamentoVendas.Infrastructure
<br/>
<br/>Apresentation
<br/>&nbsp; -SGL.WebUI
<br/>&nbsp; -SGL.IdentityServer
<br/>&nbsp; -SGL.APIGateway
<br/>&nbsp; -SGL.Cliente.Apresentation.Api
<br/>&nbsp; -SGL.Fornecedor.Apresentation.Api
<br/>&nbsp; -SGL.Produto.Apresentation.Api
<br/>&nbsp; -SGL.ContasPagar.Apresentation.Api
<br/>&nbsp; -SGL.ContasReceber.Apresentation.Api
<br/>&nbsp; -SGL.LancamentoVendas.Apresentation.Api

<blockquote>
  <p>
    Referência para o desenvolvimento da APi SM.Catalog
  </p>
  <p>

[Implementing a Clean Architecture in ASP.NET Core 6](https://patelalpeshn.medium.com/implementing-a-clean-architecture-in-asp-net-core-6-985a31f717f5)

  </p>

</blockquote>
