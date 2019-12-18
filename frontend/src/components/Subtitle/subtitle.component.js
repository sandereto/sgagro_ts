import React from 'react';
import { SubtitleStyle } from './subtitle.style';

//Renderiza o componente "Subtitle", que engloba todos os seus filhos "children" com o estilo de 
//"Subtitle.style"  e possui um props para setar seu "padding"
const Subtitle = (props) => <SubtitleStyle nopadding={props.nopadding}>{props.children}</SubtitleStyle>;

export default Subtitle;
