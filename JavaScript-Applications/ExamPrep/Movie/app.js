import { render } from "./node_modules/lit-html/lit-html.js";
import page from "./node_modules/page/page.mjs";

import { addMoviePage } from "./pages/addMovie.js";
import { detailsPage } from "./pages/details.js";
import { editPage } from "./pages/editPage.js";
import { homePage } from "./pages/homePage.js";
import { loginPage } from "./pages/loginPage.js";
import { registerPage } from "./pages/registerPage.js";

const main = document.getElementById('main-section');

setNav();
page('/', decorateContext, homePage);
page('/register', decorateContext, registerPage);
page('/login', decorateContext, loginPage);
page('/add', decorateContext, addMoviePage);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);

page.start();

async function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main)
    ctx.setNav = setNav;
    next();
}

const logoutBtn = document.getElementById('logout');
logoutBtn.addEventListener('click', async () => {
    const response = await fetch('http://localhost:3030/users/register', {
        method: 'GET',
        headers: {
            'X-Authorization': localStorage.getItem('authToken')
        }
    })
    if (response.ok) {
        
        localStorage.removeItem('username');
        localStorage.removeItem('authToken');
        localStorage.removeItem('userId');
    }
    setNav();
    page.redirect('/');
})

function setNav() {
    const user = localStorage.getItem('username');
    if (user != null) {
        document.getElementById('welcome').style.display = 'block';
        document.getElementById('welcome').textContent = `Welcome, ${user}`;
        document.getElementById('register').style.display = 'none';
        document.getElementById('login').style.display = 'none';
        document.getElementById('logout').style.display = 'block';
    }else {
        document.getElementById('welcome').style.display = 'none';
        document.getElementById('register').style.display = 'block';
        document.getElementById('login').style.display = 'block';
        document.getElementById('logout').style.display = 'none';
    }
}