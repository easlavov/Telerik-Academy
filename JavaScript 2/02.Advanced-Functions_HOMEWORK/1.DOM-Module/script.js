var DomModule = (function(){
	
	// constructor
	var DomModule = function () {
	};
	
	// buffer variable
	var buffer = {};
	// buffer flush counter
	var flushCounter = 100;
	
	// methods
	DomModule.prototype = {
	
		constructor:DomModule,
		
		appendChild:function(element, parent){
		
			var parent = document.querySelector(parent);
			parent.appendChild(element);
		},
		
		removeChild:function(parent, element){
		
			var parent = document.querySelector(parent);
			var child = document.querySelector(element);
			parent.removeChild(child);
		},
		
		appendToBuffer:function(parentSelector, childSelector){
			// check if parent selector is present in the buffer
			// else create it as document fragment
			if (!buffer[parentSelector]){
				buffer[parentSelector] = document.createDocumentFragment();
			}
			
			// create element
			var element = document.createElement(childSelector);
			
			// append it to the fragment
			buffer[parentSelector].appendChild(element);
			
			// check if buffer needs flushing
			if (buffer[parentSelector].childNodes.length === flushCounter){
				var parent = document.querySelector(parentSelector);
				parent.appendChild(buffer[parentSelector]);
				// clear corresponding buffer
				buffer[parentSelector] = null;
			}
		},
		
		getElements:function(selector){
			return document.querySelectorAll(selector);
		}
	}
	
	return DomModule;
})();

function testOne(){
	// Testing appendChild
	domModule = new DomModule(); // declared global to be used in other tests
	var testDiv = document.createElement('div');
	testDiv.id = 'testDiv' // for removeChild test
	domModule.appendChild(testDiv, '#testBody');
	
	// Testing removeChild
	var testInnerDiv = document.createElement('div');
	domModule.appendChild(testInnerDiv, '#testDiv');
	
	document.getElementById('testOneButton').disabled = true;
	return false;
}

function testTwo(){
	domModule.removeChild('#testDiv', 'div div');
}