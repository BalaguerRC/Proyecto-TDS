import react from "react";

function Agregar({ post }) {
    const descripcion=useRef(null);
    const Title=useRef(null);
    const Price=useRef(null);

    const agregarpost=()=>{
        const post={
            titulo: Title.current.value,
            descripcion: descripcion.current.value,
            precio: Price.current.value
        }
        Title.current.value="";
        descripcion.current.value="";
        Price.current.value="";
        AddPost(post);
    }
    return (
        <div>
            <div>
                <p className="btn button3" type="button" data-bs-toggle="modal" data-bs-target="#agregar">+</p>
            </div>
            <div className="modal fade" id="agregar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div className="modal-dialog modal-dialog-centered">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title fs-5" id="exampleModalLabel">Agregar</h1>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="mb-3">
                                    <label for="recipient-name" className="col-form-label">Titulo:</label>
                                    <input ref={Title} type="text" className="form-control" id="recipient-name" />
                                </div>
                                <div className="mb-3">
                                    <label for="recipient-name" className="col-form-label">Link imagen:</label>
                                    <input type="text" className="form-control" id="recipient-name" />
                                </div>
                                <div className="mb-3">
                                    <label for="recipient-name" className="col-form-label">Precio:</label>
                                    <input ref={Price} type="text" className="form-control" id="recipient-name" />
                                </div>
                                <div className="mb-3">
                                    <label for="message-text" className="col-form-label">Descripcion:</label>
                                    <textarea ref={Descripcion} className="form-control" id="message-text"></textarea>
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button className="btn btn-primary" data-bs-dismiss="modal" onClick={agregarpost}>Agregar</button>
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}