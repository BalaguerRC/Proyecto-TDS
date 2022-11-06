import React from "react";
function Post({titulo,descripcion,precio}){
    return(
        <div>
                <div >
                    <div className="producto_footer1">
                        <div id="div2">
                            <div id="user">
                                {titulo}
                            </div>
                            <img src="https://cdn-icons-png.flaticon.com/512/25/25400.png" class="card-img-top" width="160" height="160"/>
                             <div>
                                <p className="card-text" >{descripcion}</p>
                            </div>
                            <div>
                                RD$ {precio}
                             </div>
                             <div>
                                 <button className="btn" id="button3">Comprar</button>
                             </div>
                        </div>
                    </div>
                </div>
        </div>
    );
}
export default Post