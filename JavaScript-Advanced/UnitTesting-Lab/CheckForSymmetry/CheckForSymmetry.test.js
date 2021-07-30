const assert = require('chai').assert;
const isSymmetric = require('../CheckForSymmetry');

describe('testing is symmetric to array', () => {
    it('Should [1, 2, 2, 1] be symmetric', () => {
        let arr1 = [1, 2, 2, 1];
        let actual = isSymmetric(arr1);
        let expected = true;

        assert.equal(actual, expected);
    })

    it('Should not be symmetric', () => {
        let arr = [1, 2, 3, 1];
        let actual = isSymmetric(arr);
        let expected = false;

        assert.equal(actual, expected);
    })

    it('should be false if not array', () => {
        
        assert.equal(false, isSymmetric(1));
        assert.equal(false, isSymmetric('1'));
        assert.equal(false, isSymmetric({}));
        assert.equal(false, isSymmetric(NaN));
        assert.equal(false, isSymmetric(undefined));
    })

    it('should be false if [1, "1"]', () => {
        let arr = [1, '1'];
        let actual = isSymmetric(arr);
        let expected = false;

        assert.equal(actual, expected);
    })
})