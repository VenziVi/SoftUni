import { editRecord, getItemById } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"
import { notify } from "../notification.js";

const editTemp = (info, onSubmit) => html`
<section id="edit-meme">
    <form @submit=${onSubmit} id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${info.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"
                .value=${info.description}></textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${info.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

export async function editpage(ctx) {
    const id = ctx.params.id;
    const info = await getItemById(id);
    ctx.render(editTemp(info, onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const title = form.get('title').trim();
        const description = form.get('description').trim();
        const imageUrl = form.get('imageUrl').trim();

        try{
        if (!title || !description || !imageUrl) {
            throw new Error ('All fields are required!');
        }

        const result = await editRecord(info._id, {title, description, imageUrl}); 
        console.log(result);
        ctx.page.redirect(`/details/${id}`);

        } catch (err) {
            notify(err.message)
        }
    }
}