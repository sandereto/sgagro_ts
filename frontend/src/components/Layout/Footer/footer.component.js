import React from "react";
import { FooterStyle } from "./footer.style";

const Footer = (props) => {
  return (
    <FooterStyle>
      <span>{props.descricao}</span>
    </FooterStyle>
  );
};

export default Footer;
