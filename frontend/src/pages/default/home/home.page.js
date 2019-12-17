import React, { Component, Fragment } from 'react';
import { withRouter, Link } from 'react-router-dom';
import { connect } from 'react-redux';
import Title from '../../../components/Title/title.component';
import { CardStyle, HomeStyle } from './home.style';

class Home extends Component {
	render() {
		return (
			<Fragment>
				<Title>
					<div className='row'>
						<div className='col-10'>Home</div>
					</div>
				</Title>
				<HomeStyle className='justify-content-center align-items-center'>
					<div className="card-deck">
						<CardStyle className="card border-primary text-center mb-3 w-50">
							<div className="card-body-menu">
								<i class="fas fa-balance-scale-left font-50"></i>
							</div>
							<div className="card-footer">
							<Link className="btn btn-lg btn-block btn-primary" to="/apontamentos">Gerenciar Apontamentos</Link>
							</div>
						</CardStyle>
						<CardStyle className="card border-primary text-center mb-3 w-50">
							<div className="card-body-menu">
								<i class="fas fa-folder font-50"></i>
							</div>
							<div className="card-footer">
							<Link className="btn btn-lg btn-block btn-primary" to="/about">Gerenciar Equipamentos</Link>
							</div>
						</CardStyle>
						<CardStyle className="card border-primary text-center mb-3 w-50">
							<div className="card-body-menu">
								<i class="fas fa-chart-line font-50"></i>
							</div>
							<div className="card-footer">
							<Link className="btn btn-lg btn-block btn-primary" to="/about">Gerenciar Relatórios</Link>
							</div>
						</CardStyle>
						<CardStyle className="card border-primary text-center mb-3 w-50">
							<div className="card-body-menu">
								<i class="fas fa-box-open font-50"></i>
							</div>
							<div className="card-footer">
								<Link className="btn btn-lg btn-block btn-primary" to="/about">Gerenciar Cadastros</Link>
							</div>
						</CardStyle>
					</div>
				</HomeStyle>
			</Fragment>
		);
	}
}

const mapStateToProps = state => ({});

export default connect(mapStateToProps)(withRouter(Home));
