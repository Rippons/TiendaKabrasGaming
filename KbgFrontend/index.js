import express from 'express'
const app = express()
const PORT = process.env.PORT ?? 4321 

app.use(express.static(process.cwd() + "/public"))

app.get("/", (req,res)=>{
    res.sendFile(process.cwd() + '/public/views/index.html')
})

app.get("/products", (req,res)=>{
    res.sendFile(process.cwd() + '/public/views/Productos.html')
})

app.get("/producto", (req,res)=>{
    res.sendFile(process.cwd() + '/public/views/product.html')
})


app.listen(PORT, ()=>{
    console.log("Server on port ", PORT);
})