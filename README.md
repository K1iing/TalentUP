TalentUP

Visão Geral

O TalentUP é uma plataforma corporativa feita para ajudar pessoas a colaborar em tarefas, usando um sistema de pontos e prêmios (gamificação). O foco principal deste projeto está no desenvolvimento do backend e do banco de dados, que são a base do sistema. A ideia é que as pessoas se ajudem, ganhem pontos e desbloqueiem conquistas, aumentando o envolvimento e a produtividade.

Objetivos do Sistema

•
Aumentar o envolvimento dos colaboradores com jogos (gamificação).

•
Facilitar a organização de tarefas entre equipes.

•
Incentivar a ajuda entre pessoas de diferentes áreas.

•
Ter um painel fácil de usar para ver tarefas, pontos e prêmios.

Como Funciona (Funcionalidades Principais)

•
Entrar (Login): Você entra na plataforma só com seu nome.

•
Ver Pontos e Prêmios: Cada pessoa pode ver seus pontos e os prêmios que já ganhou.

•
Organizar Tarefas:

•
Criar Tarefas: Você pode criar novas tarefas, dizendo o que é e se está ativa.

•
Ver Suas Tarefas: Veja as tarefas que você criou (ativas ou já feitas).

•
Ver Todas as Tarefas: Veja todas as tarefas disponíveis no sistema.

•
Ajudar em Tarefas: Você pode se oferecer para ajudar em tarefas de outras pessoas.

•
Terminar Tarefas: Quando uma tarefa é concluída, quem criou e quem ajudou ganha pontos.

•
Sistema de Prêmios: Acumular pontos te dá prêmios (ex: 50 pontos = “Iniciante Da Matrix”).

Como é Feito (Arquitetura do Sistema)

(Backend)
•
Tecnologia: Usamos ASP.NET Core 9 para criar a parte que faz a lógica do sistema (API REST).

•
Banco de Dados: Guardamos as informações no SQL Server, usando o Entity Framework Core para organizar os dados.

•
Caminhos Principais (Endpoints da API):

•
POST /Colaborador: Para cadastrar novas pessoas.

•
GET /Colaborador: Para ver a lista de todas as pessoas cadastradas.

•
POST /Task: Para criar uma nova tarefa.

•
PUT /Task/{taskId}/helper: Para adicionar alguém como ajudante em uma tarefa.

•
PUT /Task/{taskId}/finishTask: Para finalizar uma tarefa e dar os pontos.

Parte da Frente (Frontend) - Onde Você Vê e Interage (Em Desenvolvimento)

•
Tecnologia: Está sendo desenvolvida com .NET MAUI.

•
Funcionalidades: Terá telas para entrar, ver tarefas, ver detalhes de tarefas (com opção de ajudar) e ver seus pontos e prêmios.

Como as Partes se Falam (Comunicação)

•
O Front-End (app MAUI) se conecta com o Back-End (API) usando HttpClient.

•
As informações são trocadas no formato JSON.

Como Usar (Fluxo do Usuário)

1.
Entrar: Digite seu nome na tela inicial.

2.
Painel Principal: Veja seus pontos e prêmios.

3.
Tarefas: Você pode criar tarefas novas, ver todas as tarefas disponíveis ou ajudar em tarefas de outras pessoas.

4.
Terminar Tarefa: Quando uma tarefa é feita, quem criou e quem ajudou ganha pontos, e o sistema verifica se você ganhou novos prêmios.

Imagens (Screenshots)


Tela de Login

<img width="1598" height="818" alt="{9222DE33-80E2-4912-9CF9-BB0A68C2824E}" src="https://github.com/user-attachments/assets/9f0e2a06-772d-4c5d-9079-4db1d9f4f97c" />

Cadastro Realizado com Sucesso

<img width="1598" height="821" alt="image" src="https://github.com/user-attachments/assets/e02ef6de-16e4-480e-88d1-3f1e5db43bc5" />

Criar Nova Tarefa

<img width="1600" height="816" alt="{D55C69AD-B750-48D5-A431-A0F2F3C465C7}" src="https://github.com/user-attachments/assets/a6b33dd6-17bf-4992-b1cc-5c92268e8ba0" />

Tarefas Disponíveis para Ajudar

<img width="1595" height="807" alt="{08958171-7210-4CC7-9B4C-05ED9A0E3031}" src="https://github.com/user-attachments/assets/7a129b88-f5d2-4a04-8357-362b3d68f3d0" />

Ajuda em Tarefa Registrada

<img width="1600" height="809" alt="{50E37E44-76F2-428B-AA40-C63F73BE6C17}" src="https://github.com/user-attachments/assets/20103f67-fe3c-4589-b4c7-0f1579afabcd" />

Detalhes do Colaborador

<img width="1600" height="810" alt="{53EBD86F-2C44-4CE2-8EC5-3A69753613AF}" src="https://github.com/user-attachments/assets/66472a8d-6008-44af-a66b-6c81aae61a57" />

Endpoints da API

<img width="1514" height="682" alt="{6D4F9CA8-813F-4D01-BB15-330C538617D0}" src="https://github.com/user-attachments/assets/13a7101c-fd63-4932-b806-4dafd673be99" />

Estrutura de Pastas do Backend

<img width="308" height="695" alt="{0644AC4B-FCEE-4F73-A5E7-CCE953F848E1}" src="https://github.com/user-attachments/assets/9851ea84-637d-4c9e-9d1d-16e5083dccc1" />

Esquema da Tabela dbo.taskEntities

<img width="309" height="127" alt="{C77BCA75-7F62-4173-8098-DCCEA1730E96}" src="https://github.com/user-attachments/assets/63220a29-7493-4609-a7f4-c8c627c8494a" />

Esquema da Tabela dbo.PontuacaoEntities

<img width="291" height="130" alt="{52AAFF7D-9486-4F73-8082-AE0062E41BAE}" src="https://github.com/user-attachments/assets/f6db8d9c-b8e4-4b06-bced-0f13539a1b6c" />

Esquema da Tabela dbo.Colaboradores

<img width="256" height="95" alt="{4ED2796A-287F-4B2E-92AB-FAB30E1D5605}" src="https://github.com/user-attachments/assets/1d92f6a3-7635-404e-b75f-1520f8a34d28" />

Esquema da Tabela dbo.BadgeEntities

<img width="288" height="114" alt="{894CCC9B-0B8E-46E6-88D6-A64AFBB05D3E}" src="https://github.com/user-attachments/assets/ea909759-091f-4f09-a874-d7e607ec774a" />


Como Instalar

O que Você Precisa (Pré-requisitos)

•
.NET 8 SDK

•
SQL Server

•
Visual Studio (recomendado)

Configurando a Parte de Trás (Backend)

1.
Baixe o projeto: git clone https://github.com/K1iing/TalentUP.git

2.
Ajuste o Banco de Dados: No arquivo appsettings.json, mude a conexão para seu SQL Server. Depois, rode dotnet ef database update.

3.
Inicie o Backend: dotnet run (ele vai funcionar em https://localhost:5283).

