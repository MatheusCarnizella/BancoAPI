Utilizei dos meus conhecimentos para gerar essa MinimalAPI, um recurso do da versão 6.0 para cima.

Para usufruir dessa é preciso alguns passos antes de abrir a API.

- 1: Abrir o CMD e digitar o comando "dotnet tool install --global dotnet-ef" e em seguida digitar "dotnet ef" para confirmar a instalação.

- 2: Abrir outro CMD e digitar "cd -Diretório onde se encontra a pasta da API\BancoAPI\BancoAPI".

- 3: No mesmo CMD digitar "dotnet ef migrations add UmNome" para gerar uma migration sua.

- 4: No mesmo CMD digitar "dotnet ef database update Mesmo nome usado anteriormente" para gerar o banco de dados no SQLServer.

- 5: Executar a API e abrir o Swagger.

Pronto.