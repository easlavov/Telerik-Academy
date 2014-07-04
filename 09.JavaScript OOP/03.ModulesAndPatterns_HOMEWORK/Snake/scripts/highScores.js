var highScores = (function() {
    var highScoresButton = document.getElementsByTagName('button')[0];
    highScoresButton.addEventListener('click', displayHighScores, false);

    function addScore(currentScore) {
        var name = prompt('Enter your name: ');
        localStorage.setItem(name, currentScore);
    }

    function displayHighScores() {
        var message = '';
        var scores = [];
        for (var sc in localStorage) {
            if (localStorage.hasOwnProperty(sc)) {
                var playerName = sc;
                var playerScore = localStorage.getItem(sc);
                var score = {
                    name: playerName,
                    score: playerScore
                };
                scores.push(score);
            }
        }

        scores.sort(compareScores);

        for (var i = 0; i < scores.length; i++) {
            var name = scores[i].name;
            var score = scores[i].score;
            message += name + ': ' + score + '\n';
        }

        alert(message);

        function compareScores(a, b) {
            a = parseInt(a.score);
            b = parseInt(b.score);
            if (a < b) {
                return 1;
            }

            if (a > b) {
                return -1;
            }

            return 0;
        }
    }

    return {
        addScore: addScore
    }
}());