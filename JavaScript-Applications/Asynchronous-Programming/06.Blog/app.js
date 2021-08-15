function attachEvents() {
    let loadBtn = document.getElementById('btnLoadPosts');
    let postBtn = document.getElementById('btnViewPost');
    let infoCont = [];
  
    loadBtn.addEventListener('click', ()=> {
        (async function loadPosts() {
            let responce = await fetch('http://localhost:3030/jsonstore/blog/posts');
            let posts = await responce.json();
            let postsElement = document.getElementById('posts');
            Object.values(posts).forEach(x => {
                let optionEl = document.createElement('option');
                optionEl.setAttribute('value', x.id);
                optionEl.textContent = x.title;
                postsElement.appendChild(optionEl);
                infoCont.push({id: x.id, title: x.title, body: x.body})
            })   
        })()
    });

    postBtn.addEventListener('click', () => {
        let postId = document.getElementById('posts').value;

        let liArr = Array.from(document.querySelectorAll('#post-comments li'));
        if (liArr.length !== 0) {
            liArr.forEach(li => li.remove());
        }

        (async function loadComments() {
            let responce = await fetch(`http://localhost:3030/jsonstore/blog/comments`);
            let comment = await responce.json();
            let ulComment = document.getElementById('post-comments');

            Object.keys(comment).forEach(x => {
                let currId = comment[x].postId;
                if (currId === postId) {
                    let commentId = comment[x].id;
                    let liComment = document.createElement('li');
                    liComment.setAttribute('value', commentId);
                    liComment.textContent = comment[x].text;
                    ulComment.appendChild(liComment);
                    console.log(comment[x].text);

                }
            })
            
            let h1Title = document.getElementById('post-title');
            let postTitle = '';
            let postBody ='';
            for (const i of infoCont) {
                if (i.id === postId) {
                    postTitle = i.title;
                    postBody = i.body;
                    break;
                }
            }
            h1Title.textContent = postTitle;
            let ulBody = document.getElementById('post-body');
            ulBody.textContent = postBody;
        })();
    })
}

attachEvents();