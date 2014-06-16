function createCalendar(selector, events) {
    var calendar = document.querySelector(selector);
    var NUMBER_OF_DAYS = 30;
    var NUMBER_OF_WEEKS = 5;
    var MONTH_AND_YEAR = 'June 2014';
    var DEFAULT_SIZE = 150;
    var WEEK_DAYS = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    var weekTemplate = document.createElement('div');
    var dayTemplate = generateDayNodeTemplate();

    stylizeDay(dayTemplate);
    calendar.appendChild(getMonth());

    addEvents(events, calendar);
    attachMouseover();
    attachMouseout();
    attachClickEvent();

    function attachMouseover() {
        calendar.addEventListener('mouseover', function (ev) {
            if (ev.target.className === 'day' && !ev.target.classList.contains('selected')) {
                ev.target.getElementsByTagName('h4')[0].style.backgroundColor = 'gray';
            }
        }, true);
    }

    function attachMouseout() {
        calendar.addEventListener('mouseout', function (ev) {
            if (ev.target.className === 'day' && !ev.target.classList.contains('selected')) {
                ev.target.getElementsByTagName('h4')[0].style.backgroundColor = 'lightgray';
            }
        }, true);
    }

    function attachClickEvent() {
        calendar.addEventListener('click', function (ev) {
            if (ev.target.className === 'day') {
                var headings = calendar.getElementsByTagName('h4');
                for (var i = 0; i < headings.length; i++) {
                    headings[i].style.background = 'lightgray';
                    headings[i].parentElement.classList.remove('selected');
                }
                ev.target.getElementsByTagName('h4')[0].style.background = 'white';
                ev.target.classList.add('selected');
            }
        }, true);
    }

    function generateDayNodeTemplate() {
        var dayNode = document.createElement('div');
        var head = document.createElement('h4');
        dayNode.appendChild(head);
        return dayNode;
    }

    function stylizeDay(dayTempl) {
        var dayHead = dayTempl.getElementsByTagName('h4')[0];
        dayHead.style.textAlign = 'center';
        dayHead.style.borderBottom = '1px solid black';
        dayHead.style.display = 'block';
        dayHead.style.margin = 0;
        dayHead.style.padding = 0;
        dayHead.style.background = 'lightgray';
        dayTempl.style.width = DEFAULT_SIZE + 'px';
        dayTempl.style.height = DEFAULT_SIZE + 'px';
        dayTempl.style.border = '1px solid black';
        dayTempl.style.display = 'inline-block';
        dayTempl.style.margin = 0;
        dayTempl.style.padding = 0;
        dayTempl.className = 'day';
    }

    function getMonth() {
        var month = document.createDocumentFragment();
        var week;
        for (var i = 1; i <= NUMBER_OF_WEEKS; i++) {
            week = getWeek(i * 7);
            month.appendChild(week);
        }

        return month;
    }

    function getWeek(endDay) {
        var currentDay = endDay - 6;
        var week = weekTemplate.cloneNode(true);
        var day;
        var weekDayCounter = 0;
        for (currentDay; currentDay <= endDay && currentDay <= NUMBER_OF_DAYS; currentDay++, weekDayCounter++) {
            day = getDay(currentDay, weekDayCounter);
            week.appendChild(day);
        }

        return week;
    }

    function getDay(dayOfMonth, weekDay) {
        var day = dayTemplate.cloneNode(true);
        var text = WEEK_DAYS[weekDay] + ' ' + dayOfMonth + ' ' + MONTH_AND_YEAR;
        day.getElementsByTagName('h4')[0].innerHTML = text;
        day.dataset.day = dayOfMonth;
        return day;
    }

    function addEvents(events, calendar) {
        var eventsDict = createDict(events);
        var days = calendar.getElementsByClassName('day');
        var currentDay;
        var spanNode = document.createElement('span');
        spanNode.style.display = 'block';
        spanNode.style.float = 'left';
        var newSpan;
        for (var i = 0; i < days.length; i++) {
            currentDay = days[i].dataset.day;
            if (eventsDict[currentDay]) {
                newSpan = spanNode.cloneNode(true);
                newSpan.innerHTML = eventsDict[currentDay].hour + ' ' + eventsDict[currentDay].title;
                days[i].appendChild(newSpan);
            }
        }
    }

    function createDict(events, eventsDict) {
        var eventsDict = [];
        for (var i in events)
        {
            addEvent(events[i], eventsDict);
        }

        return eventsDict;
    }

    function addEvent(event, eventsDict) {
        var date = parseInt(event.date);
        eventsDict[date] = event;
    }
}