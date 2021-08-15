function attachEvents() {
    let refreshBtn = document.getElementById('refresh');
    let textAreaElement = document.getElementById('messages');
    let inputElement = document.getElementsByTagName('input');
    let nameElement = inputElement[0];
    let messageElement = inputElement[1];
    let sendBtn = document.getElementById('submit');

    refreshBtn.addEventListener('click', refreshMessages);
    sendBtn.addEventListener('click', sendMessage);

    async function refreshMessages() {
        textAreaElement.textContent = '';
        try{
            let response = await fetch('http://localhost:3030/jsonstore/messenger');
        let messages = await response.json();

        Object.values(messages).forEach(m => {
            textAreaElement.textContent += `${m.author}: ${m.content}\n`;
        })
        }catch(err){
            console.error('Error');
        }
    }

    async function sendMessage() {

        let newMessage = {
            author: nameElement.value,
            content: messageElement.value
        }
        try {
            let response = await fetch('http://localhost:3030/jsonstore/messenger', {
                headers: {
                    'Content-Type': 'application.json'
                },
                method: 'POST',
                body: JSON.stringify(newMessage)
            });

            let createResult = await response.json();
            textAreaElement.textContent += `${createResult.author}: ${createResult.content}\n`;
        }catch(err){
            console.error('Error');
        }

        nameElement.value = '';
        messageElement.value = '';
    }
}

attachEvents();