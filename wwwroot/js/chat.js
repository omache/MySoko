var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    li.innerHTML = `<strong class="username">${user}</strong><br>${message}`;
    document.getElementById("messagesList").appendChild(li);
    var chatBox = document.getElementById("chatBox");
    chatBox.scrollTop = chatBox.scrollHeight; // Auto-scroll to bottom
});

connection.on("ReceiveUserList", function (users) {
    var userListContainer = document.getElementById("userList");
    userListContainer.innerHTML = ""; // Clear existing list

    // Populate the list of users who have sent messages
    users.forEach(function (user) {
        var li = document.createElement("li");
        li.innerHTML = `<strong>${user.firstName}</strong> <button onclick="startReply('${user.id}')">Reply</button>`;
        userListContainer.appendChild(li);
    });
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = ''; // Clear input field after sending
    event.preventDefault();
});

// Function to handle replies from the admin
function startReply(userId) {
    var replyMessage = prompt("Type your reply:");
    if (replyMessage) {
        connection.invoke("ReplyToUser", userId, replyMessage).catch(function (err) {
            return console.error(err.toString());
        });
    }
}

// Accordion toggle
document.getElementById("chatHeader").addEventListener("click", function () {
    var chatBox = document.getElementById("chatBox");
    chatBox.classList.toggle("hidden");
});
