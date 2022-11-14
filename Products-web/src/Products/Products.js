import React, { useState, useEffect } from "react";
import { basededato } from "../Login/ConfiguracionFirebase";
import Post from "./post";
import EnviarP from "./EnviarP";
import Post_Admin from "./Post-Admin";

const Products = () => {
//test
    const [postID, setPostID] = useState([]);


//test
    const [post1, setPost] = useState([]);
    

    const AddPost = (post) => {
        const tempPost = post1.slice();
        tempPost.push(post);
        setPost(tempPost);
    }

    useEffect(() => {
        const listado = []
        basededato.collection('productos').get().then(result => {
            result.forEach(post => {
                //console.log(post.data());
                listado.push(post.data());
                //console.log(post.id);
            })
            setPost(listado);
            //console.log(listado);
            
        }).catch(error => console.error(error));
    }, []);

    //div3
    return (
        <div>
            <div id="envio">
                <EnviarP AddPost={AddPost} />
            </div>
            <div className="Productos">
                <div id="test">
                    {
                        post1 && post1.slice().reverse().map((post, i) => {
                            const {titulo, descripcion, precio } = post
                            return (
                                <Post_Admin key={i} id={i} titulo={titulo} descripcion={descripcion} precio={precio} />)
                        })
                    }
                    {
                    post1 && post1.map((post,i) => <p>{post.id} - {post.titulo} - {i}</p>)
                    }

                </div>
            </div>
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">Borrar</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Id: {post1.key}
                            <br/>
                            Titulo: {post1.titulo} 
                            <br />
                            Descripcion: {}
                            <br />
                            Precio: {}
                            <br />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <button type="button" class="btn btn-primary">Borrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Products;