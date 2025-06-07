# InvestmentControl-backend

Este projeto é um backend para controle de investimentos, desenvolvido em ASP.NET MVC com Entity Framework Core.

## Visão Geral

O sistema permite o gerenciamento de investimentos, incluindo cadastro, edição, exclusão, listagem e geração de relatórios. O backend foi projetado para ser modular, seguro e facilmente extensível.

## Arquitetura

O projeto segue a arquitetura MVC (Model-View-Controller) do ASP.NET, separando responsabilidades em camadas distintas:

- **Controllers**: Responsáveis por receber as requisições HTTP, processar as entradas, acionar a lógica de negócio e retornar respostas apropriadas (geralmente em JSON ou redirecionamentos).
- **Models**: Representam as entidades de domínio do sistema, como Investimento, e contêm as regras de validação de dados.
- **ViewModels**: Estruturas intermediárias para transportar dados entre as views e os controllers, facilitando a validação e a formatação.
- **Repositories**: Camada de acesso a dados, responsável por interagir com o banco de dados utilizando Entity Framework Core. Implementa padrões como Repository e Unit of Work para desacoplar a lógica de persistência.
- **Data**: Contém o contexto do banco de dados (`AppDbContext`), responsável pelo mapeamento das entidades e configuração do EF Core.
- **Attributes**: Implementa validações customizadas para regras de negócio específicas.

### Fluxo de Dados

1. O usuário realiza uma requisição (ex: cadastrar investimento).
2. O Controller recebe a requisição, valida os dados recebidos (diretamente ou via ViewModel).
3. O Controller aciona o Repository para persistir ou recuperar dados.
4. O Repository utiliza o `AppDbContext` para interagir com o banco de dados.
5. O Controller retorna a resposta ao usuário.

### Segurança

- Validações de entrada em Models e ViewModels.
- Possibilidade de integração com autenticação/autorização do ASP.NET Identity.

## Funcionalidades

- **Cadastro de Investimentos**: Permite criar novos investimentos, informando tipo, valor, data e descrição.
- **Edição de Investimentos**: Atualização dos dados de um investimento existente.
- **Exclusão de Investimentos**: Remoção lógica ou física de registros.
- **Listagem Paginada**: Exibição de investimentos com paginação e ordenação.
- **Relatórios**: Geração de relatórios de totais investidos por tipo de investimento.
- **Validações Customizadas**: Regras como valor positivo, datas válidas e campos obrigatórios.
- **Migrations**: Controle de versão do banco de dados via Entity Framework Core.

## Estrutura de Pastas

- `Controllers/` — Lógica das rotas e ações.
- `Models/` — Entidades de domínio.
- `ViewModels/` — Modelos para transporte de dados.
- `Repositories/` — Interfaces e implementações de acesso a dados.
- `Data/` — Contexto do banco de dados.
- `Migrations/` — Histórico de alterações do banco.
- `Attributes/` — Validações customizadas.
