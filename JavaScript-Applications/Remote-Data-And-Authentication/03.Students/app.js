let firstNameEl = document.querySelector('input[name=firstName]');
let lastNameEl = document.querySelector('input[name=lastName]');
let facNumEl = document.querySelector('input[name=facultyNumber]');
let gradeElement = document.querySelector('input[name=grade]');
let formElement = document.getElementById('form');
let tableElement = document.querySelector("#results > tbody");

formElement.addEventListener('submit', saveData);

(async function getInfo() {
    try {
        let response = await fetch('http://localhost:3030/jsonstore/collections/students');
        let info = await response.json();

        Object.values(info).forEach(s => {
            tableElement.appendChild(createNewElemnt(s.firstName, s.lastName, s.facultyNumber, s.grade));
        });
    } catch {
        console.error('Error');
    }
})();

async function saveData(event) {
    event.preventDefault();

    if (firstNameEl.value == '' || lastNameEl.value == '' ||
        facNumEl.value == '' || gradeElement.value == '') {
        return
    }

    if (isNaN(gradeElement.value) || (isNaN(Number(facNumEl.value)))) {
        return;
    }

    let student = {
        firstName: firstNameEl.value,
        lastName: lastNameEl.value,
        facultyNumber: facNumEl.value,
        grade: Number(gradeElement.value)
    };

    try {
        let url = 'http://localhost:3030/jsonstore/collections/students';
        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-type': 'aplication/json' },
            body: JSON.stringify(student)
        });
        let currStudent = await response.json();
        tableElement.appendChild(createNewElemnt(currStudent.firstName, currStudent.lastName, currStudent.facultyNumber, currStudent.grade));
    } catch {
        console.error('Error');
    }

    formElement.reset();
}

function createNewElemnt(firstName, lastName, facNum, grade) {
    let tr = document.createElement('tr');
    tr.setAttribute('id', 'trItem');

    let thFirstName = document.createElement('th');
    thFirstName.textContent = firstName;
    let thLastName = document.createElement('th');
    thLastName.textContent = lastName;
    let thFacNum = document.createElement('th');
    thFacNum.textContent = facNum;
    let thGrade = document.createElement('th');
    thGrade.textContent = grade;

    tr.appendChild(thFirstName);
    tr.appendChild(thLastName);
    tr.appendChild(thFacNum);
    tr.appendChild(thGrade);

    return tr;
}