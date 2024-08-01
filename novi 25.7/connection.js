let socket = new WebSocket("wss://maticr.tenzor.live:7278/messageHub/Join/Matic");
socket.onopen = function(event) {
    console.log("Socket se je odprl");
};


messageQueue = []
socket.onmessage = function(event) { // vsak response od backenda pride v ta function
    const receivedObject = JSON.parse(event.data); 

    const side = receivedObject.side;
    const id = receivedObject.id;

    //Če je msg po vrsti iz Queueja pa če je iz backenda
    if (side == "BE" && id == messageQueue[0]) {
        messageQueue.shift(); //zbrises ta id vn iz queueja

        const action = receivedObject.action;
        const approved = receivedObject.accepted;
    
        switch (action) {
            case 'swapPage':
                approved ? (showPage(receivedObject.newPageId), disableError()) : displayError(receivedObject.error);
                break
            case 'verifyIdentity':
                approved ? 'verified' : 'error';
            case 'paymentProces':
        }


    }
    //če ni
    else if (side == "FE") {
        console.log("svoj msg");
    }
    else {
        console.log("nepravilen msg");
    }
};














socket.onclose = function(event) { 
    if (event.wasClean) {
        console.log(`Closed cleanly, code=${event.code} reason=${event.reason}`);
    } else {
        console.log('Connection died');
    }
};
socket.onerror = function(error) {
    console.error("WebSocket error observed:", error);
};
window.messageQueue = messageQueue;
window.socket = socket; //da ga lohka globally uporablas




