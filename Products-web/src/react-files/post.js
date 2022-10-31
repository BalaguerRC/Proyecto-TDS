import React from "react";
function Post({titulo,descripcion,precio}){
    return(
        <div id="div2">
            <div id="user">
                {titulo}
            </div>
            <div>
                {descripcion}
            </div>
            <div>
                {precio}
            </div>
        </div>
    );
}
export default Post