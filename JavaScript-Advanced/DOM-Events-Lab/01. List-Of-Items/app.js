function addItem() {
    let inputElement = document.querySelector('#newItemText');
    let ulElement = document.querySelector('#items');
    let newLiElement = document.createElement('li');
    newLiElement.textContent = inputElement.value;
    ulElement.appendChild(newLiElement);
    inputElement.value = '';
}