const assert = require('chai').assert;
const mathEnforcer = require('../04. Math-Enforcer');

describe('test math enforcer', () => {
    describe('test addFive', () => {
        it('should return corect answer', () => {

            let enforcer = mathEnforcer;
            assert.equal(enforcer.addFive('5'), undefined);
            assert.equal(enforcer.addFive(5), 10);
            assert.equal(enforcer.addFive(-8), -3);
            assert.closeTo(enforcer.addFive(2.5), 7.5, 0.01);
        })
    })

    describe('test subtractTen', () => {
        it('should return corect answer', () => {
            let enforcer = mathEnforcer;
            assert.equal(enforcer.subtractTen('5'), undefined);
            assert.equal(enforcer.subtractTen(25), 15);
            assert.equal(enforcer.subtractTen(5), -5);
            assert.closeTo(enforcer.subtractTen(1.5), -8.5, 0.01);
            assert.equal(enforcer.subtractTen(-5), -15);
        })
    })

    describe('test sum', () => {
        it('should return corect answer', () => {
            let enforcer = mathEnforcer;
            assert.equal(enforcer.sum('5', 5), undefined);
            assert.equal(enforcer.sum(5, '5'), undefined);
            assert.equal(enforcer.sum(5, '5', 5), undefined);
            assert.equal(enforcer.sum(5, 5), 10);
            assert.closeTo(enforcer.sum(5.2, 5.3), 10.5, 0.01);
            assert.equal(enforcer.sum(0, 0), 0);
        })
    })
})