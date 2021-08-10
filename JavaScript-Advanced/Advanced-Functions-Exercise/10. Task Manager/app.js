function solve() {
    
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
 
       
 
        if (taskInput.value == '' &&  dateInput.value == '' && textareaElement.value == '') {
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