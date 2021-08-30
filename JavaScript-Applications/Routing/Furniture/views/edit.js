import { html } from "./../node_modules/lit-html/lit-html.js";
import { getItemById, editRecord } from "../api/data.js";

const editTemp = (item, onSubmit, form) => html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${onSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class="form-control${form.invalidFields.make ? ' is-invalid' : ' is-valid'}" id="new-make" type="text" name="make" .value=${item.make}>
                    </div>
                    <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control${form.invalidFields.model ? ' is-invalid' : ' is-valid'}" id="new-model" type="text" name="model" .value=${item.model}>
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control${form.invalidFields.year ? ' is-invalid' : ' is-valid'}" id="new-year" type="number" name="year" .value=${item.year}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control${form.invalidFields.description ? ' is-invalid' : ' is-valid'}" id="new-description" type="text" name="description" .value=${item.description}>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control${form.invalidFields.price ? ' is-invalid' : ' is-valid'}" id="new-price" type="number" name="price" .value=${item.price}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control${form.invalidFields.img ? ' is-invalid' : ' is-valid'}" id="new-image" type="text" name="img" .value=${item.img}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material(optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material" .value=${item.material}>
                    </div>
                    <input type="submit" class="btn btn-info" value="Edit" />
                </div>
            </div>
        </form>`;

let form = {
    invalidFields: {}
};
export async function editPage(ctx) {
    const id = ctx.params.id;
    const item = await getItemById(id);
    ctx.render(editTemp(item, onSubmit, form));

    async function onSubmit(e) {
        e.preventDefault();
        const formData = new FormData(e.target);
        let make = formData.get('make');
        let model = formData.get('model');
        let year = formData.get('year');
        let description = formData.get('description');
        let price = formData.get('price');
        let img = formData.get('img');
        let material = formData.get('material');

        if (make.length < 4) {
            form.invalidFields.make = true;
        }else {
            form.invalidFields.make = false;
        }
        if (model.length < 4) {
            form.invalidFields.model = true;
        }else {
            form.invalidFields.model = false;
        }
        if (Number(year) < 1950 || Number(year) > 2050) {
            form.invalidFields.year = true;
        }else {
            form.invalidFields.year = false;
        }
        if (description.length < 10) {
            form.invalidFields.description = true;
        }else {
            form.invalidFields.description = false;
        }
        if (Number(price) < 0 || Number(price) == '') {
            form.invalidFields.price = true;
        }else {
            form.invalidFields.price = false;
        }
        if (img.trim() === '') {
            form.invalidFields.img = true;
        }else {
            form.invalidFields.img = false;
        }

        if(form.invalidFields.make || form.invalidFields.model ||  form.invalidFields.year ||
            form.invalidFields.description ||  form.invalidFields.price || form.invalidFields.img){
            return ctx.render(editTemp(item, onSubmit, form));
        }

        await editRecord(item._id, {make, model, year, description, price, img, material});

        ctx.page.redirect(`/details/${item._id}`);
    }
}