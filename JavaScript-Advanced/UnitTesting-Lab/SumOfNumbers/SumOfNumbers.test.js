const assert = require('chai').assert;
const sum = require('../SumOfNumbers');


    it('should return 3 for [1, 2]', () => {
        let actiual = sum([1, 2]);
        let expected = 3;

        assert.strictEqual(actiual, expected);
    });

    it('should not be equal', () => {
        let actual = sum([1, 2, 3]);
        let expected = 2;

        assert.notEqual(actual, expected);
    })
