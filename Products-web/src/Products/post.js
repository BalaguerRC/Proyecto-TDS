import React from "react";
function Post({ titulo, descripcion, precio }) {
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
                            <button className="btn button3" data-bs-toggle="modal" data-bs-target="#exampleModal">Comprar</button>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Comprar</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                Titulo: {titulo} 
                                <br/>
                                Descripcion: {descripcion}
                                <br/>
                                Precio: {precio}
                                <br/>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                <button type="button" class="btn btn-primary">Comprar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
export default Post