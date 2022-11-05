import React from "react";
function Post({titulo,descripcion,precio}){
    return(
        <div>
                <div className="producto">
                    <div className="producto_footer">
                        <div id="div2">
                            <div id="user">
                                {titulo}
                            </div>
                             <div>
                                {descripcion}
                            </div>
                            <div>
                                RD$ {precio}
                             </div>
                             <div>
                                 <button>Test</button>
                             </div>
                        </div>
                    </div>
                </div>
        </div>
    );
}
export default Post