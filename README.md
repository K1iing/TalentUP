🚀 Visão Geral

O TalentUP é uma plataforma corporativa pensada para aumentar o engajamento entre colaboradores por meio de gamificação. Cada colaborador pode criar tarefas, ajudar colegas e acumular pontos que liberam conquistas (badges). O foco atual do repositório está no back-end/API + banco de dados; a interface .NET MAUI está em desenvolvimento.

🎯 Objetivos

Engajar colaboradores com pontos & conquistas.

Facilitar organização e acompanhamento de tarefas entre equipes.

Incentivar ajuda entre áreas diferentes.

Oferecer painel simples para ver tarefas, pontos e prêmios.

🧭 Como Funciona

Login por nome → Colaborador entra só digitando o nome.Pontuação & Conquistas → Painel mostra pontos acumulados e badges desbloqueadas.Gerenciamento de Tarefas → Criar tarefa (descrição + status), listar todas, ver só as suas, acompanhar status (Ativa / Finalizada).Ajudar Colegas → Registrar-se como ajudante em tarefas de outros.Finalização → Ao concluir, criador e ajudantes recebem pontos; checagem de conquistas.

🏗 Arquitetura

Back-end: ASP.NET Core 9 (ajuste para sua versão instalada; compatível com .NET 8+).Banco: SQL Server + Entity Framework Core.Front: .NET MAUI (em construção) → telas de login, tarefas, detalhes, pontos & conquistas.Comunicação: App consome API via HttpClient (JSON).

🔁 Fluxo do Usuário

Digita nome e entra.

Vê painel com pontos & conquistas.

Lista tarefas (todas ou minhas).

Cria nova tarefa (descrição, status inicial = Ativa).

Pode se registrar como ajudante em tarefa de outro colaborador.

Ao finalizar: distribui pontos, atualiza status, verifica conquistas.

🏅 Regras de Pontuação & Conquistas

Ajuste conforme sua política interna.

Evento

Pontos Criador

Pontos Ajudante

Tarefa finalizada

+15

+10

Níveis sugeridos:

50 pts → Iniciante Da Matrix

100 pts → Colaborador Prata
📡 Endpoints da API

Método

Rota

Descrição

POST

/Colaborador

Cadastra colaborador.

GET

/Colaborador

Lista colaboradores.

POST

/Task

Cria nova tarefa.

PUT

/Task/{taskId}/helper

⚙️ Instalação Rápida

Pré-requisitos

.NET 8 SDK ou superior (recomendado 9 se disponível)

SQL Server (local ou remoto)

Visual Studio 2022+ (com workloads .NET e MAUI se quiser testar o front)

Backend

# Clonar
git clone https://github.com/K1iing/TalentUP.git
cd TalentUP

# Ajustar conexão no appsettings.json
# Depois aplicar migrações
 dotnet ef database update

# Rodar API
 dotnet run
# API em http://localhost:5283 (ajuste conforme seu profile)

📷 Screenshots

As imagens abaixo estão hospedadas em GitHub user-attachments (prévias do desenvolvimento MAUI).

Tela de Login

Cadastro Realizado com Sucesso

Criar Nova Tarefa

Tarefas Disponíveis para Ajudar

Ajuda Registrada

Detalhes do Colaborador

Endpoints da API

Estrutura de Pastas Backend

Schema: dbo.taskEntities

Schema: dbo.PontuacaoEntities

Schema: dbo.Colaboradores

Schema: dbo.BadgeEntities

Associa ajudante.

PUT

/Task/{taskId}/finishTask

Finaliza e distribui pontos.
