import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";

import { allMemePage } from "./pages/allMeme.js";
import { homePage } from "./pages/home.js";
import { loginPage } from "./pages/login.js";
import { registerPage } from "./pages/register.js";
import { logout } from "./api/data.js";
import { createMemePage } from "./pages/createMeme.js";
import { detailsPage } from "./pages/details.js";
import { editpage } from "./pages/edit.js";
import { profilePage } from "./pages/profile.js";

const main = document.querySelector('main');

setNav();

page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/createMeme', decorateContext, createMemePage);
page('/allMeme', decorateContext, allMemePage);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editpage);
page('/profile', decorateContext, profilePage);

page.start();


    let logoutBtn = document.querySelector('#logoutBtn');
    logoutBtn.addEventListener('click', async () => {
        await logout();
        setNav();
        page.redirect('/');
    });


function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setNav = setNav;
    next();
}

function setNav() {
    let token = localStorage.getItem('authToken');
    let userEmail = localStorage.getItem('email');
    if (token != null) {
        document.querySelector('.user').style.display = '';
        document.querySelector('.guest').style.display = 'none';
        document.querySelector('.user span').textContent = `Welcome, ${userEmail}`;
    }else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = '';
    }
}