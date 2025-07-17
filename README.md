# TalentUP

> Plataforma gamificada para colaboração interna: colaboradores ajudam outros colegas em tarefas, ganham pontos e desbloqueiam conquistas. Back-end pronto; front .NET MAUI em construção.

---

## 🔖 Índice

* [Visão Geral](#-visão-geral)
* [Objetivos](#-objetivos)
* [Como Funciona](#-como-funciona)
* [Arquitetura](#-arquitetura)
* [Fluxo do Usuário](#-fluxo-do-usuário)
* [Modelos de Dados](#-modelos-de-dados)
* [Regras de Pontuação & Conquistas](#-regras-de-pontuação--conquistas)
* [Endpoints da API](#-endpoints-da-api)
* [Instalação Rápida](#-instalação-rápida)
* [Screenshots](#-screenshots)
* [Roadmap](#-roadmap)

---

## 🚀 Visão Geral

O **TalentUP** é uma plataforma corporativa pensada para aumentar o engajamento entre colaboradores por meio de **gamificação**. Cada colaborador pode criar tarefas, ajudar colegas e acumular **pontos** que liberam **conquistas (badges)**. O foco atual do repositório está no **back-end/API + banco de dados**; a interface **.NET MAUI** está em desenvolvimento.

---

## 🎯 Objetivos

* Engajar colaboradores com pontos & conquistas.
* Facilitar organização e acompanhamento de tarefas entre equipes.
* Incentivar ajuda entre áreas diferentes.
* Oferecer painel simples para ver tarefas, pontos e prêmios.

---

## 🧭 Como Funciona

**Login por nome** → Colaborador entra só digitando o nome.
**Pontuação & Conquistas** → Painel mostra pontos acumulados e badges desbloqueadas.
**Gerenciamento de Tarefas** → Criar tarefa (descrição + status), listar todas, ver só as suas, acompanhar status (Ativa / Finalizada).
**Ajudar Colegas** → Registrar-se como ajudante em tarefas de outros.
**Finalização** → Ao concluir, criador e ajudantes recebem pontos; checagem de conquistas.

---

## 🏗 Arquitetura

**Back-end:** ASP.NET Core 9 (ajuste para sua versão instalada; compatível com .NET 8+).
**Banco:** SQL Server + Entity Framework Core.
**Front:** .NET MAUI (em construção) → telas de login, tarefas, detalhes, pontos & conquistas.
**Comunicação:** App consome API via `HttpClient` (JSON).

---

## 🔁 Fluxo do Usuário

1. Digita nome e entra.
2. Vê painel com pontos & conquistas.
3. Lista tarefas (todas ou minhas).
4. Cria nova tarefa (descrição, status inicial = Ativa).
5. Pode se registrar como ajudante em tarefa de outro colaborador.
6. Ao finalizar: distribui pontos, atualiza status, verifica conquistas.

---

## 🧾 Modelos de Dados (Simplificado)

**Colaborador**

```json
{
  "id": 1,
  "nome": "João",
  "pontuacao": 150,
  "conquistas": ["Iniciante Da Matrix", "Colaborador Prata"]
}
```

**Task**

```json
{
  "id": 10,
  "descricao": "Organizar documentos",
  "status": "Ativa",
  "criador": "Maria",
  "ajudantes": ["João", "Pedro"]
}
```

---

## 🏅 Regras de Pontuação & Conquistas

> Ajuste conforme sua política interna.

| Evento            | Pontos Criador | Pontos Ajudante |
| ----------------- | -------------- | --------------- |
| Tarefa finalizada | +15            | +10             |

**Níveis sugeridos:**

* 50 pts → *Iniciante Da Matrix*
* 100 pts → *Colaborador Prata*
* 200 pts → *Colaborador Ouro*

---

## 📡 Endpoints da API

| Método | Rota                        | Descrição                    |
| ------ | --------------------------- | ---------------------------- |
| `POST` | `/Colaborador`              | Cadastra colaborador.        |
| `GET`  | `/Colaborador`              | Lista colaboradores.         |
| `POST` | `/Task`                     | Cria nova tarefa.            |
| `PUT`  | `/Task/{taskId}/helper`     | Associa ajudante.            |
| `PUT`  | `/Task/{taskId}/finishTask` | Finaliza e distribui pontos. |

### Exemplo de Cadastro (cURL)

```bash
curl -X POST "http://localhost:5283/Colaborador" \
  -H "Content-Type: application/json" \
  -d '{"nome":"João"}'
```

### Exemplo via C# (HttpClient)

```csharp
var dados = new { nome = EntryNome.Text };
var json = JsonSerializer.Serialize(dados);
var content = new StringContent(json, Encoding.UTF8, "application/json");
var response = await http.PostAsync("http://localhost:5283/Colaborador", content);
```

---

## ⚙️ Instalação Rápida

### Pré-requisitos

* .NET 8 SDK ou superior (recomendado 9 se disponível)
* SQL Server (local ou remoto)
* Visual Studio 2022+ (com workloads .NET e MAUI se quiser testar o front)

### Backend

```bash
# Clonar
git clone https://github.com/K1iing/TalentUP.git
cd TalentUP

# Ajustar conexão no appsettings.json
# Depois aplicar migrações
 dotnet ef database update

# Rodar API
 dotnet run
# API em http://localhost:5283 (ajuste conforme seu profile)
```

---

## 📷 Screenshots

> As imagens abaixo estão hospedadas em *GitHub user-attachments* (prévias do desenvolvimento MAUI).

**Tela de Login**
![Tela de Login](https://github.com/user-attachments/assets/9f0e2a06-772d-4c5d-9079-4db1d9f4f97c)

**Cadastro Realizado com Sucesso**
![Cadastro OK](https://github.com/user-attachments/assets/e02ef6de-16e4-480e-88d1-3f1e5db43bc5)

**Criar Nova Tarefa**
![Criar Tarefa](https://github.com/user-attachments/assets/a6b33dd6-17bf-4992-b1cc-5c92268e8ba0)

**Tarefas Disponíveis para Ajudar**
![Tarefas Disponíveis](https://github.com/user-attachments/assets/7a129b88-f5d2-4a04-8357-362b3d68f3d0)

**Ajuda Registrada**
![Ajuda Registrada](https://github.com/user-attachments/assets/20103f67-fe3c-4589-b4c7-0f1579afabcd)

**Detalhes do Colaborador**
![Detalhes Colaborador](https://github.com/user-attachments/assets/66472a8d-6008-44af-a66b-6c81aae61a57)

**Endpoints da API**
![Endpoints](https://github.com/user-attachments/assets/13a7101c-fd63-4932-b806-4dafd673be99)

**Estrutura de Pastas Backend**
![Estrutura Backend](https://github.com/user-attachments/assets/9851ea84-637d-4c9e-9d1d-16e5083dccc1)

**Schema: dbo.taskEntities**
![taskEntities](https://github.com/user-attachments/assets/63220a29-7493-4609-a7f4-c8c627c8494a)

**Schema: dbo.PontuacaoEntities**
![PontuacaoEntities](https://github.com/user-attachments/assets/f6db8d9c-b8e4-4b06-bced-0f13539a1b6c)

**Schema: dbo.Colaboradores**
![Colaboradores](https://github.com/user-attachments/assets/1d92f6a3-7635-404e-b75f-1520f8a34d28)

**Schema: dbo.BadgeEntities**
![BadgeEntities](https://github.com/user-attachments/assets/ea909759-091f-4f09-a874-d7e607ec774a)

---

## 🗺 Roadmap

* [ ] Completar telas MAUI (Login, Lista, Detalhes, Conquistas).
* [ ] Adicionar vinculação de ajudantes no app.
* [ ] Finalização de tarefas via UI.
* [ ] Autenticação (JWT / Identity).
* [ ] Deploy API (Azure) & publicação app.

---

## 🤝 Contribuições

Pull requests são bem-vindos! Abra uma issue para discutir melhorias.

---

## 📄 Licença

Defina uma licença (MIT sugerida). Adicione um arquivo `LICENSE` na raiz.

---

**Feito com 💙 por Gabriel (K1iing). Feedbacks são muito bem-vindos!**
