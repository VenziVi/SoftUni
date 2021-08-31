import page from "./node_modules/page/page.mjs";
import { render } from "./node_modules/lit-html/lit-html.js";

import { navPage } from "./views/navView.js";
import { homePage } from "./views/homeView.js";
import { loginPage } from "./views/loginView.js";
import { listingsPage } from "./views/listingsView.js";
import { registerPage } from "./views/registerView.js";
import { detailsPage } from "./views/detailsView.js";
import { createPage } from "./views/createView.js";
import { editPage } from "./views/editView.js";
import { profilePage } from "./views/profileView.js";
import { searchPage } from "./views/searchView.js";

const navEl = document.getElementById('navigation');
const mainEl = document.getElementById('site-content');

page('/', decorateNavContext, navPage, decorateMainContext, homePage);
page('/login', decorateNavContext, navPage, decorateMainContext, loginPage);
page('/listings', decorateNavContext, navPage, decorateMainContext, listingsPage);
page('/register', decorateNavContext, navPage, decorateMainContext, registerPage);
page('/details/:id', decorateNavContext, navPage, decorateMainContext, detailsPage);
page('/create', decorateNavContext, navPage, decorateMainContext, createPage);
page('/edit/:id', decorateNavContext, navPage, decorateMainContext, editPage);
page('/profile', decorateNavContext, navPage, decorateMainContext, profilePage);
page('/search/:query', decorateNavContext, navPage, decorateMainContext, searchPage);

page.start();

function decorateNavContext(ctx, next) {
    ctx.render = (content) => render(content, navEl);
    next();
}

function decorateMainContext(ctx, next) {
    ctx.render = (content) => render(content, mainEl);
    next();
}