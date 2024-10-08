
const formEdit = document.querySelector("#formEdit")
const idProduct = new URLSearchParams(window.location.search).get("id")

formEdit.addEventListener("submit", editarProducto)
document.addEventListener("DOMContentLoaded", getData)

async function getData(event) {
    const request = await fetch(`https://localhost:7239/productos/${idProduct}`,{
        method: "GET"
    })


    if(request.status == 200){
        const data = await request.json()
        document.getElementById("nombre").value = data.nombre;
        document.getElementById("descripcion").value = data.descripcion;
        document.getElementById("precio").value = data.precio;
        document.getElementById("cantidadEnStock").value = data.cantidadEnStock;
    }
}

async function editarProducto(event) {
    event.preventDefault()

    const dataFromForm = Object.fromEntries(new FormData(event.target))
    const request = await fetch(`https://localhost:7239/productos/${idProduct}`,{
        method: "PUT",
        headers: {
            "Content-type":"application/json"
        },
        body:  JSON.stringify(dataFromForm)
    })
    if(request.status == 200){
        Swal.fire({
            title: 'success!',
            text: 'Edtado correctamente',
            icon: 'success',
            confirmButtonText: 'Cool'
        })
    }
}


