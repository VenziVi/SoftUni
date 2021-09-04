import { getAll } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"

const dashboardTemp = (data) => html`
<section id="dashboard-page" class="dashboard">
<h1>Dashboard</h1>
${data.length > 0 ? html`
<!-- Display ul: with list-items for All books (If any) -->
<ul class="other-books-list">
    ${data.map(b => bookTemp(b))}
</ul>`
: html`
<!-- Display paragraph: If there are no books in the database -->
<p class="no-books">No books in database!</p>`}
</section>;`

const bookTemp = (book) => html`
<li class="otherBooks">
<h3>${book.title}</h3>
<p>Type: ${book.type}</p>
<p class="img"><img src=${book.imageUrl}></p>
<a class="button" href="/details/${book._id}">Details</a>
</li>`;

export async function dashboardPage(ctx) {
    const data = await getAll();
    ctx.render(dashboardTemp(data));
}