function search() {
   let listItems = document.querySelectorAll('#towns > li')
   let input = document.querySelector('input').value
   let result = document.getElementById('result')
   let sum = 0

   if (input.length > 0) {
      for (const li of listItems) {
         if (li.textContent.includes(input)) {
            li.style.fontWeight = 'bold'
            li.style.textDecoration = 'underline'
            sum++
         } else {
            li.style.fontWeight = ''
            li.style.textDecoration = ''
         }
      }
      result.textContent = `${sum} matches found`;

   } else {
      for (const li of listItems) {
         li.style.fontWeight = ''
         li.style.textDecoration = ''
      }
      result.textContent = '';
   }
}

