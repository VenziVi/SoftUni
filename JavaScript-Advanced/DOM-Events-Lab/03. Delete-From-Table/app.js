function deleteByEmail() {
    let inputElement = document.getElementsByTagName('input')[0];
    let tableElements = document.querySelectorAll('#customers td:nth-child(2)');
    let resultElement = document.getElementById('result');
    
    let tableArray = Array.from(tableElements);
    let result ='Not found.';

    for (const td of tableArray) {
        if (td.textContent === inputElement.value) {
            td.parentNode.remove();
            result = 'Deleted.';
        }
    }

    inputElement.value = '';
    resultElement.textContent = result;
}