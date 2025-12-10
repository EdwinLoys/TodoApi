const apiUrl = "http://localhost:5036/api/tasks";

// DOM elements
const titleEl = document.getElementById("title");
const descriptionEl = document.getElementById("description");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

// Load tasks on page load
window.onload = loadTasks;

// Add Task
addBtn.addEventListener("click", async () => {

    const title = titleEl.value.trim();
    const description = descriptionEl.value.trim();

    if (!title) {
        alert("Title is required");
        return;
    }

    const task = {
        title,
        description
    };

    await fetch(apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(task)
    });

    titleEl.value = "";
    descriptionEl.value = "";

    loadTasks();
});

// Load latest 5 tasks
async function loadTasks() {

    taskList.innerHTML = "";

    const response = await fetch(apiUrl);
    const tasks = await response.json();

    const latest = tasks.slice(0, 5);

    latest.forEach(task => {
        const div = document.createElement("div");
        div.className = "task";

        div.innerHTML = `
            <h3>${task.title}</h3>
            <p>${task.description}</p>
            <button class="done-btn" onclick="markDone(${task.id})">Done</button>
        `;

        taskList.appendChild(div);
    });
}

// Mark task as done
async function markDone(id) {
    await fetch(`${apiUrl}/${id}/done`, {
        method: "PUT"
    });

    loadTasks();
}
