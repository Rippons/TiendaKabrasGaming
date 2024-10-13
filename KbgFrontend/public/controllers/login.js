import express from 'express';
import mongoose from 'mongoose';
import bcrypt from 'bcrypt';
import bodyParser from 'body-parser';
import cors from 'cors';

const app = express();
const PORT = process.env.PORT ?? 4321;

// Configuración de CORS para permitir solicitudes desde cualquier origen
app.use(cors({
    origin: '*', // Permitir todas las solicitudes desde cualquier origen
    methods: ['GET', 'POST'], // Métodos HTTP permitidos
    allowedHeaders: ['Content-Type', 'Authorization'] // Encabezados permitidos
}));

app.use(bodyParser.json());
app.use(express.static(process.cwd() + "/public"));

// Conexión a la base de datos MongoDB
mongoose.connect('mongodb://127.0.0.1:27017/', {
    useNewUrlParser: true,
    useUnifiedTopology: true
}).then(() => console.log('Conectado a la base de datos MongoDB'))
  .catch(err => console.log('Error al conectar a MongoDB:', err));

// Definición de esquema y modelo para usuarios
const userSchema = new mongoose.Schema({
    username: String,
    password: String
});

const User = mongoose.model('Usuarios', userSchema);

// Ruta para la página principal
app.get("/", (req, res) => {
    res.sendFile(process.cwd() + '/public/views/index.html');
});

// Rutas para productos
app.get("/products", (req, res) => {
    res.sendFile(process.cwd() + '/public/views/Productos.html');
});

app.get("/producto", (req, res) => {
    res.sendFile(process.cwd() + '/public/views/product.html');
});

// Ruta para registrar un usuario
app.post('/Register', async (req, res) => {
    const { username, password } = req.body;

    try {
        const existingUser = await User.findOne({ username });
        if (existingUser) {
            return res.status(400).json({ message: 'El nombre de usuario ya está en uso' });
        }

        const hashedPassword = await bcrypt.hash(password, 10);
        const newUser = new User({ username, password: hashedPassword });

        await newUser.save();
        res.status(201).json({ message: 'Usuario registrado con éxito' });
    } catch (error) {
        res.status(500).json({ message: 'Error al registrar el usuario', error });
    }
});

// Ruta para el login de usuario
app.post('/login', async (req, res) => {
    const { username, password } = req.body;

    try {
        const user = await User.findOne({ username });
        if (!user) {
            return res.status(400).json({ message: 'Usuario no encontrado' });
        }

        const isMatch = await bcrypt.compare(password, user.password);
        if (!isMatch) {
            return res.status(400).json({ message: 'Contraseña incorrecta' });
        }

        res.status(200).json({ message: 'Login exitoso' });
    } catch (error) {
        res.status(500).json({ message: 'Error al iniciar sesión', error });
    }
});

// Iniciar el servidor
app.listen(PORT, () => {
    console.log("Server on port ", PORT);
});
