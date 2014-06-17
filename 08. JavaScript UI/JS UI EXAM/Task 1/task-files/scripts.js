function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);
    var CONTAINER_WIDTH = 1200;
    var CONTAINER_HEIGHT = 2500;
    var DEFAULT_BORDER_RADIUS = 10;
    var divTemplate = createDivTemplate();
    var BIG_IMAGE_HEADING_ID = 'big-image-heading';
    var BIG_IMAGE_IMG_ID = 'big-image-img';
    var bigImageDiv = createBigImageDiv();
    var sideBarContainer = createSideBarContainer();
    var input = createInput();
    var imageContainerTemplate = createImageContainerTemplate();

    applyContainerStyles();
    container.appendChild(bigImageDiv);
    container.appendChild(sideBarContainer);
    sideBarContainer.appendChild(input);
    insertImages(sideBarContainer, items);
    displayImage(items[0]);


    sideBarContainer.addEventListener('mouseover', function (ev) {
        if (ev.target.classList.contains('image-container')) {
            ev.target.style.backgroundColor = 'gray';
        } else if (ev.target.classList.contains('image-cont-inner')) {
            ev.target.parentNode.style.backgroundColor = 'gray';
        }
    });

    sideBarContainer.addEventListener('mouseout', function (ev) {
        if (ev.target.classList.contains('image-container')) {
            ev.target.style.backgroundColor = 'white';
        } else if (ev.target.classList.contains('image-cont-inner')) {
            ev.target.parentNode.style.backgroundColor = 'white';
        }
    });

    sideBarContainer.addEventListener('click', function (ev) {
        var imageIndex;
        if (ev.target.classList.contains('image-cont-inner')) {
            imageIndex = ev.target.parentNode.id;
            displayImage(items[imageIndex]);
        }
    });

    input.addEventListener('change', function (ev) {
        var value = ev.target.value;
        insertImages(sideBarContainer, items, value);
    });

    function createDivTemplate() {
        var template = document.createElement('div');
        template.style.margin = 0;
        template.style.padding = 0;
//        template.style.border = '1px solid black';

        return template;
    }

    function applyContainerStyles() {
//        container.style.border = '1px solid black';
        container.style.width = CONTAINER_WIDTH + 'px';
        container.style.height = CONTAINER_HEIGHT + 'px';
    }

    function createBigImageDiv() {
        var bigImage = divTemplate.cloneNode(true);
        bigImage.style.width = '800px';
        bigImage.style.height = '700px';
        bigImage.style.marginRight = '40px';
        bigImage.style.float = 'left';
        bigImage.style.textAlign = 'center';

        var bigImageHeading = document.createElement('h2');
        bigImageHeading.id = BIG_IMAGE_HEADING_ID;
        var bigImageImg = document.createElement('img');
        bigImageImg.id = BIG_IMAGE_IMG_ID;
        bigImageImg.style.width = '750px';
        bigImageImg.style.height = '600px';
        bigImageImg.style.borderRadius = DEFAULT_BORDER_RADIUS + 'px';

        bigImage.appendChild(bigImageHeading);
        bigImage.appendChild(bigImageImg);

        return bigImage;
    }

    function createSideBarContainer() {
        var sidebar = divTemplate.cloneNode(true);
        sidebar.style.border = 'none';
        sidebar.style.float = 'left';
        sidebar.style.textAlign = 'center';
        var span = document.createElement('span');
        span.innerHTML = 'Filter';
        span.style.display = 'block';
        sidebar.appendChild(span);

        return sidebar;
    }

    function createInput() {
        var newInput = document.createElement('input');
        newInput.type = 'text';

        return newInput;
    }

    function createImageContainerTemplate() {
        var imgContTempl = divTemplate.cloneNode(true);
        imgContTempl.classList.add('image-container');
        applyImageContTemplStyles(imgContTempl);
        var imageHeading = document.createElement('h4');
        imageHeading.classList.add('image-cont-inner');
        applyHeadingStyles(imageHeading);
        var image = document.createElement('img');
        image.classList.add('image-cont-inner');
        applyImageStyle(image);

        imgContTempl.appendChild(imageHeading);
        imgContTempl.appendChild(image);

        return imgContTempl;
    }

    function applyImageContTemplStyles(cont) {
        cont.style.display = 'block';
        cont.style.margin = '20px';
        cont.style.padding = '10px';
        cont.style.border = 'none';
    }

    function applyHeadingStyles(heading) {
        heading.style.padding = 0;
        heading.style.margin = 0;
    }

    function applyImageStyle(img) {
        img.style.width = '200px';
        img.style.height = 'auto';
        img.style.borderRadius = DEFAULT_BORDER_RADIUS + 'px';
    }

    function removeContainers(sbar) {
        var paras = sbar.getElementsByClassName('image-container');

        while (paras[0]) {
            paras[0].parentNode.removeChild(paras[0]);
        }
    }

    function insertImages(sbar, imgColl, string) {
        removeContainers(sbar);
        for (var i = 0; i < imgColl.length; i++) {
            if (string === '' || !string) {
                appendImage(sbar, imgColl[i], i);
            } else if (imgColl[i].title.toLowerCase().indexOf(string) !== -1) {
                appendImage(sbar, imgColl[i], i);
            }
        }
    }

    function appendImage(sbar, imgInfo, index) {
        var newCont = imageContainerTemplate.cloneNode(true);
        newCont.id = index;
        var heading = newCont.getElementsByTagName('h4')[0];
        heading.innerHTML = imgInfo.title;

        var img = newCont.getElementsByTagName('img')[0];
        img.src = imgInfo.url;

        sbar.appendChild(newCont);
    }

    function displayImage(img) {
        bigImageDiv.children[0].innerHTML = img.title;
        bigImageDiv.children[1].src = img.url;
    }
}