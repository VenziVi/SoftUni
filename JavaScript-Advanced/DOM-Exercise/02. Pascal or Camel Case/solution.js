function solve() {
  let textElement = document.querySelector('#text').value;
  let typeElement = document.querySelector('#naming-convention').value;
  let resultElement = document.querySelector('#result');
  let result = '';

  if (typeElement === 'Camel Case') {
    result = camelize(textElement);
  } else if (typeElement === 'Pascal Case') {
    result = toPascalCase(textElement);
  } else {
    result = 'Error!';
  }

  function camelize(str) {
    return str.toLowerCase().split(' ').map((x, i) => i !== 0 ? x[0].toUpperCase() + x.slice(1) : x).join('');
  }

  function toPascalCase(string) {
    return string.toLowerCase().split(' ').map(x => x[0].toUpperCase() + x.slice(1)).join('');
  }

  resultElement.textContent = result;
}