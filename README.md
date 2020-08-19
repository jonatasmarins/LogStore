# LogStore
  Criação de um WebAPI em .net Core

# Descrição
  Criação de um BackEnd para criar pedidos para uma pizzaria, podendo o usuário estar cadastrado na base ou não.
 
# Métodos
- Get por código do usuário
- Get por código do endereço 
- Insert por usuário
- Insert por endereço

# Projetos
- API
- Domain
- Data
- Test Unit
- Test Integration

# Tecnologia Utilizada
- .Net Core
- Entity Framework
- Mediator
- WebAPI
- SqlLite

# Metodologias
- DDD
- TDD
- CQRS

# Observações
Utilize os comandos abaixo para realizar a migração do Entity Framework

1. dotnet ef database update --project LogStore.Data/LogStore.Data.csproj --startup-project LogStore.Api/LogStore.Api.csproj

Ao realizar os testes de integração, verifique se os métodos de adicionar pedido com usuário e com endereço foram executados para um melhor proveito dos testes, realizado via InlineData.

<b>O projeto 'TestIntegration' utiliza banco de dados em memória<b>
