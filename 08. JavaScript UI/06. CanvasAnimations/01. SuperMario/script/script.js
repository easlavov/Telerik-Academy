var stage = new Kinetic.Stage({
    container:'canvas',
    width:1024,
    height:827
});

var layer = new Kinetic.Layer();

var mario = new Image();

mario.onload = function () {
    var marioSprite = new Kinetic.Sprite({
        x: 400,
        y: 440,
        image:mario,
        animation:'idle',
        animations:{
            idle:[
                602, 603, 175, 340,
//                307, 619, 230, 340,
            ],
            move:[
                852, 670, 211, 206,
                30,977, 224, 244,
                602, 603, 175, 340,
            ]
        },
        frameRate:3,
        frameIndex:0
    });

    layer.add(marioSprite);

    stage.add(layer);

    marioSprite.start();

    setInterval(function () {
        marioSprite.setX(marioSprite.attrs.x -= 30);
        if (marioSprite.attrs.x < -200) {
            marioSprite.attrs.x = 1024;
        }
        marioSprite.attrs.animation='move';
    },200)
};

mario.src = 'imgs/mario.png';


var paper = Raphael(0,0, 1024, 827);

paper.image('imgs/bgrnd.png', 0,0, 1024, 827);