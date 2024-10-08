const save = document.querySelector("#formularioC")
save.addEventListener('submit',async(e)=>{
    e.preventDefault()
    const dataForm = Object.fromEntries(new FormData(e.target)) 
    const request = await fetch('https://localhost:7239/productos/',{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataForm)
    })

    if(request.status == 200){
        alert('Guardado correctamente')
        return
    }
    alert('Ocurrió un error intenta más tarde')
})