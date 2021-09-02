import { html } from "./../node_modules/lit-html/lit-html.js";

const editTemp = (movie, onSubmit) => html`
<section id="edit-movie">
    <form @submit=${onSubmit} class="text-center border border-light p-5" action="#" method="">
        <h1>Edit Movie</h1>
        <div class="form-group">
            <label for="title">Movie Title</label>
            <input type="text" class="form-control" placeholder="Movie Title" .value=${movie.title} name="title">
        </div>
        <div class="form-group">
            <label for="description">Movie Description</label>
            <textarea class="form-control" placeholder="Movie Description..." name="description"
                .value=${movie.description}></textarea>
        </div>
        <div class="form-group">
            <label for="imageUrl">Image url</label>
            <input type="text" class="form-control" placeholder="Image Url" .value=${movie.img} name="imageUrl">
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
</section>`;

export async function editPage(ctx) {
    const currId = ctx.params.id;
    const response = await fetch(`http://localhost:3030/data/movies/${currId}`)
    const movie = await response.json();
    ctx.render(editTemp(movie, onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const title = form.get('title');
        const description = form.get('description');
        const imageUrl = form.get('imageUrl');

        if (!title || !description || !imageUrl) {
            return alert('All fields are required!');
        }

        const response = await fetch(`http://localhost:3030/data/movies/${currId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': localStorage.getItem('authToken')
            },
            body: JSON.stringify({
                title,
                description,
                imageUrl
            })
        })
        ctx.page.redirect(`/details/${currId}`);
    }
}