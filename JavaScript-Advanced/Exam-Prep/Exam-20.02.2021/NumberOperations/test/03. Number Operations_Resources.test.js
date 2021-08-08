const numberOperations = require('../03. Number Operations_Resources');
const assert = require('chai').assert;

describe('test', () => {
    describe('test', () =>{})
    it('test powNumbers', () => {
        assert.equal(numberOperations.powNumber(2), 4);
        assert.equal(numberOperations.powNumber(0), 0);
        assert.equal(numberOperations.powNumber(-2), 4);
        //assert.exists(numberOperations.sumArrays([1, 1, 1], [1, 1, 1]), [2, 2, 2]);
    })});
    describe('test', () => {
    it('test numberChecker', () => {
        assert.throws(() => new Error(numberOperations.numberChecker(NaN), 'The input is not a number!'));
        assert.equal(numberOperations.numberChecker(99), 'The number is lower than 100!');
        assert.equal(numberOperations.numberChecker(0), 'The number is lower than 100!');
        assert.equal(numberOperations.numberChecker(-1), 'The number is lower than 100!');

        assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
        assert.equal(numberOperations.numberChecker(100000), 'The number is greater or equal to 100!');
        
    })});
    describe('test', () => {
    it('test sumArrays', () => {
        assert.deepEqual(numberOperations.sumArrays([1, 1, 1, 1], [1, 1, 1]), [2, 2, 2, 1]);
        assert.deepEqual(numberOperations.sumArrays([1, 1, 1], [1, 1, 1, 1]), [2, 2, 2, 1]);
        assert.deepEqual(numberOperations.sumArrays([1, 1, 1], [1, 1, 1]), [2, 2, 2]);
    });
});
