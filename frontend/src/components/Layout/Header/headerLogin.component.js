import React from "react";
import { Link } from 'react-router-dom';
import { Col, Container, Row } from "reactstrap";
import { HeaderStyle } from "./header.style";
import logo from '../../../assets/logo/logo.png';

const HeaderLogin = props => (
	<HeaderStyle>
		<Container>
			<Row className="d-flex justify-content-between">
				<Col>
					<Link id='home' to='/'>
						<img alt="logo" src={logo}/>
					</Link>
				</Col>
			</Row>
		</Container>
	</HeaderStyle>
);

export default HeaderLogin;
