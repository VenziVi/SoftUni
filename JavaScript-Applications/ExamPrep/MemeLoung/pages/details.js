import { deleteRecord, getItemById } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"

const detailsTemp = (info, isOwner, id) => html`
<!-- Details Meme Page (for guests and logged users) -->
<section id="meme-details">
    <h1>Meme Title: ${info.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${info.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${info.description}
            </p>
            ${isOwner ? html`
            <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
            <a class="button warning" href="/edit/${id}">Edit</a>
            <button id="delBtn" class="button danger">Delete</button>`
            : ''}
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const userId = localStorage.getItem('userId');
    const info = await getItemById(id);
    ctx.render(detailsTemp(info, userId == info._ownerId, id));

    if (userId == info._ownerId) {

        const deleteBtn = document.querySelector('#delBtn');
        deleteBtn.addEventListener('click', async () => {
            const confirmed = confirm('Are you shure!');
            if (confirmed) {
                await deleteRecord(id);
                ctx.page.redirect('/allMeme');
            }
        })
    }
}