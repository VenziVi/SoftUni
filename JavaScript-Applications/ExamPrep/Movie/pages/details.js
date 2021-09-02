import { html } from "./../node_modules/lit-html/lit-html.js";

const detailsTemp = (movie, likes, delItem, likeMovie) => html`
<section id="movie-example">
    <div class="container">
        <div class="row bg-light text-dark">
            <h1>Movie title: ${movie.title}</h1>

            <div class="col-md-8">
                <img class="img-thumbnail" src=${movie.img} alt="Movie">
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3 ">Movie Description</h3>
                <p>${movie.description}</p>
                <a @click=${delItem} id="delBtn" class="btn btn-danger" href="javascript:void(0)">Delete</a>
                <a id="editbtn" class="btn btn-warning only-creator" href="/edit/${movie._id}">Edit</a>
                <a @click=${likeMovie} id="movie-likes" class="btn btn-primary" href="/details/${movie._id}">Like</a>
                <span class="enrolled-span">Liked ${likes}</span>
            </div>
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const movieId = ctx.params.id;
    const userId = localStorage.getItem('userId');
    const response = await fetch(`http://localhost:3030/data/movies/${movieId}`)
    const movie = await response.json();

    const likeResponse = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);
    const likes = await likeResponse.json();


    ctx.render(detailsTemp(movie, likes, delItem, likeMovie));

    if (userId != movie._ownerId) {
        document.getElementById('delBtn').style.display = 'none';
        document.getElementById('editbtn').style.display = 'none';
    }
    if (userId == movie._ownerId || userId == null){
        document.getElementById('movie-likes').style.display = 'none';
    }

    async function delItem() {
        const confirmed = confirm('Are you shure you want to delete this movie?');
        if (confirmed) {

            await fetch(`http://localhost:3030/data/movies/${movieId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': localStorage.getItem('authToken')
                }
            });
            ctx.page.redirect('/');
        }
    }

    async function likeMovie() {
        await fetch(`http://localhost:3030/data/likes`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': localStorage.getItem('authToken')
                },
                body: JSON.stringify({movieId})
            });
    }
}


