import React from "react";

import { TitleStyle } from "./title.style";

const Title = props => 
    <TitleStyle>
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
