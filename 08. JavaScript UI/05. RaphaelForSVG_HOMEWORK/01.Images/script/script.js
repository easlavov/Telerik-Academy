//roundedRectangle(x, y, width, height, upper_left_corner, upper_right_corner, lower_right_corner, lower_left_corner)
Raphael.fn.roundedRectangle = function (x, y, w, h, r1, r2, r3, r4){
    var array = [];
    array = array.concat(["M",x,r1+y, "Q",x,y, x+r1,y]); //A
    array = array.concat(["L",x+w-r2,y, "Q",x+w,y, x+w,y+r2]); //B
    array = array.concat(["L",x+w,y+h-r3, "Q",x+w,y+h, x+w-r3,y+h]); //C
    array = array.concat(["L",x+r4,y+h, "Q",x,y+h, x,y+h-r4, "Z"]); //D

    return this.path(array);
};

// Telerik
var paper = Raphael('telerik', 1000, 800);

var logoPath = 'm 170,60.938382 -30,-30 -80,79.999998 40,40 40,-40 -75,-79.999998 -30,30';
var telerikLogo = paper.path(logoPath).attr({
    stroke: '#5ce600',
    'stroke-width':20
});

var telerikText = paper.text(465, 105, 'Telerik').attr({
    'font-family':'Segoe WP',
    'font-size':180,
    'font-weight':'bold'
});

var experiencesText = paper.text(510, 210, 'Develop Experiences').attr({
    'font-family':'Segoe WP',
    'font-size':64
});

// Youtube
var youtubePaper = Raphael('youtube', 1000, 800);

var youText = youtubePaper.text(190, 150, 'You').attr({
    'font-family':'Arial',
    'font-size':180,
    'font-weight':'bold',
    length: 10
});

var redRect = youtubePaper.roundedRectangle(365, 50, 470, 200, 20, 20, 20, 20).attr({
    fill:'red',
    stroke:'none'
});

var tubeText = youtubePaper.text(600, 150, 'Tube').attr({
    'font-family':'Arial',
    'font-size':180,
    'font-weight':'bold',
    fill:'white'
});