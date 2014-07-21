(function () {
    var guessesCount = 0;
    var generatedNumber;
    var $feedbackContainer = $('#feedback-div');

    startNewGame();

    $('#guess-button').on('click', function () {
        var userInput = $('#number-input').val();
        $('#number-input').val('');
        userInput = parseInt(userInput);
        handleUserInput(userInput);
    });

    $('#high-scores-button').on('click', displayHighScores);

    function handleUserInput(userGuess) {
        var sheepsAndRams;
        guessesCount++;
        if (userGuess === generatedNumber) {
            saveScore(guessesCount);
            startNewGame();
        } else {
            sheepsAndRams = getSheepsAndRams(generatedNumber, userGuess);
            displaySheepsAndRams(sheepsAndRams, userGuess);
        }
    }

    function saveScore(guessesCount) {
        var userName = prompt('Congratulations, you have guessed correctly! Enter your name', 'Unknown');
        localStorage.setItem(userName, guessesCount);
    }

    function displaySheepsAndRams(sheepsAndRams, userGuess) {
        var sheeps = sheepsAndRams.sheeps;
        var rams = sheepsAndRams.rams;
        var message = userGuess + ': Sheeps: ' + sheeps + '; Rams: ' + rams;
        var $messageParagraph = $('<p>').text(message);
        $feedbackContainer.prepend($messageParagraph);
    }

    function startNewGame() {
        generateNumber();
        $feedbackContainer.empty();
        guessesCount = 0;
    }

    function displayHighScores() {
        var allScores = getHighScores();
        var message = '';
        allScores.sort(function (score1, score2) {
            return (score1.score - score2.score);
        });
        for (var i = 0; i < allScores.length && i < 5; i++) {
            message += allScores[i].name + ' : ' + allScores[i].score + '\n';
        }

        alert(message);
    }

    function getHighScores() {
        var allScores = [];
        var name;
        var score;
        var i;
        for (i in localStorage) {
            name = i;
            score = localStorage.getItem(i);
            allScores.push({
                name: name,
                score: score
            });
        }

        return allScores;
    }

    function generateNumber() {
        generatedNumber = getRandomInt(1000, 9999);
    }

    function getSheepsAndRams (originalNumber, guessedNumber) {
        var originalNumberDigits = {};
        var guessedNumberDigits = {};
        var sheeps = 0;
        var rams = 0;
        var addToSheeps;
        var i, currentOriginalDigit, currentGuessedDigit;

        originalNumber = originalNumber.toString();
        guessedNumber = guessedNumber.toString();
        // Getting rams count
        for (i = 0; i < originalNumber.length; i++) {
            currentOriginalDigit = originalNumber[i];
            currentGuessedDigit = guessedNumber[i];
            if (currentOriginalDigit === currentGuessedDigit) {
                rams++;
            } else {
                addToAssociativeArray(originalNumberDigits, currentOriginalDigit);
                addToAssociativeArray(guessedNumberDigits, currentGuessedDigit);
            }
        }

        // Getting sheeps count
        for (var num in originalNumberDigits) {
            if (guessedNumberDigits[num]) {
                if (originalNumberDigits[num] === guessedNumberDigits[num]) {
                    sheeps += originalNumberDigits[num];
                } else {
                    addToSheeps = Math.abs(
                            originalNumberDigits[num] - guessedNumberDigits[num]);
                    sheeps += addToSheeps;
                }
            }
        }

        function addToAssociativeArray(array, key) {
            if (!array[key]) {
                array[key] = 1;
            } else {
                array[key]++;
            }
        }

        return {
            rams:rams,
            sheeps:sheeps
        }
    }

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
})();

