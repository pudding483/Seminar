const websockect = require('ws').Server
const express = require('express')
const path = require('path')
const app = express()
app.use(express.static(path.join(__dirname, 'index')))
app.use(express.json())
const Port = 5000
const server = app.listen(Port, () => {
	console.log(`listening on http://localhost:${Port}`)
})
const wss = new websockect({ server })

// clients端儲存
const unity = new Map()
const webclients = new Map()

wss.on('connection', ws => {
	console.log('connected')
	ws.on('message', msg => {
		msg = JSON.parse(msg)
		if (msg.type == "unity_ws") {
			unity.set("unity", ws)
			console.log("unity connect")
		}
		else if (msg.type == "website_ws" && unity.get("unity")) {
			webclients.set(msg.clientId, ws)
			console.log("website connect:" + msg.clientId)
			const unityclient = unity.get("unity")
			unityclient.send(JSON.stringify(msg))
		}
		else if (msg.type == "web_message" && webclients.get(msg.clientId)) {
			console.log("msg", msg)
			const websiteClient = webclients.get(msg.clientId)
			websiteClient.send(JSON.stringify(msg))
			if (unity.get("unity")) {
				const unityclient = unity.get("unity")
				unityclient.send(JSON.stringify(msg))
			}
		}
	})
	ws.on('close', () => {
		console.log('disconnected');
		if (unity.get("unity") === ws) {
			unity.delete("unity")
		}
		for (const [clientId, client] of webclients) {
			if (client === ws) {
				webclients.delete(clientId);
				break
			}
		}
	})
})
