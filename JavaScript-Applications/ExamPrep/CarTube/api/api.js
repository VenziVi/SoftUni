export const settings = {
    host: ''
};

async function request(url, options) {
    try {
        const response = await fetch(url, options);

        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            const data = await response.json();
            return data;
        } catch (err) {
            return response;
        }

    } catch (err) {
        alert(err.message);
        throw err;
    }
}

function getOptions(method = 'get', body) {
    const options = {
        method,
        headers: {}
    };

    const token = localStorage.getItem('authToken');
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url) {
    return await request(url, getOptions());
}

export async function post(url, data) {
    return await request(url, getOptions('post', data));
}

export async function put(url, data) {
    return await request(url, getOptions('put', data));
}

export async function del(url) {
    return await request(url, getOptions('delete'));
}

export async function login(username, password) {
    const result = await post(`${settings.host}/users/login`, { username, password });
    localStorage.setItem('username', result.username);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('userId', result._id);

    return result;
}

export async function register(username, password) {
    const result = await post(`${settings.host}/users/register`, { username, password });
    localStorage.setItem('username', result.username);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('userId', result._id);

    return result;
}

export async function logout() {
    const result = await get(`${settings.host}/users/logout`);
    localStorage.removeItem('username');
    localStorage.removeItem('authToken');
    localStorage.removeItem('userId');

    return result;
}