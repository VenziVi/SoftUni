const assert = require('chai').assert;

const testNumbers = {
    sumNumbers: function (num1, num2) {
        let sum = 0;

        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        } else {
            sum = (num1 + num2).toFixed(2);
            return sum
        }
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input % 2 === 0) {
            return 'The number is even!';
        } else {
            return 'The number is odd!';
        }

    },
    averageSumArray: function (arr) {

        let arraySum = 0;

        for (let i = 0; i < arr.length; i++) {
            arraySum += arr[i]
        }

        return arraySum / arr.length
    }
};

describe("Tests …", function() {
    describe("TODO …", function() {
        it("sumNumbers …", function() {
            
            assert.strictEqual(testNumbers.sumNumbers('a', 1), undefined);
            assert.strictEqual(testNumbers.sumNumbers('a', 'b'), undefined);
            assert.strictEqual(testNumbers.sumNumbers('a', NaN), undefined);

            assert.strictEqual(testNumbers.sumNumbers(1, 1), '2.00');
            assert.strictEqual(testNumbers.sumNumbers(-1, 1), '0.00');
            assert.strictEqual(testNumbers.sumNumbers(-1, -1), '-2.00');
            assert.strictEqual(testNumbers.sumNumbers(1.5, 1), '2.50');
        });

        it('test numberChecker ', () => {
            assert.throw(()=> new Error(testNumbers.numberChecker('a'), 'The input is not a number!'));
            assert.throw(()=> new Error(testNumbers.numberChecker(NaN), 'The input is not a number!'));
            assert.throw(()=> new Error(testNumbers.numberChecker('a123'), 'The input is not a number!'));
            assert.throw(()=> new Error(testNumbers.numberChecker('123a'), 'The input is not a number!'));
            assert.throw(()=> new Error(testNumbers.numberChecker(undefined), 'The input is not a number!'));

            assert.strictEqual(testNumbers.numberChecker(2), 'The number is even!');
            assert.strictEqual(testNumbers.numberChecker(0), 'The number is even!');
            assert.strictEqual(testNumbers.numberChecker(-2), 'The number is even!');

            assert.strictEqual(testNumbers.numberChecker(1), 'The number is odd!');
            assert.strictEqual(testNumbers.numberChecker(-3), 'The number is odd!');
        })

        it('test averageSumArray ', () => {

            assert.strictEqual(testNumbers.averageSumArray([1]), 1);
            assert.strictEqual(testNumbers.averageSumArray([1, 1]), 1);
            assert.strictEqual(testNumbers.averageSumArray([1, 1, 1]), 1);
            assert.strictEqual(testNumbers.averageSumArray([2, 5, 1, 1, 1]), 2);
        })
     });
});
