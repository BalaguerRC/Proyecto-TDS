import React from "react";
function Post({titulo,descripcion,precio}){
    return(
        <div>
            <div>
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