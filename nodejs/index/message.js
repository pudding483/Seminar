const socket = new WebSocket('ws://localhost:5000');
var submit_btn = document.querySelector(".submit")
socket.addEventListener('open', () => {
    document.getElementById('output').innerHTML = '指令是停';
    console.log('WebSocket connection is established.');
    submit_btn.addEventListener("click", function () {
        if (document.getElementById("std_id").value.length != 9) {
            return;
        }
        socket.send(JSON.stringify({ clientId: document.getElementById("std_id").value, type: "website_ws" }));
    });
    document.body.addEventListener('keydown', function (e) {
        switch (e.key) {
            case ("w" || "W"):
                socket.send(JSON.stringify({ command: "1", clientId: document.getElementById("std_id").value, type: "web_message" }));
                break;
            case ("s" || "S"):
                socket.send(JSON.stringify({ command: "2", clientId: document.getElementById("std_id").value, type: "web_message" }));
                break;
            case ("a" || "A"):
                socket.send(JSON.stringify({ command: "3", clientId: document.getElementById("std_id").value, type: "web_message" }));
                break;
            case ("d" || "D"):
                socket.send(JSON.stringify({ command: "4", clientId: document.getElementById("std_id").value, type: "web_message" }));
                break;
        }
    })
    socket.addEventListener('message', (msg) => {
        msg = JSON.parse(msg.data)
        if (msg.type == "web_message") {
            const output = document.getElementById('output');
            output.innerHTML = '指令是' + directions[msg.command];
        }
        else if (msg.type == "unity_cam") {
            const imageBase64 = msg.image;
            const imageElement = document.getElementById('imageDisplay');
            imageElement.src = 'data:image/jpeg;base64,' + imageBase64;
        }

    });
});
