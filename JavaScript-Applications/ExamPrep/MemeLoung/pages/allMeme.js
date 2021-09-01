import { getMemes } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const allMemeTemp = (data) => html`
 <!-- All Memes Page ( for Guests and Users )-->
        <section id="meme-feed">
            <h1>All Memes</h1>
            <div id="memes">
                ${data.length > 0 ? html`
				<!-- Display : All memes in database ( If any ) -->
                ${data.map(m => currMemeTemp(m))};`
                : html`
				<!-- Display : If there are no memes in database -->
				<p class="no-memes">No memes in database.</p>`
                }
			</div>
        </section>`;

const currMemeTemp = (currMeme) => html`
<div class="meme">
<div class="card">
    <div class="info">
        <p class="meme-title">${currMeme.title}</p>
        <img class="meme-image" alt="meme-img" src=${currMeme.imageUrl}>
    </div>
    
    <div id="data-buttons">
        <a class="button" href="/details/${currMeme._id}">Details</a>
    </div>
    
</div>
</div>`;

export async function allMemePage(ctx) {
    let data = await getMemes();
    ctx.render(allMemeTemp(data));
}