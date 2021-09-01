import { getMyMemes } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"

const profileTemp = (memes, email, user, gender) => html`  
<section id="user-profile-page" class="user-profile">
<article class="user-info">
    <img id="user-avatar-url" alt="user-profile" src="/images/${gender}.png">
    <div class="user-content">
        <p>Username: ${user}</p>
        <p>Email: ${email}</p>
        <p>My memes count: ${memes.length}</p>
    </div>
</article>
<h1 id="user-listings-title">User Memes</h1>
<div class="user-meme-listings">
${memes.length > 0 ? html`
    <!-- Display : All created memes by this user (If any) --> 
    ${memes.map(m => memeTemp(m))}`
    : html`
    <!-- Display : If user doesn't have own memes  --> 
    <p class="no-memes">No memes in database.</p>`}
</div>
</section>`;

const memeTemp = (meme) => html`
<div class="user-meme">
<p class="user-meme-title">${meme.title}</p>
<img class="userProfileImage" alt="meme-img" src=${meme.imageUrl}>
<a class="button" href="/details/${meme._id}">Details</a>
</div>`;


export async function profilePage(ctx) {
    const email = localStorage.getItem('email');
    const user = localStorage.getItem('username');
    const gender = localStorage.getItem('gender');
    const memes = await getMyMemes();
    ctx.render(profileTemp(memes, email, user, gender));
}