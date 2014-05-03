taskName = "4. Change the text in all regions. ";

function applyTags(text) {
    // upcase lowcase mixcase
    var indexOfClosingTagStart, tagType;
    indexOfClosingTagStart = text.indexOf('</');
    while (indexOfClosingTagStart > -1) {
        // getType
        tagType = text.substr(indexOfClosingTagStart + 2, 1);
        // apply accordingly
        text = apply(text, indexOfClosingTagStart, tagType);
        
        indexOfClosingTagStart = text.indexOf('</');
    }

    return text;

    function apply(text, indexOfClosingTagStart, tagType) {
        var indexOfOpeningTagEnd, subStrOld, subStrNew;
        // find beginning of string
        indexOfOpeningTagEnd = text.lastIndexOf('>', indexOfClosingTagStart);
        // extract text between tags
        subStrNew = text.substring(indexOfOpeningTagEnd + 1, indexOfClosingTagStart);

        // apply action to extracted text
        switch (tagType) {
            case 'u': subStrNew = subStrNew.toUpperCase(); break;
            case 'l': subStrNew = subStrNew.toLowerCase(); break;
            case 'm': subStrNew = mix(subStrNew); break;
            default:
        }

        // define old string to be replaced in the original text
        switch (tagType) {
            case 'u': subStrOld = text.substring(indexOfOpeningTagEnd - 7, indexOfClosingTagStart + 9); break;
            default: subStrOld = text.substring(indexOfOpeningTagEnd - 8, indexOfClosingTagStart + 10); break;
        }        

        // replace
        text = text.replace(subStrOld, subStrNew);
        return text;
    }

    function mix(str) {
        var res = '';
        for (var i = 0; i < str.length; i++) {
            if (getRandomInt(1,2) == 1) {
                res += str[i].toLowerCase();
            } else {
                res += str[i].toUpperCase();
            }
        }
		
        return res;
    }
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new text or use default: ',
        "We are <mixcase>living</mixcase> in a <upcase>yellow <mixcase>don't</mixcase> submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.");

    SetSolveButton(function () {
        var toEdit = input.value;

        WriteLine(applyTags(toEdit));
    });
}