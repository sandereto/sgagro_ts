import React from "react";
import { Link } from 'react-router-dom';
import { Button, Col, Container, Row } from "reactstrap";
import { HeaderStyle } from "./header.style";
import logo from '../../../assets/logo/logo.png';
import Menu from '../../../components/Menu/menu'

//Importa o componente de estilo "Header.style" e engloba todas as outras tags desse novo componente com ele,
//fazendo com que todos tenham o estilo de "Header.style"
const Header = props => (
	<HeaderStyle>
		<Container>
			{/* Renderiza o componente "Menu" */}
			<Menu />
			{/* Renderiza o componente "Row", englobando outros componentes nele */}
			<Row className="d-flex justify-content-between">
				{/* Renderiza o componente "Col", englobando outros componentes nele */}
				<Col>
					{/* Renderiza o componente "Link", com uma imagem de logo dentro */}
					<Link id='home' to='/'>
						<img alt="logo" src={logo}/>
					</Link>
				</Col>
				{/* Renderiza o componente "Col", com dois componentes "Button" para login/logout
					com imagens dentro dele */}
				<Col className="d-flex justify-content-end align-items-center">
					<Button primary={"primary"} className="d-flex align-items-center">
						<i className="fas fa-user-circle fa-fw fa-2x" />
						<span>{props.username}</span>
					</Button>
					<Button onClick={props.logout}>
						<i className="fas fa-sign-out-alt fa-lg" />
					</Button>
				</Col>
			</Row>
		</Container>
	</HeaderStyle>
);

export default Header;
