import { html } from "./../node_modules/lit-html/lit-html.js";

const addMovieTemp = (onSubmit) => html` 
<section id="add-movie">
<form @submit=${onSubmit}class="text-center border border-light p-5" action="#" method="">
    <h1>Add Movie</h1>
    <div class="form-group">
        <label for="title">Movie Title</label>
        <input type="text" class="form-control" placeholder="Title" name="title" value="">
    </div>
    <div class="form-group">
        <label for="description">Movie Description</label>
        <textarea class="form-control" placeholder="Description" name="description"></textarea>
    </div>
    <div class="form-group">
        <label for="imageUrl">Image url</label>
        <input type="text" class="form-control" placeholder="Image Url" name="imageUrl" value="">
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
</section>`;

export async function addMoviePage(ctx) {
    ctx.render(addMovieTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const title = form.get('title');
        const description = form.get('description');
        const img = form.get('imageUrl');

        if (!title || !description || !img) {
            return alert('All fields are requiured!');
        }

        const response = await fetch('http://localhost:3030/data/movies', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': localStorage.getItem('authToken')
            },
            body: JSON.stringify({
                title,
                description,
                img
            })
        })

        const data = await response.json();
        ctx.page.redirect('/');
    }
}