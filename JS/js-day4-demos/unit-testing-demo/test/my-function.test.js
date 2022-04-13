const { expect } = require('chai');
const area = require('../my-function');

describe('area', () => {
  it('should compute the area', () => {
    let result = area(9);
    expect(Math.round(result)).to.equal(254);
  });

  it('should not accept a number', () => {
    try {
      area('nine');
      fail();
    } catch (e) {
      expect(e.message).to.equal('Invalid input');
    }
  });
});