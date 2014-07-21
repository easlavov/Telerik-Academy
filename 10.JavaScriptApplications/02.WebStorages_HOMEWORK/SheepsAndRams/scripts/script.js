(function () {
    var guessesCount = 0;
    var generatedNumber;
    var $feedbackContainer = $('#feedback-div');

    newGame();

    $('#guess-button').on('click', function () {
        var userInput = $('#number-input').val();
        userInput = parseInt(userInput);
        handleUserInput(userInput);
    });

    function handleUserInput(userGuess) {
        var sheepsAndRams;
        if (userGuess === generatedNumber) {
            saveScore(guessesCount);
        } else {
            sheepsAndRams = getSheepsAndRams(generatedNumber, userGuess);
            displaySheepsAndRams(sheepsAndRams);
        }
    }

    function saveScore(guessesCount) {
        var userName = prompt('Congratulations, you have guessed correctly! Enter your name', 'Unknown');
        // TODO: Save score
    }

    function displaySheepsAndRams(sheepsAndRams) {
        var sheeps = sheepsAndRams.sheeps;
        var rams = sheepsAndRams.rams;
        var message = 'Sheeps: ' + sheeps + '; Rams: ' + rams;
        var $messageParagraph = $('<p>').text(message);
        $feedbackContainer.prepend($messageParagraph);
    }

    function newGame() {
        generateNumber();
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

