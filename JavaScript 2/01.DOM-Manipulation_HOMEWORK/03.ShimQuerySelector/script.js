if(!document.querySelectorAll) {
	// IE7 support for querySelectorAll. Supports multiple / grouped selectors and the attribute selector with a "for" attribute. http://www.codecouch.com/	
	old = true;
	(function(d, s) {
		d=document, s=d.createStyleSheet();
		d.querySelectorAll = function(r, c, i, j, a) {
			a=d.all, c=[], r = r.replace(/\[for\b/gi, '[htmlFor').split(',');
			for (i=r.length; i--;) {
				s.addRule(r[i], 'k:v');
				for (j=a.length; j--;) a[j].currentStyle.k && c.push(a[j]);
				s.removeRule(0);
				old = true;
			}
			return c;
		}
	})()	
}

// querySelector support
if (!document.querySelector)
	
	document.querySelector = function(selector)
	{
		old = true;
		var head = document.documentElement.firstChild;
		var styleTag = document.createElement("STYLE");
		head.appendChild(styleTag);
		document.__qsResult = [];
		
		styleTag.styleSheet.cssText = selector + "{x:expression(document.__qsResult.push(this))}";
		window.scrollBy(0, 0);
		head.removeChild(styleTag);
		
		var result = [];
		for (var i in document.__qsResult)
			result.push(document.__qsResult[i]);
		return result;
	}
	

function createDivs(count) {
	
	
	count = 15; // hard coded for testing purposes
	// clean main div
	var contentDiv = document.getElementById("content");
	while (contentDiv.firstChild) {contentDiv.removeChild(contentDiv.firstChild);}
	
	// create divs
	var docFrag = document.createDocumentFragment();
	var div;
	for (var i = 0; i < count; i++) {
		div = document.createElement("div");
		div.className = 'test-class';
		docFrag.appendChild(div);
	}
	contentDiv.appendChild(docFrag);
}





function onStartButtonClick() {
	old = false;
	var elementList = document.querySelectorAll('.test-class');
	var resultDiv = document.querySelector('#result');
	var message = 'If you see this then the shim is working correctly! The total number of elements with class name "test-class" is ' + elementList.length;
	
	if (old == true) {resultDiv[0].innerHTML = message;}
	resultDiv.innerHTML = message;
	
	
	return false;
}

