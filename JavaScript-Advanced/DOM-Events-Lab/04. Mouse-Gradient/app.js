function attachGradientEvents() {
    let gradientElement = document.querySelector('#gradient');
    let resultElement = document.querySelector('#result');

    gradientElement.addEventListener('mousemove', (e) => {
        let percent = Math.floor(e.offsetX / (e.target.clientWidth - 1) * 100);
        resultElement.textContent = `${percent}%`;
    })
    gradientElement.addEventListener('mouseout', (e) => {
        resultElement.textContent = '';
    })
}