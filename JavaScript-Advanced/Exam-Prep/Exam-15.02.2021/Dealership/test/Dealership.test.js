const assert = require('chai').assert;

let dealership = {
    newCarCost: function (oldCarModel, newCarPrice) {

        let discountForOldCar = {
            'Audi A4 B8': 15000,
            'Audi A6 4K': 20000,
            'Audi A8 D5': 25000,
            'Audi TT 8J': 14000,
        }

        if (discountForOldCar.hasOwnProperty(oldCarModel)) {
            let discount = discountForOldCar[oldCarModel];
            let finalPrice = newCarPrice - discount;
            return finalPrice;
        } else {
            return newCarPrice;
        }
    },

    carEquipment: function (extrasArr, indexArr) {
        let selectedExtras = [];
        indexArr.forEach(i => {
            selectedExtras.push(extrasArr[i])
        });

        return selectedExtras;
    },

    euroCategory: function (category) {
        if (category >= 4) {
            let price = this.newCarCost('Audi A4 B8', 30000);
            let total = price - (price * 0.05)
            return `We have added 5% discount to the final price: ${total}.`;
        } else {
            return 'Your euro category is low, so there is no discount from the final price!';
        }
    }
}

describe("Tests …", function() {
    describe("TODO …", function() {

        it("newCarCost test", function() {
            
            assert.equal(dealership.newCarCost('Audi a5', 30000), 30000);
            assert.equal(dealership.newCarCost('Audi a5', 0), 0);
            assert.equal(dealership.newCarCost('Audi a5', -10), -10);

            assert.equal(dealership.newCarCost('Audi A4 B8', 30000), 15000);
            assert.equal(dealership.newCarCost('Audi A6 4K', 30000), 10000);
            assert.equal(dealership.newCarCost('Audi A8 D5', 30000), 5000);
            assert.equal(dealership.newCarCost('Audi TT 8J', 30000), 16000);
            assert.equal(dealership.newCarCost('Audi TT 8J', 0), -14000);
            assert.equal(dealership.newCarCost('Audi TT 8J', -10000), -24000);
        });

        it("carEquipment test", () => {

            assert.deepEqual(dealership.carEquipment(['a', 'b', 'c', 'd'], [0, 2]), ['a', 'c']);
            assert.deepEqual(dealership.carEquipment(['a', 'b', 'c', 'd'], []), []);
            assert.deepEqual(dealership.carEquipment([], []), []);
        });

        it("euroCategory test", () => {

            assert.equal(dealership.euroCategory(3), 'Your euro category is low, so there is no discount from the final price!');
            assert.equal(dealership.euroCategory(0), 'Your euro category is low, so there is no discount from the final price!');
            assert.equal(dealership.euroCategory(-1), 'Your euro category is low, so there is no discount from the final price!');

            assert.equal(dealership.euroCategory(4), `We have added 5% discount to the final price: 14250.`);
        })
     });
});

