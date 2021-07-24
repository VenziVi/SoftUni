function attachEventsListeners() {
    let daysInputElement = document.querySelector('#days');
    let daysButton = document.querySelector('#daysBtn');

    let hoursInputElement = document.querySelector('#hours');
    let hoursButton = document.querySelector('#hoursBtn');

    let minutesInputElement = document.querySelector('#minutes');
    let minutesButton = document.querySelector('#minutesBtn');

    let secondsInputElement = document.querySelector('#seconds');
    let secondsButton = document.querySelector('#secondsBtn');

    daysButton.addEventListener('click', () => {
        let days = Number(daysInputElement.value);
        hoursInputElement.value = days * 24;
        minutesInputElement.value = days * 1440;
        secondsInputElement.value = days * 86400;
    });

    hoursButton.addEventListener('click', () => {
        let hours = Number(hoursInputElement.value);
        daysInputElement.value = hours / 24;
        minutesInputElement.value = hours * 60;
        secondsInputElement.value = hours * 60 * 60;
    });

    minutesButton.addEventListener('click', () => {
        let minutes = Number(minutesInputElement.value);
        daysInputElement.value = minutes / 60 / 24;
        hoursInputElement.value = minutes / 60;
        secondsInputElement.value = minutes * 60;
    });

    secondsButton.addEventListener('click', () => {
        let seconds = Number(secondsInputElement.value);
        daysInputElement.value = seconds / 60 / 60 / 24;
        hoursInputElement.value = seconds / 60 / 60;
        minutesInputElement.value = seconds / 60;
    });
}