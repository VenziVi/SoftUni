function create(words) {
   let divElement = document.querySelector('#content');

   for (const str of words) {
      let createDiv = document.createElement('div');
      let paragaraph = document.createElement('p');
      paragaraph.textContent = str;
      paragaraph.style.display = 'none';

      createDiv.appendChild(paragaraph);
      divElement.appendChild(createDiv);
   }

   let divEventElement = document.querySelectorAll('#content div');
   let divArr = Array.from(divEventElement);

   for (const div of divArr) {
      div.addEventListener('click', () => {
      div.firstChild.style.display = 'block';
      })
   }
}