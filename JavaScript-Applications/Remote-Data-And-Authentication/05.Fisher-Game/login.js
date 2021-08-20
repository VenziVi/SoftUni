let registerForm = document.getElementById('register-form');
registerForm.addEventListener('submit', register);
let loginForm = document.getElementById('login-form');
loginForm.addEventListener('submit', login);
let loginBtn = document.querySelector('#guest a');
console.log(loginBtn);

async function register(e){
    e.preventDefault();
    let form = e.target;
    let formData = new FormData(form);

    let email = formData.get('email')
    let password = formData.get('password');
    let repeatPassword = formData.get('rePass');

    if (email == '' || password == '') {
        return;
    }

    if(password !== repeatPassword){
        console.error('Passwords don\'t match');
        return;
    }

    let newUser = {
        email: formData.get('email'),
        password: password
    }
    
    let registerResponse = await fetch('http://localhost:3030/users/register', 
    {
        headers: {
            'Content-Type': 'application/json'
        },
        method: 'Post',
        body: JSON.stringify(newUser)
    });

    let registerResult = await registerResponse.json();

    localStorage.setItem('token', registerResult.accessToken);
    localStorage.setItem('userId', registerResult._id);
    location.assign('./index.html');
}

async function login(e){
    e.preventDefault();
    let form = e.target;
    let formData = new FormData(form);
    let password = formData.get('password');
    let email = formData.get('email')

    if (email == '' || password == '') {
        return;
    }

    let loginUser = {
        email: formData.get('email'),
        password: password
    }
    
    let loginResponse = await fetch('http://localhost:3030/users/login', 
    {
        headers: {
            'Content-Type': 'application/json'
        },
        method: 'Post',
        body: JSON.stringify(loginUser)
    });

    let loginResult = await loginResponse.json();
    localStorage.setItem('token', loginResult.accessToken);
    localStorage.setItem('userId', loginResult._id);
    location.assign('./index.html');

}