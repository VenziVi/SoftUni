import { render } from "./node_modules/lit-html/lit-html.js"
import page from "./node_modules/page/page.mjs"

import { logout } from "./api/data.js";
import { createPage } from "./views/create.js";
import { dashboardPage } from "./views/dashboard.js";
import { detailsPage } from "./views/details.js";
import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";

const main = document.getElementById('main-containt');

setNav();
page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/dashboard', decorateContext, dashboardPage);
page('/details/:id', decorateContext, detailsPage);
page('/create', decorateContext, createPage);

page.start();


function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setNav = setNav;
    next();
}

const logoutBtn = document.getElementById('logout');
logoutBtn.addEventListener('click', async () => {
    await logout();
    setNav();
    page.redirect('/');
})

function setNav() {
    const username = localStorage.getItem('email');
    if (username != null) {
        document.getElementById('login').style.display = 'none';
        document.getElementById('register').style.display = 'none';
        document.getElementById('create').style.display = 'block';
        document.getElementById('logout').style.display = 'block';
    }else {
        document.getElementById('login').style.display = 'block';
        document.getElementById('register').style.display = 'block';
        document.getElementById('create').style.display = 'none';
        document.getElementById('logout').style.display = 'none';
    }
}