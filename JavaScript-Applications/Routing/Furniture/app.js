import { render } from "./node_modules/lit-html/lit-html.js";
import page from "./../node_modules/page/page.mjs";

import { createPage } from "./views/create.js";
import { dashboardPage } from "./views/dashboard.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { loginPage } from "./views/login.js";
import { furniturePage } from "./views/myFurniture.js";
import { registerPage } from "./views/register.js";
import { logout } from "./api/data.js"

const main = document.querySelector('.container');

page('/', decorateContext, dashboardPage);
page('/create', decorateContext, createPage);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);
page('/login', decorateContext, loginPage);
page('/my-furnitures', decorateContext, furniturePage);
page('/register', decorateContext, registerPage);

setNav();
page.start();

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    setNav();
    page.redirect('/');
})

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setNav = setNav;
    next();
}

function setNav() {
    const userId = localStorage.getItem('userId');
    if (userId != null) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}