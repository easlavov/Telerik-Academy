/// <reference path="_references.js" />

(function () {
    Object.create = function (obj) {
        var f = function F() { };
        f.prototype = obj;
        return new f();
    };

    Object.prototype.extend = function (childProps) {
        function ext() { }
        ext.prototype = Object.create(this);
        for (var prop in childProps) {
            ext.prototype[prop] = childProps[prop];
        }

        return new ext();
    };

    Function.prototype.addMethods = function (obj) {
        for (var func in obj) {
            this.prototype[func] = obj[func];
        }
    };

    Array.prototype.remove = function (item) {
        for (var i = 0; i < length; i++) {
            if (this[i] === item) {
                this.splice(i, 1);
                return;
            }
        }

        throw 'Element not found';
    };
})();

var ImageSlider = function (container, width, height) {
    var image = {
        init: function (title, thumbUrl, largeUrl) {
            this.title = title;
            this.thumbUrl = thumbUrl;
            this.largeUrl = largeUrl;
        }
    };

    var images = [];
    var currentImageIndex = 0;

    function initImgSlider() {        
        var wrapper = document.createElement('div');
        wrapper.clientWidth = width;
        wrapper.clientHeight = height;

        var prevButton = document.createElement('button');
        var nextButton = document.createElement('button');

        var imgDiv = document.createElement('div');
        imgDiv.style.display = 'inline-block';

        var bigImage = document.createElement('div');
        var thumbs = document.createElement('div');
        imgDiv.appendChild(bigImage);
        imgDiv.appendChild(thumbs);

        wrapper.appendChild(prevButton);
        wrapper.appendChild(imgDiv);
        wrapper.appendChild(nextButton);

        container.appendChild(wrapper);

        for (var img in images) {
            var imgElement = document.createElement('img');
            imgElement.src = img.thumbUrl;
            thumbs.appendChild(imgElement);
        }
    }
    
    function addImage(title, thumbUrl, largeUrl) {
        var newImg = Object.create(image);
        image.init(title, thumbUrl, largeUrl);
        images.push(newImg);
    }

    function removeImage(image) {
        images.remove(image);
    }

    function nextImage() {
        currentImageIndex = (currentImageIndex + 1) % images.length;
    }

    function prevImage() {
        currentImageIndex = (currentImageIndex - 1) % images.length;
    }

    return {
        addImage: addImage,
        removeImage: removeImage,
        nextImage: nextImage,
        prevImage: prevImage,
    };
};