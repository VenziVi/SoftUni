import page from "./node_modules/page/page.mjs";
import { render } from "./node_modules/lit-html/lit-html.js";

import { navPage } from "./pages/navPage.js";
import { loginPage } from "./pages/loginPage.js";
import { registerPage } from "./pages/registerPage.js";
import { dashboardPage } from "./pages/dashboardPage.js";
import { detailsPage } from "./pages/detailsPage.js";
import { createPage } from "./pages/createPage.js";
import { editPage } from "./pages/editPage.js";
import { profilePage } from "./pages/myBooks.js";



const navEl = document.getElementById('site-header');
const main = document.getElementById('site-content');

page('/', decorateNavContext, navPage);
page('/login', decorateNavContext, navPage, decorateContext, loginPage);
page('/register', decorateNavContext, navPage, decorateContext, registerPage);
page('/dashboard', decorateNavContext, navPage, decorateContext, dashboardPage);
page('/details/:id', decorateNavContext, navPage, decorateContext, detailsPage);
page('/create', decorateNavContext, navPage, decorateContext, createPage);
page('/edit/:id', decorateNavContext, navPage, decorateContext, editPage);
page('/my-books', decorateNavContext, navPage, decorateContext, profilePage);


page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    next();
}

function decorateNavContext(ctx, next) {
    ctx.render = (content) => render(content, navEl);
    next();
}