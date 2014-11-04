require.config({
    paths: {
        mocha: 'libs/mocha',
        chai: 'libs/chai',
        math: 'scripts/math'
    }
});

require(['chai', 'mocha'], function (chai) {
    mocha.setup('bdd');
    expect = chai.expect;
});


require(['mocha'], function () {
    mocha.run();
});