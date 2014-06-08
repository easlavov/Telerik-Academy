var svgNS = 'http://www.w3.org/2000/svg';
var theSvg = document.getElementById('the-svg');

var scalingMultiplicator = 4;

// letters styles
var defaultFontFamily = 'Arial';
var defaultFontSize = 23 * scalingMultiplicator;
var defaultFontWeight = 900;
var defaultLetterBottomMargin = 34 * scalingMultiplicator;

// letters anchor coords
var lettersX = 100;
var lettersY = 230;

// circles anchor coords and radius
var defaultCircleRadius = 35 * scalingMultiplicator;
var circlesX = (lettersX + (70 * scalingMultiplicator));
var circleY = (lettersY - 30);
var defaultCirclesMargin = defaultCircleRadius + 1 / 2;

// colors
var firstRowColor = '#3E3F37';
var secondRowColor = '#231F20';
var thirdRowColor = '#E23337';
var fourthRowColor = '#8EC74E';

// circle content anchors
var circleContentX = circlesX;
var circleContentY = circleY;

// Drawing
appendLetter('M', lettersX, lettersY, firstRowColor);
appendLetter('E', lettersX, lettersY, secondRowColor, 3);
appendLetter('A', lettersX, lettersY, thirdRowColor);
appendLetter('N', lettersX, lettersY, fourthRowColor);

// FIRST CIRCLE AND CONTENT
appendCircle(circlesX, circleY, defaultCircleRadius, firstRowColor);
// leaf
var leafTopX = circleContentX;
var leafTopY = circleContentY - (20 * scalingMultiplicator);
var leafHeight = 40 * scalingMultiplicator;

var leafRight = document.createElementNS(svgNS, 'path');
var leafPath = 'M' + leafTopX + ' ' + leafTopY +
               'L' + leafTopX + ' ' + (leafTopY + leafHeight) +
               'Q' + (leafTopX + leafHeight / 1.7) + ' ' + (leafHeight * 1.6) + ' ' + leafTopX + ' ' + leafTopY;
leafRight.setAttribute('d', leafPath);
leafRight.setAttribute('fill', '#449644');

var leafLeft = document.createElementNS(svgNS, 'path');
leafPath = 'M' + leafTopX + ' ' + leafTopY +
           'L' + leafTopX + ' ' + (leafTopY + leafHeight) +
           'Q' + (leafTopX - leafHeight / 1.7) + ' ' + (leafHeight * 1.6) + ' ' + leafTopX + ' ' + leafTopY;
leafLeft.setAttribute('d', leafPath);
leafLeft.setAttribute('fill', '#5EB14A');

theSvg.appendChild(leafRight);
theSvg.appendChild(leafLeft);

// SECOND CIRCLE
appendCircle(circlesX, circleY, defaultCircleRadius, secondRowColor);

var expressY = leafTopY + (56 * scalingMultiplicator);
var expressX = circlesX - (29 * scalingMultiplicator);

var express = document.createElementNS(svgNS, 'text');
express.innerHTML = 'express';
express.setAttribute('x', expressX);
express.setAttribute('y', expressY);
express.setAttribute('font-size', defaultFontSize / 2);
express.setAttribute('font-family', defaultFontFamily);
express.setAttribute('font-weight', 'normal');
express.setAttribute('textLength', (60 * scalingMultiplicator));
express.setAttribute('fill', '#FDFDFC');
theSvg.appendChild(express);


// THIRD CIRCLE
appendCircle(circlesX, circleY, defaultCircleRadius, thirdRowColor);



// FOURTH CIRCLE
appendCircle(circlesX, circleY, defaultCircleRadius, fourthRowColor);


function appendLetter(letter, x, y, color, paddingLeft) {
    if (!paddingLeft) {
        paddingLeft = 0;
    }

    var newLetter = document.createElementNS(svgNS, 'text');
    newLetter.innerHTML = letter;
    newLetter.setAttribute('x', x + paddingLeft);
    newLetter.setAttribute('y', y);
    newLetter.setAttribute('font-size', defaultFontSize);
    newLetter.setAttribute('font-family', defaultFontFamily);
    newLetter.setAttribute('font-weight', defaultFontWeight);
    newLetter.setAttribute('fill', color);
    theSvg.appendChild(newLetter);

    lettersY += defaultLetterBottomMargin;
}

function appendCircle(x, y, r, color) {
    var newCircle = document.createElementNS(svgNS, 'circle');
    newCircle.setAttribute('cx', x);
    newCircle.setAttribute('cy', y);
    newCircle.setAttribute('r', r);
    newCircle.setAttribute('fill', color);
    theSvg.appendChild(newCircle);

    circleY += defaultCirclesMargin;
}