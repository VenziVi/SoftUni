const errBox = document.getElementById('errorBox');

export function notify(message){
    errBox.innerHTML = `<span>${message}</span>`;
    errBox.style.display = 'block';

    setTimeout(() => {
        errBox.style.display = 'none';
    }, 3000);

}