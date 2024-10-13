const registerUser = async (username, password) => {
    try {
        const response = await axios.post('https://localhost:7239/api/Auth/register', {
            username,
            password
        });
        if (response.status === 200) {
            window.location.href = 'index.html';
        }
    } catch (error) {
        console.error('Error al registrar:', error);
    }
};

const loginUser = async (username, password) => {
    try {
        const response = await axios.post('https://localhost:7239/api/Auth/login', {
            username,
            password
        });
        if (response.status === 200) {
            window.location.href = 'index.html';
        }
    } catch (error) {
        console.error('Error al iniciar sesión:', error);
    }
};