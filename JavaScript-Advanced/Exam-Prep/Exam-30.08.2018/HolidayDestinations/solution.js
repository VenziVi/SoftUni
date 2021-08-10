function addDestination(){

    let inputElement = document.querySelectorAll('.inputData');
    let cityInput = inputElement[0];
    let countryInput = inputElement[1];
    let seasonInput = document.getElementById('seasons');

    if (cityInput.value === '' || countryInput === '') {
        return;
    }

    let tBody = document.getElementById('destinationsList');

    let trEl = document.createElement('tr');
    let td1El = document.createElement('td');
    td1El.textContent = `${cityInput.value}, ${countryInput.value}`;
    let td2El = document.createElement('td');

    let currSeasone = seasonInput.value.charAt(0).toUpperCase() + seasonInput.value.slice(1)

    // if (seasonInput.value === 'summer') {
    //     currSeasone = 'Summer';
    // }else if(seasonInput.value === 'autumn'){
    //     currSeasone = 'Autumn';
    // }else if(seasonInput.value === 'winter'){
    //     currSeasone = 'Winter';
    // }else if(seasonInput.value === 'spring'){
    //     currSeasone = 'Spring';
    // }
    td2El.textContent = currSeasone;

    trEl.appendChild(td1El);
    trEl.appendChild(td2El);
    tBody.appendChild(trEl);

    cityInput.value = '';
    countryInput.value = '';


    let summerEl = document.getElementById('summer');
    let numForSummer = Number(summerEl.value);
    if (seasonInput.value === 'summer') {
        numForSummer += 1;
    }
    summerEl.value = numForSummer;

    let autumnEl = document.getElementById('autumn');
    let numForAutumn = Number(autumnEl.value);
    if (seasonInput.value === 'autumn') {
        numForAutumn += 1;
    }
    autumnEl.value = numForAutumn;

    let winterEl = document.getElementById('winter');
    let numForwinter = Number(winterEl.value);
    if (seasonInput.value === 'winter') {
        numForwinter += 1;
    }
    winterEl.value = numForwinter;

    let springEl = document.getElementById('spring');
    let numForspring = Number(springEl.value);
    if (seasonInput.value === 'spring') {
        numForspring += 1;
    }
    springEl.value = numForspring;
}