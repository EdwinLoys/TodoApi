# TodoApp

Task Manager
ASP.NET Core 8 • SQL Server • EF Core • Vanilla JavaScript SPA
<p align="center"> <img src="https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet" /> <img src="https://img.shields.io/badge/SQL%20Server-EF%20Core-red?logo=microsoftsqlserver" /> <img src="https://img.shields.io/badge/Frontend-Vanilla%20JS-yellow?logo=javascript" /> <img src="https://img.shields.io/badge/Swagger-Enabled-brightgreen?logo=swagger" /> <img src="https://img.shields.io/badge/Platform-Web-blue" /> </p>

A clean and minimal full-stack Task Manager featuring an ASP.NET Core 8 Web API backend and a lightweight SPA frontend served directly from wwwroot/.

🌟 Features
🔧 Backend (ASP.NET Core 8)

✔ REST API (GET, POST, PUT)
✔ Entity Framework Core + SQL Server
✔ Task operations:

Get latest 5 tasks

Add task

Mark task as done

✔ Dependency Injection (TaskService)

✔ CORS enabled

✔ Swagger UI for easy testing

✔ Serves SPA static files

💡 Frontend (Vanilla JS SPA)

✔ Add tasks

✔ Display the latest 5 tasks

✔ Mark tasks done

✔ Clean HTML/CSS UI

✔ Uses Fetch API to communicate with the backend

📂 Project Structure


<img width="200" height="261" alt="Screenshot 2025-12-11 104211" src="https://github.com/user-attachments/assets/584bd611-e0ee-442b-951f-1e45f4ae4253" />

🚀 Getting Started

1️⃣ Clone the repository

git clone https://github.com/EdwinLoys/TaskManager.git
cd TaskManager

2️⃣ Configure SQL Server

Edit appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

3️⃣ Apply database migrations

dotnet ef database update

4️⃣ Run the project

dotnet run

Project will start at:

App: http://localhost:5036/

Swagger: http://localhost:5036/swagger

| Method | Endpoint               | Description          |
| ------ | ---------------------- | -------------------- |
| GET    | `/api/tasks`           | Returns last 5 tasks |
| POST   | `/api/tasks`           | Create a new task    |
| PUT    | `/api/tasks/{id}/done` | Mark a task as done  |


Example: POST request

{
  "title": "Buy groceries",
  "description": "Milk, eggs, bread"
}

🖼 UI Preview (optional placeholders)

<img width="548" height="401" alt="porject screen short" src="https://github.com/user-attachments/assets/2fde896c-8997-41d8-a403-9f53fedd92b0" />

<img width="556" height="100" alt="database" src="https://github.com/user-attachments/assets/3198377e-6fd9-40c8-92c4-6fbcf8366cfe" />


📦 Planned Improvements

📝 Edit & delete tasks

🎨 UI redesign (modern layout)

🐳 Docker support

🔐 Authentication (JWT)

🔍 Search + pagination







