import { deleteRecord, getItemById } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const detailsTemp = (car, isOwner, onDelete) => html`
<section id="listing-details">
<h1>Details</h1>
<div class="details-info">
    <img src=${car.imageUrl}>
    <hr>
    <ul class="listing-props">
        <li><span>Brand:</span>${car.brand}</li>
        <li><span>Model:</span>${car.model}</li>
        <li><span>Year:</span>${car.year}</li>
        <li><span>Price:</span>${car.price}$</li>
    </ul>

    <p class="description-para">${car.description}</p>

    ${isOwner ? html`
    <div class="listings-buttons">
        <a href="/edit/${car._id}" class="button-list">Edit</a>
        <a @click=${onDelete} href="javascript:void(0)" class="button-list">Delete</a>
    </div>`
    : '' }
</div>
</section>`;

export async function detailsPage(ctx) {
    const userId = localStorage.getItem('userId');
    const id = ctx.params.id;
    const car = await getItemById(id);
    ctx.render(detailsTemp(car, userId == car._ownerId, onDelete));

    async function onDelete() {
        await deleteRecord(id);
        ctx.page.redirect('/listings');
    }
}