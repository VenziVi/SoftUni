import { deleteRecord, getItemById } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const detailsTemp = (idea, isOwner, belIdea) => html`
<div class="container home some">
    <img class="det-img" src=${idea.img} />
    <div class="desc">
        <h2 class="display-5">${idea.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${idea.description}</p>
    </div>
    <div class="text-center">
        ${isOwner ? html`
        <a @click=${belIdea} class="btn detb" href="javascript:void(0)">Delete</a>`
        : ''}
    </div>
</div>`;

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const userId = localStorage.getItem('userId');
    const idea = await getItemById(id);
    ctx.render(detailsTemp(idea, userId == idea._ownerId, belIdea));

    async function belIdea() {
        const confirmation = confirm('Are you shure!');
        if (confirmation) {
            await deleteRecord(id);
            ctx.page.redirect('/dashboard');    
        }
    }
}