import styled from "styled-components";
import variaveis from "../../../styles/variaveis.scss";
//Define e exporta um estilo "Footer.style"
export const FooterStyle = styled.footer`
  && {
    bottom: 0;
    padding: 0.2%;
    width: 100%;
    background-color: ${variaveis.primaryColor};
    color: ${variaveis.textLight};
	text-align: center;
	position: absolute;

    img {
    	width: auto;
    	height: 50px;
    }

    span {
    	padding-left: 2%;
    	font-size: 90%;
    }
  }
`;
