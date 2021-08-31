import { logout } from "../api/api.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const navTemp = (user, onLogout) => html`
<header>
<nav>
    <a class="active" href="/">Home</a>
    <a href="/listings">All Listings</a>
    <a href="/search/query">By Year</a>
    ${user == null ? html`
    <!-- Guest users -->
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`
    : html`
    <!-- Logged users -->
    <div id="profile">
        <a>Welcome ${user}</a>
        <a href="/profile">My Listings</a>
        <a href="/create">Create Listing</a>
        <a @click=${onLogout} href="javascript:void(0)">Logout</a>
    </div>`}
</nav>
</header>`;

export async function navPage(ctx, next) {
    const user = localStorage.getItem('username');
    ctx.render(navTemp(user, onLogout));
    next();

    async function onLogout() {
        await logout();
        ctx.page.redirect('/');
    }
}