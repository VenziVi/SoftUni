function solution() {
    let cardElements = document.getElementsByClassName('card');

    let addElement = cardElements[0].querySelector('input');
    let addBtnElement = cardElements[0].querySelector('button');

    addBtnElement.addEventListener('click', (e) => {

        let ulElement = cardElements[1].querySelector('ul');

        let liElement = document.createElement('li');
        liElement.classList.add('gift');
        liElement.textContent = addElement.value;
        let sendBtn = document.createElement('button');
        sendBtn.id = 'sendButton';
        sendBtn.textContent = 'Send';
        let discardBtn = document.createElement('button');
        discardBtn.id = 'discardButton';
        discardBtn.textContent = 'Discard';

        liElement.appendChild(sendBtn);
        liElement.appendChild(discardBtn);
        ulElement.appendChild(liElement);

        let liArray = [...cardElements[1].querySelectorAll('ul > li')];
        

        liArray.sort((a, b) => a.textContent.localeCompare(b.textContent)).forEach(x => {
            ulElement.appendChild(x);
        });

        addElement.value = '';

        sendBtn.addEventListener('click', (e) => {
            let sendUlElement = cardElements[2].querySelector('ul');
            let currLi = e.target.parentNode;
            sendUlElement.appendChild(currLi);
            e.target.remove();
            sendUlElement.querySelector('#discardButton').remove();
        });

        discardBtn.addEventListener('click', (e) => {
            let discardUl = cardElements[3].querySelector('ul');
            let currLi = e.target.parentNode;
            discardUl.appendChild(currLi);
            e.target.remove();
            discardUl.querySelector('#sendButton').remove();
        })

    })
}