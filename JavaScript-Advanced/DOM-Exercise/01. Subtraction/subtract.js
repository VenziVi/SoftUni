function subtract() {
    let firstNum = document.querySelector('#firstNumber').value;
    let secondNum = document.querySelector('#secondNumber').value;
    let result = Number(firstNum) - Number(secondNum);
    let resultElement = document.querySelector('#result');
    resultElement.textContent = result;
}