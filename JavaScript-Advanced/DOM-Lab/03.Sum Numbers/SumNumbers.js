function calc() {
    let num1Value = document.getElementById('num1');
    let num2Value = document.getElementById('num2');
    let result = Number(num1Value.value) + Number(num2Value.value);
    let getResultElemnt = document.getElementById('sum');
    getResultElemnt.value = result;
    num1Value.value = '';
    num2Value.value = ''; 
}
