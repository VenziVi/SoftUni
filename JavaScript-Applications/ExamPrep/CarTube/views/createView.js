import { createRecord } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const createTemp = (onSubmit) => html`
<section id="create-listing">
<div class="container">
    <form @submit=${onSubmit} id="create-form">
        <h1>Create Car Listing</h1>
        <p>Please fill in this form to create an listing.</p>
        <hr>

        <p>Car Brand</p>
        <input type="text" placeholder="Enter Car Brand" name="brand">

        <p>Car Model</p>
        <input type="text" placeholder="Enter Car Model" name="model">

        <p>Description</p>
        <input type="text" placeholder="Enter Description" name="description">

        <p>Car Year</p>
        <input type="number" placeholder="Enter Car Year" name="year">

        <p>Car Image</p>
        <input type="text" placeholder="Enter Car Image" name="imageUrl">

        <p>Car Price</p>
        <input type="number" placeholder="Enter Car Price" name="price">

        <hr>
        <input type="submit" class="registerbtn" value="Create Listing">
    </form>
</div>
</section>`;

export async function createPage(ctx) {
    ctx.render(createTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const brand = form.get('brand').trim();
        const model = form.get('model').trim();
        const description = form.get('description').trim();
        const year = Number(form.get('year').trim());
        const imageUrl = form.get('imageUrl').trim();
        const price = Number(form.get('price').trim());

        if (!brand || !model || !description || year < 0 || !imageUrl || price < 0) {
            return alert('error');
        }

        await createRecord({brand, model, description, year, imageUrl, price})
        ctx.page.redirect('/listings');
    }
}