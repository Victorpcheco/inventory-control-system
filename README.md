# Inventory Control System

## Descrição
O **Inventory Control System** é uma aplicação desenvolvida em C# e .NET 8 para gerenciar o controle de estoque, fornecedores, produtos e categorias. A solução é composta por uma API RESTful que permite realizar operações CRUD (Create, Read, Update, Delete) em diversas entidades, como produtos, fornecedores e categorias, além de validações robustas e integração com banco de dados.

---

## Estrutura do Projeto
A solução está organizada em várias camadas para garantir separação de responsabilidades e escalabilidade:

- **Domain**: Contém as entidades principais do domínio, como `Produto`, `Fornecedor`, `Categoria` e `Endereco`, além de suas regras de negócio.
- **Application**: Contém os serviços, DTOs (Data Transfer Objects) e validadores para a lógica de aplicação.
- **Infrastructure**: Contém os repositórios e a configuração do banco de dados.
- **API**: Contém os controladores que expõem os endpoints RESTful.

---

## Funcionalidades
### Produtos
- Cadastro de produtos com validações de nome, descrição, preço, quantidade em estoque, categoria e fornecedor.
- Atualização de informações do produto.
- Exclusão de produtos.
- Consulta de produtos por ID ou listagem completa.

### Fornecedores
- Cadastro de fornecedores com validações de CPF/CNPJ, nome, telefone, e-mail e endereço.
- Atualização de informações do fornecedor.
- Exclusão de fornecedores.
- Consulta de fornecedores por CPF/CNPJ ou listagem completa.

### Categorias
- Cadastro de categorias com validações de nome e descrição.
- Atualização de informações da categoria.
- Exclusão de categorias.
- Consulta de categorias por ID ou nome.

### Validação de Login
- Validação de login com regras específicas para matrícula e senha.

---

## Tecnologias Utilizadas
- **Linguagem**: C# 12.0
- **Framework**: .NET 8
- **Banco de Dados**: Entity Framework Core
- **Validação**: FluentValidation
- **Autenticação**: System.IdentityModel.Tokens.Jwt
- **Hash de Senhas**: BCrypt.Net-Next

---

## Pré-requisitos
- .NET SDK 8.0 ou superior
- Banco de dados configurado (ex.: SQL Server)
- Visual Studio 2022 ou outro editor compatível

---

## Configuração e Execução
1. Clone o repositório: <br> 
`git clone https://github.com/seu-repositorio/inventory-control-system.git cd inventory-control-system`<br>

2. Configure a string de conexão no arquivo `appsettings.json` da API: <br>
`"ConnectionStrings": { "DefaultConnection": "Server=SEU_SERVIDOR;Database=InventoryControl;User Id=SEU_USUARIO;Password=SUA_SENHA;"} ` <br>

3. Execute as migrações para criar o banco de dados:<br>
`dotnet ef migrations add InitialMigration --startup-project ../InventoryControlSystem.API`<br>
`dotnet ef migrations database update --startup-project ../InventoryControlSystem.API`<br>

5. Compile e execute a solução:<br>
`dotnet run --project InventoryControlSystem.API`


5. Acesse a API em: `http://localhost:5000/api`.

---

## Endpoints Principais
### Produtos
- `GET /api/produto`: Lista todos os produtos.
- `GET /api/produto/{id}`: Consulta um produto pelo ID.
- `POST /api/produto/create`: Cadastra um novo produto.
- `PUT /api/produto/update/{id}`: Atualiza um produto existente.
- `DELETE /api/produto/delete/{id}`: Remove um produto.

### Fornecedores
- `GET /api/fornecedor`: Lista todos os fornecedores.
- `GET /api/fornecedor/{cpfCnpj}`: Consulta um fornecedor pelo CPF/CNPJ.
- `POST /api/fornecedor/create`: Cadastra um novo fornecedor.
- `PUT /api/fornecedor/update/{cpfCnpj}`: Atualiza um fornecedor existente.
- `DELETE /api/fornecedor/delete/{cpfCnpj}`: Remove um fornecedor.

### Categorias
- `GET /api/categoria`: Lista todas as categorias.
- `GET /api/categoria/{id}`: Consulta uma categoria pelo ID.
- `POST /api/categoria/create`: Cadastra uma nova categoria.
- `PUT /api/categoria/update/{id}`: Atualiza uma categoria existente.
- `DELETE /api/categoria/delete/{id}`: Remove uma categoria.

---

## Estrutura de Dados
### Produto
- **Id**: Identificador único.
- **Nome**: Nome do produto.
- **Descrição**: Descrição do produto.
- **QuantidadeEmEstoque**: Quantidade disponível no estoque.
- **Preço**: Preço do produto.
- **CategoriaId**: ID da categoria associada.
- **FornecedorId**: ID do fornecedor associado.

### Fornecedor
- **Id**: Identificador único.
- **Nome**: Nome do fornecedor.
- **CpfCnpj**: CPF ou CNPJ do fornecedor.
- **Telefone**: Telefone de contato.
- **Email**: E-mail de contato.
- **Endereco**: Endereço do fornecedor.

### Categoria
- **Id**: Identificador único.
- **Nome**: Nome da categoria.
- **Descrição**: Descrição da categoria.

---

## Contribuição
Contribuições são bem-vindas! Siga os passos abaixo:
1. Faça um fork do repositório.
2. Crie uma branch para sua feature ou correção: `git checkout -b minha-feature`.
3. Faça commit das suas alterações: `git commit -m 'Minha nova feature'`.
4. Envie para o repositório remoto: `git push origin minha-feature`.
5. Abra um Pull Request.

---

## Licença
Este projeto está licenciado sob a [MIT License](LICENSE).

---


   

   
