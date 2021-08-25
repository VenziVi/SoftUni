import { render } from "./../node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";
import { townsTemplate } from "./townTemplates.js";

let townsElement = document.getElementById('towns');
let baseTowns = towns.map(t => ({name: t}));
render(townsTemplate(baseTowns), townsElement);

let serchBtn = document.getElementById('btn');
let matchesDiv = document.getElementById('result');

serchBtn.addEventListener('click', search)

function search() {
   let textEl = document.getElementById('searchText');
   let input = textEl.value.toLowerCase();

   let allTowns = towns.map(t => ({ name: t }));
   let matched = allTowns.filter(t => t.name.toLowerCase().includes(input));
   matched.forEach(t => t.class = 'active');
   let matches = matched.length;

   render(townsTemplate(allTowns), townsElement);
   matchesDiv.textContent = `${matches} matches found`;
}
