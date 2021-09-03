import { createIdea } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const createTemp = (onSubmit) => html`
<div class="container home wrapper  my-md-5 pl-md-5">
<div class=" d-md-flex flex-mb-equal ">
    <div class="col-md-6">
        <img class="responsive-ideas create" src="./images/creativity_painted_face.jpg" alt="">
    </div>
    <form @submit=${onSubmit} class="form-idea col-md-5" action="#/create" method="post">
        <div class="text-center mb-4">
            <h1 class="h3 mb-3 font-weight-normal">Share Your Idea</h1>
        </div>
        <div class="form-label-group">
            <label for="ideaTitle">Title</label>
            <input type="text" id="title" name="title" class="form-control" placeholder="What is your idea?"
                required="" autofocus="">
        </div>
        <div class="form-label-group">
            <label for="ideaDescription">Description</label>
            <textarea id="description" type="text" name="description" class="form-control" placeholder="Description"
                required=""></textarea>
        </div>
        <div class="form-label-group">
            <label for="inputURL">Add Image</label>
            <input type="text" id="imageURl" name="imageURL" class="form-control" placeholder="Image URL"
                required="">

        </div>
        <button class="btn btn-lg btn-dark btn-block" type="submit">Create</button>

        <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2021.</p>
    </form>
</div>
</div>`;


export async function createPage(ctx) {
    ctx.render(createTemp(onSubmit));
    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const title = form.get('title').trim();
        const description = form.get('description').trim();
        const img = form.get('imageURL').trim();

        if (title.length < 6 || description.length < 10 || img.length < 5) {
            return alert('All fields are required!');
        }

        const result = await createIdea({
            title,
            description,
            img
        });

        ctx.page.redirect('/dashboard');
    }
}