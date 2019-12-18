import React from "react";

import { TitleStyle } from "./title.style";


//Importa o componente de estilo "Title.style" e engloba todas as outras tags desse novo componente com ele,
//fazendo com que todos tenham o estilo de "Title.style"
const Title = props => 
    <TitleStyle>
        {/* Cria uma linha e divide ela em 2 seções, uma que terá os props "children"(Possivelmente o nome
            do titulo) e outra que terá um botão com uma ação enviada por props  */}
        <div className='row'>
            <div className='col-10'>
                {props.children}
            </div>
            <div className='col-2'>
                {props.onclick && 
                    <button type="submit" onClick={props.onclick} className="btn btn-sm btn-block btn-raised btn-secondary">{props.acao}</button>
                }
            </div>
        </div>
    </TitleStyle>;

export default Title;
