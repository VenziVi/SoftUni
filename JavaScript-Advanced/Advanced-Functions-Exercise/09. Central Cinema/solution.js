function solve() {
    let onScreenBtn = document.querySelector('#container button')
    onScreenBtn.addEventListener('click', addMovieToScreen);

    let clearBtn = document.querySelector('#archive > button');
    clearBtn.addEventListener('click', clearArhive);

    function addMovieToScreen(e) {
        e.preventDefault();
        let containerElement = document.querySelectorAll('#container input');
        let name = containerElement[0].value;
        let hall = containerElement[1].value;
        let price = Number(containerElement[2].value).toFixed(2);

        if (name !== '' &&
            hall !== '' &&
            price !== '' &&
            !isNaN(Number(price))) {

            let ulElement = document.querySelector('#movies ul');
            let liElement = document.createElement('li');

            let spanElement = document.createElement('span');
            spanElement.textContent = name;

            let strongElement = document.createElement('strong');
            strongElement.textContent = `Hall: ${hall}`;

            let divElement = document.createElement('div');

            let priceElement = document.createElement('strong');
            priceElement.textContent = price;

            let ticketSoldElement = document.createElement('input');
            ticketSoldElement.setAttribute('placeholder', 'Tickets Sold');

            let arhiveButton = document.createElement('button');
            arhiveButton.textContent = 'Archive';

            arhiveButton.addEventListener('click', arhivateElement);

            divElement.appendChild(priceElement);
            divElement.appendChild(ticketSoldElement);
            divElement.appendChild(arhiveButton);

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(divElement);

            ulElement.appendChild(liElement);

            containerElement[0].value = '';
            containerElement[1].value = '';
            containerElement[2].value = '';
        }
    }

    function arhivateElement(e) {
        let currentElement = e.target.parentElement.parentElement;
        let name = currentElement.querySelector('span').textContent;
        let ticketsSold = currentElement.querySelector('div input').value;
        let ticketsPrice = currentElement.querySelector('div strong').textContent;

        if (ticketsSold !== '' && !isNaN(Number(ticketsSold))) {

            let strongElement = currentElement.querySelector('strong');
            let totalPrice = (Number(ticketsSold) * Number(ticketsPrice));

            strongElement.textContent = `Total amount: ${totalPrice.toFixed(2)}`;
            let rightDiv = currentElement.querySelector('div');
            rightDiv.remove();

            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', delitingItem);

            currentElement.appendChild(deleteBtn);

            let ulElement = document.querySelector('#archive ul');
            ulElement.appendChild(currentElement);
            
        }
    }

    function delitingItem(e) {
        let currElement = e.currentTarget.parentElement;
        currElement.remove();
    }

    function clearArhive() {
        let liElement = document.querySelectorAll('#archive ul li');
        let arrList = Array.from(liElement);
        arrList.forEach(x => x.remove());
    }
}