function solve() {
  let inputElement = document.getElementById('input');
  let inputArray = inputElement.value.split('.').filter(x => x.length > 0).map(x => x + '.');
  let counter = 0;
  let result = '';
  for (let i = 0; i < inputArray.length; i++) {    
    if (counter == 0) {
      result += '<p>';
    }
    result += inputArray[i];
    counter++;
    if (counter == 3 || i == inputArray.length - 1) {
      result += '</p> \n';
      counter = 0;
    }
  }
  let resultElement = document.getElementById('output');
  resultElement.innerHTML = result;
}