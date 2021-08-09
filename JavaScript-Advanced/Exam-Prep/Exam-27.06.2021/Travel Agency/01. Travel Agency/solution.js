window.addEventListener('load', solution);

function solution() {
  let submitBtn = document.getElementById('submitBTN');

  let fullNameElement = document.getElementById('fname');
  let emailElement = document.getElementById('email');
  let phoneElement = document.getElementById('phone');
  let addressElement = document.getElementById('address');
  let postCodeElement = document.getElementById('code');
  let arrInfo = [];

  submitBtn.addEventListener('click', submitInfoEvent);

  function submitInfoEvent() {

    if (fullNameElement.value === '' || emailElement.value === '') {
      return;
    }

    arrInfo.push(fullNameElement.value);
    arrInfo.push(emailElement.value);
    arrInfo.push(phoneElement.value);
    arrInfo.push(addressElement.value);
    arrInfo.push(postCodeElement.value);

    let liName = document.createElement('li');
    liName.textContent = `Full Name: ${fullNameElement.value}`;

    let liEmail = document.createElement('li');
    liEmail.textContent = `Email: ${emailElement.value}`;

    let liPhone = document.createElement('li');
    liPhone.textContent = `Phone Number: ${phoneElement.value}`;

    let liAddress = document.createElement('li');
    liAddress.textContent = `Address: ${addressElement.value}`;

    let liPostCode = document.createElement('li');
    liPostCode.textContent = `Postal Code: ${postCodeElement.value}`;

    let ulInfo = document.getElementById('infoPreview');
    ulInfo.appendChild(liName);
    ulInfo.appendChild(liEmail);
    ulInfo.appendChild(liPhone);
    ulInfo.appendChild(liAddress);
    ulInfo.appendChild(liPostCode);

    fullNameElement.value = '';
    emailElement.value = '';
    phoneElement.value = '';
    addressElement.value = '';
    postCodeElement.value = '';

    let editBtn = document.getElementById('editBTN');
    let contBtn = document.getElementById('continueBTN');

    editBtn.disabled = false;
    contBtn.disabled = false;
    submitBtn.disabled = true;


    if (editBtn.disabled === false) {

      editBtn.addEventListener('click', editingInfoEvent)

    }

    if (contBtn.disabled === false) {

      contBtn.addEventListener('click', continueInfoEvent)
    }

  }

  function editingInfoEvent(e) {
    let ulInfo = document.getElementById('infoPreview');

    if (arrInfo.length === 2) {
      fullNameElement.value = arrInfo[0];
      emailElement.value = arrInfo[1];
    } else {

      fullNameElement.value = arrInfo[0];
      emailElement.value = arrInfo[1];
      phoneElement.value = arrInfo[2];
      addressElement.value = arrInfo[3];
      postCodeElement.value = arrInfo[4];
    }

    if (fullNameElement.value !== '' || emailElement.value !== '') {
      submitBtn.disabled = false;
    }

    let editBtn = document.getElementById('editBTN').disabled = true;
    let contBtn = document.getElementById('continueBTN').disabled = true;

    let lis = ulInfo.querySelectorAll('li');
    let liarr = Array.from(lis);
    for (let i = 0; i < liarr.length; i++) {
      liarr[i].remove();

    }
  }

  function continueInfoEvent() {
    let mainDiv = document.getElementById('block')

    let divForm = document.getElementById('form');
    divForm.remove();
    let divinfo = document.getElementById('information');
    divinfo.remove();
    let h1 = document.querySelector('#block h1');
    h1.remove();
    let h4 = document.querySelector('#block h4');
    h4.remove();
    let footer = document.querySelector('#block footer');
    footer.remove();

    let h3El = document.createElement('h3');
    h3El.textContent = 'Thank you for your reservation!';

    mainDiv.appendChild(h3El);
  }
}
