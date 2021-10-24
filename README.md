
# Phone Plans Api
API de CRUD de planos telefônicos. 
Os endpoints estão documentados pelo swagger, ao rodar a aplicação irá abrir na página do swagger.
Os scripts para criação e população do banco de dados estão na pasta scritps da raiz do projeto

### Diagrama de Entidade e Relacionamentos

![](https://github.com/JBragon/phone-plans-api/blob/master/scripts/phone-plans-api-DER.jpg?raw=true)


### Estrutura do Projeto

![](https://github.com/JBragon/phone-plans-api/blob/master/solution-structure.png?raw=true)


+ Core (Pasta)
    + **Business** (Interface e Serviços responsável pela lógica de negócio)
    + **DataAccess** (Configuração das entidades com o banco de dados e DBContext da aplicação)
    + **Models** (Entidades da aplicação, mapeamentos de resquest e response e classes de filtragen das entidades)
    + **Resources** (Frases padronizadas do sitemas)
+ Tests (Pasta)
    + **PhonePlans.Test** (Testes de unidade do service de PhonePlans)
+ WebApi (Projeto onde encontra-se os controllers que fazem chamada ao service, todos os endpoints documentados pelo Swagger)
