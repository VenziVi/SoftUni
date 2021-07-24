function lockedProfile() {
    let profileElement = document.querySelector('#main');

    profileElement.addEventListener('click', (e) => {
        if (e.target.tagName == 'BUTTON' ) {
            let btn = e.target;
            let profilebtn = btn.parentNode;
            let showBtn = profilebtn.getElementsByTagName('div')[0];
            let status = profilebtn.querySelector('input[type="radio"]:checked').value;

            if (status === 'unlock') {
                if (btn.textContent === 'Show more') {
                    showBtn.style.display = 'inline-block';
                    btn.textContent = 'Hide it';
                }else if (btn.textContent === 'Hide it') {
                    showBtn.style.display = 'none';
                    btn.textContent = 'Show more';
                }
            }
        }
    })
}
