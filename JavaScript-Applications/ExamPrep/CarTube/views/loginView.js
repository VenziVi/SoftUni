import { login } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const loginTemp = (onSubmit) => html`
<section id="login">
<div class="container">
    <form @submit=${onSubmit} id="login-form" action="#" method="post">
        <h1>Login</h1>
        <p>Please enter your credentials.</p>
        <hr>

        <p>Username</p>
        <input placeholder="Enter Username" name="username" type="text">

        <p>Password</p>
        <input type="password" placeholder="Enter Password" name="password">
        <input type="submit" class="registerbtn" value="Login">
    </form>
    <div class="signin">
        <p>Dont have an account?
            <a href="/register">Sign up</a>.
        </p>
    </div>
</div>
</section>`;

export async function loginPage(ctx) {
    ctx.render(loginTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const username = form.get('username').trim();
        const password = form.get('password').trim();

        if (!username || !password) {
            return alert('error');
        }

        await login(username, password);
        ctx.page.redirect('/listings');
    }
}