function focused() {
    let inputElement = document.querySelectorAll('input[type="text"]');

    let elementArr = Array.from(inputElement);

    for (const el of elementArr) {

        el.addEventListener('focus', (e) => {
            e.target.parentNode.className = 'focused';    
        })
        el.addEventListener('blur', (e) => {
            e.target.parentNode.className = '';
        })
    }
}