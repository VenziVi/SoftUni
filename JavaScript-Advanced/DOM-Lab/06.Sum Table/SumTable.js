function sumTable() {
    let NumElements = document.querySelectorAll('tr > td:nth-child(2)');
    let arr = Array.from(NumElements);
    let result = 0;
    for (let i = 0; i < arr.length - 1; i++) {
        result += Number(NumElements[i].textContent);
    }
    let resultElement = document.querySelector('#sum');
    resultElement.textContent = result;
}