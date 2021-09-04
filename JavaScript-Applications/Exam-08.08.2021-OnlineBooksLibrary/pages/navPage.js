import { logout } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"

const navTemp = (email, logoutFunc) => html`
<nav class="navbar">
<section class="navbar-dashboard">
    <a href="/dashboard">Dashboard</a>
    ${email == null ? html`
    <!-- Guest users -->
    <div id="guest">
        <a class="button" href="/login">Login</a>
        <a class="button" href="/register">Register</a>
    </div>`
    : html`
    <!-- Logged-in users -->
    <div id="user">
        <span>Welcome, ${email}</span>
        <a class="button" href="/my-books">My Books</a>
        <a class="button" href="/create">Add Book</a>
        <a @click=${logoutFunc} class="button" href="javascript:void(0)">Logout</a>
    </div>`}
</section>
</nav>`;

export async function navPage(ctx, next) {
    const email = localStorage.getItem('email');
    ctx.render(navTemp(email, logoutFunc));
    next();

    async function logoutFunc() {
        const response = await logout();
        if (response.ok) {
            ctx.page.redirect('/dashboard');
        }
    }
}