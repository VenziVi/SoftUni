import { login } from "../api/data.js";
import { html } from "../node_modules/lit-html/lit-html.js"

const loginTemp = (onSubmit) => html`
<section id="login-page" class="login">
<form @submit=${onSubmit} id="login-form" action="" method="">
    <fieldset>
        <legend>Login Form</legend>
        <p class="field">
            <label for="email">Email</label>
            <span class="input">
                <input type="text" name="email" id="email" placeholder="Email">
            </span>
        </p>
        <p class="field">
            <label for="password">Password</label>
            <span class="input">
                <input type="password" name="password" id="password" placeholder="Password">
            </span>
        </p>
        <input class="button submit" type="submit" value="Login">
    </fieldset>
</form>
</section>`;

export async function loginPage(ctx) {
    ctx.render(loginTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const email = form.get('email').trim();
        const password = form.get('password').trim();

        if (!email || !password) {
            return alert('error');
        }

        await login(email, password);
        ctx.page.redirect('/dashboard');
    }
}