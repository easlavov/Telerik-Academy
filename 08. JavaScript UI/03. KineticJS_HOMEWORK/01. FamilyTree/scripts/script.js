var childIndex,
    indexOfMotherInChildren,
    indexOfFatherInChildren,
    startXCoord,
    startYCoord,
    parentName,
    index;

for (var i = 0; i < family.length; i++) {
    family[i].level = 0;
    family[i].indexWithChildren = [];
}

function increaseLevels(family) {
    var child;
    family.level++;
    if (family.indexWithChildren.length === 0) {
        return;
    }

    for (child in family.indexWithChildren) {
        if (family.indexWithChildren.hasOwnProperty(child)) {
            increaseLevels(family[family.indexWithChildrens[child]]);
        }
    }
}

var familyTree = [];
var stage = new Kinetic.Stage({
    container: 'canvas-container',
    width: 1920,
    height: 2000,
});

var layer = new Kinetic.Layer();

function getLine(fromX, fromY, toX, toY) {
    var headlen = 15;
    var angle = Math.atan2(toY - fromY, toX - fromX);
    var line = new Kinetic.Line({
        points: [fromX, fromY, toX, toY, toX - headlen * Math.cos(angle - Math.PI / 10),
        toY - headlen * Math.sin(angle - Math.PI / 10), toX, toY, toX - headlen
        * Math.cos(angle + Math.PI / 10), toY - headlen * Math.sin(angle + Math.PI / 10)],
        stroke: "green",
        strokeWidth:3
    });

    return line;
}

function addLines(indexOfFamily) {
    var c,
        element,
        nameOfChild,
        endXCoord,
        endYCoord;
    for (c = 0; c < family[indexOfFamily].children.length; c++) {
        nameOfChild = family[indexOfFamily].children[c];
        for (element = 0; element < familyTree.length; element++) {
            if (familyTree[element].textArr) {
                if (familyTree[element].textArr[0].text === nameOfChild) {
                    endXCoord = familyTree[element].getX() + 70;
                    endYCoord = familyTree[element].getY() - 5;
                    layer.add(getLine(startXCoord, startYCoord, endXCoord, endYCoord));
                }
            }
        }
    }
}

for (var i = 0; i < family.length; i++) {
    for (var l = 0; l < family.length; l++) {
        indexOfMotherInChildren = family[l].children.indexOf(family[i].mother);
        indexOfFatherInChildren = family[l].children.indexOf(family[i].father);
        if (indexOfMotherInChildren !== -1 || indexOfFatherInChildren !== -1) {
            family[l].indexWithChildren.push(i);
            family[i].level = family[l].level + 1;
            if (family[i].indexWithChildren.length !== 0) {
                for (childIndex in family[i].indexWithChildren) {
                    if (family[i].indexWithChildren.hasOwnProperty(childIndex)) {
                        increaseLevels(family[family[i].indexWithChildren[childIndex]]);
                    }
                }
            }
        }
    }
}

var text;

var countOfEqualLevels = [];
var prop;
var child;
for (var i = 0; i < family.length; i++) {
    if (countOfEqualLevels[family[i].level] === undefined) {
        countOfEqualLevels[family[i].level] = 0;
    }

    for (prop in family[i]) {
        if (family[i].hasOwnProperty(prop)) {
            if (prop === "mother" || prop === "father") {
                if (prop === "mother") {
                    familyTree.push(new Kinetic.Rect({
                        x: countOfEqualLevels[family[i].level] * 160,
                        y: family[i].level * 120,
                        width: 150,
                        height: 40,
                        fill: 'skyblue',
                        stroke: 'green',
                        cornerRadius: 10
                    }));
                } else {
                    familyTree.push(new Kinetic.Rect({
                        x: countOfEqualLevels[family[i].level] * 160,
                        y: family[i].level * 120,
                        width: 150,
                        height: 40,
                        fill: 'lightblue',
                        stroke: 'green'
                    }));
                }

                text = family[i][prop];
                familyTree.push(new Kinetic.Text({
                    x: countOfEqualLevels[family[i].level] * 160 + 5,
                    y: family[i].level * 120 + 5,
                    text: text,
                    fill: 'black',
                }));

                countOfEqualLevels[family[i].level]++;
            }

            if ((prop === "children") && (family[i].indexWithChildren.length === 0)) {
                if (!countOfEqualLevels[family[i].level + 1]) {
                    countOfEqualLevels[family[i].level + 1] = 0;
                }

                for (child in family[i].children) {
                    if (family[i].children.hasOwnProperty(child)) {
                        familyTree.push(new Kinetic.Rect({
                            x: countOfEqualLevels[family[i].level + 1] * 160,
                            y: (family[i].level + 1) * 120,
                            width: 150,
                            height: 40,
                            fill: 'white',
                            stroke: 'green'
                        }));
                        text = family[i].children[child];
                        familyTree.push(new Kinetic.Text({
                            x: countOfEqualLevels[family[i].level + 1] * 160 + 5,
                            y: (family[i].level + 1) * 120 + 5,
                            text: text,
                            fill: 'black',
                        }));
                        countOfEqualLevels[family[i].level + 1]++;
                    }
                }

                addLines(i);
            }
        }
    }
}

function findElement(name) {
    var m;
    for (m = 0; m < family.length; m++) {
        if (family[m].mother === name || family[m].father === name) {
            return m;
        }
    }
}

for (i = 0; i < familyTree.length; i++) {
    if (familyTree[i].textArr) {
        startXCoord = familyTree[i].getX() + 10;
        startYCoord = familyTree[i].getY() + 10;
        parentName = familyTree[i].textArr[0].text;
        index = findElement(parentName);
        if (index) {
            addLines(index);
        }
    }
    layer.add(familyTree[i]);
}

stage.add(layer);