const apiUrl = "http://localhost:5036/api/tasks"; // Backend API URL

const titleInput = document.getElementById("title");
const descInput = document.getElementById("description");
const addBtn = document.getElementById("addBtn");
const tasksDiv = document.getElementById("tasks");

// Fetch latest tasks from backend
async function fetchTasks() {
    tasksDiv.innerHTML = ""; // Clear list
    try {
        const res = await fetch(apiUrl);
        const tasks = await res.json();

        tasks.forEach(task => {
            const taskCard = document.createElement("div");
            taskCard.className = "task-card";

            const info = document.createElement("div");
            info.innerHTML = `<div class="task-title">${task.title}</div><div>${task.description}</div>`;

            const doneBtn = document.createElement("button");
            doneBtn.textContent = "Done";
            doneBtn.onclick = () => markDone(task.id);

            taskCard.appendChild(info);
            taskCard.appendChild(doneBtn);
            tasksDiv.appendChild(taskCard);
        });
    } catch (err) {
        console.error("Error fetching tasks:", err);
    }
}

// Add new task
async function addTask() {
    const title = titleInput.value.trim();
    const description = descInput.value.trim();
    if (!title || !description) {
        alert("Please enter title and description");
        return;
    }

    try {
        await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ title, description })
        });

        titleInput.value = "";
        descInput.value = "";
        fetchTasks(); // Refresh list
    } catch (err) {
        console.error("Error adding task:", err);
    }
}

// Mark task as done
async function markDone(id) {
    try {
        await fetch(`${apiUrl}/${id}/done`, { method: "PUT" });
        fetchTasks(); // Refresh list
    } catch (err) {
        console.error("Error marking task done:", err);
    }
}

// Event listener
addBtn.addEventListener("click", addTask);

// Initial load
fetchTasks();
