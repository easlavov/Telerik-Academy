Function.prototype.inherit = function(parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

Function.prototype.extend = function(parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
};

// Declaring the parent class of all Propulsion units
function PropulsionUnit(){
    this.acceleration = undefined;
}
// The produceAcceleration method, while common for all prop units,
// is not defined here as there is no common method for acceleration defined in the task.
// Defining it will lead to unnecessary overriding (more code than necessary)

// Now declaring the three types of prop units
// Wheel:
function Wheel(radius){
    this.radius = radius;
}
Wheel.inherit(PropulsionUnit);
Wheel.prototype.produceAcceleration = function(){
    this.acceleration = 2*Math.PI*this.radius;
}

// Propelling nozzle:
function PropellingNozzle(power){
    this.power = power;
    this.afterburnerPowered = false;
}
PropellingNozzle.inherit(PropulsionUnit);
PropellingNozzle.prototype = {
    produceAcceleration : function(){
        if (this.afterburnerPowered){
            this.acceleration = this.power*2;
        }
        else{
            this.acceleration = this.power;
        }
    }
}

// Propeller
function Propeller(fins){
    this.fins = fins;
    this.spinDirection = 'clockwise';
}
Propeller.inherit(PropulsionUnit);
Propeller.prototype = {
    produceAcceleration : function(){
        if (this.spinDirection === 'clockwise'){
            this.acceleration = this.fins;
        }
        else{
            this.acceleration = this.fins * -1;
        }
    }
}

// Declaring parent class of all vehicles
function Vehicle(baseSpeed, propulsionUnits){
	this.baseSpeed = baseSpeed;
	this.propUnits = new Array();
	this.currentSpeed = baseSpeed;
	for(var i = 1; i < arguments.length; i++){
		this.propUnits.push(arguments[i]);
	}
}
Vehicle.prototype.accelerate = function(){
	var len = this.propUnits.length;
	var sum = 0;
	for(var i = 0; i < len; i++){
		this.propUnits[i].produceAcceleration();
		sum += this.propUnits[i].acceleration;
	}
	this.currentSpeed = this.baseSpeed + sum;
}

// Land vehicle
function LandVehicle(baseSpeed, wheels){}
LandVehicle.inherit(Vehicle);

// Air vehicle
function AirVehicle(baseSpeed, proppellingNozzle){}
AirVehicle.inherit(Vehicle);
AirVehicle.prototype.toggleAfterburners = function(mode){
	var len = this.propUnits.length;
	for(var i = 0; i < len; i++){
		if (mode === 'on'){
			this.propUnits[i].afterburnerPowered = true;
		}
		else if (mode === 'off'){
			this.propUnits[i].afterburnerPowered = false;
		}
	}
}

// Water vehicle
function WaterVehicle(baseSpeed, propellers){}
WaterVehicle.inherit(Vehicle);
WaterVehicle.prototype.changeSpin = function(){
	var len = this.propUnits.length;
	for(var i = 0; i < len; i++){
		if (this.propUnits[i].spinDirection === 'clockwise'){
			this.propUnits[i].spinDirection = 'counter-clockwise';
		}
		else {
			this.propUnits[i].spinDirection = 'clockwise';
		}
	}
}

// Amphibious vehicle
function AmphibiousVehicle(baseSpeed, propellerAndWheels){
    this.mode = 'land';
}
AmphibiousVehicle.inherit(Vehicle);
AmphibiousVehicle.prototype = {
    changeMode:function(){
        if(this.mode === 'land'){
            this.mode = 'water';
        }
        else{
            this.mode = 'land';
        }
    },
    produceAcceleration:function(){
        var len = this.propUnits.length;
        var sum = 0;
        if(this.mode === 'land'){
            for(var i = 0; i < len; i++){
                if(typeof this.propUnits[i] === 'Wheel'){
                    this.propUnits[i].produceAcceleration();
                    sum += this.propUnits[i].acceleration;
                }
            }
        }
        else{
            for(var i = 0; i < len; i++){
                if(typeof this.propUnits[i] === 'Propeller'){
                    this.propUnits[i].produceAcceleration();
                    sum += this.propUnits[i].acceleration;
                }
            }
        }

        this.currentSpeed = this.baseSpeed + sum;
    }
}

// Testing wheel
console.log('Testing wheel class');
var wheel = new Wheel(15);
console.log('Wheel radius: ' + wheel.radius);
wheel.produceAcceleration();
console.log('Wheel acceleration: ' + wheel.acceleration);

// Testing propelling nozzle
console.log('Testing propelling nozzle class');
var propNozzle = new PropellingNozzle(5);
console.log('Prop nozzle power: ' + propNozzle.power);
console.log('Afterburner is powered: ' + propNozzle.afterburnerPowered);
propNozzle.produceAcceleration();
console.log('Acceleration with afterburner powered off: ' + propNozzle.acceleration); // with afterburner powered off

propNozzle.switchAfterburner();
console.log('Afterburner is powered: ' + propNozzle.afterburnerPowered);
propNozzle.produceAcceleration();
console.log('Acceleration with afterburner powered on: ' + propNozzle.acceleration); // with afterburner powered on

// Testing propeller
console.log('Testing propeller');
var propeller = new Propeller(100);
console.log('Propeller fins: ' + propeller.fins);
console.log('Spin direction: ' + propeller.spinDirection);
propeller.produceAcceleration();
console.log('Acceleration with clockwise spin: ' + propeller.acceleration);

propeller.changeSpinDirection();
console.log('Spin direction: ' + propeller.spinDirection);
propeller.produceAcceleration();
console.log('Acceleration with counter-clockwise spin: ' + propeller.acceleration);

// Test vehicle
var veh = new Vehicle(50, wheel, propNozzle, propeller);
console.log(veh.currentSpeed);
veh.accelerate();
console.log(veh.currentSpeed);

