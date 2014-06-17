$.fn.gallery = function (colsPerRow) {
    var DEFAULT_COLS_PER_ROW = 4;
    var imageContainerWidthAndMargin = 260;
    var columnsPerRow;
    var $theGallery = $('#gallery');
    var $theGalleryList = $theGallery.find('.gallery-list');
    var $displayedImages = $theGallery.find('.selected');
    if (colsPerRow) {
        columnsPerRow = colsPerRow;
    } else {
        columnsPerRow = DEFAULT_COLS_PER_ROW;
    }

    $theGallery.addClass('gallery');
    $theGalleryList.width(columnsPerRow*imageContainerWidthAndMargin);
    $displayedImages.hide();
    turnOn();
    function turnOn() {
        $theGalleryList.on('click', '.image-container', function () {
            var $clickedImage = $(this);
            $theGalleryList.addClass('blurred');
            $theGallery.addClass('disabled-background');

            var currentImageIndex = $clickedImage.find('img').data('info');
            setDsiplayedImages(currentImageIndex);
            turnOff();

            $displayedImages.show();
        });
    }

    function turnOff() {
        $theGalleryList.off('click');
    }

    $displayedImages.on('click', '.current-image', function () {
        $displayedImages.hide();
        $theGalleryList.removeClass('blurred');
        turnOn();
    });

    $displayedImages.on('click', '.previous-image', function () {
        var $thisPrevImageCont = $(this);
        var $thisPrevImage = $thisPrevImageCont.find('img');
        var src = $thisPrevImage.attr('src');
        var index = getIndex(src);
        console.log(index);
        setDsiplayedImages(index);
    });

    $displayedImages.on('click', '.previous-image', function () {
        var $thisPrevImageCont = $(this);
        var $thisPrevImage = $thisPrevImageCont.find('img');
        var src = $thisPrevImage.attr('src');
        var index = getIndex(src);
        console.log(index);
        setDsiplayedImages(index);
    });

    $displayedImages.on('click', '.next-image', function () {
        var $thisNextImageCont = $(this);
        var $thisNextImage = $thisNextImageCont.find('img');
        var src = $thisNextImage.attr('src');
        var index = getIndex(src);
        console.log(index);
        setDsiplayedImages(index);
    });

    function setDsiplayedImages(centralImageIndex) {
        centralImageIndex = parseInt(centralImageIndex);
        var prevImageIndex = centralImageIndex - 1;
        if (prevImageIndex === 0) {
            prevImageIndex = 12;
        }

        var nextImageIndex = centralImageIndex + 1;
        if (nextImageIndex === 13) {
            nextImageIndex = 1;
        }

        var $prev = $displayedImages.find('.previous-image');
        var $prevImage = $prev.find('img');
        var $current = $prev.next();
        var $currentImage = $current.find('img');
        var $next = $current.next();
        var $nextImage = $next.find('img');

        var index = 'imgs/' + centralImageIndex + '.jpg';
        $currentImage.attr('src',  index);

        index = 'imgs/' + prevImageIndex + '.jpg';
        $prevImage.attr('src',  index);

        index = 'imgs/' + nextImageIndex + '.jpg';
        $nextImage.attr('src',  index);
    }

    function getIndex(src) {
        var index = src.substr(5);

        var result = parseInt(index);
        return index;
    }
};