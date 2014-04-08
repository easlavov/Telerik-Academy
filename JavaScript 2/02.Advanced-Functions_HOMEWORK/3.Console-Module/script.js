var SpecialConsole = (function(){
	
	
	// the console div constructor
	function createConsole(){
		var div = document.createElement('div');
		div.style.width = '1000px';
		div.style.height = '600px';
		div.style.fontFamily = 'consolas';
		div.style.fontSize = '14px';
		div.style.color = 'white';
		div.style.backgroundColor = 'black';
		div.style.overflowY = 'scroll';  // overflow-y: scroll
		div.style.wordWrap = 'break-word';
		
		return div;
	}
	
	
	// constructor
	var SpecialConsole = function (consoleParentElement) {
		this.console = createConsole();
		consoleParentElement.appendChild(this.console);
	};
	
	// constants
	
	
	// methods
	SpecialConsole.prototype = {
	
		constructor:SpecialConsole,
		
		writeLine:function(str){
			var line = document.createElement('span');
			
			if (arguments.length > 1){
				var argsArray = getPlaceholders(arguments);
				str = formatString(str, argsArray);
			}
			
			line.textContent = str.toString();
			this.console.appendChild(line);
			this.console.appendChild(document.createElement('br'));
		},
		writeError:function(arg){
			this.writeLine(arg);
		},
		writeWarning:function(arg){
			this.writeLine(arg);
		},
		
	}
	
	function getPlaceholders(args){
		var pHarr = new Array();
		for (var i = 1; i < args.length; i++) {
			pHarr.push(args[i]);
		}
		return pHarr;
	}
	
	function formatString(str, args){
		var current;
		for (var i = 0, placeholder = 0; i < args.length; i++, placeholder++) {
			current = '\{' + placeholder + '\}';
			str = str.replace(current, args[i].toString(), 'g');
		}
		
		return str;
	}
	
	return SpecialConsole;
})();

function testOne(){	
	var specialConsole = new SpecialConsole(document.body);
	specialConsole.writeLine('The quick brown fox jumps over the lazy dog');
	specialConsole.writeLine('The {0} brown fox jumps {1} the lazy dog', 'quick', 'over');
	
	specialConsole.writeWarning('The quick brown fox jumps over the lazy dog');
	
	// document.getElementById('testOneButton').disabled = true;
	return false;
}

function testTwo(){
	
}