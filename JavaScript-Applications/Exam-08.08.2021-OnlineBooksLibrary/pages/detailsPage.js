import { deleteItem, getItemById } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"

const detailsTemp = (book, isOwner, user, onDelete, totalLikes, onLike) => html`
<section id="details-page" class="details">
<div class="book-information">
    <h3>${book.title}</h3>
    <p class="type">Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl}></p>
    <div class="actions">
        ${isOwner ? html`
        <!-- Edit/Delete buttons ( Only for creator of this book )  -->
        <a class="button" href="/edit/${book._id}">Edit</a>
        <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>`
        : ''}

        <!-- Bonus -->
        ${user != null && !isOwner ? html`
        <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
        <a @click=${onLike} class="button" href="/details/${book._id}">Like</a>`
        : ''}
        <!-- ( for Guests and Users )  -->
        <div class="likes">
            <img class="hearts" src="/images/heart.png">
            <span id="total-likes">Likes: ${totalLikes}</span>
        </div>
        <!-- Bonus -->
    </div>
</div>
<div class="book-description">
    <h3>Description:</h3>
    <p>${book.description}</p>
</div>
</section>`;

export async function detailsPage(ctx) {
    
    const userId = localStorage.getItem('userId');
    const bookId = ctx.params.id;
    const book = await getItemById(bookId)

    const likesResponse = await fetch(`http://localhost:3030/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
    const totalLikes = await likesResponse.json();
    ctx.render(detailsTemp(book, userId == book._ownerId, userId, onDelete, totalLikes, onLike));

    async function onDelete() {
        const confirmed = confirm('Are you sure!');

        if (confirmed) {
            const response = await deleteItem(book._id);
            ctx.page.redirect('/dashboard');
        }
    }

    async function onLike() {
       const bookId = book._id
        const likeResponce = await fetch(`http://localhost:3030/data/likes`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': localStorage.getItem('authToken')
            },
            body: JSON.stringify({bookId})
        })
        await likeResponce.json();
    }
}