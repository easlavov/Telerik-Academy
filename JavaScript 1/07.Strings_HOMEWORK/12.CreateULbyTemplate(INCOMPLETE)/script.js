taskName = "12. Create UL using template. ";

// Returns an ul with li's based on a template and an array of persons
function generateList(people, template) {
    var newList = document.createElement('ul');

    for (var pers in people) {
        var newLi = document.createElement('li');
        newLi.innerHTML = template;
        newLi.innerHTML = newLi.innerHTML.replace('-{name}-', people[pers].name);
        newLi.innerHTML = newLi.innerHTML.replace('-{age}-', people[pers].age);
        newList.appendChild(newLi);
    }

    return newList;
}

// Executes a test
function test() {
    var peopleList = generateList(people, template);
    document.body.appendChild(peopleList);
}

// Main script
var people = [{ name: "Peter", age: 14 },
    { name: "Mimi", age: 13 },
    { name: "Gosho", age: 16 },
    { name: "Krisi", age: 15 },
    { name: "Pesho", age: 18 }, ];

var template = document.getElementById('list-item').innerHTML;
var button = document.getElementsByTagName('button')[0];
button.addEventListener('click', test, false);