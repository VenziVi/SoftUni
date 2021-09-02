import { html } from "./../node_modules/lit-html/lit-html.js";

const navtemp = () => html`
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
<a class="navbar-brand text-light" href="#">Movies</a>
<ul class="navbar-nav ml-auto ">
    <li class="nav-item">
        <a class="nav-link">Welcome, email</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#">Logout</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#">Login</a>
    </li>
    <li class="nav-item">
        <a class="nav-link" href="#">Register</a>
    </li>
</ul>
</nav>`;

export function nav(ctx, next) {
    ctx.render(navtemp());
    next();
}