function extractText() {
    var input = document.querySelector('input[type=text]');
    var value = input.value;
    var output = document.getElementById('extracted-text');
    output.innerHTML = value;
}