import { getIdeas } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const dashboardTemp = (data) => html`
<div id="dashboard-holder">
    ${data.length > 0 ? html`
        ${data.map(i => ideaTemp(i))}`
        : html`
    <h1>No ideas yet! Be the first one :)</h1>`}
</div>`;

const ideaTemp = (idea) => html`
<div class="card overflow-hidden current-card details" style="width: 20rem; height: 18rem;">
<div class="card-body">
    <p class="card-text">${idea.title}</p>
</div>
<img class="card-image" src=${idea.img} alt="Card image cap">
<a class="btn" href="/details/${idea._id}">Details</a>
</div>`;

export async function dashboardPage(ctx) {
    const data = await getIdeas();
    ctx.render(dashboardTemp(data));
}