import React from "react";
function Post_Admin({ titulo, descripcion, precio }) {
    return (
        <div>
            <div >
                <div className="producto_footer1">
                    <div id="div2">
                        <div className="Titulo">
                            {titulo}
                        </div>
                        <img src="https://cdn-icons-png.flaticon.com/512/25/25400.png" className="card-img-top" width="160" height="160" />
                        <div>
                            <p className="card-text" >{descripcion}</p>
                        </div>
                        <div>
                            RD$ {precio}
                        </div>
                        <div>
                            <button type="button" className="btn btn-danger btnDelete">Eliminar</button>
                            <button type="button" className="btn btn-warning">Editar</button>
                            <button type="button" className="btn button3">Comprar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
export default Post_Admin