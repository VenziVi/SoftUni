const assert = require('chai').assert;
const createCalculator = require('../Add-Substract');

describe('test calculator', () => {
    it('test add', () => {
        let calculator = createCalculator();
        calculator.add(5);
        let actual = calculator.get();
        let expected = 5;

        assert.equal(actual, expected)
    })

    it('test substract', () => {
        let calculator = createCalculator();
        calculator.subtract(5);
        let actual = calculator.get();
        let expected = -5;

        assert.equal(actual, expected)
    })

    it('test with not a number', () => {
        let calculator = createCalculator();
        calculator.add('a');
        let actual = calculator.get();
        let expected = 5;

        assert.notEqual(actual, expected)
    })

    it(`add method adds parsable input`, () => {
        const calculator = createCalculator()
        calculator.add('1')
        let expected = '1';
        assert.equal(calculator.get(), expected)
    })
    
})