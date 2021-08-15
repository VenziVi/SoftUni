function attachEvents() {
    let loadBtn = document.getElementById('btnLoad');
    let ulElement = document.getElementById('phonebook');
    let createBtn = document.getElementById('btnCreate');
    let personEl = document.getElementById('person');
    let phoneEl = document.getElementById('phone');

    createBtn.addEventListener('click', createContact)
    loadBtn.addEventListener('click', loadPhonebook);

    async function createContact() {
        let newContact = {
            person: personEl.value,
            phone: phoneEl.value,
        };

        try {
            let responce = await fetch('http://localhost:3030/jsonstore/phonebook', {
                headers: {
                    'Content-Type': 'application.json'
                },
                method: 'POST',
                body: JSON.stringify(newContact),
            });
            let addedContact = await responce.json();
            createLiElement(addedContact)
        } catch {
            console.error('Error')
        }

        personEl.value = '';
        phoneEl.value = '';
    }

    async function loadPhonebook() {
        let ulContent = document.querySelectorAll('#phonebook li');
        if (ulContent.length > 0) {
            ulContent.forEach(el => el.remove());
        }

        try {
            let responce = await fetch('http://localhost:3030/jsonstore/phonebook');
            let phonebook = await responce.json();

            Object.values(phonebook).forEach(p => {
                createLiElement(p);
            })
        } catch {
            console.error('Error')
        }
    }

    async function deletePhone(e) {
        let key = e.target.parentNode.getAttribute('value');

        try {
            let delResponce = await fetch(`http://localhost:3030/jsonstore/phonebook/${key}`, {
                method: 'DELETE',
            });
            let delited = await delResponce.json();
            e.target.parentNode.remove();
        } catch {
            console.error('Error')
        }
    }

    function createLiElement(contact) {
        let liEl = document.createElement('li');
        liEl.setAttribute('value', contact._id)
        liEl.textContent = `${contact.person}: ${contact.phone}`;
        let delBtn = document.createElement('button');
        delBtn.textContent = 'Delete';
        delBtn.addEventListener('click', deletePhone)
        liEl.appendChild(delBtn);
        ulElement.appendChild(liEl);
    }
}

attachEvents();