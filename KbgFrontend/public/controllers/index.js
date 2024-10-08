//Eliminar productos
async function deleteProducto(id) {
    Swal.fire({
        title: '¿Estás seguro que quieres eliminar este producto?',
        text: 'Esta acción no se puede deshacer',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: "#d33",
        confirmButtonText: 'Sí, confirmar',
        cancelButtonText: 'Cancelar'
        
    }).then(async(resulta)=>{
        if(resulta.isConfirmed){
            const request = await fetch(`https://localhost:7239/productos/${id}`, {
                method: 'DELETE',
            });
           
            
            if(request.status ==200){
                Swal.fire(
                    'Confirmado!',
                    'Se ha eliminado el producto',
                    'Success'
                )
                return
            }
            Swal.fire(
                'Cancelado',
                'Ocurrió un error',
                'error'
            )
        }
    })
}

//cargar productos
document.addEventListener("DOMContentLoaded", async (event) => {
    const request = await fetch('https://localhost:7239/productos/' ,{
        method: "GET"
    });

    if(request.status ==200){
        const data = await request.json()
        let content
        data.forEach(element => {
        let actualRow = `
            <tr>
                <td>${element.id}</td>
                <td>${element.nombre}</td>
                <td>${element.descripcion}</td>
                <td>${element.precio}</td>
                <td>${element.cantidadEnStock}</td>
                <td>
                    <a href="https://localhost:7239/productos/?id=${element.id}">
                        <button class="btn btn-warning btn-sm">Actualizar</button>
                    </a>
                    <button class="btn btn-danger btn-sm" data-id="${element.id}" id="eliminarProductBtn">Eliminar</button>
                </td>
            </tr>
        `;
        content += actualRow;
        })
        document.querySelector("#productosTableBody").innerHTML = content
    }
    const btnDelete = document.querySelectorAll("#eliminarProductBtn")
    btnDelete.forEach(element=>{
        
        element.addEventListener("click", function(){
            const id = element.getAttribute("data-id");
            deleteProducto(id);
        })
    })
});





