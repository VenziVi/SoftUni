function solve() {
    let taskelement = document.getElementById('task');
    let descriptionElement = document.getElementById('description');
    let dateElement = document.getElementById('date');

    let addButtonElement = document.getElementById('add');

    addButtonElement.addEventListener('click', addSection)

    function addSection(e) {
        e.preventDefault();

        if (taskelement.value !== '' && descriptionElement.value !== '' &&
            dateElement.value !== '') {
            let taskInput = taskelement.value;
            let descriptionInput = descriptionElement.value;
            let dateInput = dateElement.value;

            let divElement = document.querySelector('section:nth-child(2) div:nth-child(2)')

            let articleEl = document.createElement('article');
            let h3Element = document.createElement('h3');
            h3Element.textContent = taskInput;

            let pDescriptionElement = document.createElement('p');
            pDescriptionElement.textContent = `Description: ${descriptionInput}`;

            let pDateElement = document.createElement('p');
            pDateElement.textContent = `Due Date: ${dateInput}`;

            let InnerDivElement = document.createElement('div');
            InnerDivElement.classList.add("flex")

            let startBtn = document.createElement('button');
            startBtn.textContent = 'Start';
            startBtn.className = "green";
            let delBtn = document.createElement('button');
            delBtn.className = "red";
            delBtn.textContent = 'Delete';

            InnerDivElement.appendChild(startBtn);
            InnerDivElement.appendChild(delBtn);
            articleEl.appendChild(h3Element);
            articleEl.appendChild(pDescriptionElement);
            articleEl.appendChild(pDateElement);
            articleEl.appendChild(InnerDivElement);
            divElement.appendChild(articleEl);

            taskelement.value = '';
            descriptionElement.value = '';
            dateElement.value = '';

            delBtn.addEventListener('click', (e) => {
                e.target.parentNode.parentNode.remove();
            });

            startBtn.addEventListener('click', moveInProgress);

        }
    }

    function moveInProgress(e) {
        let btnElement = e.target;
        let articleElement = e.target.parentNode.parentNode;
        let divElement = document.querySelector('section:nth-child(3) div:nth-child(2)');
        divElement.appendChild(articleElement);
        
        let btnDiv = btnElement.parentNode;
        let deleteBtn = btnElement.nextSibling;
        btnElement.remove();
        deleteBtn.remove();

        let finishBtn = document.createElement('button');
        finishBtn.textContent = 'Finish';
        finishBtn.className = "orange";
        let delBtn = document.createElement('button');
        delBtn.className = "red";
        delBtn.textContent = 'Delete';

        btnDiv.appendChild(delBtn);
        btnDiv.appendChild(finishBtn);

        delBtn.addEventListener('click', (e) => {
            e.target.parentNode.parentNode.remove();
        });

        finishBtn.addEventListener('click', moveToCompeted);
    }

    function moveToCompeted(e) {
        let article = e.target.parentNode.parentNode;
        let divElement = document.querySelector('section:nth-child(4) div:nth-child(2)');
        let div = e.target.parentNode;
        div.remove();
        divElement.appendChild(article);
    }
}

function solve1() {

    let openSection = document.querySelector('.orange').parentElement.parentElement;
    let inProgressSection = document.querySelector('.yellow').parentElement.parentElement;
    let completeSection = document.querySelector('.green').parentElement.parentElement;

    let addButton = document.querySelector('.wrapper div:nth-of-type(2) button');
    addButton.addEventListener('click', add);

    function createElement(type, text, className) {
        let result = document.createElement(type);
        result.textContent = text;
        if (className) {
            result.className = className
        }
        return result;
    }

    function add(e) {
        e.preventDefault();

        let taskInput = document.getElementById('task');
        let dateInput = document.getElementById('date');
        let textareaElement = document.getElementById('description');



        if (taskInput.value == '' && dateInput.value == '' && textareaElement.value == '') {
            return;
        }
        let article = createElement('article');
        let task = createElement('h3', taskInput.value);
        let description = createElement('p', `Description: ` + textareaElement.value);
        let date = createElement('p', `Due Date: ` + dateInput.value);
        let div = createElement('div', undefined, 'flex');
        let startButton = createElement('button', 'Start', 'green');
        startButton.addEventListener('click', moveTask);
        let deleteButton = createElement('button', 'Delete', 'red');
        deleteButton.addEventListener('click', deleteTask);

        div.appendChild(startButton);
        div.appendChild(deleteButton);

        article.appendChild(task);
        article.appendChild(description);
        article.appendChild(date);
        article.appendChild(div);

        openSection.children[1].appendChild(article);

        taskInput.value = '';
        dateInput.value = '';
        textareaElement.value = '';

        function deleteTask() {
            article.remove();
        }
        function moveTask(e) {
            inProgressSection.children[1].appendChild(article);

            let finishButton = createElement('button', 'Finish', 'orange');

            startButton.remove();
            div.appendChild(finishButton);

            finishButton.addEventListener('click', completeTask);

            function completeTask() {
                completeSection.children[1].appendChild(article);
                div.remove();
            }
        }
    }
}