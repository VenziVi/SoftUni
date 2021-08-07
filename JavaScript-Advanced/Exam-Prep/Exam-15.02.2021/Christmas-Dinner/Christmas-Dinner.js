class ChristmasDinner {
    constructor(budget) {
        if (Number(budget) < 0) {
            throw new Error('The budget cannot be a negative number')
        }
        this.budget = Number(budget);
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }



    shopping(product) {
        let [productName, price] = [...product];
        price = Number(price);
        if (this.budget < price) {
            throw new Error('Not enough money to buy this product');
        }
        this.products.push(productName);
        this.budget -= price;
        return `You have successfully bought ${productName}!`
    };

    recipes(recipe) {

        for (const prod of recipe.productsList) {
            if (this.products.includes(prod)) {

            } else {
                throw new Error('We do not have this product');
            }
        }

        this.dishes.push(recipe);
        return `${recipe.recipeName} has been successfully cooked!`

    };

    inviteGuests(name, dish) {
        let isDishCoocked = false
        for (let i = 0; i < this.dishes.length; i++) {
            if (this.dishes[i]['recipeName'] === dish) {
                isDishCoocked = true;
                break;
            }
        }

        if (!isDishCoocked) {
            throw new Error('We do not have this dish');
        }

        let gestArr = Object.keys(this.guests);

        if (gestArr.includes(name)) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;

    }

    showAttendance() {
        let result = '';
        for (const key in this.guests) {
            let dish = this.guests[key];
            let products = '';
            for (const currDish of this.dishes) {
                if (currDish.recipeName === dish) {
                    products = currDish.productsList;
                    result += `${key} will eat ${this.guests[key]}, which consists of ${products.join(', ')}\n`;
                    break;
                }
            }
        }
        return result.trimEnd();
    }

}

let dinner = new ChristmasDinner(300);
dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);
dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});
dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');
console.log(dinner.showAttendance());



class ChristmasDinner {
    constructor(budget) {
        if (Number(budget) < 0) {
            throw new Error('The budget cannot be a negative number')
        }
        this.budget = Number(budget);
        this.dishes = []
        this.products = [];
        this.guests = {};

    }
    
    shopping([product, price]) {

        if (price > this.budget) {
            throw new Error('Not enough money to buy this product');
        }
        this.products.push(product);
        this.budget -= price;
        return `You have successfully bought ${product}!`
    };

    recipes(recipe) {
        let name = recipe.recipeName;
        let productsNeeded = recipe.productsList;
        let isOk = true;
        productsNeeded.forEach(element => {
            if (!this.products.includes(element)) {
                isOk = false
            }
        });
        if (!isOk) {
            throw new Error('We do not have this product');
        }

        this.dishes.push(recipe);
        return `${name} has been successfully cooked!`

    };

    inviteGuests(name, dish) {
        let curDish = this.dishes.find(x => x.recipeName == dish);
        if (!curDish) {
            throw new Error('We do not have this dish');
        }
        if (name in this.guests) {
            throw new Error('This guest has already been invited');
        }
        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    };

    showAttendance() {
        let result = '';
        Object.entries(this.guests).forEach(
            el => {

                let name = el[0];
                let meal = el[1];
                let productl = this.dishes.find(x => x.recipeName == meal);
                let products = productl.productsList;

                result += `${name} will eat ${meal}, which consists of ${products.join(', ')}\n`;
            }
        )
        return result.trim()
    };
}