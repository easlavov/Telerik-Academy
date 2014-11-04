/// <reference path="C:\Users\easla_000\Downloads\tests\Trash\KarmaTest\scripts/_references.js" />

define(['math', 'mocha', 'chai'], function (math) {
    describe('#testing math', function () {
        it('when adding 1 and 2 should return 3', function () {
            var actual = math.sum(1, 2);
            expect(actual).to.eql(3);
        });
    });
});