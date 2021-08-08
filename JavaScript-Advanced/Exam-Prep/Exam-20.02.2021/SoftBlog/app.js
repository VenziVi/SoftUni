function solve() {
   let createBtnElement = document.getElementsByClassName('btn create')[0];
   

   createBtnElement.addEventListener('click', (e) => {
      e.preventDefault();

      let authorElement = document.getElementById('creator');
      let titleElement = document.getElementById('title');
      let categoryElement = document.getElementById('category');
      let contentElement = document.getElementById('content');

      if (authorElement.value === '' || titleElement.value === '' ||
         categoryElement.value === '' || contentElement.value === '') {
         return;
      }

      let articleEl = document.createElement('article');

      let h1Element = document.createElement('h1');
      h1Element.textContent = titleElement.value;

      let pCategoryEl = document.createElement('p');
      pCategoryEl.textContent = 'Category:'
      let strongCategoryEl = document.createElement('strong');
      strongCategoryEl.textContent = ` ${categoryElement.value}`;
      pCategoryEl.appendChild(strongCategoryEl);

      let pCcreatorEl = document.createElement('p');
      pCcreatorEl.textContent = 'Creator:'
      let strongCreatorEl = document.createElement('strong');
      strongCreatorEl.textContent = ` ${authorElement.value}`;
      pCcreatorEl.appendChild(strongCreatorEl);

      let pContentEl = document.createElement('p');
      pContentEl.textContent = contentElement.value;

      let divBtnEl = document.createElement('div');
      divBtnEl.classList.add('buttons');
      let delBtn = document.createElement('button');
      delBtn.classList.add('btn');
      delBtn.classList.add('delete');
      delBtn.textContent = 'Delete';
      let archBtn = document.createElement('button');
      archBtn.classList.add('btn');
      archBtn.classList.add('archive');
      archBtn.textContent = 'Archive';
      divBtnEl.appendChild(delBtn);
      divBtnEl.appendChild(archBtn);

      articleEl.appendChild(h1Element);
      articleEl.appendChild(pCategoryEl);
      articleEl.appendChild(pCcreatorEl);
      articleEl.appendChild(pContentEl);
      articleEl.appendChild(divBtnEl);

      let postEl = document.getElementsByTagName('section')[1];
      postEl.appendChild(articleEl);

      // authorElement.value = '';
      // titleElement.value = '';
      // categoryElement.value = '';
      // contentElement.value = '';

      delBtn.addEventListener('click', (e) => {
         e.target.parentNode.parentNode.remove();
      });

      archBtn.addEventListener('click', (e) => {
         let title = e.target.parentElement.parentElement.querySelector('h1').textContent;
         e.target.parentNode.parentNode.remove();
   
         let newLi = document.createElement('li');
         newLi.textContent = title;
   
         let olParent = document.querySelector('section.archive-section>ol');
         let allLis = [...document.querySelectorAll('section.archive-section>ol>li')];
   
         allLis.push(newLi);
   
         allLis = allLis.sort((a, b) => a.textContent.localeCompare(b.textContent));
   
         for (let i = 0; i < allLis.length; i++) {
            olParent.appendChild(allLis[i]);
         }
      })
   })
}
