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
Sistema de Prêmios: Acumular pontos te dá prêmios (ex: 50 pontos = “Colaborador Ouro”).

Como é Feito (Arquitetura do Sistema)

Parte de Trás (Backend) - Onde a Lógica Acontece

•
Tecnologia: Usamos ASP.NET Core 8 para criar a parte que faz a lógica do sistema (API REST).

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
A parte da frente (app MAUI) se conecta com a parte de trás (API) usando HttpClient.

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

As imagens da aplicação TalentUP estão no repositório:

•
Tela de Login

•
Cadastro Realizado com Sucesso

•
Criar Nova Tarefa

•
Tarefa Criada com Sucesso

•
Tarefas Disponíveis para Ajudar

•
Ajuda em Tarefa Registrada

•
Detalhes do Colaborador

•
Endpoints da API

•
Estrutura de Pastas do Backend

•
Esquema da Tabela dbo.taskEntities

•
Esquema da Tabela dbo.PontuacaoEntities

•
Esquema da Tabela dbo.Colaboradores

•
Esquema da Tabela dbo._EFMigrationsHistory

•
Esquema da Tabela dbo.BadgeEntities

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
Baixe o projeto: git clone https://github.com/K1iing/TalentUP.git && cd TalentUP/Backend

2.
Ajuste o Banco de Dados: No arquivo appsettings.json, mude a conexão para seu SQL Server. Depois, rode dotnet ef database update.

3.
Inicie o Backend: dotnet run (ele vai funcionar em https://localhost:5283).

Configurando a Parte da Frente (Frontend)

1.
Vá para a pasta: cd ../Frontend

2.
Ajuste a Conexão: No projeto .NET MAUI, mude o endereço da API para https://localhost:5283.

3.
Inicie o Frontend: Abra o projeto no Visual Studio, escolha onde rodar (Windows, Android, etc.) e inicie.

Como Usar

1.
Entrar: Digite seu nome na tela inicial.

2.
Painel Principal: Veja seus pontos e prêmios.

3.
Organizar Tarefas:

•
Criar: Adicione novas tarefas com descrição e status "Ativa".

•
Ver: Veja suas tarefas ou todas as tarefas disponíveis.

•
Ajudar: Escolha uma tarefa e clique em "Ajudar".

•
Terminar: Conclua tarefas para dar pontos e ver se ganhou prêmios.



4.
Prêmios e Pontos: Seus pontos aumentam conforme você participa, e novos prêmios são liberados.

