import React from "react";
import { FooterStyle } from "./footer.style";

//Importa o componente de estilo "Footer.style" e engloba os filhos "descricao "desse novo componente com ele,
//fazendo com que todos tenham o estilo de "Footer.style"
const Footer = (props) => {
  return (
    <FooterStyle>
      <span>{props.descricao}</span>
    </FooterStyle>
  );
};

export default Footer;
