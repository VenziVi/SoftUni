import { html } from "./../node_modules/lit-html/lit-html.js";
import { register } from "../api/data.js";


const registerTemp = (onSubmit, errorMsg, invalidEmail, InvalidPassword, invalidRePass) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            ${errorMsg ? html`<div class="form-group">
                <p>${errorMsg}</p>
            </div>` : ''}
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class=${'form-control' + (invalidEmail ? ' is-invalid' : '')} id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class=${'form-control' + (InvalidPassword ? ' is-invalid' : '')} id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class=${'form-control' + (invalidRePass ? ' is-invalid' : '')} id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`;

export async function registerPage(ctx) {

    ctx.render(registerTemp(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();
        const formData = new FormData(e.target);
        const email = formData.get('email').trim();
        const password = formData.get('password').trim();
        const rePass = formData.get('rePass').trim();
    
        if (!email || !password || !rePass) {
            return ctx.render(registerTemp(onSubmit, 'All fields are required!', email == '', password == '', rePass == ''));
        }
        if (password != rePass) {
            return ctx.render(registerTemp(onSubmit, 'Passwords don\'t match!', false, true, true));
        }
    
        await register(email, password);

        ctx.setNav();
        ctx.page.redirect('/');
    }
}