import React from "react";
import { Link } from 'react-router-dom';
import { Button, Col, Container, Row } from "reactstrap";
import { HeaderStyle } from "./header.style";
import logo from '../../../assets/logo/logo.png';
import Menu from '../../../components/Menu/menu'

const Header = props => (
	<HeaderStyle>
		<Container>
			<Menu />
			<Row className="d-flex justify-content-between">
				<Col>
					<Link id='home' to='/'>
						<img alt="logo" src={logo}/>
					</Link>
				</Col>
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
