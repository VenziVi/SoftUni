function solve() {
    function del(e) {
        let parent = e.target.parentNode;
        let headModule = parent.parentNode;

        parent.remove();
        if (headModule.children.length === 0) {
            headModule.parentNode.remove();
        }
    }
    let addBtn = document.querySelector(".form-control button");
    addBtn.addEventListener("click", (e) => {
        e.preventDefault();
        let inputs = document.querySelectorAll(".form-control input");

        let module = document.querySelector(".form-control select");

        let lectureName = inputs[0];
        let lectureDate = inputs[1];

        let [date, time] = lectureDate.value.split("T");
        date = date.split("-").join("/");
        if (
            !lectureName.value ||
            !lectureDate.value ||
            module.value == "Select module"
        ) {
            return;
        }
        let trainSection = document.querySelector(".modules");

        let divEL = document.createElement("div");
        divEL.setAttribute("class", "module");
        let headOfModule = document.createElement("h3");
        headOfModule.textContent = `${module.value.toUpperCase()}-MODULE`;
        let ulEl = document.createElement("ul");
        let liEl = document.createElement("li");
        liEl.setAttribute("class", "flex");
        let headofLiel = document.createElement("h4");
        headofLiel.textContent = `${lectureName.value} - ${date} - ${time}`;
        let delBtn = document.createElement("button");
        delBtn.setAttribute("class", "red");
        delBtn.textContent = "Del";
        delBtn.addEventListener("click", del);
        liEl.appendChild(headofLiel);
        liEl.appendChild(delBtn);
        ulEl.appendChild(liEl);
        divEL.appendChild(headOfModule);
        divEL.appendChild(ulEl);
        let modules = document.querySelectorAll(".modules h3");
        let currModule = Array.from(modules).find(
            (x) => x.textContent == headOfModule.textContent
        );
        if (currModule) {
            let ul = currModule.parentNode.querySelector("ul");
            ul.appendChild(liEl);

            let lielOfModules = currModule.parentNode.querySelectorAll("li");
            let liArr = [];
            for (let m of lielOfModules) {
                liArr.push(m);
            }
            liArr.sort((a, b) => {
                let datePattern = /[0-9]{4}\/[0-9]{2}\/[0-9]{2}/g;
                let [dateA] = a.textContent.match(datePattern);
                let [dateB] = b.textContent.match(datePattern);
                let adate = dateA.split("/").join("-");

                let bdate = dateB.split("/").join("-");

                return adate.localeCompare(bdate);
            });

            liArr.forEach((el) => {
                ul.appendChild(el);
            });
        } else {
            trainSection.appendChild(divEL);
        }

        lectureDate.value = "";
        lectureName.value = "";
        module.value = "";
    });
}