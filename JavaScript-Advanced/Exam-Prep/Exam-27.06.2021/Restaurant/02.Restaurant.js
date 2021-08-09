class Restaurant {
    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(arr){
        
        for (const currProd of arr) {
            let [prodname, quantity, totalPrice] = currProd.split(' ');
            totalPrice = Number(totalPrice);
            quantity = Number(quantity);
            if (this.budgetMoney >= totalPrice) {
                
                if (this.stockProducts[prodname] === undefined) {
                    this.stockProducts[prodname] = 0;
                }

                this.stockProducts[prodname] += quantity;
                this.budgetMoney -= totalPrice;
                this.history.push(`Successfully loaded ${quantity} ${prodname}`);
            }else{
                this.history.push(`There was not enough money to load ${quantity} ${prodname}`);
            }
        }
        return this.history.join('\n');
    }

    addToMenu(meal, prodArr, price){
        price = Number(price);

        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in the our menu, try something different.`;
        }

        this.menu[meal] = {
            products: prodArr,
            price: price
        };

        let count = 0;
        for (const key in this.menu) {
            if (this.menu.hasOwnProperty(key)) {
                count++;   
            }
        }

        if (count === 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }

        return `Great idea! Now with the ${meal} we have ${count} meals in the menu, other ideas?`;
    }

    showTheMenu(){
        let count = 0;
        for (const key in this.menu) {
            if (this.menu.hasOwnProperty(key)) {
                count++;   
            }
        }

        if (count === 0) {
            return `Our menu is not ready yet, please come later...`;
        }
        let result ='';

      
        for (const key in this.menu) {

            let price = this.menu[key]['price'];

            result += `${key} - $ ${price}\n`
        }
        return result.trimEnd();
    }

    makeTheOrder(meal){

        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProd = this.menu[meal]['products'];
        let prodArr = Object.keys(this.stockProducts);
        let stockquantity = Object.values(this.stockProducts);
        for (const prod of neededProd) {
            let [prodname, quantity] = prod.split(' ');
            if (!prodArr.includes(prodname)) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
            let counter = 0;
            let currpQ = stockquantity[counter];
            if (currpQ < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
            this.stockProducts[prodname] -= quantity;
            counter++;
        }
        let price = this.menu[meal]['price'];
        this.budgetMoney += price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${price}.`;
    }
}

let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));

