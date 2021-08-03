function validate() {
    let inputElement = document.querySelector('#email');

    const regex = /([a-z]+[@]+[a-z]+[.]+[a-z]+)/gm;

    inputElement.addEventListener('change', (e) => {
        if (inputElement.value.match(regex)) {
            e.target.className = '';
        }else{
            e.target.className = 'error';
        }
    })
}