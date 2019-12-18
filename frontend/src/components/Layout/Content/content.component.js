import React from 'react';
import { Content } from './content.style';

//Importa o componente de estilo "Content.style" e engloba os filhos "children "desse novo componente com ele,
//fazendo com que todos tenham o estilo de "Content.style"
const Header = props => <Content>{props.children}</Content>;

export default Header;
