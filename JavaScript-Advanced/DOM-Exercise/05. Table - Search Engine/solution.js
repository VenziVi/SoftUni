function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let inputElement = document.querySelector('#searchField').value;
      let elementsList = document.querySelectorAll('.container td');
      let rowList = document.querySelectorAll('.container tr')
      let listOfRows = Array.from(rowList);
      listOfRows.map(x => x.className = '');
      for (const td of elementsList) {
         if (td.textContent.includes(inputElement)) {
            for (const tr of rowList) {
               if (tr.textContent.includes(td.textContent)) {
                  tr.className = 'select';
               }
            }
         }
      }
      inputElement = '';
   }
}