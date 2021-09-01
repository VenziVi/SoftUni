import { createMeme } from "../api/data.js";
import { notify } from "../notification.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const createMemeTemp = (onSubmit) => html`
        <section id="create-meme">
            <form @submit=${onSubmit} id="create-form">
                <div class="container">
                    <h1>Create Meme</h1>
                    <label for="title">Title</label>
                    <input id="title" type="text" placeholder="Enter Title" name="title">
                    <label for="description">Description</label>
                    <textarea id="description" placeholder="Enter Description" name="description"></textarea>
                    <label for="imageUrl">Meme Image</label>
                    <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
                    <input type="submit" class="registerbtn button" value="Create Meme">
                </div>
            </form>
        </section>`;

export async function createMemePage(ctx) {
    ctx.render(createMemeTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formaData = new FormData(e.target);
        const title = formaData.get('title').trim();
        const description = formaData.get('description').trim();
        const imageUrl = formaData.get('imageUrl').trim();

        try {

            if (!title || !description || !imageUrl) {
                throw new Error('All fields are required!');
            }

            await createMeme({ title, description, imageUrl });
            ctx.page.redirect('/allMeme');

        } catch (err) {
            notify(err.message);
        }
    }
}