# Como executar o projeto

## 1º Passo: substituir configurações
Altere em [GerenciarProjetos/appsettings.json](GerenciarProjetos/appsettings.json) os seguintes valores:
1. ***ConnectionStrings/DbGerenciarProjetos*** para a string de conexão do banco de dados
2. ***JwtSecret*** para uma chave de criptografia de, no mínimo, 32 caracteres (recomendável 256 caracteres)

## 2º Passo: executando o projeto
Com o docker já inicialiado, siga os passos
1. Execute o docker build (***docker build -t gerenciarprojetos .***)
2. Execute o docker run (***docker run -d -p 8080:80 --name gerenciarprojetos gerenciarprojetos***)

## 3º Passo: Utilizando o projeto
Todas as urls estarão disponíveis em ***/swagger/index.html***
1. Realize o cadastro de um usuário em ***/api/Usuario/Cadastrar***
2. Faça o login em ***/api/Usuario/Login*** você receberá um JWT que deve ser enviado em todas as requisições, e um refresh token para re-gerar o JWT quando ele expirar
