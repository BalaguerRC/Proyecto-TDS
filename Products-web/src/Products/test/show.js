import React, { useState, useEffect, useRef } from "react";
import { collection, getDocs, getDoc, deleteDoc, doc, updateDoc, addDoc } from 'firebase/firestore';
import { db } from "../../Login/ConfiguracionFirebase";
import { async } from "@firebase/util";
import EnviarP from "../EnviarP";

const Show = () => {
    const Descripcion = useRef(null);
    const Title = useRef(null);
    const Price = useRef(null);
    const Descripcion2 = useRef(null);
    const Title2 = useRef(null);
    const Price2 = useRef(null);
    const [newtitulo, setTitulo] = useState(null);
    const [newdescripcion, setDescripcion] = useState(null);
    const [newprecio, setPrecio] = useState(null);

    const [produc, setProduc] = useState([]);
    const producCollectionRef = collection(db, 'productos');

    const [mostrar, SetMostrar] = useState([]);

    const [post1, setPost] = useState([]);
    const getProduc = async () => {
        const data = await getDocs(producCollectionRef);
        //console.log(data);
        setProduc(data.docs.map((doc) => ({ ...doc.data(), id: doc.id })));
        Title2.current.value = "";
        Descripcion2.current.value = "";
        Price2.current.value = "";
    }

    const AddPost = (post) => {
        const tempPost = post1.slice();
        tempPost.push(post);
        setPost(tempPost);
        setProduc();
    }

    const AddProduct = async () => {
        /*const post={
            titulo: Title2.current.value,
            descripcion: Descripcion2.current.value,
            precio: Price2.current.value
        }*/
        //console.log(post)
        await addDoc(producCollectionRef, {titulo: Title2.current.value,
            descripcion: Descripcion2.current.value,
            precio: Price2.current.value})
        getProduc();
        /*const tempPost = post1.slice();
        tempPost.push(post);
        setPost(tempPost);*/
    }


    const EditPost = (id, titulo, descripcion, precio) => {
        const pos = {
            id: id,
            titulo: titulo,
            descripcion: descripcion,
            precio: precio
        }
        Title.current.value = pos.titulo;
        Descripcion.current.value = pos.descripcion;
        Price.current.value = pos.precio;
        SetMostrar(pos);

        //console.log(pos);
    }
    const EditarPost = async (id, titulo, descripcion, precio) => {
        await updateDoc(doc(db, 'productos', id), { titulo, descripcion, precio });
        getProduc();
    }

    const deletePost = async (id) => {
        const productDoc = doc(db, 'productos', id);
        await deleteDoc(productDoc);
        getProduc();
    }

    useEffect(() => {
        getProduc()
    }, [])

    return (
        <div>
            <div id="envio">
                <p>
                    <a class="btn btn-primary" data-bs-toggle="collapse" href="#multiCollapseExample1" role="button" aria-expanded="false" aria-controls="multiCollapseExample1">Add</a>
                </p>
                <div class="row">
                    <div class="col">
                        <div class="collapse multi-collapse" id="multiCollapseExample1">
                            <div class="envio3">
                                <div>
                                    <h1>Enviar un producto</h1>
                                    <div id="pdeenvio">
                                        <p>Apartado Admin</p>
                                    </div>
                                    <div>
                                        <input ref={Title2} type="text" placeholder="Titulo"></input>
                                        <p></p>
                                        <input type="text" placeholder="Link Imagen"></input>
                                        <p></p>
                                        <input ref={Descripcion2} type="text" placeholder="Descripcion"></input>
                                        <p></p>
                                        <input ref={Price2} type="text" placeholder="Precio"></input>
                                        <p></p>
                                        <button className="btn boton-envio" onClick={AddProduct}>Enviar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div className="Productos">
                <div id="test">
                    {produc.map((produc) => {
                        return (

                            <div className="producto_footer" key={produc.id}>
                                <div id="div2" className="card">
                                    <h3 className="ID">ID: {produc.id}</h3>
                                    <div className="Titulo">Titulo: {produc.titulo}</div>
                                    <p className="card-text" >Descripcion: {produc.descripcion}</p>
                                    <div>RD$ {produc.precio}</div>
                                    <button type="button" className="btn btn-warning" data-bs-toggle="modal" data-bs-target="#exampleModal" onClick={() => { EditPost(produc.id, produc.titulo, produc.descripcion, produc.precio) }}>Editar</button>
                                    <button type="button" className="btn btn-danger btnDelete" onClick={() => { deletePost(produc.id) }}>Borrar</button>
                                </div>
                            </div>

                        );
                    })}
                </div>
            </div>
            <div>
                <div className="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog modal-dialog-centered">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h1 className="modal-title fs-5" id="exampleModalLabel">Editar</h1>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                Id: {mostrar.id}
                                <br />
                                Titulo: {mostrar.titulo}
                                <br />
                                Descripcion: {mostrar.descripcion}
                                <br />
                                Precio: {mostrar.precio}
                                <br />
                                <form>
                                    <div className="mb-3">
                                        <label for="recipient-name" className="col-form-label">Titulo:</label>
                                        <input ref={Title} type="text" className="form-control" id="recipient-name" />
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
                                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                <button className="btn btn-primary" onClick={() => { EditarPost(mostrar.id, Title.current.value, Descripcion.current.value, Price.current.value) }} data-bs-dismiss="modal">Editar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Show;