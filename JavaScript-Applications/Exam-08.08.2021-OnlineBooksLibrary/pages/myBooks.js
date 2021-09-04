import { getMyItem } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"

const profileTemp = (books) => html`<section id="my-books-page" class="my-books">
<h1>My Books</h1>
${books.length > 0 ? html`
<!-- Display ul: with list-items for every user's books (if any) -->
<ul class="my-books-list">
   ${books.map(b => bookTemp(b))}
</ul>`
: html`
<!-- Display paragraph: If the user doesn't have his own books  -->
<p class="no-books">No books in database!</p>`}
</section>`;

const bookTemp = (book) => html`
<li class="otherBooks">
<h3>${book.title}</h3>
<p>Type: ${book.type}</p>
<p class="img"><img src=${book.imageUrl}></p>
<a class="button" href="/details/${book._id}">Details</a>
</li>`;

export async function profilePage(ctx) {
    const memes = await getMyItem();
    ctx.render(profileTemp(memes));
}