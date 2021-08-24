import { render } from "./../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";
import { catsTamplate } from "./catTemplates.js";

function showStatus(e){
    let btn = e.target;

    let infoDiv = btn.closest('.info');
    let statusDiv = infoDiv.querySelector('.status');
    if (btn.textContent === 'Show status code') {
        btn.textContent = 'Hide status code';
        statusDiv.style.display = 'block';
    }else{
        btn.textContent = 'Show status code';
        statusDiv.style.display = 'none';
    }
}

let allCatsSection = document.getElementById('allCats');

render(catsTamplate(cats, showStatus), allCatsSection)

