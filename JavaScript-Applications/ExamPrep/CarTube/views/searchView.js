import { getMyCars } from "../api/data.js";
import { html } from "./../node_modules/lit-html/lit-html.js";

const searchTemp = (data, onSearch) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click=${onSearch} class="button-list">Search</button>
    </div>

    <!-- Display all records -->
    ${data.length > 0 ? html`
    <h2>Results:</h2>
    <div class="listings">
        ${data.map(c => carTemp(c))}`
        : html`
        <!-- Display if there are no matches -->
        <p class="no-cars"> No results.</p>`}
    </div>
</section>`;

const carTemp = (car) => html`
<div class="listing">
    <div class="preview">
        <img src=${car.imageUrl}>
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

export async function searchPage(ctx) {
    const searchedYear = Number(ctx.params.query);
    const response = Number.isNaN(searchedYear) ? [] : await fetch(`http://localhost:3030/data/cars?where=year%3D${searchedYear}`);

    let data = [];
    if (response.ok) {
        data = await response.json();
    }
    ctx.render(searchTemp(data, onSearch));

    function onSearch() {
        const query = Number(document.getElementById('search-input').value);
        ctx.page.redirect(`/search/${query}`)
    }
}