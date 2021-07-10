function colorize() {
    let colorizedElements = document.querySelectorAll('tr');
    let elements = Array.from(colorizedElements);
    for (let i = 0; i < elements.length; i++) {
        if (i % 2 != 0) {
            colorizedElements[i].style.backgroundColor = "Teal";
        }
    }
}