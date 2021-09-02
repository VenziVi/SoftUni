import { html } from "./../node_modules/lit-html/lit-html.js";

const registerTemp = (onSubmit) => html`
<section id="form-sign-up">
<form @submit=${onSubmit} class="text-center border border-light p-5" action="#" method="post">
    <div class="form-group">
        <label for="email">Email</label>
        <input type="email" class="form-control" placeholder="Email" name="email" value="">
    </div>
    <div class="form-group">
        <label for="password">Password</label>
        <input type="password" class="form-control" placeholder="Password" name="password" value="">
    </div>

    <div class="form-group">
        <label for="repeatPassword">Repeat Password</label>
        <input type="password" class="form-control" placeholder="Repeat-Password" name="repeatPassword" value="">
    </div>

    <button type="submit" class="btn btn-primary">Register</button>
</form>
</section>`;

export async function registerPage(ctx) {
    ctx.render(registerTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const email = form.get('email');
        const password = form.get('password');
        const repeatPassword = form.get('repeatPassword');

        if (!email || !password || !repeatPassword) {
            return alert('All fields are required!');
        }
        if (password != repeatPassword) {
            return alert('Passwords should match!');
        }

        const response = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            body: JSON.stringify({
                email,
                password
            })
        })

        const data = await response.json();
        localStorage.setItem('username', data.email);
        localStorage.setItem('authToken', data.accessToken);
        localStorage.setItem('userId', data._id);

        ctx.setNav();
        ctx.page.redirect('/');
    }
}