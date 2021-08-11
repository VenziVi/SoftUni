function getInfo() {
    let stopIdElement = document.getElementById('stopId');
    let stopId = stopIdElement.value;
    let mainUri = 'http://localhost:3030/jsonstore/bus/businfo/';

    fetch(`${mainUri}${stopId}`)
    .then(b => b.json())
    .then(stopInfo => {
        let stopName = document.getElementById('stopName');
        stopName.textContent = stopInfo.name;
        let busesInfo = document.getElementById('buses');

        Array.from(document.querySelectorAll('#buses li'))
        .forEach(li => li.remove());

        Object.entries(stopInfo.buses)
        .forEach(b => {
            let liEl = document.createElement('li');
            liEl.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`;
            busesInfo.appendChild(liEl)
        });
        stopIdElement.value = '';
    })
    .catch(e => {
        Array.from(document.querySelectorAll('#buses li'))
        .forEach(li => li.remove());
        let stopName = document.getElementById('stopName');
        stopName.textContent = 'Error';
        stopIdElement.value = '';
    })
}