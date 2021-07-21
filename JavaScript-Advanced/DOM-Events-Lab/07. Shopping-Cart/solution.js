function solve() {
   let addElement = document.querySelectorAll('.add-product');
   let boxElement = document.querySelector('textarea');
   let chekoutElement = document.querySelector('.checkout');

   let addArray = Array.from(addElement);
   let sum = 0;
   let productArray = [];

   for (const el of addArray) {
      el.addEventListener('click', (e => {
         let elementName = e.currentTarget.parentNode.parentNode.querySelector('.product-title').textContent;
         let elementPrice = Number(e.currentTarget.parentNode.parentNode.querySelector('.product-line-price').textContent);
         boxElement.textContent += `Added ${elementName} for ${elementPrice.toFixed(2)} to the cart.\n`;
         sum += elementPrice;
         if (!productArray.includes(elementName)) {       
            productArray.push(elementName);
         }
      }))
   }
   chekoutElement.addEventListener('click', checkout);

   function checkout(){
   boxElement.textContent += `You bought ${productArray.join(', ')} for ${sum.toFixed(2)}.`
   chekoutElement.removeEventListener('click', checkout)
   disableButtons();
   }

   function disableButtons() {
      addButons = Array.from(addElement);
      addButons.forEach(x => x.disabled = true);
   }
}