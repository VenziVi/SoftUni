function solve() {

    function depart() {
        let nextStop = 'depot';
        let arriveBtn = document.getElementById('arrive');
        let departBtn = document.getElementById('depart');
        let span = document.querySelector('#info .info');

        if (span.getAttribute('data-next-stop') !== null) {
            nextStop = span.getAttribute('data-next-stop');
        }

        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStop}`)
        .then(b => b.json())
        .then(info => {
            span.setAttribute('data-stop-name', info.name);
            span.setAttribute('data-next-stop', info.next);
            span.textContent = `Next stop ${info.name}`;
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        })
        .catch(e => {
            span.textContent = `Error`;
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        })
    }

    function arrive() {
        let span = document.querySelector('#info .info');
        let arriveBtn = document.getElementById('arrive');
        let departBtn = document.getElementById('depart');

        let stopName = span.getAttribute('data-stop-name');
        span.textContent = `Arriving at ${stopName}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();