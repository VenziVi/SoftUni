function addItem() {
    let inputElement = document.getElementById('newItemText');
    let ulElement = document.getElementById('items');

    let newLiElement = document.createElement('li');
    newLiElement.textContent = inputElement.value;

    let deleteButton = document.createElement('a');
    deleteButton.setAttribute('href', '#');
    deleteButton.textContent = '[Delete]';

    deleteButton.addEventListener('click', (e) =>{
        e.currentTarget.parentNode.remove();
    })

    newLiElement.appendChild(deleteButton);
    ulElement.appendChild(newLiElement);
    inputElement.value = '';
}