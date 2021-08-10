function getArticleGenerator(articles) { 
    let  containerElement = document.querySelector('#content'); 
   
    return function () {
         if (articles.length > 0) {
            let artElement = document.createElement('article');
            artElement.textContent = articles.shift();
            containerElement.appendChild(artElement);
            } 
        }
}
