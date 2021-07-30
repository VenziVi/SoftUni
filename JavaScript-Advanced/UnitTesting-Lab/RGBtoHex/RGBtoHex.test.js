const assert = require('chai').assert;
const rgbToHexColor = require('../RGBtoHex');

describe('test RGB to Hex color', () => {

    it('should be undefined if not a number', () => {
        let expected = undefined;

        assert.equal(rgbToHexColor('a', 155, 130), expected);
        assert.equal(rgbToHexColor('100', 'b', 130), expected);
        assert.equal(rgbToHexColor('121', 155, 'a'), expected);

        assert.equal(rgbToHexColor(-1, 155, 130), expected);
        assert.equal(rgbToHexColor(155, -5, 130), expected);
        assert.equal(rgbToHexColor(135, 155, -2), expected);

        assert.equal(rgbToHexColor(350, 155, 130), expected);
        assert.equal(rgbToHexColor(130, 155, 350), expected);
        assert.equal(rgbToHexColor(155, 350, 130), expected);

    })

    it('should return hex color', () => {
        let expected = '#343AEB';
        assert.equal(rgbToHexColor(52, 58, 235), expected);
    })

    it('should return hex color', () => {
        let expected = '#000000';
        assert.equal(rgbToHexColor(0, 0, 0), expected);
    })

    it('should return hex color', () => {
        let expected = '#FFFFFF';
        assert.equal(rgbToHexColor(255, 255, 255), expected);
    })
    
})