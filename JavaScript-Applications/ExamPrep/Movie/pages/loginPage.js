import { html } from "./../node_modules/lit-html/lit-html.js";

const loginTemp = (onSubmit) => html`
<section id="form-login">
<form @submit=${onSubmit} class="text-center border border-light p-5" action="" method="">
    <div class="form-group">
        <label for="email">Email</label>
        <input type="email" class="form-control" placeholder="Email" name="email" value="">
    </div>
    <div class="form-group">
        <label for="password">Password</label>
        <input type="password" class="form-control" placeholder="Password" name="password" value="">
    </div>

    <button type="submit" class="btn btn-primary">Login</button>
</form>
</section>`;

export async function loginPage(ctx) {
    ctx.render(loginTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const form = new FormData(e.target);
        const email = form.get('email');
        const password = form.get('password');

        if (!email || !password) {
            return alert('All fields are required!');
        }

        const response = await fetch('http://localhost:3030/users/login', {
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