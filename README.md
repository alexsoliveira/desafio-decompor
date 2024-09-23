# Desafio Sistema Decompor

**Primeiro passo:** baixa o projeto na máquina e executa a linha de comando abaixo:<br>
**git clone https://github.com/alexsoliveira/desafio-decompor.git**

**Segundo Passo:** quando finalizar de baixar o projeto, executa a linha de comando abaixo:<br>
**cd .\desafio-decompor**

**Terceiro passo:** dentro da pasta do projeto **"/desafio-decompor"** <br>
executar o comando abaixo:<br>
**docker compose up -d --build**

**Quarto passo:** executa a url abaixo, no browser:<br>
**[http://localhost:4200/decompor](http://localhost:4200/decompor)** <br>
**Obs.: A primeira vez pode demorar um pouco para subir a aplicação**

**Quinto passo:** para testar a api execura a url abaixo, no browse:<br>
**[http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)** clica na api **/api/v1/decompor** e executa  json abaixo:<br>
``{
  "entrada": 45,  
}``

**Sexto passo:** rodar os testes de unidade, executa o comando abaixo:<br>
**cd .\back-end\tests\Desafio.Decompor.UnitTests** <br>
**dotnet test** <br>

**Sétimo passo:** rodar os testes de unidade do angular, executa o comando abaixo:<br>
**cd ..\..\..\front-end\desafio.decompor.client** <br>
**ng test --code-coverage** <br>
**Obs.: o comando acima só funciona no promtp bash**

**Oitavo passo:** rodar projeto no kubernetes, executa o comando abaixo:<br>
**cd ..\..\..\k8s** <br>
**Obs.: Caso esteja usando o kind, executa o comando primeiro. (kind create cluster --config=k8s/kind --name=decompor)**
**kubectl apply -f .\deployments\decompor-api.yaml**
**kubectl apply -f .\deployments\decompor-web.yaml**
**kubectl apply -f .\services\decompor-api-svc.yaml**
**kubectl apply -f .\services\decompor-web-svc.yaml**





