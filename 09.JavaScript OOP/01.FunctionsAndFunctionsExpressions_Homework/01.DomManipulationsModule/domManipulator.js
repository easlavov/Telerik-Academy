var domManipulator = (function () {
    var MAX_BUFFER_SIZE = 5;
    var buffer = [];

    function appendElement(selector, element) {
        var parent = document.querySelector(selector);
        parent.appendChild(element);
    }

    function removeElement(selector, element) {
        var parent = document.querySelector(selector);
        parent.removeChild(element);
    }

    function attachEventHandler(selector, eventType, eventHandler) {
        var element = document.querySelector(selector);
        element.addEventListener(eventType, eventHandler);
    }

    function addToBuffer(selector, element) {
        var parent = document.querySelector(selector);
        if (!buffer[parent]) {
            buffer[parent] = document.createDocumentFragment();
        }

        buffer[parent].appendChild(element);

        // Flush if necessary
        if (buffer[parent].childElementCount === MAX_BUFFER_SIZE) {
            parent.appendChild(buffer[parent]);
        }
    }

    function getElementBySelector(selector) {
        return document.querySelector(selector);
    }

    function getElementsBySelector(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        appendElement : appendElement,
        removeElement : removeElement,
        attachEventHandler : attachEventHandler,
        addToBuffer : addToBuffer,
        getElementBySelector : getElementBySelector,
        getElementsBySelector : getElementsBySelector
    }
})();