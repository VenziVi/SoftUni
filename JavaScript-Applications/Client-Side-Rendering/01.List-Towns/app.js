import { render } from "./../node_modules/lit-html/lit-html.js"
import { townsTemplate } from "./templates.js";

let townsForm = document.getElementById('towns-form');
townsForm.addEventListener('submit', printTowns);
let rootEl = document.getElementById('root');

function printTowns(e){
    e.preventDefault();
    let form = e.target;
    let formEl = new FormData(form);
    let townsInput = formEl.get('towns');
    let towns = townsInput.split(', ');

    render(townsTemplate(towns), rootEl);
    form.reset();
}