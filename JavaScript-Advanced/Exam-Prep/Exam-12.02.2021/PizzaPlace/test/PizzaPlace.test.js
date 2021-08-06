const assert = require('chai').assert;

let pizzUni = {
    makeAnOrder: function (obj) {

        if (!obj.orderedPizza) {
            throw new Error('You must order at least 1 Pizza to finish the order.');
        } else {
            let result = `You just ordered ${obj.orderedPizza}`
            if (obj.orderedDrink) {
                result += ` and ${obj.orderedDrink}.`
            }
            return result;
        }
    },

    getRemainingWork: function (statusArr) {

        const remainingArr = statusArr.filter(s => s.status != 'ready');

        if (remainingArr.length > 0) {

            let pizzaNames = remainingArr.map(p => p.pizzaName).join(', ')
            let pizzasLeft = `The following pizzas are still preparing: ${pizzaNames}.`

            return pizzasLeft;
        } else {
            return 'All orders are complete!'
        }

    },

    orderType: function (totalSum, typeOfOrder) {
        if (typeOfOrder === 'Carry Out') {
            totalSum -= totalSum * 0.1;

            return totalSum;
        } else if (typeOfOrder === 'Delivery') {

            return totalSum;
        }
    }
}


describe('test', () => {
    it('test makeAnOrder', () => {
        assert.throw(() => new Error(pizzUni.makeAnOrder(), 'You must order at least 1 Pizza to finish the order.'));
        assert.throw(() => new Error(pizzUni.makeAnOrder({orderedDrink:'coke'}), 'You must order at least 1 Pizza to finish the order.'));
        assert.throw(() => new Error(pizzUni.makeAnOrder({orderedPizza: '', orderedDrink:'coke'}), 'You must order at least 1 Pizza to finish the order.'));

        assert.strictEqual(pizzUni.makeAnOrder({orderedPizza: 'vegi'}), `You just ordered vegi`);
        assert.strictEqual(pizzUni.makeAnOrder({orderedPizza: 'vegi', orderedDrink:'coke'}), `You just ordered vegi` + ` and coke.`);
    });

    it('test getRemainingWork', () => {

        let test = [{pizzaName: 'vegi', status: 'ready'},];
        let test1 = [{pizzaName: 'megi', status: 'ready'}, {pizzaName: 'segi', status: 'preparing'}, {pizzaName: 'degi', status: 'preparing'}];
        let test3 = [{pizzaName: 'degi', status: 'preparing'}];

        assert.strictEqual(pizzUni.getRemainingWork(test1), `The following pizzas are still preparing: segi, degi.`);
        assert.strictEqual(pizzUni.getRemainingWork(test), 'All orders are complete!');
        assert.strictEqual(pizzUni.getRemainingWork([]), 'All orders are complete!');
        assert.strictEqual(pizzUni.getRemainingWork(test3), `The following pizzas are still preparing: degi.`);
    });

    it('test orderType', () => {
        assert.strictEqual(pizzUni.orderType(100, 'Carry Out'), 90);
        assert.strictEqual(pizzUni.orderType(0, 'Carry Out'), 0);
        assert.strictEqual(pizzUni.orderType(-100, 'Carry Out'), -90);
        assert.strictEqual(pizzUni.orderType(100.5, 'Carry Out'), 90.45);

        assert.strictEqual(pizzUni.orderType(100, 'Delivery'), 100);
        assert.strictEqual(pizzUni.orderType(0, 'Delivery'), 0);
        assert.strictEqual(pizzUni.orderType(-10, 'Delivery'), -10);
        assert.strictEqual(pizzUni.orderType(100.1, 'Delivery'), 100.1);
    })
});