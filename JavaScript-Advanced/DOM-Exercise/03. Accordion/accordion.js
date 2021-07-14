function toggle() {
    let elementToShow = document.getElementById('extra');
    let buttonElement = document.getElementsByClassName('button')[0];

    buttonElement.textContent = buttonElement.textContent === 'More' ? 'Less' : 'More';

    elementToShow.style.display = elementToShow.style.display === 'block' ? 'none' : 'block';

}