function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue'); 
    let dropElement = document.getElementById('menu');

    let optionEL = document.createElement('option');
    optionEL.value = valueElement.value;
    optionEL.textContent = textElement.value;

    dropElement.appendChild(optionEL);

    textElement.value ='';
    valueElement.value = '';
}