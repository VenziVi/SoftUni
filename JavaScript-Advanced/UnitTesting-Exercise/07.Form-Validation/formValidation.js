function validate() {
    let submitBtn = document.getElementById('submit');

    let checkBoxElement = document.getElementById('company');
    let companiInfoEl = document.getElementById('companyInfo');

    let userNameRegex = /^[a-zA-Z0-9]{3,20}$/;
    let emailRegex = /^.*@.*\..*$/;
    let passwordRegex = /^\w{5,15}$/;

    checkBoxElement.addEventListener('change', (e) => {
        companiInfoEl.style.display = e.target.checked ? 'block' : 'none';
    })

    submitBtn.addEventListener('click', validateFields);

    function validateFields(e) {
        e.preventDefault();
        let usernameElement = document.getElementById('username');
        let mailelement = document.getElementById('email');
        let passElement = document.getElementById('password');
        let conformPassEleemnt = document.getElementById('confirm-password');
        let companyNumberElement = document.getElementById('companyNumber');
        let validDiv = document.getElementById('valid');

        let isNameValid = userNameRegex.test(usernameElement.value);
        borderColoring(usernameElement, isNameValid);

        let isEmailValid = emailRegex.test(mailelement.value);
        borderColoring(mailelement, isEmailValid);

        let isPassValid = passwordRegex.test(passElement.value);
        borderColoring(passElement, isPassValid);

        let isConformPassValid = passElement.value === conformPassEleemnt.value &&
            conformPassEleemnt.value !== '';
        borderColoringConfirmPass(conformPassEleemnt, passElement, isConformPassValid);

        let isCompanyNumberValid = false;
        if(checkBoxElement.checked) {
            
            if(companyNumberElement.value.trim() !== '' && !isNaN(Number(companyNumberElement.value))) {
                let companyNumber = Number(companyNumberElement.value);
                if(companyNumber >= 1000 && companyNumber <= 9999) {
                    isCompanyNumberValid = true;
                }
            }
        }
        borderColoring(companyNumberElement, isCompanyNumberValid);

        if (isNameValid && isEmailValid && isPassValid && isConformPassValid && !checkBoxElement.checked) {
            validDiv.style.display = 'block';
        } else if (isNameValid && isEmailValid && isPassValid && isConformPassValid && checkBoxElement.checked && isCompanyNumberValid) {
            validDiv.style.display = 'block';
        } else {
            validDiv.style.display = 'none';
        }

    }

    function borderColoringConfirmPass(elemnt, element2, isValid) {
        if (!isValid) {
            elemnt.style.setProperty('border', '2px solid red');
            element2.style.setProperty('border', '2px solid red');
        } else {
            elemnt.style.border = 'none';
            element2.style.border = 'none';
        }
    }

    function borderColoring(elemnt, isValid) {
        if (!isValid) {
            elemnt.style.setProperty('border', '2px solid red');

        } else {
            elemnt.style.border = 'none';
        }
    }
}
